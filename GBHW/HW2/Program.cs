//Болдин
/*
Написать игру «Верю. Не верю». В файле хранятся вопрос и ответ, правда это или нет.
Например: «Шариковую ручку изобрели в древнем Египте», «Да».
Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
Список вопросов ищите во вложении или воспользуйтесь интернетом.
*/

#region пока дичь
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            g.Start();
            Console.ReadKey();
        }

        class Questions
        {
            string[] sQuestions = File.ReadAllLines("q.txt", Encoding.GetEncoding(1251));
            string[] sAnswers = File.ReadAllLines("a.txt", Encoding.GetEncoding(1251));
            private Dictionary<int, string> Question, Answer;

            public string this[string AQ, int index]
            {
                get {
                    if (AQ == "1")
                        return sAnswers[index];
                    return sQuestions[index];
                }
                set { sAnswers[index] = value;  }
            }



            public Questions()
            {
                Question = new Dictionary<int, string>();
                int i = 0;
                foreach (string m in sQuestions)
                {
                    Question.Add(i++, m);
                }

                i = 0;
                Answer = new Dictionary<int, string>();
                foreach (string m in sAnswers)
                {
                    Answer.Add(i++, m);
                }
            }
        }

        class Game
        {
            Questions q = new Questions();
            public void Start()
            {
                int count = 0;
                while (true)
                {
                    Random randomQuestion = new Random();
                    int rand = randomQuestion.Next(Question.Count);
                    Console.WriteLine(Question[rand]);
                    Console.WriteLine("Ваш ответ: ");
                    if (Check(rand, Console.ReadLine()))
                        count++;
                    Console.WriteLine("{0} правильных ответов", count);
                }
            }
            bool Check(int s, string g)
            {
                if (g == Answer[s])
                    return true;
                else
                    return false;
            }
        }
    }

}
#endregion