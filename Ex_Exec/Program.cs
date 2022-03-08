using System;
using Ex_Exec.Entities;
using Ex_Exec.Entities.Exceptions;
using System.Globalization;

namespace Ex_Exec
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter account data");
            Console.WriteLine();

            Console.Write("Number: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Holder: ");
            string name = Console.ReadLine();

            Console.Write("Initial balance: ");
            double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Withdraw limit: ");
            double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Accont accont = new Accont(id, name, balance, limit);

            Console.WriteLine();

            Console.Write("Enter amount for withdraw: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);


            try
            {
                accont.Withdraw(amount);
                Console.WriteLine(accont);
            }

            catch (DomainException e)
            {
                Console.WriteLine("Withdraw error: " + e.Message);
            }

            catch (FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}   