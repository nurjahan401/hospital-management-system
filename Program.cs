
using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract void DisplayDetails();
    }

    // Patient class(EMON)
    public class Patient : Person
    {
        public string PatientId { get; set; }
        public string Illness { get; set; }

        public Patient(string name, int age, string patientId, string illness) : base(name, age)
        {
            PatientId = patientId;
            Illness = illness;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Patient ID: {PatientId}, Name: {Name}, Age: {Age}, Illness: {Illness}");
        }
    }

    // Doctor class(NURJAHAN)
    public class Doctor : Person
    {
        public string DoctorId { get; set; }
        public string Specialization { get; set; }

        public Doctor(string name, int age, string doctorId, string specialization) : base(name, age)
        {
            DoctorId = doctorId;
            Specialization = specialization;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Doctor ID: {DoctorId}, Name: {Name}, Age: {Age}, Specialization: {Specialization}");
        }
    }

    // Staff class(JANNAT)
    public class Staff : Person
    {
        public string Role { get; set; }

        public Staff(string name, int age, string role) : base(name, age)
        {
            Role = role;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Staff Name: {Name}, Age: {Age}, Role: {Role}");
        }
    }

    // Appointment class(KIBREYA)
    public class Appointment
    {
        public string AppointmentId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Appointment(string appointmentId, Patient patient, Doctor doctor, DateTime date)
        {
            AppointmentId = appointmentId;
            Patient = patient;
            Doctor = doctor;
            AppointmentDate = date;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Appointment ID: {AppointmentId}, Patient: {Patient.Name}, Doctor: {Doctor.Name}, Date: {AppointmentDate}");
        }
    }

    // Hospital class(ABU BAKKAR)
    public class Hospital
    {
        private static int patientCount = 0;
        private List<Patient> patients = new List<Patient>();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Appointment> appointments = new List<Appointment>();

        public void AddPatient(string name, int age, string illness)
        {
            patientCount++;
            string patientId = $"P{patientCount:D4}";
            var patient = new Patient(name, age, patientId, illness);
            patients.Add(patient);
            Console.WriteLine("Patient added successfully!");
        }

        public void AddDoctor(string name, int age, string specialization)
        {
            string doctorId = $"D{doctors.Count + 1:D4}";
            var doctor = new Doctor(name, age, doctorId, specialization);
            doctors.Add(doctor);
            Console.WriteLine("Doctor added successfully!");
        }

        public void ScheduleAppointment(string patientId, string doctorId, DateTime date)
        {
            var patient = patients.Find(p => p.PatientId == patientId);
            var doctor = doctors.Find(d => d.DoctorId == doctorId);
            if (patient != null && doctor != null)
            {
                var appointment = new Appointment($"A{appointments.Count + 1:D4}", patient, doctor, date);
                appointments.Add(appointment);
                Console.WriteLine("Appointment scheduled successfully!");
            }
            else
            {
                Console.WriteLine("Patient or Doctor not found!");
            }
        }

        public void DisplayPatients()
        {
            Console.WriteLine("\nPatients List:");
            foreach (var patient in patients)
            {
                patient.DisplayDetails();
            }
        }

        public void DisplayDoctors()
        {
            Console.WriteLine("\nDoctors List:");
            foreach (var doctor in doctors)
            {
                doctor.DisplayDetails();
            }
        }

        public void DisplayAppointments()
        {
            Console.WriteLine("\nAppointments List:");
            foreach (var appointment in appointments)
            {
                appointment.DisplayDetails();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var hospital = new Hospital();

            // Add sample data
            hospital.AddPatient("RAHAD", 30, "Flu");
            hospital.AddDoctor("NURJAHAN KHATUN", 45, "Cardiology");

            hospital.AddPatient("samia", 24, "lung diseases");
            hospital.AddDoctor("jannat", 36, "pulmonologist");

            hospital.AddPatient("mehedi", 34, "cancer");
            hospital.AddDoctor("sumaiya", 36, "medicine");

            hospital.AddPatient("faysal", 24, "cancer");
            hospital.AddDoctor("nusrat mow", 26, "medicine");


            Console.WriteLine("\nEnter patient ID for appointment:");
            string patientId = Console.ReadLine();

            Console.WriteLine("Enter doctor ID for appointment:");
            string doctorId = Console.ReadLine();

            Console.WriteLine("Enter appointment date (YYYY-MM-DD):");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

            hospital.ScheduleAppointment(patientId, doctorId, appointmentDate);

            // Display details
            hospital.DisplayPatients();
            hospital.DisplayDoctors();
            hospital.DisplayAppointments();
        }
    }
}
