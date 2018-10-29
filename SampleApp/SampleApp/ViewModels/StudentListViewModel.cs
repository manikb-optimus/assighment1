using DataAccessLayer;
using ModelClasses;
using SampleApp.ExtensionMethod;
using SampleApp.Messages;
using SampleApp.Utility;
using SampleApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SampleApp.ViewModels
{
    public class StudentListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                RaisePropertyChanged("Students");
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                selectedStudent = value;
                RaisePropertyChanged("SelectedStudent");
            }
        }

        public ICommand EditCommand { get; set; }
        public ICommand CreateCommand { get; set; }

        public StudentListViewModel()
        {
            Messenger.Default.Register<StudentUpdated>(this, OnStudentUpdated);
            EditCommand = new CustomCommand(EditStudent, CanEditStudent);
            CreateCommand = new CustomCommand(CreateStudent, CanCreateStudent);
            LoadData();
        }

        private bool CanCreateStudent(object obj)
        {
            return true;
        }

        private void CreateStudent(object obj)
        {
            Student newStudent = new Student();
            Messenger.Default.Send<Student>(newStudent);
            studentDetailView = new StudentDetail();
            studentDetailView.ShowDialog();
        }

        Window studentDetailView = null;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnStudentUpdated(StudentUpdated obj)
        {
            LoadData();
            studentDetailView.Close();
        }
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void EditStudent(object obj)
        {
            Messenger.Default.Send<Student>(SelectedStudent);
            studentDetailView = new StudentDetail();
            studentDetailView.ShowDialog();
        }

        private bool CanEditStudent(object obj)
        {
            if (SelectedStudent != null)
                return true;
            return false;
        }

        private void LoadData()
        {
            StudentPersister persister = new StudentPersister();
            Students = persister.GetStudents().ToObservableCollection();
        }
    }
}
