using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using TaskManager_Ostanin.Classes;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager_Ostanin.Models
{
    public class Tasks : Notification
    {
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,50}$");
                if (!match.Success)
                    MessageBox.Show("Ошибка при вводе - подумай ещё! (а еще не более 50 символов)", "Ошибка");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string priority;
        public string Priority
        {
            get { return priority; }
            set
            {
                Match match = Regex.Match(value, "^.{1,30}$");
                if (!match.Success)
                    MessageBox.Show("Ошибка при вводе - подумай ещё! (а еще не более 30 символов)", "Ошибка");
                else
                {
                    priority = value;
                    OnPropertyChanged("Priority");
                }
            }
        }

        private DateTime dateExecute;
        public DateTime DateExecute
        {
            get { return dateExecute; }
            set
            {
                if (value.Date < DateTime.Now.Date)
                    MessageBox.Show("Дата меньше текущей?", "Ошибка");
                else
                {
                    dateExecute = value;
                    OnPropertyChanged("DateExecute");
                }
            }
        }

        private string comment;
        public string Comment
        {
            get { return comment; }
            set
            {
                Match match = Regex.Match(value, "^.{1,1000}$");
                if (!match.Success)
                    MessageBox.Show("Ошибка при вводе - подумай ещё! (1000 символов строчи)", "Ошибка");
                else
                {
                    comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }

        public bool done;
        public bool Done
        {
            get { return done; }
            set
            {
                done = value;
                OnPropertyChanged("Done");
                OnPropertyChanged("IsDoneText");

            }
        }

        [Schema.NotMapped]
        private bool isEnable;
        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }
        [Schema.NotMapped]
        public string IsEnableText
        {
            get
            {
                if (IsEnable) return "Сохранить";
                else return "Изменить";
            }
        }
        [Schema.NotMapped]
        public string IsDoneText
        {
            get
            {
                if (Done) return "Не выполнено";
                else return "Выполенено";
            }
        }
        [Schema.NotMapped]
        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    IsEnable = !IsEnable;
                    if (!IsEnable)
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                });
            }
        }
        [Schema.NotMapped]
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Мы это удаляем?", "Хорошо", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.Tasks.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_tasks.tasksContext.SaveChanges();
                    }
                });
            }
        }
        [Schema.NotMapped]
        public RelayCommand OnDone
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Done = !Done;
                });
            }
        }
    }
}
