using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "karunya123.edu  , www.karunya.edu, www.karunya.edu,  http://karunya.edu, https://karunya.edu, www.karunyauniversity.in  ,  https://mykarunya.edu, https://www.karunya.edu  ,  google.com,  google.co.in, www.google.com,  https://www.gmail.com, gmail.com";

            while (true)
            {
                Console.WriteLine("\n\nEnter your choice: ");
                Console.WriteLine("1.Extract all the URLs");
                Console.WriteLine("2.Display all the URLs which start with https://");
                Console.WriteLine("3.URLs ending with .edu");
                Console.WriteLine("4.Replace all the vowels in url with given character");
                Console.WriteLine("5.Replace all the numbers in the URL with 1 and display");
                Console.WriteLine("6.Display all duplicate URLs");
                Console.WriteLine("7.Concatenate any two URLs");
                Console.WriteLine("8.Given any URL, display last occurence of any repeating character");
                Console.WriteLine("9.Insert [URL] at the beginning of URLs");
                Console.WriteLine("10.Find out first occurence of character in given url");
                Console.WriteLine("11.List out all the URLs with substring 'oo' in it.");


                int n = Int32.Parse(Console.ReadLine());                

                switch (n)
                {

                    case 1:
                        // An URL contains protocol (http, ftp, etc), subdomain, domain, TLD (.ro, .com, .edu)
                        Regex regEx = new Regex(@"([a-zA-Z]+:\/\/)[a-zA-Z\.0-9@:%_\+~#=]{2,256}\.[a-zA-Z]{2,6}");
                        MatchCollection matches = regEx.Matches(text);
                        foreach (Match m in matches)
                        {
                            if (m.Length != 0)
                            {
                                Console.WriteLine(m);

                            }
                        }
                        break;

                    case 2:
                        Regex regEx2 = new Regex(@"(https:\/\/)[a-zA-Z\.0-9@:%_\+~#=]{2,256}\.[a-zA-Z]{2,6}");
                        MatchCollection matches2 = regEx2.Matches(text);
                        foreach (Match m in matches2)
                        {
                            if (m.Length != 0)
                            {
                                Console.WriteLine(m);

                            }
                        }
                        break;

                    case 3:
                        Regex regEx3 = new Regex(@"([a-zA-Z]+:\/\/)[a-zA-Z\.0-9@:%_\+~#=]{2,256}\.edu");
                        MatchCollection matches3 = regEx3.Matches(text);
                        foreach (Match m in matches3)
                        {
                            if (m.Length != 0)
                            {
                                Console.WriteLine(m);

                            }
                        }
                        break;

                    case 4:
                        StringBuilder url = new StringBuilder(text);
                        String ch;
                        Console.WriteLine("The replacement character is: ");
                        ch = Console.ReadLine();
                        Console.WriteLine(Regex.Replace(text, @"[aeiou]", ch));
                        break;

                    case 5:
                        Console.WriteLine(Regex.Replace(text, @"[0-9]+", "1"));
                        break;

                    case 6:
                        String[] split = text.Split(',');
                        for (int i = 0; i < split.Length - 1; i++)
                        {
                            for (int j = i + 1; j < split.Length; j++)
                            {
                                if (split[i].Trim() == split[j].Trim())
                                {
                                    Console.WriteLine(split[i].Trim());
                                }
                            }

                        }
                        break;

                    case 7:
                        Regex regEx7 = new Regex(@"([a-zA-Z]+:\/\/)[a-zA-Z\.0-9@:%_\+~#=]{2,256}\.[a-zA-Z]{2,6}");
                        MatchCollection matches7 = regEx7.Matches(text);

                        for (int i = 0; i < matches7.Count; i++)
                        {
                            for (int j = 0; j < matches7.Count; j++)
                            {
                                Console.WriteLine(matches7[i].ToString() + matches7[j].ToString());
                            }
                        }


                        break;

                    case 8:
                        String url8 = "karunya123.edu";

                        for (int i = 0; i < url8.Length; i++)
                        {
                            if (url8.LastIndexOf(url8[i]) != i)
                            {
                                Console.WriteLine("The last occurance of repeating character {0} is {1 }", url8[i], url8.LastIndexOf(url8[i]));
                            }
                        }

                        break;

                    case 9:
                        Regex regEx9 = new Regex(@"([a-zA-Z]+:\/\/)[a-zA-Z\.0-9@:%_\+~#=]{2,256}\.[a-zA-Z]{2,6}");
                        MatchCollection matches9 = regEx9.Matches(text);
                        foreach (Match m in matches9)
                        {
                            if (m.Length != 0)
                            {
                                Console.WriteLine("[URL]" + m);

                            }
                        }
                        break;

                    case 10:
                        String url10 = "karunya123.edu";
                        String c;
                        Console.WriteLine("Please enter a character: ");
                        c = Console.ReadLine();
                        int position = url10.IndexOf(c);
                        if (position > -1)
                        {
                            Console.WriteLine("The character {0} was found at position {1}", c, position);
                        }
                        else
                        {
                            Console.WriteLine("The character {0} was not found in the url", c);
                        }

                        break;

                    case 11:
                        String[] split11 = text.Split(',');
                        foreach (var s in split11)
                        {
                            if (s.Trim().IndexOf("oo") > -1)
                            {
                                Console.WriteLine(s.Trim());

                            }
                        }
                        break;

                }
            }
        }
    }
}
