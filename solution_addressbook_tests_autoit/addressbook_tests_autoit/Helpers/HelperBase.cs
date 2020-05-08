using AutoIt;

namespace AddressBookAutoItTests
{
    public class HelperBase
    {
        protected ApplicationManager applicationManager;

        public HelperBase(ApplicationManager applicationManager)
        {
            this.applicationManager = applicationManager;
        }

        protected void WaitAndActivateWindow(string program)
        {
            AutoItX.WinWait(program, "", 5);
            AutoItX.WinActivate(program);
            AutoItX.WinWaitActive(program, "", 5);
        }
    }
}
