using PayrollSystemCsharp.Entities.Exceptions;

namespace PayrollSystemCsharp.Entities
{
    internal class EmployeesManagement
    {
        public List<Employee> ListEmployee = new List<Employee>();

        public EmployeesManagement() { }

        public EmployeesManagement(List<Employee> listEmployee)
        {
            if(listEmployee.Count <= 0)
            {
                throw new EmployeesManagementException("The list is empty!");
            }
            ListEmployee = listEmployee;
        }

        public void AddEmployee(Employee employee)
        {
            ListEmployee.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            ListEmployee.Remove(employee);
        }

        public void ListingEmployee()
        {
            foreach(Employee e in ListEmployee)
            {
                Console.WriteLine($"Employee: {e}");
            }
        }

        public Employee FindEmployee(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
            {
                throw new EmployeesManagementException("Check the format of the CPF (Brazilian taxpayer ID) entered.\nIs must have 11 digits.");
            }

            Employee employee = ListEmployee.Find(x => x.CPF == cpf);

            if(employee == null)
            {
                throw new EmployeeException("The employee not found!");
            }

            return employee;
        }
    }
}
