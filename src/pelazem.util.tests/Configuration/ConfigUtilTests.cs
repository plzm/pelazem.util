using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using Xunit;
using pelazem.util;
using pelazem.util.Configuration;

namespace pelazem.util.tests
{
	public class ConfigUtilTests
	{
		[Fact]
		public void ConfigShouldRead()
		{
			// Arrange
			string settingsFileFolderName = "Configuration";
			string settingsFileName = "ConfigUtil.Test.Settings.json";
			string sectionName = "Settings";

			string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), settingsFileFolderName, settingsFileName);

			// Act
			Dictionary<string, string> config = ConfigUtil.GetConfiguration
			(
				addJsonSettingsFile: true,
				jsonSettingsFileName: settingsFilePath,
				jsonSettingsSectionName: sectionName,
				addEnvironmentVariables: false
			);

			// Assert
			Assert.Equal("A", config["Foo"]);
			Assert.Equal("B", config["Bar"]);
			Assert.Equal("C", config["Baz"]);
			Assert.Equal("D", config["Bam"]);
		}
	}
}
