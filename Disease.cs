using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS125_CSVA
{
    public class Disease
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Disease(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string GetDiseaseInfo()
        {
            return $"Disease: {Name}, Description: {Description}";
        }
    }
}
