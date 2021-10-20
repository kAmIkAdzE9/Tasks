using InternshipTest.Person;
using System.Collections.Generic;
using System;

namespace InternshipTest.Institution
{
    class University
    {
        string name;
        int sumOfMarks;
        double middleMark;
        List<Student> students;
        
        public string GetName() {
            return name;
        }

        public double GetMiddleMark() {
            return middleMark;
        }

        public List<Student> GetStudents() {
            return students;
        }

        public University(string name)
        {
            this.name = name; 
            students = new List<Student>();
            sumOfMarks = 0;
            middleMark = 0;
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
            sumOfMarks += student.GetKnowledge().GetLevel();
            UpdateMiddleMark();
        }

        private void UpdateMiddleMark() {
            middleMark = Convert.ToDouble(sumOfMarks) / students.Count;
        }
    }
}
