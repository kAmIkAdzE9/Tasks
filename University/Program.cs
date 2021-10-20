using System;
using InternshipTest.Person;
using InternshipTest.Institution;
using InternshipTest.Institution.InterLink;
using System.Collections.Generic;

namespace InternshipTest
{
    class Program
    {
        static void PrintStudent(List<Student> students) {
            foreach(Student student in students) {
                Console.WriteLine($"{student.GetStudentName()} Knowledge: {student.GetKnowledge().GetLevel()}");
            }
        }

        static void Main(string[] args)
        {
            University university = new University("CH.U.I.");
            university.AddStudent(new Student("Andrew Kostenko", new Knowledge(4)));
            university.AddStudent(new Student("Julia Veselkina", new Knowledge(5)));
            university.AddStudent(new Student("Maria Perechrest", new Knowledge(2)));          

            Internship internship = new Internship("Interlink");
            internship.AddStudents(university);

            Console.WriteLine("List of internship's students:");
            PrintStudent(internship.GetStudents());
        }
    }
}
