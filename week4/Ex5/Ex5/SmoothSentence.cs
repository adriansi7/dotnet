using System;
using System.Collections.Generic;
using System.Text;

namespace Ex5
{
    public class SmoothSentence
    {
        public string Sentence { get; set; }

        public SmoothSentence(string sentence) 
        {
            Sentence = sentence;
        }

        public bool IsSmooth() 
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] words = Sentence.Split(delimiterChars);

            bool smooth = false;

            if (words.Length < 1)
            {
                return smooth;
            }

            for (int i = 0; i < words.Length; i++)
            {
                if ((i + 1) == words.Length)
                {
                    break;
                }

                if (!words[i].EndsWith(words[i + 1][0]))
                {
                    return smooth;
                }
            }

            smooth = true;

            return smooth;
        }
    }
}
