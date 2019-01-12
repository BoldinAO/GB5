using System;
using AQ;

namespace GameAskQuestion
{
    class Game
    {
        public void Start()
        {
            int countRightAnswer = 0;
            do
            {
                QuestionAsk questionAsk = new QuestionAsk();
                Console.Write("Вопрос: ");
                Console.WriteLine(questionAsk.GetRandomQuestion() + "\nВаш ответ: ");
                if (questionAsk.CompareAnswer(Console.ReadLine()))
                    ++countRightAnswer;
                Console.Clear();
                Console.WriteLine($"Правильных ответов {countRightAnswer}");
            } while (true);
        }
    }
}
