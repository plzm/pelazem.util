using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using pelazem.util;
using pelazem.util.Configuration;
using System.Dynamic;

namespace pelazem.util.tests
{
	public class ConfigUtilTests
	{
		[Fact]
		public void ConfigShouldRead()
		{
			// Arrange
			string fileName = "ConfigUtil.Test.Settings.json";
			string sectionname = "Settings";

			// Act
			Dictionary<string, string> config = ConfigUtil.GetConfiguration
			(
				addJsonSettingsFile: true,
				jsonSettingsFileName: fileName,
				jsonSettingsSectionName: sectionname,
				addEnvironmentVariables: true
			);

			// Assert
			Assert.Equal("A", config["Foo"]);
			Assert.Equal("B", config["Bar"]);
			Assert.Equal("C", config["Baz"]);
			Assert.Equal("D", config["Bam"]);
		}
	}
}
