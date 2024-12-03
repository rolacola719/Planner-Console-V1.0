using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner_Console_V1._0.UIManager
{

    public static class UI
    {
        //OUTPUTS
        public static void DisplayAppointments()
        {
            Output.DisplayAppointments();
        }
        public static void MainMenuDialog()
        {
            Output.MainMenu();
        }
        public static void EnterSubjectDialog()
        {
            Output.EnterSubjectDialog();
        }

        public static void EnterStartDateandTimeDialog()
        {
            Output.EnterStartDateandTimeDialog();
        }
        public static void EnterEndDateandTimeDialog(DateTime startDate)
        {
            Output.EnterEndDateandTimeDialog(startDate);
        }

        public static void ErrorMessageDialog()
        {
            Output.ErrorMessageDialog();
        }

        //INPUTS
        public static string GetSubject()
        {
            return Input.GetSubject();
        }

        public static DateTime GetDateandTime()
        {
            return Input.GetDateTime();
        }

        public static char GetKeystroke()
        {
            return Input.GetKeyStroke();
        }

        //COMBINED
        public static void MainMenu()
        {
            while (true)
            {
                UI.DisplayAppointments();
                Console.WriteLine();
                string optionSelected = Input.GetReadLine();

                switch (optionSelected)
                {
                    case "ct":
                        Database.CreateAppointment();
                        break;
                    case "dl":
                        Database.DeleteAppointment();
                        break;
                    default:
                        UI.ErrorMessageDialog();
                        break;
                }
            }
        }
        public static void CreateAppointment(out string subject, out DateTime startDate, out DateTime endDate)
        {
            UI.EnterSubjectDialog();
            subject = UI.GetSubject();

            UI.EnterStartDateandTimeDialog();
            startDate = UI.GetDateandTime();



            UI.EnterEndDateandTimeDialog(startDate);
            endDate = UI.GetDateandTime();
        }
    }
}
