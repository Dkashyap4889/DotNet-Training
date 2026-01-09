using System;
using System.Collections.Generic;
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

    class Product {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        public Product(int id, string name, int price)
        {
            this.ProductId = id;
            this.ProductName = name;
            this.Price = price;
        }

        override
        public string ToString() {

            return $"ProductId {ProductId} ProductName {ProductName} Price {Price}";
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

    internal class Employee
    {
        public Employee(int id, int salary)
        {
            Id = id;
            Salary = salary;
        }

        public int Id { get; set; }
        public int Salary { get; set; }

        override
        public string ToString()
        {
            return $"Id {Id} Salary {Salary}";
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

            // Arrays
            const int PASS_MARKS = 30;
            int[] Marks = { 100, 29, 60, 50, 50 };

            int Highest = int.MinValue;
            int Lowest = int.MaxValue;
            int PassedCount = 0;

            for(int i = 0; i < Marks.Length; i++)
            {

                Highest = Math.Max(Highest, Marks[i]);
                Lowest = Math.Min(Lowest, Marks[i]);
                PassedCount += Marks[i] >= PASS_MARKS ? 1 : 0;
            }

            Console.WriteLine($"Highest {Highest} Lowest {Lowest} PassCount {PassedCount}");


            // Array of Object
            Product[] Bills = { new Product(1, "a", 100), new Product(2, "b", 400), new Product(3, "c", 30) };
            int IdToSearch = 2;
            Product FoundProduct;
            int PriceLimit = 200;
            foreach (Product item in Bills)
            {
                if(item.ProductId == IdToSearch)
                {
                    FoundProduct = item;
                }
                if (item.Price >= PriceLimit)
                {
                    Console.WriteLine(item.ToString());
                }

            }

            // List
            List<Employee> list = new List<Employee>();
            // Adding
            list.Add(new Employee(1, 2000));
            list.Add(new Employee(2, 2000));
            list.Add(new Employee(3, 2000));

            foreach (Employee item in list)
            {
                item.Salary += 1000;
                
            }
            foreach (Employee item in list)
            {
                Console.WriteLine(item.ToString());
            }
            // REMOVING an Employee
            list.Remove(list.Find(i => i.Id == 1));
            Console.WriteLine("Display All");
            foreach (Employee item in list)
            {
                Console.WriteLine(item.ToString());
            }

            // Dictionary

            //Diction<Id, Name>
            Dictionary<int, string> d = new Dictionary<int, string>();

            //Preventing Duplicate Key
            if (!d.ContainsKey(1))
                d.Add(1, "Dheeraj");
            if(!d.ContainsKey(2))
                d.Add(2, "Kashyap");
                
            Console.ReadKey();
        }
    }
}
