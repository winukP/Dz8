using System;
using D.Enums;

namespace D.Classes
{
    public class Task
    {
        public string Name { get; set; }
        public Person Executor { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedDate { get; set; }
        public Task(string name, Person executor, DateTime deadline)
        {
            Name = name;
            Executor = executor;
            Status = TaskStatus.Назначена;
            Deadline = deadline;
            CreatedDate = DateTime.Now;
        }
        public void StartWork()
        {
            Status = TaskStatus.ВРаботе;
        }
        public void Complete()
        {
            Status = TaskStatus.Выполнена;
        }
        public bool IsDone
        {
            get { return Status == TaskStatus.Выполнена; }
        }
        public bool IsOverdue
        {
            get { return DateTime.Now > Deadline && !IsDone; }
        }
    }
}
