using PayrollSystemCsharp.Entities;

namespace PayrollSystemCsharp.Services
{
    internal class CLTSalaryService : ISalaryService
    {
        private double Tax = 0.10;

        public double CalculateGrossSalary(Employee e)
        {
            EmployeeCLT employeeCLT = (EmployeeCLT)e;

            double grossSalary =
                employeeCLT.BaseSalary +
                employeeCLT.FoodVoucher +
                employeeCLT.TransportVoucher;

            return grossSalary;
        }

        public double CalculateTax(double grossSalary)
        {
            double tax = grossSalary * Tax;
            return tax;
        }

        public double CalculateNetSalary(double grossSalary, double taxSalary)
        {
            double netSalary = grossSalary - taxSalary;
            return netSalary;
        }
    }
}