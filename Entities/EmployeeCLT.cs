using System.Globalization;
using PayrollSystemCsharp.Entities.Enum;
using PayrollSystemCsharp.Entities.Exceptions;

namespace PayrollSystemCsharp.Entities
{
    internal class EmployeeCLT : Employee
    {
        public double BaseSalary { get; private set; }

        public double FoodVoucher { get; private set; }

        public double TransportVoucher { get; private set; }

        public EmployeeCLT() { }

        public EmployeeCLT(string name, string cpf, Department department, double baseSalary, double foodVoucher, double transportVoucher) : base (name, cpf, department)
        {
            if(baseSalary < 1650.00)
            {
                throw new EmployeeCLTException("Salary not in line with minimum wage (R$1650.00)");
            }

            if(foodVoucher < 500.00)
            {
                throw new EmployeeCLTException("Meal allowance not compatible with the minimum expected (R$500.00");
            }

            if(transportVoucher < 0.00)
            {
                throw new EmployeeCLTException("The transportation voucher needs to be above zero!");
            }

            BaseSalary = baseSalary;
            FoodVoucher = foodVoucher;
            TransportVoucher = transportVoucher;
        }

        public void AlterBaseSalary(double newSalary)
        {
            BaseSalary = newSalary;
        }

        public void AlterFoodVoucher(double foodVoucher)
        {
            FoodVoucher = foodVoucher;
        }

        public void AlterTranpsortVoucher(double transportVoucher)
        {
            TransportVoucher = transportVoucher;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n\nBase Salary: {BaseSalary.ToString("F2", CultureInfo.InvariantCulture)}\nFood Voucher: {FoodVoucher.ToString("F2", CultureInfo.InvariantCulture)}\nTransport Voucher: {TransportVoucher.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
