using System;
using System.Text;
using System.IO;

namespace AQ
{
    class QuestionAsk
    {
        readonly string path = "qa.txt";
        readonly Random random = new Random();
        readonly int i = 0;
        readonly int answerCount = 0;
        readonly int questionCount = 0;
        readonly string[] Questions;
        public string[] Answer { get; }
        public int numQuestion { get; set; }

        public QuestionAsk()
        {
            Questions = new string[File.ReadAllLines(path).Length / 2];
            Answer = new string[File.ReadAllLines(path).Length / 2];

            if (File.Exists(path))
            {
                foreach(string line in File.ReadAllLines(path, Encoding.GetEncoding(1251)))
                {
                    if (i % 2 == 0)
                        Questions[questionCount++] = line;
                    else
                        Answer[answerCount++] = line;
                    i++;
                }
            }
        }

        public string GetRandomQuestion()
        {
            numQuestion = random.Next(0, Questions.Length - 1);
            return Questions[numQuestion];
        }

        public bool CompareAnswer(string myAnswer)
        {
            if (myAnswer == Answer[numQuestion])
                return true;
            return false;
        }
    }
}
