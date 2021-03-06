﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace WJStore.Test
{
    [TestClass]
    public abstract class SeleniumTest {

        const int iisPort = 26642;
        private string _applicationName;
        private Process _iisProcess;
 
        protected SeleniumTest(string applicationName) {
            _applicationName = applicationName;
        }


        public InternetExplorerDriver InternetExplorerDriver { get; set; }

        [TestInitialize]
        public void TestInitialize() {
            // Start IISExpress
            StartIIS();
 
            // Start Selenium drivers
            this.InternetExplorerDriver = new InternetExplorerDriver();
        }
 
 
        [TestCleanup]
        public void TestCleanup() {
            // Ensure IISExpress is stopped
            if (_iisProcess.HasExited == false) {
                _iisProcess.Kill();
            }
 
            // Stop all Selenium drivers
            this.InternetExplorerDriver.Quit();
        }
 
 
 
        private void StartIIS() {
            var applicationPath = GetApplicationPath(_applicationName);
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
 
            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = programFiles + "\\IIS Express\\iisexpress.exe";
            _iisProcess.StartInfo.Arguments = string.Format("/path:{0} /port:{1}", applicationPath, iisPort);
            _iisProcess.Start();
        }
 
 
        protected virtual string GetApplicationPath(string applicationName) {
            var solutionFolder = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)));
            return Path.Combine(solutionFolder, applicationName);
        }
 
 
        public string GetAbsoluteUrl(string relativeUrl) {
            if (!relativeUrl.StartsWith("/")) {
                relativeUrl = "/" + relativeUrl;
            }
            return String.Format("http://localhost:{0}{1}", iisPort, relativeUrl);
        }
 
 
    }
}
