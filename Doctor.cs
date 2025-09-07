using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS125_CSVA
{
    public class Doctor
    {
        public string Name { get; set; }
        public string Specialty { get; set; }

        public Doctor(string name, string specialty)
        {
            Name = name;
            Specialty = specialty;
        }

        public string GetDoctorInfo()
        {
            return $"Doctor Name: {Name}, Specialty: {Specialty}";
        }
    }
}
