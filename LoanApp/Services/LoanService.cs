using System;

namespace LoanApp.Services
{
    class LoanService
    {
        /// <summary>
        public decimal CalculateMonthlyPayment(double loanAmount, double interestRate, double loanTermMonths)
        {
            var rate = interestRate / 12 / 100;

            var denominator = Math.Pow((1 + rate), loanTermMonths) - 1;
            var factor = rate + (rate / denominator);
            var payment = (loanAmount * factor);

            return (decimal)Math.Round(payment, 2);
        }

        public double CalculateAnnualPercentageRates(double loanAmount, double paymentAmount, double numberOfPayments)
        {
            double deposit = 0;
            double p = loanAmount;
            double a = paymentAmount;
            double n = numberOfPayments;
            double r = 1.01;
            double pp = (p - deposit);
            double rnew = 0;
            double q = 0;

            while (Math.Abs(r - rnew) > 0.0000001)
            {
                double rn = Math.Pow(r, n);
                double rnm1 = rn / r;
                double fac = (pp * rn - q) * (1 - r) / (1 - rn) - a;
                double facdash = (n * pp * rnm1 * (1 - r) - (pp * rn - q)) / (1 - rn) + (pp * rn - q) * (1 - r) * n * rnm1 / ((1 - rn) * (1 - rn));
                rnew = r - fac / facdash;
                r = rnew;
            }
            double r12 = Math.Pow(r, 12);
            double apr = 0.01 * Math.Round((r12 - 1) * 100 * 100);
            return apr;
        }
    }
}


