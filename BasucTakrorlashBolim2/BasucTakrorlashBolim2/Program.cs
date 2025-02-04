using System;
using System.Collections.Generic;

class Program
{
    static List<Task> tasks = new List<Task>();

    class Task
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Vazifalar ro'yxati bo'sh.");
            return;
        }
        Console.WriteLine("\nVazifalar ro'yxati:");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasks[i].Completed ? "✅ Bajarildi" : "❌ Bajarilmagan";
            Console.WriteLine($"{i + 1}. {tasks[i].Title} - {status}");
        }
    }

    static void AddTask(string title)
    {
        tasks.Add(new Task { Title = title, Completed = false });
        Console.WriteLine($"Vazifa qo'shildi: {title}");
    }

    static void RemoveTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            Console.WriteLine($"O'chirildi: {tasks[index].Title}");
            tasks.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Noto'g'ri indeks!");
        }
    }

    static void CompleteTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].Completed = true;
            Console.WriteLine($"Bajarildi: {tasks[index].Title}");
        }
        else
        {
            Console.WriteLine("Noto'g'ri indeks!");
        }
    }

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Vazifa qo'shish\n2. Vazifani o'chirish\n3. Vazifani bajarildi deb belgilash\n4. Vazifalarni ko'rish\n5. Chiqish");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Vazifa nomini kiriting: ");
                string title = Console.ReadLine();
                AddTask(title);
            }
            else if (choice == "2")
            {
                ShowTasks();
                Console.Write("O'chirish uchun vazifa raqamini kiriting: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                RemoveTask(index);
            }
            else if (choice == "3")
            {
                ShowTasks();
                Console.Write("Bajarildi deb belgilash uchun vazifa raqamini kiriting: ");
                int index = int.Parse(Console.ReadLine()) - 1;
                CompleteTask(index);
            }
            else if (choice == "4")
            {
                ShowTasks();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Dasturdan chiqildi.");
                break;
            }
            else
            {
                Console.WriteLine("Noto'g'ri tanlov, qayta urinib ko'ring.");
            }
        }
    }
}
