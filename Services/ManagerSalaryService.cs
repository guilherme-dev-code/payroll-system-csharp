using PayrollSystemCsharp.Entities;

namespace PayrollSystemCsharp.Services
{
    internal class ManagerSalaryService : ISalaryService
    {
        private double Tax = 0.15;

        public double CalculateGrossSalary(Employee e)
        {
            Manager manager = (Manager)e;

            double grossSalary = manager.BaseSalary;

            if (manager.BonusMng > 0.0)
            {
                grossSalary =
                    manager.BaseSalary +
                    manager.BonusMng;
            }

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