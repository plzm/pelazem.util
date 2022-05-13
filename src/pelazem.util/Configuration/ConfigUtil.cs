using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace pelazem.util.Configuration
{
	public static class ConfigUtil
	{
		public static Dictionary<string, string> GetConfiguration(bool addJsonSettingsFile = false, string jsonSettingsFileName = "", string jsonSettingsSectionName = "", bool addEnvironmentVariables = false, string environmentVariablePrefix = "")
		{
			Dictionary<string, string> config = new();

			var builder = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory());

			bool useJsonSettingsFile = (addJsonSettingsFile && !string.IsNullOrWhiteSpace(jsonSettingsFileName) && File.Exists(jsonSettingsFileName));

			if (useJsonSettingsFile)
				builder.AddJsonFile(jsonSettingsFileName, optional: true, reloadOnChange: true);

			if (addEnvironmentVariables)
				builder.AddEnvironmentVariables(environmentVariablePrefix);

			IConfigurationRoot configuration = builder.Build();

			if (useJsonSettingsFile)
				configuration.GetSection(jsonSettingsSectionName).Bind(config);

			if (addEnvironmentVariables)
			{
				try
				{
					// TODO
					// This can throw System.InvalidOperationException: 'Cannot create instance of type 'System.String' because it is missing a public parameterless constructor.'
					// However, env vars do get picked up. Tracking down if this is a transient/system-specific issue.
					configuration.Bind(config);
				}
				catch
				{ }
			}

			return config;
		}
	}
}
