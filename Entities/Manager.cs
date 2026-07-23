using System.Globalization;
using PayrollSystemCsharp.Entities.Enum;
using PayrollSystemCsharp.Entities.Exceptions;

namespace PayrollSystemCsharp.Entities
{
    internal class Manager : Employee
    {
        public double BaseSalary { get; private set; }
        public double BonusMng { get; set; }

        public Manager() { }

        public Manager (string name, string cpf, Department department, double baseSalary, double bonusMng) : base(name, cpf, department)
        {
            if(baseSalary < 6000.00)
            {
                throw new ManagerException("The stated value is not compatible with the minimum wage for the position (R$6000.00)");
            }

            if(bonusMng < 0.0)
            {
                throw new ManagerException("The bonus cannot be below zero!");
            }

            BaseSalary = baseSalary;
            BonusMng = bonusMng;
        }

        public void AlterBaseSalary(double newSalary)
        {
            BaseSalary = newSalary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n\nBase salary: {BaseSalary.ToString("F2", CultureInfo.InvariantCulture)}\nBonus managment: {BonusMng.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
