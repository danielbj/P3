using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HifiPrototype2.Model
{
    public class Route
    {
        public int Duration { get; set; }
        public int StartTime { get; set; }
        public int EndTime
        {
            get
            {
                return StartTime + Duration;
            }
        }
    }

    public class Assignment
    {
        public int Duration { get; set; }
        public int Location { get; set; }
        public string Description { get; set; }
        public Employee Provider { get; set; }
        public int StartTime
        {
            get
            {
                return route.EndTime;
            }
        }
        public int EndTime
        {
            get
            {
                return StartTime + Duration;
            }
        }
        public Route route { get; set; } = new Route();

        public static Assignment CreateRandomAssignment(int number)
        {
            var random = new Random();
            var assignment = new Assignment();
            switch (number) {
                case 1:
                    assignment.Description = "Job 1";
                    assignment.Duration = 5;
                    assignment.Location = 5;
                    break;
                case 2:
                    assignment.Description = "Job 2";
                    assignment.Duration = 10;
                    assignment.Location = 25;
                    break;
                case 3:
                    assignment.Description = "Job 3";
                    assignment.Duration = 59;
                    assignment.Location = 55;
                    break;
                case 4:
                    assignment.Description = "Job 4";
                    assignment.Duration = 60;
                    assignment.Location = 40;
                    break;
                case 5:
                    assignment.Description = "Job 5";
                    assignment.Duration = 70;
                    assignment.Location = 70;
                    break;
                default:
                    assignment.Description = "Description";
                    assignment.Duration = random.Next(5, 100);
                    assignment.Location = random.Next(0, 100);
                    break;
            }

            return assignment;
        }
    }
}
