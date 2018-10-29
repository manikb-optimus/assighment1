using SampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    public class ViewModelLocator
    {

        private static StudentListViewModel studentListViewModel = new StudentListViewModel();
        private static StudentDetailViewModel studentDetailViewModel = new StudentDetailViewModel();

        public static StudentDetailViewModel StudentDetailViewModel
        {
            get
            {
                return studentDetailViewModel;
            }
        }

        public static StudentListViewModel StudentListViewModel
        {
            get
            {
                return studentListViewModel;
            }
        }
    }
}
