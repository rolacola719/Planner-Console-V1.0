using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner_Console_V1._0
{
    public class Appointment
    {
            public int Id { get; set; }         // Assuming there's an Id column in the database
            public string Title { get; set; }
            public DateTime Start { get; set; }
            public DateTime End { get; set; }


        }
    }

