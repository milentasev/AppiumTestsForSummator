# AppiumTestsForSummator
## This repo contains UI Automated tests for the SummatorDesktopApp
Instrinctions:
* Download the SummatorDesktopApp.exe
* Enter the full path to the app in the following row in the 'SetUp' of SummatorAppiumTests.cs: options.AddAdditionalCapability(MobileCapabilityType.App, @"ENTER THE PATH TO THE SummatorDesktopApp.exe");
