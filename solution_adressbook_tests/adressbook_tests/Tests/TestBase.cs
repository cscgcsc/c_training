using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Text;

namespace WebAddressBookTests
{
    public class TestBase
    {
        public Stopwatch stopWatch;
        public static Random rnd = new Random();
        protected ApplicationManager app;
        public bool LONG_UI_CHECKS = true;
      
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

        public static string GenerateRandomString(int maxLength)
        {
            int rndLengh = rnd.Next(0, maxLength);
            StringBuilder text = new StringBuilder();

            for(int i=0; i<rndLengh; i++)
            {
                text.Append(Convert.ToChar(rnd.Next(97, 122))); 
            }

            return text.ToString();
        }

        public static int GenerateRandomNumber(int maxNumber)
        {
            return rnd.Next(0, maxNumber);
        }

        public static string GetRandomMonth()
        {
            string[] monthNames = new System.Globalization.CultureInfo("en-US").DateTimeFormat.MonthNames;        
            return monthNames[rnd.Next(0, 11)];
        }

        public static DateTime GenerateRandomDate()
        {
            DateTime start = new DateTime(1950, 1, 1);
            int range = (DateTime.Today - start).Days;

            return start.AddDays(rnd.Next(range));
        }

        public static string GetFormatDay(DateTime date)
        {
            return int.Parse(date.ToString("dd")).ToString();
        }

        public static string GetFormatMonth(DateTime date)
        {
            return date.ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"));
        }

        [SetUp]
        protected void SetupTest()
        {
            app = ApplicationManager.GetInstance();
            app.NavigationHelper.OpenURL();
        }   
    }
}
