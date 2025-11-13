using System;
using System.Collections.Generic;
using System.Linq;
using D.Enums;

namespace D.Classes
{
    public class Project
    {
        public string Name { get; set; }
        public Person TeamLead { get; set; }
        public List<Task> Tasks { get; set; }
        public ProjectStatus Status { get; set; }
        public Project(string name, Person teamLead)
        {
            Name = name;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            Status = ProjectStatus.Проект;
        }
        public void AddTask(string taskName, Person executor, DateTime deadline)
        {
            if (Status == ProjectStatus.Проект)
            {
                Tasks.Add(new Task(taskName, executor, deadline));
            }
        }
        public void Start()
        {
            Status = ProjectStatus.Исполнение;
        }
        public void Close()
        {
            if (Tasks.All(t => t.IsDone))
            {
                Status = ProjectStatus.Закрыт;
            }
        }
        public List<Task> GetOverdueTasks()
        {
            return Tasks.Where(t => t.IsOverdue).ToList();
        }
    }

}
