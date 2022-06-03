using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSummatorTests
{
	public class SummatorAppiumTests
	{

		private WindowsDriver<WindowsElement> driver;
		private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
		private AppiumOptions options;
		private WindowsElement firstNumField => driver.FindElementByAccessibilityId("textBoxFirstNum");
		private WindowsElement secondNumField => driver.FindElementByAccessibilityId("textBoxSecondNum");
		private WindowsElement resultField => driver.FindElementByAccessibilityId("textBoxSum");
		private WindowsElement calculateSumButton => driver.FindElementByAccessibilityId("buttonCalc");

		[SetUp]
		public void OpenApp()
		{
			this.options = new AppiumOptions() { PlatformName = "Windows"};
			options.AddAdditionalCapability(MobileCapabilityType.App, @"ENTER THE PATH TO THE SummatorDesktopApp.exe");
			this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
		}

		[TearDown]
		public void ShutDownApp()
		{
			this.driver.Quit();
		}

		[TestCase("0", "0", "0")]
		[TestCase("5","5","10")]
		[TestCase("-5", "-5", "-10")]
		[TestCase("5", "-5", "0")]
		[TestCase("-5", "5", "0")]
		[TestCase("hello", "5", "error")]
		[TestCase("5", "hello", "error")]
		[TestCase("hello", "hello", "error")]
		[TestCase("", "5", "error")]
		[TestCase("5", "", "error")]
		[TestCase("", "", "error")]
		public void Test_Summator(string numberOne, string numberTwo, string expectedResult)
		{
			this.firstNumField.Click();
			this.firstNumField.SendKeys(numberOne);

			this.secondNumField.Click();
			this.secondNumField.SendKeys(numberTwo);

			this.calculateSumButton.Click();

			Assert.That(this.resultField.Text, Is.EqualTo(expectedResult));
		}
	}
}