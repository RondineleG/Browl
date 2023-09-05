using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System;
using System.ComponentModel;

namespace Browl.Client.Test
{
	public class EdgeDriverTest : IDisposable 
	{
		private IWebDriver _webDriver;

		public EdgeDriverTest()
		{
			var edgeOptions = new EdgeOptions();
			edgeOptions.AddArgument("--headless");
			_webDriver = new EdgeDriver(edgeOptions);
		}

		[Fact]
		public void ShouldDisplayBingHomePageTitle()
		{
			_webDriver.Url = "https://www.bing.com";
			Assert.Equal("Bing", _webDriver.Title);
			Dispose();
		}

		[Theory]
		[InlineData("https://www.bing.com", "Bing")]
		[InlineData("https://www.google.com", "Google")]
		public void ShouldDisplayCorrectPageTitle(string url, string expectedTitle)
		{
			_webDriver.Url = url;
			Assert.Equal(expectedTitle, _webDriver.Title);
			Dispose();
		}


		public void Dispose()
		{
			_webDriver.Quit();
		}
	}
}