using System;
using System.Linq;

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


    abstract class Bill
    {
        public int usage;

        public abstract int CalculateBill();
    }

    internal class MobileBill : Bill
    {
        public MobileBill(int usage)
        {
            this.usage = usage;
        }

        public override int CalculateBill()
        {
            return this.usage * 100;
        }
    }
    internal class InternetBill : Bill
    {
        public InternetBill(int usage)
        {
            this.usage = usage;
        }

        public override int CalculateBill()
        {
            return this.usage * 200;
        }
    }
    internal class ElectricityBill : Bill
    {
        public ElectricityBill(int usage)
        {
            this.usage = usage;
        }

        public override int CalculateBill()
        {
            return this.usage * 300;
        }
    }

    internal class Program
    {
        public static Boolean checkPalindrome(int num)
        {
            string s = $"{num}";
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            char[] revereCharArray = s.ToCharArray();
            for (int a = 0; a < charArray.Length; a++)
            {
                if (charArray[a] != revereCharArray[a])
                    return false;
            }

            return true;
        }

        public static int factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
             return n * factorial(n - 1);
        }

        public static Boolean validateEmail(string email)
        {
            return email.Contains("@");
        }


        static void Main(string[] args)
        {
            Console.WriteLine(checkPalindrome(1221)); //TRUE
            Console.WriteLine(checkPalindrome(12213)); //FALSE
            Console.WriteLine(factorial(5)); // 120
            Console.WriteLine(validateEmail("dheeraj@gm")); // TRUE
            Console.WriteLine(validateEmail("dheerajgm")); // FALSE

            Bill mobileBill = new MobileBill(12);
            Bill internetBill = new InternetBill(34);
            Bill electricityBill = new ElectricityBill(56);

            Console.WriteLine(mobileBill.CalculateBill());
            Console.WriteLine(internetBill.CalculateBill());
            Console.WriteLine(electricityBill.CalculateBill());

            Console.ReadKey();
        }
    }
}
