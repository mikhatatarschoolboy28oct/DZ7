using System;
using System.Collections.Generic;
using System.IO;

class MailParser
{
        public void SearchMail(ref string s)
    {
        int pos = s.IndexOf('#');
        if (pos == -1)
        {
            s = "";
        }
        else
        {
            s = s.Substring(pos + 1).Trim();
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введите имя входного файла: ");
        string inputName = Console.ReadLine();

        if (!File.Exists(inputName))
        {
            Console.WriteLine("Файл \"" + inputName + "\" не найден. Программа завершена.");
            return;
        }

        MailParser parser = new MailParser();
        string[] lines = File.ReadAllLines(inputName);
        List<string> emails = new List<string>();

        foreach (string line in lines)
        {
            string s = line;
            parser.SearchMail(ref s);

            if (s != "")
            {
                emails.Add(s);
            }
        }

        string outputName = "emails.txt";
        File.WriteAllLines(outputName, emails);

        Console.WriteLine("Найдено адресов: " + emails.Count);
        Console.WriteLine("Список сохранен в файл: " + Path.GetFullPath(outputName));
    }
}