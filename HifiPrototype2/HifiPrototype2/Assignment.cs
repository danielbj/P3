using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2
{
    public class Assignment
    {
        public int Duration { get; set; }
        public int Location { get; set; }
        public string Description { get; set; }
        public Employee Provider { get; set; }

        public static Assignment CreateRandomAssignment()
        {
            var random = new Random();
            var assignment = new Assignment();

            assignment.Description = "Description";
            assignment.Duration = random.Next(5, 100);
            assignment.Location = random.Next(0, 100);

            return assignment;
        }
    }
}
