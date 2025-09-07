using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS125_CSVA
{
    public class Nurse
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public Nurse(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public string GetNurseInfo()
        {
            return $"Nurse Name: {Name}, Department: {Department}";
        }
    }
}
