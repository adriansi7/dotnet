using System;
using System.Collections.Generic;

namespace Ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(10);
            list.AddLast(12);
            list.AddLast(11);
            list.AddLast(11);
            list.AddLast(12);
            list.AddLast(11);
            list.AddLast(10);

            LinkedListNode<int> start = list.First;

            var numbers = new HashSet<int>();

            RemoveDuplicates(ref numbers, ref list, start);


            DisplayList("list after remove duplicates", list);

        }

        static void RemoveDuplicates(ref HashSet<int> numbers, ref LinkedList<int> list, LinkedListNode<int> start)
        {
            if (start == null)
            {
                return;
            }

            LinkedListNode<int> next = start.Next;

            if (numbers.Contains(start.Value))
            {
                list.Remove(start);
            }

            else
            {
                numbers.Add(start.Value);
            }

            if (next != null)
            {

                RemoveDuplicates(ref numbers, ref list, next);
            }


        }

        static void DisplayList(string type, LinkedList<int> list)
        {

            Console.WriteLine("{0}:" + System.Environment.NewLine, type);

            foreach (int x in list)
            {
                Console.WriteLine("{0}" + System.Environment.NewLine, x);
            }
        }
    }
}
