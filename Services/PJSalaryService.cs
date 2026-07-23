using PayrollSystemCsharp.Entities;

namespace PayrollSystemCsharp.Services
{
    internal class PJSalaryService : ISalaryService
    {
        private double Tax = 0.05;

        public double CalculateGrossSalary(Employee e)
        {
            EmployeePJ employeePJ = (EmployeePJ)e;

            double grossSalary =
                employeePJ.ValuePerHour *
                employeePJ.HoursWorked;

            return grossSalary;
        }

        public double CalculateTax(double grossSalary)
        {
            double taxSalary = grossSalary * Tax;
            return taxSalary;
        }

        public double CalculateNetSalary(double grossSalary, double taxSalary)
        {
            double netSalary = grossSalary - taxSalary;
            return netSalary;
        }
    }
}