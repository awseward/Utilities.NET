require 'yaml'

def create_config
  sh "cp config.example.yml config.yml"
end

create_config if !File.file?('config.yml')

config = YAML.load_file('config.yml')

desc "Removes files ignored by git, minus ones matching do_not_clean from config.yml"
task :clean => 'clean:clean'

namespace :clean do
  do_not_clean = config['do_not_clean']
  exclude_string = do_not_clean.map{ |str| "-e \"#{str}\"" }.join(' ')
  clean_base = 'git clean -xdf'
  dry_flag = '-n'

  desc "Removes files ignored by git, minus ones matching do_not_clean from config.yml"
  task :clean do
    sh "#{clean_base} #{exclude_string}"
  end

  desc "Does a dry run of clean task"
  task :dry do
    sh "#{clean_base} #{dry_flag} #{exclude_string}"
  end
end

namespace :msbuild do
  msbuild = config['binaries']['msbuild']
  configuration_flag = '/p:Configuration=Release'
  target_flag = '/t:Rebuild'
  parallel_flag = '/m'

  desc "Builds the project"
  task :build => [:clean, 'nuget:restore'] do
    sh "'#{msbuild}' #{configuration_flag} #{target_flag} #{parallel_flag}"
  end

end

namespace :nuget do
  nuget = config['binaries']['nuget']
  name = config['name']

  desc "Builds a NuGet package"
  task :pack => ['msbuild:build'] do
    sh "#{nuget} pack #{name}/#{name}.csproj -Properties Configuration=Release"
  end

  desc "Restores any NuGet packages this project depends on"
  task :restore do
    sh "#{nuget} restore ."
  end

  desc "Pushes NuGet package"
  task :push => [:clean, :pack] do
    sh "#{nuget} push *.nupkg"
  end
end
