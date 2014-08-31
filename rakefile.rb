require 'yaml'

def create_config
  sh "cp config.example.yml config.yml"
end

create_config if !File.file?('config.yml')

config = YAML.load_file('config.yml')

task :clean => 'clean:clean'

namespace :clean do
  do_not_clean = config['do_not_clean']
  exclude_string = do_not_clean.map{ |str| "-e \"#{str}\"" }.join(' ')
  clean_base = 'git clean -xdf'
  dry_flag = '-n'

  task :clean do
    sh "#{clean_base} #{exclude_string}"
  end

  task :dry do
    sh "#{clean_base} #{dry_flag} #{exclude_string}"
  end
end
