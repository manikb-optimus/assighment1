using ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentPersister
    {
        private static List<Student> students;

        public List<Student> GetStudents()
        {
            if (students == null)
                LoadStudents();
            return students;
        }

        public void DeleteStudent(Student student)
        {
            students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            Student studentToUpdate = students.Where(c => c.StudentId == student.StudentId).FirstOrDefault();
            if (studentToUpdate == null)
            {
                students.Add(student);
                return;
            }
            studentToUpdate = student;
        }

        private void LoadStudents()
        {
            students = new List<Student>()
            {
                new Student ()
                {
                    StudentId = 1,
                    StudentName = "Ram",
                    ContactNumber = "9213509685",
                    DateOfBirth = DateTime.Today,
                    EmailAddress="jnkfd@gmail.com",
                },
                new Student ()
                {
                    StudentId = 2,
                    StudentName = "Shyam",
                    ContactNumber = "thfhfggfhghg",
                    DateOfBirth = DateTime.Today,
                    EmailAddress="thf",
                },
                new Student ()
                {
                    StudentId = 3,
                    StudentName = "Karan",
                    ContactNumber = "thfhfggfhghg",
                    DateOfBirth = DateTime.Today,
                    EmailAddress="thf",
                },
                new Student ()
                {
                    StudentId = 4,
                    StudentName = "Arjun",
                    ContactNumber = "thfhfggfhghg",
                    DateOfBirth = DateTime.Today,
                    EmailAddress="thf",
                },
                new Student ()
                {
                    StudentId = 5,
                    StudentName = "Karan ABC",
                    ContactNumber = "thfhfggfhghg",
                    DateOfBirth = DateTime.Today,
                    EmailAddress="thf",
                },
                new Student ()
                {
                    StudentId = 8,
                    StudentName = "Karan ABCd",
                    ContactNumber = "thfhfggfhghg",
                    DateOfBirth = DateTime.Today,
                    EmailAddress="thf",
                },
                new Student ()
                {
                    StudentId = 6,
                    StudentName = "Karan Afdthg",
                    ContactNumber = "thfhfggfhghg",
                    DateOfBirth = DateTime.Today,
                    EmailAddress="thf",
                },
                new Student ()
                {
                    StudentId = 7,
                    StudentName = "Karan Afdthu",
                    ContactNumber = "thfhfggfhghg",
                    DateOfBirth = DateTime.Today,
                    EmailAddress="thf",
                }
            };
        }

    }
}
