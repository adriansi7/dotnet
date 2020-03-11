using System;
using System.Collections.Generic;

namespace Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(2);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(7);
            list.AddLast(9);


            DisplayList("initial list", list);

            LinkedList<int> reversedList = new LinkedList<int>();

            LinkedListNode<int> start = list.Last;

            while (start != null)
            {
                reversedList.AddLast(start.Value);
                start = start.Previous;
            }

            list = reversedList;

            DisplayList("reversed list", list);

            recursiveReverse(ref list, list.Last);


            DisplayList("recursive reversed list", list);

            recursiveReverse(ref list, list.Last);

        }


        static void DisplayList(string type, LinkedList<int> list)
        {

            Console.WriteLine("{0}:" + System.Environment.NewLine, type);

            foreach (int x in list)
            {
                Console.WriteLine("{0}" + System.Environment.NewLine, x);
            }
        }

        static void recursiveReverse(ref LinkedList<int> list, LinkedListNode<int> head)
        {

            if (head.Previous == null || head == null)
            {
                return;
            }

            LinkedListNode<int> elementToAdd = head.Previous;
            list.AddLast(elementToAdd.Value);
            list.Remove(elementToAdd);

            recursiveReverse(ref list, head);

        }

    }
}
