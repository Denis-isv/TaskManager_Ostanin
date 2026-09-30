using System;
using System.Collections.ObjectModel;
using System.Linq;
using TaskManager_Ostanin.Classes;
using TaskManager_Ostanin.Context;
using TaskManager_Ostanin.Models;

namespace TaskManager_Ostanin.ViewModels
{
    public class VM_Tasks : Notification
    {
        public TasksContext tasksContext = new TasksContext();
        public ObservableCollection<Tasks> Tasks { get; set; }
        public VM_Tasks() => Tasks = new ObservableCollection<Tasks>(tasksContext.Tasks.OrderBy(x => x.Done));
        public RelayCommand OnAddTask
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Tasks NewTask = new Tasks()
                    {
                        Name = "Напиши что то",
                        Priority = "Высокая",
                        DateExecute = DateTime.Now,
                        Comment = "Давай давай",
                        Done = false,
                        IsEnable = true
                    };
                    Tasks.Add(NewTask);
                    tasksContext.Tasks.Add(NewTask);
                    tasksContext.SaveChanges();
                });
            }
        }
    }
}
