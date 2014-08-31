using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Utilities.String.Http
{
    public static class Extensions
    {
        public static IDictionary<string, string> ToParameters(this string parameterString)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            foreach (var pair in parameterString.Split('&'))
            {
                var kAndV = pair.Split('=');
                parameters.Add(kAndV[0], kAndV[1]);
            }

            return parameters;
        }

        public static IDictionary<string, string> ToDecodedParameters(this string parameterString)
        {
            return ToParameters(parameterString)
                .ToDictionary(kvp => kvp.Key, kvp => HttpUtility.UrlDecode(kvp.Value));
        }

        public static string ToParameterString(this IDictionary<string, string> parameters)
        {
            var builder = new StringBuilder();
            foreach (var pair in parameters.Take(1))
            {
                builder.AppendFormat("{0}={1}", pair.Key, pair.Value);
            }

            foreach (var pair in parameters.Skip(1))
            {
                builder.AppendFormat("&{0}={1}", pair.Key, pair.Value);
            }

            return builder.ToString();
        }

        public static string ToEncodedParameterString(this IDictionary<string, string> parameters)
        {
            return ToParameterString(parameters.ToDictionary(kvp => kvp.Key, kvp => HttpUtility.UrlEncode(kvp.Value)));
        }
    }
}
