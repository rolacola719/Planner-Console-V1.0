using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner_Console_V1._0.UIManager
{
    internal static class Output
    {
        internal static void MainMenu()
        {
            Console.WriteLine(@"What would you like to do:

1. Add Appointment
2. Add a daily note");
        }
        internal static void EnterSubjectDialog()
        {
            Console.WriteLine("Please enter the subject for the appointment");
        }

        internal static void EnterStartDateandTimeDialog()
        {
            Console.WriteLine("When does the appointment begin (Plesae enter as dd/mm/yyyy hh:mm)");
        }

        internal static void EnterEndDateandTimeDialog(DateTime startDate)
        {
            Console.WriteLine($"Start date/time: {startDate}");
            Console.WriteLine("When does the appointment end (Plesae enter as dd/mm/yyyy hh:mm)");
        }

        internal static void ErrorMessageDialog()
        {
            Console.WriteLine("Please select a valid option");
        }

        internal static void DisplayAppointments()
        {
                List<Appointment> appointments = Database.ReturnAppointments();

                Console.WriteLine("Appointments:");
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"Id: {appointment.Id}, Title: {appointment.Title}, Start: {appointment.Start}, End: {appointment.End}");
                }
            }
  
        internal static void DeleteOptionDialog()
        {
            Console.WriteLine("Which appointment would you like to delete?");
        }
    }


}

