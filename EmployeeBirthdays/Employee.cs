using System;

namespace EmployeeBirthdays
{
    class Employee
    {
        string name;
        DateTime birthday;

        public string getName() {
            return name;
        }

        public DateTime getBirthday() {
            return birthday;
        }
        
        public Employee(string name, DateTime birthday) {
            this.name = name;
            this.birthday = birthday;
        }
    }
}