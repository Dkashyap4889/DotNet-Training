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

        public void increaseSalary(ref int salary) {
            salary += 10000;
        }

        public void calcBonus(int currentSalary, out int bonus)
        {
            bonus = currentSalary / 10;
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
            // Ref KeyWord Usage
            int salary = 10000;
            //Console.WriteLine(salary);
            c.increaseSalary(ref salary);
            //Console.WriteLine(salary);

            c.calcBonus(salary, out int bonus);

            Console.WriteLine(bonus);
        }
    }
}
