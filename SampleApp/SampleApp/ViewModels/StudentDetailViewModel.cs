using DataAccessLayer;
using ModelClasses;
using SampleApp.Messages;
using SampleApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleApp.ViewModels
{
    public class StudentDetailViewModel
    {

        public Student SelectedStudent { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public StudentDetailViewModel()
        {
            SaveCommand = new CustomCommand(SaveStudent, CanSaveStudent);
            DeleteCommand = new CustomCommand(DeleteStudent, CanDeleteStudent);
            Messenger.Default.Register<Student>(this, OnStudentReceived);
        }

        private void OnStudentReceived(Student obj)
        {
            SelectedStudent = obj;
        }

        private bool CanDeleteStudent(object obj)
        {
            return true;
        }

        private void DeleteStudent(object student)
        {
            StudentPersister persister = new StudentPersister();
            persister.DeleteStudent(SelectedStudent);
            Messenger.Default.Send<StudentUpdated>(new StudentUpdated());
        }

        private bool CanSaveStudent(object obj)
        {
            return true;
        }

        private void SaveStudent(object student)
        {
            StudentPersister persister = new StudentPersister();
            persister.UpdateStudent(SelectedStudent);
            Messenger.Default.Send<StudentUpdated>(new StudentUpdated());
        }
    }
}
