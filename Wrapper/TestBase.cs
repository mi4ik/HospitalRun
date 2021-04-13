﻿using NUnit.Allure.Core;
using NUnit.Framework;
using System;

namespace HospitalRun
{
    [AllureNUnit]
    public class TestBase
    {
        [SetUp]
        public void Setup()
        {
            var browserParameter = TestContext.Parameters.Get("Browser", "Chrome");

            var browserType = (WebDriver.BrowserType)Enum.Parse(typeof(WebDriver.BrowserType), browserParameter);
            //WebDriver.UseBrowser(WebDriver.BrowserType.Firefox);
            WebDriver.UseBrowser(browserType);
        }


        [TearDown]
        public void TearDown()
        {
            WebDriver.Quit();
        }
    }
}
