using System;
using System.Globalization;
using PayrollSystemCsharp.Entities;

namespace PayrollSystemCsharp.Services
{
    internal class PayRollService
    {
        private ISalaryService _salaryService { get; }

        public PayRollService(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        public void ProcessPayroll(Employee e)
        {
            double grossSalary = _salaryService.CalculateGrossSalary(e);

            double taxSalary = _salaryService.CalculateTax(grossSalary);

            double netSalary = _salaryService.CalculateNetSalary(
                grossSalary,
                taxSalary
            );

            Console.WriteLine();
            Console.WriteLine("PAYROLL");
            Console.WriteLine();

            Console.WriteLine($"Name: {e.Name}");
            Console.WriteLine($"CPF: {e.CPF}");
            Console.WriteLine($"Department: {e.Department}");
            Console.WriteLine();

            Console.WriteLine($"Gross Salary: {grossSalary.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Tax Salary: {taxSalary.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Net Salary: {netSalary.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine();
        }
    }
}