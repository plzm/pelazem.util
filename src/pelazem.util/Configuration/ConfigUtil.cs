using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace pelazem.util.Configuration
{
	public static class ConfigUtil
	{
		public static T GetConfiguration<T>(bool addJsonSettingsFile = false, string jsonSettingsFilePath = "", bool addEnvironmentVariables = false, string environmentVariablePrefix = "")
			where T : new()
		{
			var builder = GetConfigurationBuilder();

			if (addJsonSettingsFile && !string.IsNullOrWhiteSpace(jsonSettingsFilePath) && File.Exists(jsonSettingsFilePath))
				AddJsonSettingsFile(builder, jsonSettingsFilePath, true, true);

			if (addEnvironmentVariables)
				AddEnvironmentVariables(builder, environmentVariablePrefix);

			IConfigurationRoot config = GetConfiguration(builder);

			T result = BindConfiguration<T>(config);

			return result;
		}

		internal static IConfigurationBuilder GetConfigurationBuilder()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory());

			builder.Sources.Clear();

			return builder;
		}

		internal static void AddJsonSettingsFile(IConfigurationBuilder builder, string jsonSettingsFilePath, bool optional = true, bool reloadOnFileChanged = true)
		{
			if (builder == null || string.IsNullOrWhiteSpace(jsonSettingsFilePath) || !File.Exists(jsonSettingsFilePath))
				return;

			builder.AddJsonFile(jsonSettingsFilePath, optional: optional, reloadOnChange: reloadOnFileChanged);
		}

		internal static void AddEnvironmentVariables(IConfigurationBuilder builder, string environmentVariablePrefix = "")
		{
			if (builder == null)
				return;

			builder.AddEnvironmentVariables(environmentVariablePrefix);
		}

		internal static IConfigurationRoot GetConfiguration(IConfigurationBuilder builder)
		{
			if (builder == null)
				return null;

			return builder.Build();
		}

		internal static T BindConfiguration<T>(IConfigurationRoot config)
			where T : new()
		{
			T result;

			if (config != null)
			{
				result = new();

				config.Bind(result);

			}
			else
				result = default;

			return result;
		}
	}
}
