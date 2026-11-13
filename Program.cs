using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Введите имя файла: ");
        string name = Console.ReadLine();

        
        if (!File.Exists(name))
        {
            Console.WriteLine("Файл \"" + name + "\" не найден. Программа завершена.");
            return;
        }

        
        string text = File.ReadAllText(name);
        string upper = text.ToUpper();

        
        string outputName = "output.txt";
        File.WriteAllText(outputName, upper);

        Console.WriteLine("Готово. Результат записан в файл: " + Path.GetFullPath(outputName));
    }
}