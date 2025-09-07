using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace HMS125_CSVA
{
    public class HospitalManagementSystem
    {
        private readonly List<Nurse> nurses = new List<Nurse>();

        private readonly List<Prescription> prescriptions = new List<Prescription>();
        private readonly List<Patient> patients = new List<Patient>();
        private readonly List<Doctor> doctors = new List<Doctor>();
        private readonly List<Appointment> appointments = new List<Appointment>();

        public HospitalManagementSystem()
        {
            nurses = new List<Nurse>();
            prescriptions = new List<Prescription>();
            patients = new List<Patient>();
            doctors = new List<Doctor>();
            appointments = new List<Appointment>();
        }

        // Nurse methods
        public void AddNurse(Nurse nurse)
        {
            nurses.Add(nurse);
        }

        public List<Nurse> GetNurses()
        {
            return nurses;
        }

        public void DeleteNurse(Nurse nurse)
        {
            nurses.Remove(nurse);
        }

        // Prescription methods

        public void AddPrescription(Prescription prescription, Patient patient)
        {
            prescription.Patient = patient;
            prescriptions.Add(prescription);
        }
        public void AddPrescriptionToPatient(Prescription prescription, Patient patient)
        {
            patient.Prescriptions.Add(prescription);
        }

        public List<Prescription> GetPrescriptionsForPatient(Patient patient)
        {
            return patient.Prescriptions;
        }

        public void AddPrescription(Prescription prescription)
        {
            prescriptions.Add(prescription);
        }

        public List<Prescription> GetPrescriptions()
        {
            return prescriptions;
        }

        public void DeletePrescription(Prescription prescription)
        {
            prescriptions.Remove(prescription);
        }
        //disease methods
        public void AddDisease(Patient patient, Disease disease)
        {
            patient.AddDisease(disease);
        }

        // Patient methods
        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public void DeletePatient(Patient patient)
        {
            patients.Remove(patient);
        }

        // Doctor methods
        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }

        public void DeleteDoctor(Doctor doctor)
        {
            doctors.Remove(doctor);
        }

        // Appointment methods
        public void ScheduleAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public List<Appointment> GetAppointments()
        {
            return appointments;
        }

        public void CancelAppointment(Appointment appointment)
        {
            appointments.Remove(appointment);
        }
    }

}

