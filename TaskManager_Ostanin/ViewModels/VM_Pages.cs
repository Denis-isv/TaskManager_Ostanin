using System;
using System.Collections.Generic;
using System.Text;
using TaskManager_Ostanin.Classes;

namespace TaskManager_Ostanin.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Tasks vm_tasks = new VM_Tasks();
        public VM_Pages()
        {
            MainWindow.init.frame.Navigate(new View.Main(vm_tasks));
        }
        public RelayCommand OnClose
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.Close();
                });
            }
        }
    }
}
