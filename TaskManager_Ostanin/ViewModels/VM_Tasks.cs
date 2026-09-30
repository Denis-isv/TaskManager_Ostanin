using System.Collections.ObjectModel;
using TaskManager_Ostanin.Context;
using TaskManager_Ostanin.Models;

namespace TaskManager_Ostanin.ViewModels
{
    public class VM_Tasks 
    {
        public TasksContext tasksContext;
        public ObservableCollection<Tasks> Tasks { get; set; }
    }
}
