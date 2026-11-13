using System;
using System.Collections.Generic;

enum Group
{
    Director,
    Accounting,
    Management,
    Systems,
    Developers
}

class Employee
{
    public string Name { get; set; }
    public Group Group { get; set; }
    private List<Employee> bosses = new List<Employee>();

    public Employee(string name, Group group)
    {
        Name = name;
        Group = group;
    }

    public void AddBoss(Employee boss)
    {
        bosses.Add(boss);
    }

    public bool IsDirectBoss(Employee other)
    {
        return bosses.Contains(other);
    }

    public bool TakesTask(Employee from, WorkTask task)
    {
        if (!IsDirectBoss(from))
        {
            return false;
        }
        return task.Target == Group;
    }
}

class WorkTask
{
    public string Title { get; set; }
    public Group Target { get; set; }

    public WorkTask(string title, Group target)
    {
        Title = title;
        Target = target;
    }
}

class Program
{
    static void Assign(Employee from, Employee to, WorkTask task)
    {
        Console.Write("От " + from.Name + " задача \"" + task.Title + "\" -> " + to.Name + ": ");

        if (!to.IsDirectBoss(from))
        {
            Console.WriteLine("НЕ берет (" + from.Name + " не прямой руководитель)");
        }
        else if (task.Target != to.Group)
        {
            Console.WriteLine("НЕ берет (задача не для его группы)");
        }
        else
        {
            Console.WriteLine("берет");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Employee timur = new Employee("Тимур", Group.Director);

        Employee rashid = new Employee("Рашид", Group.Accounting);
        Employee ilham = new Employee("Ильхам", Group.Management);
        rashid.AddBoss(timur);
        ilham.AddBoss(timur);

        Employee lukas = new Employee("Лукас", Group.Accounting);
        lukas.AddBoss(rashid);

        Employee orkadiy = new Employee("Оркадий", Group.Management);
        Employee volodya = new Employee("Володя", Group.Management);
        orkadiy.AddBoss(ilham);
        volodya.AddBoss(orkadiy);

        Employee ilshat = new Employee("Ильшат", Group.Systems);
        Employee ivanych = new Employee("Иваныч", Group.Systems);
        Employee ilya = new Employee("Илья", Group.Systems);
        Employee vitya = new Employee("Витя", Group.Systems);
        Employee zhenya = new Employee("Женя", Group.Systems);
        ilshat.AddBoss(orkadiy);
        ilshat.AddBoss(volodya);
        ivanych.AddBoss(ilshat);
        ilya.AddBoss(ivanych);
        vitya.AddBoss(ivanych);
        zhenya.AddBoss(ivanych);

        Employee sergey = new Employee("Сергей", Group.Developers);
        Employee lyaysan = new Employee("Ляйсан", Group.Developers);
        Employee marat = new Employee("Марат", Group.Developers);
        Employee dina = new Employee("Дина", Group.Developers);
        Employee ildar = new Employee("Ильдар", Group.Developers);
        Employee anton = new Employee("Антон", Group.Developers);
        sergey.AddBoss(orkadiy);
        sergey.AddBoss(volodya);
        lyaysan.AddBoss(sergey);
        marat.AddBoss(lyaysan);
        dina.AddBoss(lyaysan);
        ildar.AddBoss(lyaysan);
        anton.AddBoss(lyaysan);

        WorkTask t1 = new WorkTask("Автоматизировать отчет бухгалтерии", Group.Developers);
        WorkTask t2 = new WorkTask("Настроить сеть в офисе", Group.Systems);
        WorkTask t3 = new WorkTask("Утвердить план автоматизации", Group.Management);

        Console.WriteLine("=== Распределение задач ===");
        Console.WriteLine();

        Assign(ilham, orkadiy, t3);
        Assign(orkadiy, sergey, t1);
        Assign(sergey, lyaysan, t1);
        Assign(lyaysan, dina, t1);
        Assign(lyaysan, marat, t1);
        Assign(timur, dina, t1);
        Assign(sergey, marat, t1);

        Console.WriteLine();
        Assign(orkadiy, ilshat, t2);
        Assign(ilshat, ivanych, t2);
        Assign(ivanych, ilya, t2);
        Assign(ivanych, dina, t2);
        Assign(ivanych, vitya, t1);
        Assign(lyaysan, ilya, t2);

        Console.WriteLine();
        Assign(rashid, lukas, t3);
    }
}