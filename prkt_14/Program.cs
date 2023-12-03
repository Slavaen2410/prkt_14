using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputText = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек. А это веселая птица­ синица, Которая часто вору­ет пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";

        Dictionary<string, int> wordStatistics = CountWordOccurrences(inputText);

        Console.WriteLine("Статистика по тексту:");
        Console.WriteLine("Слово\t\tКоличество");
        Console.WriteLine("------------------------");

        foreach (var pair in wordStatistics)
        {
            Console.WriteLine($"{pair.Key}\t\t{pair.Value}");
        }
    }

    static Dictionary<string, int> CountWordOccurrences(string text)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        // Разделение текста на слова с использованием регулярных выражений
        string[] words = Regex.Split(text, @"\W+");

        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                // Приведение слова к нижнему регистру для учета регистра
                string lowercaseWord = word.ToLower();

                if (wordCount.ContainsKey(lowercaseWord))
                {
                    // Увеличение счетчика, если слово уже встречалось
                    wordCount[lowercaseWord]++;
                }
                else
                {
                    // Добавление нового слова в словарь
                    wordCount.Add(lowercaseWord, 1);
                }
            }
        }

        return wordCount;
    }
}
