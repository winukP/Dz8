using D.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using D.Enums;


namespace D
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Task Manager ===\n");
            var team = new List<Person>
            {
                new Person("Анна", "Тимлид"),
                new Person("Петр", "Дизайнер"),
                new Person("Мария", "Программист"),
                new Person("Иван", "Программист"),
                new Person("Ольга", "Тестировщик"),
                new Person("Сергей", "Программист"),
                new Person("Елена", "Дизайнер"),
                new Person("Дмитрий", "Аналитик"),
                new Person("Наталья", "Тестировщик"),
                new Person("Алексей", "Технический писатель")
            };
            var project = new Project("Разработка приложения", team[0]);
            Console.WriteLine($"Создан проект: {project.Name}");

            project.AddTask("Дизайн", team[1], DateTime.Now.AddDays(5));
            project.AddTask("Программирование", team[2], DateTime.Now.AddDays(10));
            project.AddTask("Тестирование", team[4], DateTime.Now.AddDays(15));
            project.AddTask("Документация", team[9], DateTime.Now.AddDays(20));
            Console.WriteLine($"Добавлено задач: {project.Tasks.Count}");

            project.Start();
            Console.WriteLine($"Проект запущен: {project.Status}");

            Console.WriteLine("\nЗадачи проекта:");
            foreach (var task in project.Tasks)
            {
                Console.WriteLine($"- {task.Name}");
                Console.WriteLine($"  Срок: {task.Deadline:dd.MM.yyyy}");
                Console.WriteLine($"  Исполнитель: {task.Executor.Name}");
                Console.WriteLine($"  Статус: {task.Status}");
            }
            Console.WriteLine("\nРабота с задачами:");
            foreach (var task in project.Tasks)
            {
                task.StartWork();
                task.Complete();
                Console.WriteLine($"- {task.Name} -> {task.Status}");
            }
            project.Close();
            Console.WriteLine($"\nПроект завершен: {project.Status}");

            Console.WriteLine("\nСтатистика:");
            Console.WriteLine($"Всего задач: {project.Tasks.Count}");
            Console.WriteLine($"Выполнено: {project.Tasks.Count(t => t.IsDone)}");

            Console.WriteLine("\nИсполнители:");
            foreach (var task in project.Tasks)
            {
                Console.WriteLine($"- {task.Executor.Name} ({task.Executor.Role}): {task.Name}");
            }
            var overdue = project.GetOverdueTasks();
            if (overdue.Count > 0)
            {
                Console.WriteLine($"\nПросроченные задачи: {overdue.Count}");
            }
        }
    }   
}
