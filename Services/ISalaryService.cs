using PayrollSystemCsharp.Entities;

namespace PayrollSystemCsharp.Services
{
    internal interface ISalaryService
    {
        double CalculateGrossSalary(Employee employee);

        double CalculateTax(double grossSalary);

        double CalculateNetSalary(double grossSalary, double taxSalary);
    }
}