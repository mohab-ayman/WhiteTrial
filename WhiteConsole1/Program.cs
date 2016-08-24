using System;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using System.Diagnostics;
using System.Threading;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;

namespace WhiteConsole1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Extract MSI File
            var commandLine = @"D:\WORK AREA\M2 Test Automation\Trials\Build 3.0.0.14\Config\setup.exe";
            var parameters = @"/s /x /b""setupfiles"" /v"" /qn""";
            Process.Start(commandLine, parameters);

            //Launch the installer
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var appPath = System.IO.Directory.GetCurrentDirectory() + @"\setupfiles\CareFusion - Alaris System Tracking Application Configuration v3.0.msi";
            Application app = Application.Launch(appPath);

            //Get Window and click Next
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Window mainWindow = app.GetWindow("CareFusion - Alaris System Tracking Application Configuration v3.0");

            Thread.Sleep(TimeSpan.FromSeconds(15));
            mainWindow = app.GetWindow("CareFusion - Alaris System Tracking Application Configuration v3.0");
            Button NextButton = mainWindow.Get<Button>(SearchCriteria.ByAutomationId("2495"));
            NextButton.Click();

            //Select Existing SQL instance and click Next
            Thread.Sleep(TimeSpan.FromSeconds(2));
            mainWindow = app.GetWindow("CareFusion - Alaris System Tracking Application Configuration v3.0 - InstallShield Wizard");

            Thread.Sleep(TimeSpan.FromSeconds(2));
            RadioButton ExistingDBRadioButton = mainWindow.Get<RadioButton>(SearchCriteria.ByAutomationId("2602"));
            ExistingDBRadioButton.Click();

            NextButton = mainWindow.Get<Button>(SearchCriteria.ByText("Next >"));
            NextButton.Click();

            //Browser for local SQL instance
            Thread.Sleep(TimeSpan.FromSeconds(2));
            mainWindow = app.GetWindow("CareFusion - Alaris System Tracking Application Configuration v3.0");
            Button BrowseButton = mainWindow.Get<Button>(SearchCriteria.ByAutomationId("2613"));
            BrowseButton.Click();

            Window serverWindow = mainWindow.ModalWindow("CareFusion - Alaris System Tracking Application Configuration v3.0");
            
            ListBox list = serverWindow.Get<ListBox>(SearchCriteria.ByAutomationId("4014"));
            ListItem server = list.Item("(local)");
            server.Click();
            

            //Button nextButton = (Button)mainWindow.Get(sc);
            //nextButton.Click();

        }
    }
}
