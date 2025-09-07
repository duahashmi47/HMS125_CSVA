using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace HMS125_CSVA
{
    public enum Gender
    {
        Male,
        Female
    }
    internal class Program
    {
        private static readonly HospitalManagementSystem hospitalSystem = new HospitalManagementSystem();
        static void Main()
        {
            Console.WriteLine("Welcome to the Hospital Management System (HMS)");

            while (true)
            {
                Console.WriteLine("\n**************");
                Console.WriteLine("Select an option:");
                Console.WriteLine("a. Manage Patients");
                Console.WriteLine("b. Manage Doctors");
                Console.WriteLine("c. Manage Nurses");
                Console.WriteLine("d. Manage Prescriptions");
                Console.WriteLine("e. Manage Appointments");
                Console.WriteLine("f. Exit");
                Console.WriteLine("\n**************");

                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "a":
                        ManagePatients();
                        break;
                    case "b":
                        ManageDoctors();
                        break;
                    case "c":
                        ManageNurses();
                        break;
                    case "d":
                        ManagePrescriptions();
                        break;
                    case "e":
                        ManageAppointments();
                        break;
                    case "f":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Patient methods
        static void ManagePatients()
        {
            while (true)
            {
                Console.WriteLine("\n**************");
                Console.WriteLine("\nManage Patients:");
                Console.WriteLine("1. Add a new patient");
                Console.WriteLine("2. View all patients");
                Console.WriteLine("3. Delete a patient");
                Console.WriteLine("4. Update patient information");
                Console.WriteLine("5. Search for a patient");
                Console.WriteLine("6. Add disease to a patient");
                Console.WriteLine("7. Go back");
                Console.WriteLine("\n**************");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPatient();
                        break;
                    case "2":
                        ViewAllPatients();
                        break;
                    case "3":
                        DeletePatient();
                        break;
                    case "4":
                        UpdatePatient();
                        break;
                    case "5":
                        SearchPatient();
                        break;
                    case "6":
                        AddDiseaseToPatient();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddPatient()
        {
            Console.WriteLine("Enter patient name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter patient age:");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age. Please enter a valid number.");
                return;
            }

            Gender gender;
            while (true)
            {
                Console.WriteLine("Enter patient gender (Male/Female/Other):");
                if (Enum.TryParse(Console.ReadLine(), true, out gender))
                {
                    break; // Exit the loop if a valid gender is entered
                }
                else
                {
                    Console.WriteLine("Invalid gender. Please enter Male, Female, or Other.");
                }
            }

            Patient newPatient = new Patient(name, age, gender);
            hospitalSystem.AddPatient(newPatient);

            Console.WriteLine("Patient added successfully.");
        }


        static void ViewAllPatients()
        {
            List<Patient> patients = hospitalSystem.GetPatients();

            Console.WriteLine("\nList of Patients:");
            foreach (var patient in patients)
            {
                Console.WriteLine(patient.GetPatientInfo());
            }
        }

        static void DeletePatient()
        {
            Console.WriteLine("Enter patient name to delete:");
            string nameToDelete = Console.ReadLine();

            Patient patientToDelete = hospitalSystem.GetPatients().FirstOrDefault(p => p.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (patientToDelete != null)
            {
                hospitalSystem.DeletePatient(patientToDelete);
                Console.WriteLine("Patient deleted successfully.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        static void UpdatePatient()
        {
            Console.WriteLine("Enter patient name to update:");
            string nameToUpdate = Console.ReadLine();

            Patient patientToUpdate = hospitalSystem.GetPatients().FirstOrDefault(p => p.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));

            if (patientToUpdate != null)
            {
                Console.WriteLine("Enter new age:");
                if (int.TryParse(Console.ReadLine(), out int newAge))
                {
                    patientToUpdate.Age = newAge;
                    Console.WriteLine("Patient information updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid age. Update failed.");
                }
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        static void SearchPatient()
        {
            Console.WriteLine("Enter patient name to search:");
            string searchName = Console.ReadLine();

            List<Patient> searchResults = hospitalSystem.GetPatients().Where(p => p.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (searchResults.Any())
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var result in searchResults)
                {
                    Console.WriteLine(result.GetPatientInfo());
                }
            }
            else
            {
                Console.WriteLine("No matching patients found.");
            }
        }

        // Doctor methods
        static void ManageDoctors()
        {
            while (true)
            {
                Console.WriteLine("\n**************");
                Console.WriteLine("\nManage Doctors:");
                Console.WriteLine("1. Add a new doctor");
                Console.WriteLine("2. View all doctors");
                Console.WriteLine("3. Delete a doctor");
                Console.WriteLine("4. Update doctor information");
                Console.WriteLine("5. Search for a doctor");
                Console.WriteLine("6. Go back");
                Console.WriteLine("\n**************");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDoctor();
                        break;
                    case "2":
                        ViewAllDoctors();
                        break;
                    case "3":
                        DeleteDoctor();
                        break;
                    case "4":
                        UpdateDoctor();
                        break;
                    case "5":
                        SearchDoctor();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddDoctor()
        {
            Console.WriteLine("Enter doctor name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter doctor specialty:");
            string specialty = Console.ReadLine();

            Doctor newDoctor = new Doctor(name, specialty);
            hospitalSystem.AddDoctor(newDoctor);

            Console.WriteLine("Doctor added successfully.");
        }

        static void ViewAllDoctors()
        {
            List<Doctor> doctors = hospitalSystem.GetDoctors();

            Console.WriteLine("\nList of Doctors:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.GetDoctorInfo());
            }
        }

        static void UpdateDoctor()
        {
            Console.WriteLine("Enter doctor name to update:");
            string nameToUpdate = Console.ReadLine();

            Doctor doctorToUpdate = hospitalSystem.GetDoctors().FirstOrDefault(d => d.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));

            if (doctorToUpdate != null)
            {
                Console.WriteLine("Enter new specialty:");
                string newSpecialty = Console.ReadLine();
                doctorToUpdate.Specialty = newSpecialty;

                Console.WriteLine("Doctor information updated successfully.");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        static void SearchDoctor()
        {
            Console.WriteLine("Enter doctor name to search:");
            string searchName = Console.ReadLine();

            List<Doctor> searchResults = hospitalSystem.GetDoctors().Where(d => d.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


            if (searchResults.Any())
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var result in searchResults)
                {
                    Console.WriteLine(result.GetDoctorInfo());
                }
            }
            else
            {
                Console.WriteLine("No matching doctors found.");
            }
        }

        static void DeleteDoctor()
        {
            Console.WriteLine("Enter doctor name to delete:");
            string nameToDelete = Console.ReadLine();

            Doctor doctorToDelete = hospitalSystem.GetDoctors().FirstOrDefault(d => d.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (doctorToDelete != null)
            {
                hospitalSystem.DeleteDoctor(doctorToDelete);
                Console.WriteLine("Doctor deleted successfully.");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        // Nurse methods
        static void ManageNurses()
        {
            while (true)
            {
                Console.WriteLine("\n**************");
                Console.WriteLine("\nManage Nurses:");
                Console.WriteLine("1. Add a new nurse");
                Console.WriteLine("2. View all nurses");
                Console.WriteLine("3. Delete a nurse");
                Console.WriteLine("4. Update nurse information");
                Console.WriteLine("5. Search for a nurse");
                Console.WriteLine("6. Go back");
                Console.WriteLine("\n**************");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNurse();
                        break;
                    case "2":
                        ViewAllNurses();
                        break;
                    case "3":
                        DeleteNurse();
                        break;
                    case "4":
                        UpdateNurse();
                        break;
                    case "5":
                        SearchNurse();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddNurse()
        {
            Console.WriteLine("Enter nurse name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter nurse department:");
            string department = Console.ReadLine();

            Nurse newNurse = new Nurse(name, department);
            hospitalSystem.AddNurse(newNurse);

            Console.WriteLine("Nurse added successfully.");
        }

        static void ViewAllNurses()
        {
            List<Nurse> nurses = hospitalSystem.GetNurses();

            Console.WriteLine("\nList of Nurses:");
            foreach (var nurse in nurses)
            {
                Console.WriteLine(nurse.GetNurseInfo());
            }
        }

        static void UpdateNurse()
        {
            Console.WriteLine("Enter nurse name to update:");
            string nameToUpdate = Console.ReadLine();

            Nurse nurseToUpdate = hospitalSystem.GetNurses().FirstOrDefault(n => n.Name.Equals(nameToUpdate, StringComparison.OrdinalIgnoreCase));

            if (nurseToUpdate != null)
            {
                Console.WriteLine("Enter new department:");
                string newDepartment = Console.ReadLine();
                nurseToUpdate.Department = newDepartment;

                Console.WriteLine("Nurse information updated successfully.");
            }
            else
            {
                Console.WriteLine("Nurse not found.");
            }
        }

        static void SearchNurse()
        {
            Console.WriteLine("Enter nurse name to search:");
            string searchName = Console.ReadLine();

            List<Nurse> searchResults = hospitalSystem.GetNurses().Where(n => n.Name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (searchResults.Any())
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var result in searchResults)
                {
                    Console.WriteLine(result.GetNurseInfo());
                }
            }
            else
            {
                Console.WriteLine("No matching nurses found.");
            }
        }

        static void DeleteNurse()
        {
            Console.WriteLine("Enter nurse name to delete:");
            string nameToDelete = Console.ReadLine();

            Nurse nurseToDelete = hospitalSystem.GetNurses().FirstOrDefault(n => n.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (nurseToDelete != null)
            {
                hospitalSystem.DeleteNurse(nurseToDelete);
                Console.WriteLine("Nurse deleted successfully.");
            }
            else
            {
                Console.WriteLine("Nurse not found.");
            }
        }

        //disease method
        static void AddDiseaseToPatient()
        {
            Console.WriteLine("Enter patient name to add disease:");
            string patientName = Console.ReadLine();

            Patient patient = hospitalSystem.GetPatients()
                .FirstOrDefault(p => p.Name.Equals(patientName, StringComparison.OrdinalIgnoreCase));

            if (patient != null)
            {
                Console.WriteLine("Enter disease name:");
                string diseaseName = Console.ReadLine();

                Console.WriteLine("Enter disease description:");
                string diseaseDescription = Console.ReadLine();

                Disease newDisease = new Disease(diseaseName, diseaseDescription);
                hospitalSystem.AddDisease(patient, newDisease);

                Console.WriteLine("Disease added to patient successfully.");
            }
            else
            {
                Console.WriteLine($"Patient '{patientName}' not found. Disease not added.");
            }
        }

        // Prescription methods
        static void ManagePrescriptions()
        {
            while (true)
            {
                Console.WriteLine("\n**************");
                Console.WriteLine("\nManage Prescriptions:");
                Console.WriteLine("1. Add a new prescription");
                Console.WriteLine("2. View all prescriptions");
                Console.WriteLine("3. Delete a prescription");
                Console.WriteLine("4. Update prescription information");
                Console.WriteLine("5. Search for a prescription");
                Console.WriteLine("6. Go back");
                Console.WriteLine("\n**************");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPrescription();
                        break;
                    case "2":
                        ViewAllPrescriptions();
                        break;
                    case "3":
                        DeletePrescription();
                        break;
                    case "4":
                        UpdatePrescription();
                        break;
                    case "5":
                        SearchPrescription();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddPrescription()
        {
            Console.WriteLine("Enter medicine name:");
            string medicineName = Console.ReadLine();

            Console.WriteLine("Enter prescription instructions:");
            string instructions = Console.ReadLine();

            Prescription newPrescription = new Prescription(medicineName, instructions);
            hospitalSystem.AddPrescription(newPrescription);

            Console.WriteLine("Enter patient name for the prescription:");
            string patientName = Console.ReadLine();

            Patient patient = hospitalSystem.GetPatients()
                .FirstOrDefault(p => p.Name.Equals(patientName, StringComparison.OrdinalIgnoreCase));

            if (patient != null)
            {
                hospitalSystem.AddPrescription(new Prescription(medicineName, instructions, patient), patient);

                Console.WriteLine("Prescription added successfully.");
            }
            else
            {
                Console.WriteLine($"Patient '{patientName}' not found. Prescription not added.");
            }
        }
        static void ViewAllPrescriptions()
        {
            List<Prescription> prescriptions = hospitalSystem.GetPrescriptions();

            Console.WriteLine("\nList of Prescriptions:");
            foreach (var prescription in prescriptions)
            {
                Console.WriteLine(prescription.GetPrescriptionInfo());
            }
        }

        static void UpdatePrescription()
        {
            Console.WriteLine("Enter medicine name to update prescription:");
            string medicineNameToUpdate = Console.ReadLine();

            Prescription prescriptionToUpdate = hospitalSystem.GetPrescriptions().FirstOrDefault(p => p.MedicineName.Equals(medicineNameToUpdate, StringComparison.OrdinalIgnoreCase));

            if (prescriptionToUpdate != null)
            {
                Console.WriteLine("Enter new instructions:");
                string newInstructions = Console.ReadLine();
                prescriptionToUpdate.Instructions = newInstructions;

                Console.WriteLine("Prescription information updated successfully.");
            }
            else
            {
                Console.WriteLine("Prescription not found.");
            }
        }

        static void SearchPrescription()
        {
            Console.WriteLine("Enter medicine name to search prescription:");
            string searchMedicineName = Console.ReadLine();

            List<Prescription> searchResults = hospitalSystem.GetPrescriptions().Where(p => p.MedicineName.IndexOf(searchMedicineName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (searchResults.Any())
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var result in searchResults)
                {
                    Console.WriteLine(result.GetPrescriptionInfo());
                }
            }
            else
            {
                Console.WriteLine("No matching prescriptions found.");
            }
        }

        static void DeletePrescription()
        {
            Console.WriteLine("Enter medicine name to delete prescription:");
            string medicineNameToDelete = Console.ReadLine();

            Prescription prescriptionToDelete = hospitalSystem.GetPrescriptions().FirstOrDefault(p => p.MedicineName.Equals(medicineNameToDelete, StringComparison.OrdinalIgnoreCase));

            if (prescriptionToDelete != null)
            {
                hospitalSystem.DeletePrescription(prescriptionToDelete);
                Console.WriteLine("Prescription deleted successfully.");
            }
            else
            {
                Console.WriteLine("Prescription not found.");
            }
        }

        // Appointment methods
        static void ManageAppointments()
        {
            while (true)
            {
                Console.WriteLine("\n**************");
                Console.WriteLine("\nManage Appointments:");
                Console.WriteLine("1. Add a new appointment");
                Console.WriteLine("2. View all appointments");
                Console.WriteLine("3. Delete an appointment");
                Console.WriteLine("4. Update appointment information");
                Console.WriteLine("5. Search for an appointment");
                Console.WriteLine("6. Go back");
                Console.WriteLine("\n**************");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAppointment();
                        break;
                    case "2":
                        ViewAllAppointments();
                        break;
                    case "3":
                        DeleteAppointment();
                        break;
                    case "4":
                        UpdateAppointment();
                        break;
                    case "5":
                        SearchAppointment();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddAppointment()
        {
            Console.WriteLine("Enter patient name for the appointment:");
            string patientName = Console.ReadLine();

            Doctor selectedDoctor = null;

            while (selectedDoctor == null)
            {
                Console.WriteLine("Enter doctor name for the appointment:");
                string doctorName = Console.ReadLine();

                // Check if the specified doctor exists
                selectedDoctor = hospitalSystem.GetDoctors().FirstOrDefault(d => d.Name.Equals(doctorName, StringComparison.OrdinalIgnoreCase));

                if (selectedDoctor == null)
                {
                    Console.WriteLine($"Doctor '{doctorName}' not found. Please enter a valid doctor name.");
                }
            }

            DateTime appointmentDateTime;

            while (true)
            {
                Console.WriteLine("Enter appointment date and time (YYYY-MM-DD HH:mm):");

                if (DateTime.TryParse(Console.ReadLine(), out appointmentDateTime))
                {
                    // Check if the selected doctor is available at the specified date and time
                    if (IsDoctorAvailable(selectedDoctor.Name, appointmentDateTime))
                    {
                        Console.WriteLine("Enter wardroom name (optional):");
                        string wardroomName = Console.ReadLine();

                        Appointment newAppointment = new Appointment(patientName, selectedDoctor.Name, appointmentDateTime, wardroomName);
                        hospitalSystem.ScheduleAppointment(newAppointment);

                        Console.WriteLine("Appointment added successfully.");
                        break; // Exit the loop if the appointment is added successfully
                    }
                    else
                    {
                        Console.WriteLine($"Doctor '{selectedDoctor.Name}' is not available at the specified date and time. Please enter a different date and time.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date and time format. Please enter a valid date and time.");
                }
            }
        }


        static void ViewAllAppointments()
        {
            List<Appointment> appointments = hospitalSystem.GetAppointments();

            Console.WriteLine("\nList of Appointments:");
            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment.GetAppointmentInfo());
            }
        }

        static void UpdateAppointment()
        {
            Console.WriteLine("Enter patient name for the appointment to update:");
            string patientNameToUpdate = Console.ReadLine();

            Appointment appointmentToUpdate = hospitalSystem.GetAppointments().FirstOrDefault(a => a.Patient.Name.Equals(patientNameToUpdate, StringComparison.OrdinalIgnoreCase));

            if (appointmentToUpdate != null)
            {
                Console.WriteLine("Enter new appointment date and time (YYYY-MM-DD HH:mm):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newAppointmentDateTime))
                {
                    Console.WriteLine("Enter new wardroom name (optional):");
                    string newWardroomName = Console.ReadLine();

                    appointmentToUpdate.AppointmentDate = newAppointmentDateTime;
                    appointmentToUpdate.WardroomName = newWardroomName;

                    Console.WriteLine("Appointment information updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date and time format. Update failed.");
                }
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        private static bool IsDoctorAvailable(string doctorName, DateTime appointmentDateTime)
        {
            // Check if the doctor with the given name exists in the list of doctors
            Doctor selectedDoctor = hospitalSystem.GetDoctors().FirstOrDefault(d => d.Name.Equals(doctorName, StringComparison.OrdinalIgnoreCase));

            // If the doctor is found, you can implement additional logic to check availability based on the appointmentDateTime
            if (selectedDoctor != null)
            {
                // For now, let's assume the doctor is always available
                return true;
            }
            else
            {
                // Doctor not found, so not available
                return false;
            }
        }

        static void SearchAppointment()
        {
            Console.WriteLine("Enter patient name for the appointment to search:");
            string searchPatientName = Console.ReadLine();

            List<Appointment> searchResults = hospitalSystem.GetAppointments().Where(a => a.Patient.Name.IndexOf(searchPatientName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (searchResults.Any())
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var result in searchResults)
                {
                    Console.WriteLine(result.GetAppointmentInfo());
                }
            }
            else
            {
                Console.WriteLine("No matching appointments found.");
            }
        }

        static void DeleteAppointment()
        {
            Console.WriteLine("Enter patient name for the appointment to delete:");
            string patientNameToDelete = Console.ReadLine();

            Appointment appointmentToDelete = hospitalSystem.GetAppointments().FirstOrDefault(a => a.Patient.Name.Equals(patientNameToDelete, StringComparison.OrdinalIgnoreCase));

            if (appointmentToDelete != null)
            {
                hospitalSystem.CancelAppointment(appointmentToDelete);
                Console.WriteLine("Appointment deleted successfully.");
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

    }

}