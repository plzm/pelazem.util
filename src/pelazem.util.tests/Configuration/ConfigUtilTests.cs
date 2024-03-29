﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;
using pelazem.util;
using pelazem.util.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace pelazem.util.tests
{
	public class ConfigUtilTests
	{
		[Fact]
		public void ConfigShouldBindToDictionary()
		{
			// Arrange
			string settingsFileFolderName = "Configuration";
			string settingsFileName = "ConfigUtil.Test.Settings.json";

			string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileFolderName, settingsFileName);

			// Act
			Dictionary<string, string> config = ConfigUtil.GetConfiguration<Dictionary<string, string>>
			(
				addJsonSettingsFile: true,
				jsonSettingsFilePath: settingsFilePath,
				addEnvironmentVariables: true,
				environmentVariablePrefix: ""
			);

			// Assert
			Assert.NotNull(config);
			Assert.NotEmpty(config);
			Assert.Equal("A", config["Foo"]);
			Assert.Equal("B", config["Bar"]);
			Assert.Equal("C", config["Baz"]);
			Assert.Equal("D", config["Bam"]);
		}

		[Fact]
		public void GetConfigurationBuilderReturnsNonNullIConfigurationBuilder()
		{
			// Arrange

			// Act
			var builder = ConfigUtil.GetConfigurationBuilder();

			// Assert
			Assert.NotNull(builder);
			Assert.True(builder is IConfigurationBuilder);
		}

		[Fact]
		public void GetConfigurationReturnsNullWithNullBuilder()
		{
			// Arrange

			// Act
			var config = ConfigUtil.GetConfiguration(null);

			// Assert
			Assert.Null(config);
		}

		[Fact]
		public void BuilderShouldLoadJsonFile()
		{
			// Arrange
			string settingsFileFolderName = "Configuration";
			string settingsFileName = "ConfigUtil.Test.Settings.json";

			string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileFolderName, settingsFileName);

			var builder = ConfigUtil.GetConfigurationBuilder();

			// Act
			OpResult result = ConfigUtil.AddJsonSettingsFile(builder, settingsFilePath, true, true);

			IConfigurationRoot config = ConfigUtil.GetConfiguration(builder);

			// Assert
			Assert.True(result.Succeeded);
			Assert.Equal("A", config.GetValue<string>("Foo"));
			Assert.Equal("B", config.GetValue<string>("Bar"));
			Assert.Equal("C", config.GetValue<string>("Baz"));
			Assert.Equal("D", config.GetValue<string>("Bam"));
		}

		[Fact]
		public void BuilderShouldNotLoadJsonFileIfBuilderIsNull()
		{
			// Arrange
			string settingsFileFolderName = "Configuration";
			string settingsFileName = "ConfigUtil.Test.Settings.json";

			string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileFolderName, settingsFileName);

			IConfigurationBuilder builder = null;

			// Act
			OpResult result = ConfigUtil.AddJsonSettingsFile(builder, settingsFilePath, true, true);

			// Assert
			Assert.Null(result.Succeeded);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("")]
		public void BuilderShouldNotLoadJsonFileIfFilePathIsNullOrWhiteSpace(string value)
		{
			// Arrange
			string settingsFilePath = value;

			var builder = ConfigUtil.GetConfigurationBuilder();

			// Act
			OpResult result = ConfigUtil.AddJsonSettingsFile(builder, settingsFilePath, true, true);

			// Assert
			Assert.Null(result.Succeeded);
		}

		[Theory]
		[InlineData("foo.json")]
		[InlineData("bar.json")]
		public void BuilderShouldNotLoadJsonFileIfFileDoesNotExist(string value)
		{
			// Arrange
			string settingsFileFolderName = "Configuration";
			string settingsFileName = value;

			string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileFolderName, settingsFileName);

			var builder = ConfigUtil.GetConfigurationBuilder();

			// Act
			OpResult result = ConfigUtil.AddJsonSettingsFile(builder, settingsFilePath, true, true);

			// Assert
			Assert.Null(result.Succeeded);
		}

		[Fact]
		public void BuilderShouldLoadEnvVars()
		{
			// Arrange
			var builder = ConfigUtil.GetConfigurationBuilder();

			// Act
			OpResult result = ConfigUtil.AddEnvironmentVariables(builder);

			IConfigurationRoot config = ConfigUtil.GetConfiguration(builder);

			// Assert
			Assert.True(result.Succeeded);
			Assert.NotEmpty(config.Providers);
			Assert.True(config.Providers.First() is EnvironmentVariablesConfigurationProvider);
		}

		[Fact]
		public void BuilderShouldNotLoadEnvVarsIfBuilderIsNull()
		{
			// Arrange
			IConfigurationBuilder builder = null;

			// Act
			OpResult result = ConfigUtil.AddEnvironmentVariables(builder);

			// Assert
			Assert.Null(result.Succeeded);
		}

		[Fact]
		public void ConfigShouldBind()
		{
			// Arrange
			var builder = ConfigUtil.GetConfigurationBuilder();

			// Act
			ConfigUtil.AddEnvironmentVariables(builder);

			IConfigurationRoot configRoot = ConfigUtil.GetConfiguration(builder);

			Dictionary<string, string> config = ConfigUtil.BindConfiguration<Dictionary<string, string>>(configRoot);

			// Assert
			Assert.NotNull(config);
			Assert.NotEmpty(config);
		}

		[Fact]
		public void BindConfigToNullShouldReturnDefaultT()
		{
			// Arrange
			object expected = default;

			// Act
			object actual = ConfigUtil.BindConfiguration<object>(null);

			// Assert
			Assert.Equal(expected, actual);
		}
	}
}
