using System;

namespace Ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentence1 = new SmoothSentence("Carlos swam masterfully");
            Console.WriteLine("Carlos swam masterfully -> " + sentence1.IsSmooth());

            var sentence2 = new SmoothSentence("Marta appreciated deep perpendicular right trapezoids");
            Console.WriteLine("Marta appreciated deep perpendicular right trapezoids -> " + sentence2.IsSmooth());

            var sentence3 = new SmoothSentence("Someone is outside the doorway");
            Console.WriteLine("Someone is outside the doorway -> " + sentence3.IsSmooth());

            var sentence4 = new SmoothSentence("She eats super righteously");
            Console.WriteLine("She eats super righteously -> " + sentence4.IsSmooth());
        }
    }
}
