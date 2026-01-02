using System;

namespace PracticalAssignments
{
    class Company {
        // Compilers Propagate Constants, So Only Make something a Constant If it won't be changed Later otherwise Re-compile will be required
        private const string CompanyName = "Dheeraj";
        private readonly int RegistrationNumber;
        private static int TotalEmployee = 0;


        public Company(int RegistrationNumber)
        {
            this.RegistrationNumber = RegistrationNumber;
        }
        public void addEmployee() {
            TotalEmployee++;
        }

        public int getEmployeeCount() {
            return TotalEmployee;
        }

        override
        public String ToString() {
            return $"CompanyName {CompanyName} RegistrationNumber {this.RegistrationNumber} TotalEmployee {TotalEmployee}";
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Company c = new Company(123);
            Console.WriteLine(c.ToString());
            c.addEmployee();
            Console.WriteLine(c.ToString());
        }
    }
}
