using NUnit.Framework;
using System;
using System.Diagnostics;

namespace AddressBookAutoItTests
{
    public class TestBase
    {   
        protected ApplicationManager applicationManager;
        public Stopwatch stopWatch;

        public TestBase()
        {
        }

        [OneTimeSetUp]
        protected void SetupTest()
        {
            applicationManager = new ApplicationManager();              
        }

        [OneTimeTearDown]
        protected void Stop()
        {
            applicationManager.Stop();
        }

        public void StartCalculationRunTime()
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
        }

        public void StopCalculationRunTime()
        {
            stopWatch.Stop();
            Console.WriteLine("RunTime: " + stopWatch.Elapsed);
        }      
    }
}
