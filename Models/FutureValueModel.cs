// Jeremy Brannen
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Chapter02FutureValueBrannen.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Plese enter a monthly investment.")]
        [Range(1,1000, ErrorMessage = "Monthly investment amount must be between 1 and 1000.")]
        public decimal? MonthlyInvestment { get; set; }

        [Required(ErrorMessage = "Please enter a yearly interest rate.")]
        [Range(0.1, 10.0,  ErrorMessage = "Yearly interest rate much be between 0.1 and 10.0")]
        public decimal? YearlyInterestRate { get; set; }

        [Required(ErrorMessage = "Please enter a number of years.")]
        [Range(1, 50, ErrorMessage = "Number of years must be between 1 and 50.")]
        public int? Years { get; set; }

        public decimal? CalculateFutureValue()
        {
            int? months = Years * 12;
            decimal? monthlyInterestRate = YearlyInterestRate.Value / 12 / 100;
            decimal? futureValue = 0;
            for( int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment.Value) *
                    (1 + monthlyInterestRate);
            }
            return futureValue;
        }

    }
}
