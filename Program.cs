using System.Globalization;
using PayrollSystemCsharp.Entities;
using PayrollSystemCsharp.Entities.Enum;
using PayrollSystemCsharp.Entities.Exceptions;
using PayrollSystemCsharp.Services;

namespace PayrollSystemCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("PAYROLL");
                Console.WriteLine();

                //instantiating the employee and the list of employees:
                Employee employee = new Employee();
                EmployeesManagement listEmployees = new EmployeesManagement();

                Console.Write("Please specify how many employees will be registered: ");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"EMPLOYEE REGISTRATION #{i + 1}");
                    employee = EmployeeRegistration();

                    //adding the employee tot he employee list:
                    listEmployees.AddEmployee(employee);
                }

                Console.WriteLine();
                Console.WriteLine("LIST OF EMPLOYEE:");
                listEmployees.ListingEmployee();
                Console.WriteLine();

                bool validatingSalaryEmployee = true;

                while (validatingSalaryEmployee)
                {
                    Console.Write("Are you looking for an employee to perform a salary verification? (Y/N)");
                    char validatingSearch = char.Parse(Console.ReadLine().Trim().ToUpper());

                    if (validatingSearch == 'N')
                    {
                        Console.WriteLine("Thank you for using the payroll system.");
                        validatingSalaryEmployee = false;
                        break;
                    }
                    else if (validatingSearch == 'Y')
                    {
                        Console.Write("Write the supplier's CPF (Brazilian tax identification number): ");
                        string cpfSearch = Console.ReadLine().Trim().ToUpper();
                        employee = listEmployees.FindEmployee(cpfSearch);

                        ISalaryService salaryService = null;

                        if (employee is EmployeeCLT)
                        {
                            salaryService = new CLTSalaryService();
                        }
                        else if (employee is EmployeePJ)
                        {
                            salaryService = new PJSalaryService();
                        }
                        else if (employee is Manager)
                        {
                            salaryService = new ManagerSalaryService();
                        }

                        PayRollService payRoll = new PayRollService(salaryService);

                        payRoll.ProcessPayroll(employee);
                    }
                    else
                    {
                        Console.WriteLine("Write an acceptable value, either Y or N");
                    }
                }
            }
            catch (EmployeeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (EmployeeCLTException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (EmployeePJException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ManagerException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (EmployeesManagementException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static Employee EmployeeRegistration()
        {
            try
            {
                Employee employee = new Employee();

                Console.WriteLine();

                Console.Write("Name: ");
                string nameEmployee = Console.ReadLine().Trim().ToUpper();

                Console.Write("CPF: ");
                string cpfEmployee = Console.ReadLine().Trim().ToUpper();

                Console.Write("Department: ");
                string departmentEmployee = Console.ReadLine().Trim().ToUpper();

                //Converting to Enum:

                bool success = Enum.TryParse<Department>(departmentEmployee, true, out Department department);
                Console.WriteLine();

                if (!success)
                {
                    throw new EmployeeException("Invalid department!");
                }

                employee = new Employee(nameEmployee, cpfEmployee, department);

                Console.Write("Specify category of employee (CLT/ PJ/ MANAGER): ");
                string categoryEmployee = Console.ReadLine().Trim().ToUpper();
                Console.WriteLine();

                employee = EmployeeCategory(employee, categoryEmployee);

                return employee;
            }
            catch (EmployeeException e)
            {
                throw;
            }
        }

        private static Employee EmployeeCategory(Employee employee, string category)
        {
            try
            {

                if (category == "CLT")
                {
                    Console.Write("Base salary: ");
                    double baseSalary = double.Parse(Console.ReadLine().Trim(), CultureInfo.InvariantCulture);

                    Console.Write("Food Voucher: ");
                    double foodVoucher = double.Parse(Console.ReadLine().Trim(), CultureInfo.InvariantCulture);

                    Console.Write("Transport voucher: ");
                    double transportVoucher = double.Parse(Console.ReadLine().Trim(), CultureInfo.InvariantCulture);

                    employee = new EmployeeCLT(employee.Name, employee.CPF, employee.Department, baseSalary, foodVoucher, transportVoucher);

                }
                else if (category == "PJ")
                {
                    Console.Write("Value per hour: ");
                    double valuePerHour = double.Parse(Console.ReadLine().Trim(), CultureInfo.InvariantCulture);

                    Console.Write("Hours worked: ");
                    int hoursWorked = int.Parse(Console.ReadLine().Trim());

                    employee = new EmployeePJ(employee.Name, employee.CPF, employee.Department, valuePerHour, hoursWorked);
                }
                else if (category == "MANAGER")
                {
                    double bonus = 0.0;

                    Console.Write("Base salary: ");
                    double baseSalaryManager = double.Parse(Console.ReadLine().Trim(), CultureInfo.InvariantCulture);

                    Console.Write("Will the employee receive a bonus? (Y/N): ");
                    char validatingBonus = char.Parse(Console.ReadLine().Trim().ToUpper());

                    if (validatingBonus == 'Y')
                    {
                        Console.Write("Please state the bonus amount: ");
                        bonus = double.Parse(Console.ReadLine().Trim(), CultureInfo.InvariantCulture);
                    }

                    employee = new Manager(employee.Name, employee.CPF, employee.Department, baseSalaryManager, bonus);
                }
                else
                {
                    throw new EmployeeException("Invalid employee category!\nCategory must be CLT, PJ or MANAGER");
                }

                return employee;
            }
            catch (EmployeeCLTException e)
            {
                throw;
            }
            catch (EmployeePJException e)
            {
                throw;
            }
            catch (ManagerException m)
            {
                throw;
            }
        }
    }
}
