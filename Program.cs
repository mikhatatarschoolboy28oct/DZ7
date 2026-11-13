using System;

class Program
{
    
    static bool CheckWithIs(object obj)
    {
        return obj is IFormattable;
    }

    
    static bool CheckWithAs(object obj)
    {
        IFormattable f = obj as IFormattable;
        return f != null;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        object[] tests =
        {
            42,
            3.14,
            12.5m,
            DateTime.Now,
            "строка",
            'a',
            true,
            null,
            new object()
        };

        foreach (object item in tests)
        {
            string shown = item == null ? "null" : item.GetType().Name + " (" + item + ")";
            Console.WriteLine(shown);
            Console.WriteLine("  is: " + CheckWithIs(item) + ", as: " + CheckWithAs(item));
        }

        Console.WriteLine();
        object number = 1234.5678;
        IFormattable formattable = number as IFormattable;
        if (formattable != null)
        {
            Console.WriteLine("Число с форматом F2: " + formattable.ToString("F2", null));
        }
    }
}