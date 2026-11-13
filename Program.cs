using System;
using System.Collections.Generic;

class Song
{
    private string name;
    private string author;
    private Song prev;

    public void SetName(string value)
    {
        name = value;
    }

    public void SetAuthor(string value)
    {
        author = value;
    }

    public void SetPrev(Song value)
    {
        prev = value;
    }

    public string Title()
    {
        return name + " - " + author;
    }

    public void Print()
    {
        Console.WriteLine("Песня: " + Title());
        if (prev != null)
        {
            Console.WriteLine("  Предыдущая: " + prev.Title());
        }
        else
        {
            Console.WriteLine("  Предыдущей песни нет");
        }
    }

    public override bool Equals(object d)
    {
        Song other = d as Song;
        if (other == null)
        {
            return false;
        }
        return name == other.name && author == other.author;
    }

    public override int GetHashCode()
    {
        return (name + author).GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Song s1 = new Song();
        s1.SetName("Группа крови");
        s1.SetAuthor("Кино");

        Song s2 = new Song();
        s2.SetName("Звезда по имени Солнце");
        s2.SetAuthor("Кино");
        s2.SetPrev(s1);

        Song s3 = new Song();
        s3.SetName("Знаешь ли ты");
        s3.SetAuthor("Ария");
        s3.SetPrev(s2);

        Song s4 = new Song();
        s4.SetName("Группа крови");
        s4.SetAuthor("Кино");
        s4.SetPrev(s3);

        List<Song> list = new List<Song>();
        list.Add(s1);
        list.Add(s2);
        list.Add(s3);
        list.Add(s4);

        Console.WriteLine("=== Список песен ===");
        foreach (Song song in list)
        {
            song.Print();
        }

        Console.WriteLine();
        Console.WriteLine("Первая и вторая песни одинаковые: " + list[0].Equals(list[1]));
        Console.WriteLine("Первая и четвертая песни одинаковые: " + list[0].Equals(list[3]));
    }
}