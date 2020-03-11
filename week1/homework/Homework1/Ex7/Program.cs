using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ex 7.2.1
            string[] newArray = new string[0];
            Console.WriteLine("Ex 7.2.1: new string array of length 0 created" + System.Environment.NewLine);

            // Ex 7.2.2
            string[] names = new string[1];
            names[0] = "Han Solo";
            Console.WriteLine("Ex 7.2.2: {0}" + System.Environment.NewLine, names[0]);

            // Ex 7.2.3
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Ex 7.2.3: " + System.Environment.NewLine);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("{0}" + " ", numbers[i]);
            }

            // Ex 7.3.1
            List<String> stringList = new List<String>();
            Console.WriteLine(System.Environment.NewLine + "Ex 7.3.1: new string list created" + System.Environment.NewLine);

            // Ex 7.3.2
            stringList.Add("Chewbacca");
            Console.WriteLine("Ex 7.3.2: {0}" + System.Environment.NewLine, stringList[0]);

            // Ex 7.3.3
            List<string> characters = new List<string>()
            {
                "Luke Skywalker",
                "Han Solo",
                "Chewbacca"
            };

            characters.Remove("Luke Skywalker");
            Console.WriteLine("Ex 7.3.3: Removed Luke Skywalker from the characters list" + System.Environment.NewLine);

            // Ex 7.3.4
            characters.Add("Luke Skywalker");
            characters.RemoveAt(2);
            Console.WriteLine("Ex 7.3.4: Removed third element using index from the characters list" + System.Environment.NewLine);

            // Ex 7.3.5
            Console.WriteLine("Ex 7.3.5: " + System.Environment.NewLine);
            foreach (var x in characters)
            {
                Console.WriteLine("{0}" + " ", x);
            }

            // Ex 7.4.1
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Console.WriteLine(System.Environment.NewLine + "Ex 7.4.1: new dictionary created" + System.Environment.NewLine);

            // Ex 7.4.2
            dict.Add("Adrian", 30);
            dict["Marian"] = 40;
            Console.WriteLine("Ex 7.4.2: {0}" + System.Environment.NewLine, dict.First());

            // Ex 7.4.3
            Dictionary<string, bool> characters2 = new Dictionary<string, bool>()
            {
                { "Luke", true },
                { "Han", false },
                { "Chewbacca", false }
            };

            characters2.Remove("Han");
            Console.WriteLine("Ex 7.4.3: Removed element with key Han from the dictionary" + System.Environment.NewLine);

            // Ex 7.4.4
            Console.WriteLine("Ex 7.4.4: foreach dictionary loop" + System.Environment.NewLine);
            characters2.Add("Han", true);

            foreach (var x in characters2)
            {
                Console.WriteLine("{0}" + " ", x.ToString());
            }

            // Ex 7.5.1            
            Queue<int> primes = new Queue<int>();
            Console.WriteLine(System.Environment.NewLine + "Ex 7.5.1: new primes int queue created" + System.Environment.NewLine);

            // Ex 7.5.2
            primes.Enqueue(2);
            primes.Enqueue(3);
            primes.Enqueue(5);
            primes.Enqueue(7);
            primes.Enqueue(11);

            Console.WriteLine("Ex 7.5.2: added the first 5 prime numbers to the queue" + System.Environment.NewLine);

            // Ex 7.5.3
            int total = 0;

            while (primes.Count > 0)
            {
                total += primes.Dequeue();
            }

            Console.WriteLine("Ex 7.5.3: total of prime numbers in queue is {0}" + System.Environment.NewLine, total);

            // Ex 7.6.1            
            Stack<string> films = new Stack<string>();
            Console.WriteLine(System.Environment.NewLine + "Ex 7.6.1: films string stack created" + System.Environment.NewLine);

            // Ex 7.6.2
            films.Push("Star Wars Episode IV – A New Hope");
            films.Push("Star Wars Episode V – The Empire Strikes Back");
            films.Push("Star Wars Episode VI – Return of the Jedi");

            Console.WriteLine("Ex 7.6.2: Added first 3 Star Wars films to the stack" + System.Environment.NewLine);

            // Ex 7.6.3
            Console.WriteLine("Ex 7.6.3: the films from the stack are" + System.Environment.NewLine);
            do
            {
                string film = films.Pop();
                Console.WriteLine("{0}" + " ", film);
            } while (films.Count() > 0);

            // Ex 7.7.1
            LinkedList<string> movies = new LinkedList<string>();
            Console.WriteLine(System.Environment.NewLine + "Ex 7.7.1: new string list movies created" + System.Environment.NewLine);

            // Ex 7.7.2
            movies.AddFirst("Avatar");
            LinkedListNode<string> titanic = new LinkedListNode<string>("Titanic");
            movies.AddLast(titanic);
            movies.AddAfter(titanic, "Star Wars: The Force Awakens");

            Console.WriteLine("Ex 7.7.2: added new nodes titanic + star wars force awakens" + System.Environment.NewLine);

            // Ex 7.7.3
            LinkedList<string> droids = new LinkedList<string>();

            droids.AddLast("C-3PO");
            droids.AddLast("AZI-3");
            droids.AddLast("R2-D2");
            droids.AddLast("IG-88");
            droids.AddLast("2-1B");

            droids.Remove("C-3PO");

            LinkedListNode<string> node = droids.Find("R2-D2");
            droids.Remove(node);
            droids.RemoveLast();

            Console.WriteLine("Ex 7.7.3: removed nodes C-3P0, R2-D2 and the last one" + System.Environment.NewLine);

        }
    }
}
