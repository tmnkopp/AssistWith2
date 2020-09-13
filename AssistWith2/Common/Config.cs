using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistWith.Common
{
    public class AppSettings
    {
        public string TemplateRoot { get; set; }
    }

    public static class ConfigurationHelper
    {
        #region GetConfiguration()
        public static IConfigurationRoot GetConfiguration(string path, string environmentName = null, bool addUserSecrets = false)
        {

            if (path.Contains("UnitTests") && !path.EndsWith("UnitTests"))
                path = path.Substring(0, path.LastIndexOf(@"\UnitTests\", StringComparison.Ordinal) + @"\UnitTests\".Length);
            else if (path.Contains("AssistWith2") && !path.EndsWith("AssistWith2"))
                path = path.Substring(0, path.LastIndexOf(@"\AssistWith2\", StringComparison.Ordinal) + @"\AssistWith2\".Length);

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!String.IsNullOrWhiteSpace(environmentName))
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }
            builder = builder.AddEnvironmentVariables();
            return builder.Build();
        }
        #endregion
    }
}
