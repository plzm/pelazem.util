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

			//if (useJsonSettingsFile)
			//	configuration.GetSection(jsonSettingsSectionName).Bind(config);

			configuration.Bind(config);

			return config;
		}

		public static IConfigurationBuilder GetConfigurationBuilder()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory());

			return builder;
		}

		public static void AddJsonSettingsFile(IConfigurationBuilder builder, string jsonSettingsFilePath, bool optional = true, bool reloadOnFileChanged = true)
		{
			if (builder == null || string.IsNullOrWhiteSpace(jsonSettingsFilePath) || !File.Exists(jsonSettingsFilePath))
				return;

			builder.AddJsonFile(jsonSettingsFilePath, optional: optional, reloadOnChange: reloadOnFileChanged);
		}

		public static void AddEnvironmentVariables(IConfigurationBuilder builder, string environmentVariablePrefix = "")
		{
			if (builder == null)
				return;

			builder.AddEnvironmentVariables(environmentVariablePrefix);
		}

		public static IConfigurationRoot BuildAndGetConfiguration(IConfigurationBuilder builder)
		{
			if (builder == null)
				return null;

			return builder.Build();
		}

		public static Dictionary<string, object> GetConfiguration(IConfigurationBuilder builder)
		{
			Dictionary<string, object> result = new();

			if (builder != null)
			{

			}

			return result;
		}
	}
}
