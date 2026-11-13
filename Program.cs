using System;

class Program
{
    static string Reverse(string text)
    {
        if(text==null)
        {
            return "";
        }
        string result="";
        for(int i = text.Length - 1; i>=0; i--)
        {
            result += text[i];
        }
        return result;

    }
    static void Main()
    {
        string[] tests={ "привет", "Hello World", "шалаш", "a", "", null };
        foreach(string s in tests)
        {
            string shown = s == null ? "null" : "\"" + s + "\"";
            Console.WriteLine("Исходная: " + shown + " -> перевернутая: \"" + Reverse(s) + "\"");   
        }
        Console.Write("\nВведите свою строку: ");
        string input = Console.ReadLine();
        Console.WriteLine("Результат: " + Reverse(input));
    }
}