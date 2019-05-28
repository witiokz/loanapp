using LoanApp.Services;
using System;

namespace LoanApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var loanService = new LoanService();

            double.TryParse(args[0], out double loanAmount);
            double.TryParse(args[1], out double interestRate);
            int.TryParse(args[2], out int loanTermMonths);

            var monthlyPay = loanService.CalculateMonthlyPayment(loanAmount, interestRate, loanTermMonths);

            for (int i = 0; i < loanTermMonths; i++)
            {
                Console.WriteLine("Date: {0}", DateTime.Now.AddMonths(i + 1));
                Console.WriteLine("Monthly Payment: {0} €", monthlyPay);
                Console.WriteLine();
            }

            var arp = loanService.CalculateAnnualPercentageRates(loanAmount, (double)monthlyPay, loanTermMonths);

            Console.WriteLine("APR: {0}", arp);

            Console.ReadKey();
        }

    }
}
