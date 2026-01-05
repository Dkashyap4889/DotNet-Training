using System;

namespace PracticalAssignments
{
    enum SalaryDetail {
        DA,
        HRA,
        GRS
    }


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

        public void calcHraOrDa(int salary, out int calcAmount, SalaryDetail key)
        { 
            if(key == SalaryDetail.DA)
            {
                calcAmount = salary / 5;
            }
            else if(key == SalaryDetail.HRA)
            {
                calcAmount = salary / 10;
            }
            else
            {
                calcAmount = 0;
            }
        }

        public void displayGross(int salary)
        {
            calcHraOrDa(salary, out int da, SalaryDetail.DA);
            calcHraOrDa(salary, out int hra, SalaryDetail.HRA);
            Console.WriteLine($"SALARY {salary} HRA {hra} DA {da}");
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
            Console.WriteLine("Please Enter Your Basic Salary");
            int basicSalary = int.Parse(Console.ReadLine());
            Console.WriteLine("Type 1 For DA, 2 for HRA, 3 for GRS:");
            int selectedOption = int.Parse(Console.ReadLine());
            if(selectedOption == 1)
            {
                c.calcHraOrDa(basicSalary, out int calcAmount,SalaryDetail.DA);
                Console.WriteLine($"{calcAmount}");
            }   else if(selectedOption == 2)
            {
                c.calcHraOrDa(basicSalary, out int calcAmount, SalaryDetail.HRA);
                Console.WriteLine($"{calcAmount}");
            }   else if (selectedOption == 3)
            {
                c.displayGross(basicSalary);
            }

            Console.WriteLine("Entering Calculator:");
            Console.WriteLine("1. Add, 2. Subtract, 3. Multiply, 4. Exit");

            int op = int.Parse(Console.ReadLine());

            if(op == 4) {
                Environment.Exit(0);
            }

            Console.WriteLine("Enter Operand 1 : ");
            int operandOne = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Operand 2 : ");
            int operandTwo = int.Parse(Console.ReadLine());
            int sol = op == 1 ? operandOne + operandTwo : op == 2 ? operandOne - operandTwo : operandTwo * operandTwo;
            Console.WriteLine($"Solution: {sol}");
            Console.ReadKey();
        }
    }
}
