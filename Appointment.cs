using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS125_CSVA
{
    public class Appointment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string WardroomName { get; set; }

        public Appointment(string patientName, string doctorName, DateTime appointmentDate, string wardroomName)
        {
            Patient = new Patient(patientName, 0, Gender.Male);
            Doctor = new Doctor(doctorName, "");
            AppointmentDate = appointmentDate;
            WardroomName = wardroomName;
        }

        public string GetAppointmentInfo()
        {
            return $"Appointment for Patient: {Patient.Name}, Doctor: {Doctor.Name}, Date: {AppointmentDate}, Wardroom: {WardroomName}";
        }
    }
}
