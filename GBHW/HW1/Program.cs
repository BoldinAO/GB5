//Болдин
/*
4. Задача ЕГЭ.
*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран
фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
Достаточно решить 2 задачи. Старайтесь разбивать программы на подпрограммы. Переписывайте в
начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения
задач используйте неизменяемые строки (string)
*/

using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Students st = new Students();
            Console.WriteLine("Введите кол-во учеников");
            Students.SetQuantity(Console.ReadLine());
            st.SetSNR();
            st.GetN();
            Console.ReadKey();
        }

        class Students
        {
            List<StudentInfo> Student = new List<StudentInfo>();
            class StudentInfo
            {
                public string Name { get; set; }
                public string Surname { get; set; }
                private int[] Marks = new int[3];
                public int this[int i]
                {
                    get { return Marks[i]; }
                    set { Marks[i] = value; }
                }
                public double NodMark { get; set; }
            }

            static int quantity { get; set; }
            Regex SNR = new Regex(@"^[А-Я]{1}[а-я]{0,19}\s{1}[А-Я]{1}[а-я]{0,14}\s{1}([2-5]\s{1}){2}[2-5]{1}$");

            public static void SetQuantity(string q)
            {
                try
                {
                    int qq = int.Parse(q);
                    quantity = qq > 9 ? (qq < 101 ? qq : 0) : 0;
                    if (quantity == 0)
                        Console.WriteLine("Необходимо ввести кол-во учеников от 10 до 100!");
                }
                catch
                {
                    Console.WriteLine("Необходимо ввести кол-во учеников от 10 до 100!");
                }
            }

            public void SetSNR()
            {
                string _SNR;
                for (int i = 0; i < quantity; i++)
                {
                    do
                    {
                        Console.WriteLine("Введите фамилию, имя и три оценки {0} ученика:", i + 1);
                        _SNR = Console.ReadLine();
                        if (SNR.IsMatch(_SNR))
                        {
                            Student.Add(new StudentInfo
                            {
                                Surname = _SNR.Split()[0],
                                Name = _SNR.Split()[1],
                                [0] = int.Parse(_SNR.Split()[2]),
                                [1] = int.Parse(_SNR.Split()[3]),
                                [2] = int.Parse(_SNR.Split()[4]),
                            });
                            Student[i].NodMark = (Student[i][0] + Student[i][1] + Student[i][2]) / 3.0;
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод");
                        }
                    } while (!SNR.IsMatch(_SNR));
                }
            }

            public void GetN()
            {
                if(Student.Count > 0)
                {
                    Student.Sort(delegate (StudentInfo student, StudentInfo student2)
                    { return student.NodMark.CompareTo(student2.NodMark); });

                    var uniqueMarks =
                    from StudentInfo n in Student.Distinct()
                    group n.NodMark by n.NodMark into nGroup
                    select nGroup.Key;

                    Console.WriteLine("Список учеников с плохой средней оценкой:");
                    foreach (double mark in uniqueMarks.Take(3))
                    {
                        foreach (StudentInfo st in Student)
                        {
                            if (st.NodMark == mark)
                                Console.WriteLine($"{st.Surname} {st.Name} {st.NodMark}");
                        }
                    }
                } else
                {
                    Console.WriteLine("Список учеников отсутствует!");
                }
            }
        }
    }
}
