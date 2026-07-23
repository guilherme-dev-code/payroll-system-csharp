# Payroll System

A payroll management system developed in C# using Object-Oriented Programming concepts.

## About the Project

This project simulates a payroll system capable of registering employees, searching them by CPF, and calculating payroll information according to the employee category.

The system supports different employee types and applies specific business rules for each one.

## Features

- Employee registration
- Employee search by CPF
- Payroll processing
- Gross salary calculation
- Tax calculation
- Net salary calculation
- Employee management

## Employee Categories

### CLT

- Base Salary
- Food Voucher
- Transport Voucher
- 10% Tax

### PJ

- Value Per Hour
- Hours Worked
- 5% Tax

### Manager

- Base Salary
- Management Bonus
- 15% Tax

## Concepts Applied

- Object-Oriented Programming (OOP)
- Encapsulation
- Inheritance
- Polymorphism
- Interfaces
- Dependency Injection
- Custom Exceptions
- Service Layer
- Collections (`List<T>`)
- Business Rules

## Project Structure

```text
Entities
│
├── Employee
├── EmployeeCLT
├── EmployeePJ
├── Manager
└── EmployeesManagement

Services
│
├── ISalaryService
├── CLTSalaryService
├── PJSalaryService
├── ManagerSalaryService
└── PayRollService

Exceptions

Enums
```

## Example

Employee:

```text
Name: John Smith
CPF: 12345678901
Department: INFORMATION_TECHNOLOGY
Category: CLT
```

Payroll Result:

```text
Gross Salary: 6100.00

Tax Salary: 610.00

Net Salary: 5490.00
```
## 📸 Screenshots

### Employee Registration

![Employee Registration](employee-registration.png.png)

---

### Employee List

![Employee List](employee-list.png.png)

---

### Payroll Processing

![Payroll Processing](payroll-processing.png.png)

## Author

Guilherme Da Silva Ribeiro

Systems Analyst Junior
