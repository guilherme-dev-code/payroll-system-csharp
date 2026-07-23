using System.Globalization;
using PayrollSystemCsharp.Entities.Enum;
using PayrollSystemCsharp.Entities.Exceptions;

namespace PayrollSystemCsharp.Entities
{
    internal class EmployeePJ : Employee
    {
        public double ValuePerHour { get; private set; }
        public int HoursWorked { get; set; }

        public EmployeePJ() { }

        public EmployeePJ(string name, string cpf, Department department, double valuePerHour, int hoursWorked) : base (name, cpf, department)
        {
            if(valuePerHour < 20.00)
            {
                throw new EmployeePJException("The hourly rate does not meet the base value (R$20.00)");
            }

            if(hoursWorked <= 0)
            {
                throw new EmployeePJException("The number of hours worked must be above zero!");
            }

            ValuePerHour = valuePerHour;
            HoursWorked = hoursWorked;
        }

        public void AlterValuePerHour(double newValue)
        {
            ValuePerHour = newValue;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n\nValue per hour: {ValuePerHour.ToString("F2", CultureInfo.InvariantCulture)}\nHours worked: {HoursWorked}";
        }
    }
}
