using NUnit.Framework;
using System;
using System.Diagnostics;

namespace WebAddressBookTests
{
    public class TestBase

    {
        public Stopwatch stopWatch;
        protected ApplicationManager applicationManager;

        [SetUp]
        protected void SetupTest()
        {
            applicationManager = ApplicationManager.GetInstance();
            applicationManager.NavigationHelper.OpenURL();
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
