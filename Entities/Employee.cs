using PayrollSystemCsharp.Entities.Enum;
using PayrollSystemCsharp.Entities.Exceptions;

namespace PayrollSystemCsharp.Entities
{
    internal class Employee
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public Department Department { get; set; }

        public Employee() { }

        public Employee (string name, string cpf, Department department)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new EmployeeException("Name is required!");
            }

            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new EmployeeException("CPF is required!");
            }

            if(cpf.Length != 11)
            {
                throw new EmployeeException("CPF invalid!\nNeed 11 digits");
            }

            Name = name;
            CPF = cpf;
            Department = department;
        }

        public void AlterDepartment(Department department)
        {
            Department = department;
        }

        public override string ToString()
        {
            return $"EMPLOYEE DATA\n\nName: {Name}\nCPF: {CPF}\nDeparment: {Department}";
        }
    }
}
