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

		internal static OpResult AddJsonSettingsFile(IConfigurationBuilder builder, string jsonSettingsFilePath, bool optional = true, bool reloadOnFileChanged = true)
		{
			OpResult result = new();

			if (builder == null || string.IsNullOrWhiteSpace(jsonSettingsFilePath) || !File.Exists(jsonSettingsFilePath))
			{
				if (builder == null)
					result.Message = Properties.Resources.NullBuilderPassed;
				else if (string.IsNullOrWhiteSpace(jsonSettingsFilePath))
					result.Message = Properties.Resources.JsonSettingsFilePathNullOrWhiteSpace;
				else if (!File.Exists(jsonSettingsFilePath))
					result.Message = Properties.Resources.JsonSettingsFileDoesNotExist;

				return result;
			}

			builder.AddJsonFile(jsonSettingsFilePath, optional: optional, reloadOnChange: reloadOnFileChanged);

			result.Succeeded = true;

			return result;
		}

		internal static OpResult AddEnvironmentVariables(IConfigurationBuilder builder, string environmentVariablePrefix = "")
		{
			OpResult result = new();

			if (builder == null)
			{
				result.Message = Properties.Resources.NullBuilderPassed;

				return result;
			}

			builder.AddEnvironmentVariables(environmentVariablePrefix);

			result.Succeeded = true;

			return result;
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