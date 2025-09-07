using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS125_CSVA
{
    public class Prescription
    {
        public string MedicineName { get; set; }
        public string Instructions { get; set; }

        public Patient Patient { get; set; }

        public Prescription(string medicineName, string instructions, Patient patient)
        {
            MedicineName = medicineName;
            Instructions = instructions;
            Patient = patient;
        }

        public Prescription(string medicineName, string instructions)
        {
            MedicineName = medicineName;
            Instructions = instructions;
        }

        public string GetPrescriptionInfo()
        {
            string patientInfo = (Patient != null) ? $" for Patient: {Patient.Name}" : "";
            return $"Medicine: {MedicineName}, Instructions: {Instructions}{patientInfo}";
        }
    }
}
