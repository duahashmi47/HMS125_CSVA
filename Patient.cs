using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;


namespace HMS125_CSVA
{
    public class Patient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public List<Prescription> Prescriptions { get; set; }

        public Patient(string name, int age, Gender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Prescriptions = new List<Prescription>();
        }
        public List<Disease> Diseases { get; set; } = new List<Disease>();

        public void AddDisease(Disease disease)
        {
            Diseases.Add(disease);
        }
        public string GetPatientInfo()
        {
            StringBuilder patientInfo = new StringBuilder($"Patient Name: {Name}, Age: {Age}, Gender: {Gender}");

            if (Prescriptions.Any())
            {
                patientInfo.AppendLine("\nPrescriptions:");
                foreach (var prescription in Prescriptions)
                {
                    patientInfo.AppendLine($"- {prescription.GetPrescriptionInfo()}");
                }
                string diseaseInfo = (Diseases.Any()) ? $"\nDiseases:\n{string.Join("\n", Diseases.Select(d => d.GetDiseaseInfo()))}" : "";

                return $"Patient Name: {Name}, Age: {Age}, Gender: {Gender}{diseaseInfo}";
            }

            return patientInfo.ToString();
        }
    }
}
