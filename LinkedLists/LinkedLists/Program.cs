using System;
using System.Text;
using System.Collections.Generic;

public class Linked_List
{
     public static void Main()
    {
        //Создание односвязанного списка
        string[] words =
            { "the", "fox", "jumps", "over", "the", "dog" };
        LinkedList<string> sentence = new LinkedList<string>(words);
        Display(sentence, "Значения односвязного списка:");

        //Добавление узла 'today' в начало списка
        sentence.AddFirst("today");
        Display(sentence, "Добавление слова 'today' в начало списка:");

        //Перемещение узла 'today' из начала списка в конец
        LinkedListNode<string> mark1 = sentence.First;
        sentence.RemoveFirst();
        sentence.AddLast(mark1);
        Display(sentence, "Перемещение слова из начала списка в конец:");

        //Замена узла 'today' на 'yesterday'
        sentence.RemoveLast();
        sentence.AddLast("yesterday");
        Display(sentence, "Замена последнего слова на 'yesterday':");

        //Перемещение узла 'yesterday' из конца списка в начало
        mark1 = sentence.Last;
        sentence.RemoveLast();
        sentence.AddFirst(mark1);
        Display(sentence, "Перемещение слова из конца списка в начало:");

        //Выделение последнего 'the' в списке
        sentence.RemoveFirst();
        LinkedListNode<string> current = sentence.FindLast("the");
        IndicateNode(current, "Выделение последнего 'the':");

        //Добавление 'lazy' и 'old' после каждого 'the'
        sentence.AddAfter(current, "old");
        sentence.AddAfter(current, "lazy");
        IndicateNode(current, "Добавление 'lazy' и 'old' после последнего 'the':");

        //Выделение узла 'fox'
        current = sentence.Find("fox");
        IndicateNode(current, "Выделение узла 'fox':");

        //Добавление 'quick' и 'brown' перед 'fox'
        sentence.AddBefore(current, "quick");
        sentence.AddBefore(current, "brown");
        IndicateNode(current, "Добавление 'quick' и 'brown' перед 'fox':");

        //Выделение узла 'dog', который мы убираем из списка и пробуем найти с помощью метода
        mark1 = current;
        LinkedListNode<string> mark2 = current.Previous;
        current = sentence.Find("dog");
        sentence.Remove(current);
        IndicateNode(current, "Выделение узла 'dog', который мы убираем из списка и пробуем найти с помощью метода:");

        // Add the node after the node referred to by mark2.
        sentence.AddAfter(mark2, current);
        IndicateNode(current, "Tест №13: Add node removed in test 11 after a referenced node (brown):");

        // The Remove method finds and removes the
        // first node that that has the specified value.
        sentence.Remove("old");
        Display(sentence, "Tест №14: Remove node that has the value 'old':");

        // When the linked list is cast to ICollection(Of String),
        // the Add method adds a node to the end of the list.
        sentence.RemoveLast();
        ICollection<string> icoll = sentence;
        icoll.Add("rhinoceros");
        Display(sentence, "Tест №15: Remove last node, cast to ICollection, and add 'rhinoceros':");

        Console.WriteLine("Tест №16: Copy the list to an array:");
        // Create an array with the same number of
        // elements as the linked list.
        string[] sArray = new string[sentence.Count];
        sentence.CopyTo(sArray, 0);

        foreach (string s in sArray)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine("Односвязный список содержит 'jumps' = {0}",
            sentence.Contains("jumps"));

        // Release all the nodes.
        sentence.Clear();

        Console.WriteLine();
        Console.WriteLine("Tест №18: Cleared linked list Contains 'jumps' = {0}",
            sentence.Contains("jumps"));

        Console.ReadLine();
    }

    //метод для упрощения вывода в консоль
    private static void Display(LinkedList<string> words, string test)
    {
        //вывод сообщения
        Console.WriteLine(test);
        //итерация элементов списка и вывод каждого элемента, разделяя пробелом
        foreach (string word in words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
        Console.WriteLine();
    }

    //метод выделения
    private static void IndicateNode(LinkedListNode<string> node, string test)
    {
        Console.WriteLine(test);

        //выявление ошибки, если узел отсутствует в списке
        if (node.List == null)
        {
            Console.WriteLine("Узел не находится в списке\n",
                node.Value);
            return;
        }

        //выделение нужного слова с помощью скобок
        StringBuilder result = new StringBuilder("(" + node.Value + ")");
        LinkedListNode<string> nodeP = node.Previous;

        //разделение выделенного узла от других с помощью пробелов
        while (nodeP != null)
        {
            result.Insert(0, nodeP.Value + " ");
            nodeP = nodeP.Previous;
        }

        node = node.Next;
        while (node != null)
        {
            result.Append(" " + node.Value);
            node = node.Next;
        }

        Console.WriteLine(result);
        Console.WriteLine();
    }
}