using System.Collections.Generic;
using InternshipTest.Person;
using System;

namespace InternshipTest.Institution.InterLink
{
    class Internship
    {
        string name;
        List<Student> students;

        public string GetName()
        {
            return name;
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public Internship(string name)
        {
            this.name = name;
            students = new List<Student>();
        }

        public void AddStudents(University university)
        {
            List<Student> university_students = university.GetStudents();
            double middlemark = university.GetMiddleMark();
            foreach (Student student in university_students)
            {
                if (student.GetKnowledge().GetLevel() > middlemark)
                {
                    students.Add(student);
                }
            }
        }
    }
}
