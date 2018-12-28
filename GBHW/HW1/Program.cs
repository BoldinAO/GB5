using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            Students st = new Students();
            Console.WriteLine("Введите кол-во учеников");
            Students.SetQuantity(Console.ReadLine());
            st.SetFIR();
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
            }

            static int quantity { get; set; }
            Regex FIR = new Regex(@"^[А-Я]{1}[а-я]{0,19}\s{1}[А-Я]{1}[а-я]{0,14}\s{1}([2-5]\s{1}){2}[2-5]{1}$");

            public static void SetQuantity(string q)
            {
                int qq = int.Parse(q);
                quantity = qq > 0 ? (qq < 101 ? qq : 0) : 0;
            }

            public void SetFIR()
            {
                for (int i = 0; i < quantity; i++)
                {
                    string _FIR = Console.ReadLine();
                    if (FIR.IsMatch(_FIR))
                    {
                        Student.Add(new StudentInfo { Surname = _FIR.Split()[0], Name = _FIR.Split()[1], [0] = int.Parse(_FIR.Split()[2]), [1] = int.Parse(_FIR.Split()[3]), [2] = int.Parse(_FIR.Split()[4]) });
                    }
                }
                Console.WriteLine($"{Student[0].Name} {Student[0].Surname} {Student[0][2]}");
            }

            public void GetN()
            {
                int marks;
                double[] nodMark = new double[3];
                bool flag = false;
                for(int i = 0; i < 3; i++)
                {
                    marks = 0;
                    for (int x = 0; x < 3; x++)
                    {
                        marks += Student[i][x];
                    }
                    nodMark[i] = marks / 3.0;
                    Console.WriteLine(nodMark[i]);
                }

                for(int i = 0; i < 3; i++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (nodMark[i] < nodMark[x])
                            flag = true;
                        else
                            flag = false;
                    }
                    if (flag)
                        Console.WriteLine($"{Student[i].Surname} {Student[i].Name}");
                }
            }
        }
    }
}
