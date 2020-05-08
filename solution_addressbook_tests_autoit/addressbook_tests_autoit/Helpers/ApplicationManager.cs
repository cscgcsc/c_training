using AutoIt;

namespace AddressBookAutoItTests
{
    public class ApplicationManager
    {
        public GroupHelper GroupHelper { get; set; }
        public static string PROGRAM_TITLE = "Free Address Book";

        public ApplicationManager()
        {
            AutoItX.Run(@"D:\FreeAddressBookPortable\AddressBook.exe", "", 1);
            AutoItX.WinWait(PROGRAM_TITLE);
            AutoItX.WinActivate(PROGRAM_TITLE);
            AutoItX.WinWaitActive(PROGRAM_TITLE);

            GroupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            AutoItX.ControlClick(PROGRAM_TITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }
    }
}
