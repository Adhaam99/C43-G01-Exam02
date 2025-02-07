using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Question_Classes;
using Exam.Questions_Classes;

namespace Exam.Exam_Classes
{
    internal class Subject : ICloneable, IComparable<Subject>
    {
        #region Properties
        public int SubjectID { get; set; }
        public string? SubjectName { get; set; }
        public Exam? Exam { get; set; }

        #endregion

        #region Methods

        public void CreateExam()
        {
            //Console.Write("Please Enter The Type of Exam You Want To Create : ");

            #region Chose type of the exam

            OneOrTwoEnum type;

            bool flag;

            do
            {
                Console.Write("Please Enter The Type of Exam You Want To Create ( 1 for Practical 2 for Final ) : ");

                flag = OneOrTwoEnum.TryParse(Console.ReadLine(), out type);

            } while (!flag);

            if (type == (OneOrTwoEnum)1)
                Exam = new PracticalExam();
            else if (type == (OneOrTwoEnum)2)
                Exam = new FinalExam();

            Exam.Subject = this;

            #endregion

            #region Take the time of the exam

            int examTime;

            do
            {
                Console.Write("Please Enter The Time of The Exam in Minutes : ");

                flag = int.TryParse(Console.ReadLine(), out examTime);

            } while (!flag);

            Exam.TimeOfExam = examTime;

            #endregion

            #region Take the number of questions

            int numOfQuestions;

            do
            {
                Console.Write("Please Enter Number Of Questions : ");

                flag = int.TryParse(Console.ReadLine(), out numOfQuestions);

            } while (!flag);

            Exam.NumberOfQuestions = numOfQuestions;

            Console.Clear();

            #endregion

            #region Making Practical Exam

            if (type == (OneOrTwoEnum)1)
            {
                Exam.Questions = new List<Question>();

                for (int i = 1; i <= numOfQuestions; i++)
                {
                    Console.WriteLine($"Question Number ({i})");

                    Console.WriteLine("True | False Question\n");

                    string? text;

                    Console.WriteLine("Please Enter The Body of The Question :");

                    text = Console.ReadLine();

                    int marks;

                    do
                    {
                        Console.Write("Please Enter The Marks Of The Question : ");

                        flag = int.TryParse(Console.ReadLine(), out marks);

                    } while (!flag);

                    do
                    {
                        Console.Write($"Please Enter The Right Answer For Question ( 1 For True and 2 For False ): ");

                        flag = OneOrTwoEnum.TryParse(Console.ReadLine(), out type);

                    } while (!flag);

                    Console.Clear();

                    Exam?.Questions?.Add(new TrueOrFalseQuestion() { BodyOfTheQuestion = text, Mark = marks, RightAnswerID = (int)type });

                }

            }

            #endregion

            #region Making Final Exam

            else if (type == (OneOrTwoEnum)2)
            {
                Exam.Questions = new List<Question>();

                for (int i = 1; i <= numOfQuestions; i++)
                {

                    do
                    {
                        Console.Write($"Please Choice Type of Question Number ({i}) ( 1 For True Or False || 2 For MCQ ): ");

                        flag = Enum.TryParse(Console.ReadLine(), out type);

                    } while (!flag);

                    Console.Clear();

                    #region Making True Or False Question

                    if (type == (OneOrTwoEnum) 1 )
                    {
                        Console.WriteLine("True | False Question\n");

                        string? text;

                        Console.WriteLine("Please Enter The Body of The Question :");

                        text = Console.ReadLine();

                        int marks;

                        do
                        {
                            Console.Write("Please Enter The Marks Of The Question : ");

                            flag = int.TryParse(Console.ReadLine(), out marks);

                        } while (!flag);

                        int answerID;

                        do
                        {
                            Console.Write($"Please Enter The Right Answer For Question ( 1 For True and 2 For False ) : ");

                            flag = int.TryParse(Console.ReadLine(), out answerID);

                        } while (!flag);

                        Console.Clear();

                        Exam?.Questions?.Add(new TrueOrFalseQuestion() { BodyOfTheQuestion = text, Mark = marks, RightAnswerID =  answerID });

                    }
                    #endregion

                    #region Making MCQ Question

                    else if (type == (OneOrTwoEnum) 2 )
                    {
                        Console.WriteLine("MCQ Question");

                        string? text;

                        Console.WriteLine("Please Enter The Body of The Question :");

                        text = Console.ReadLine();

                        int marks;

                        do
                        {
                            Console.Write("Please Enter The Marks Of The Question : ");

                            flag = int.TryParse(Console.ReadLine(), out marks);

                        } while (!flag);

                        List<Answer> answers = new List<Answer>();

                        for (int j = 1; j <= 3; j++)
                        {
                            Console.Write($"Please Enter The Choice Number {j} : ");

                            string? answer = Console.ReadLine();

                            answers.Add(new Answer() { AnswerId = j, AnswerText = answer });
                        }

                        int rightAnswerID;

                        do
                        {
                            Console.WriteLine("Please Enter The Right Answer ID ");

                            flag = int.TryParse(Console.ReadLine(), out rightAnswerID);

                        } while (!flag);


                        Exam?.Questions?.Add(new MCQQuestion() { BodyOfTheQuestion = text, Mark = marks, Answers = answers, RightAnswerID = rightAnswerID });
                    } 
                    #endregion

                }
            }

        } 
        #endregion
        public override string ToString()
        {
            return $"Subject ID : {SubjectID}{new string(' ', 10)}Subject Name : {SubjectName}";
        } 

        public object Clone()
        {
            return new Subject()
            {

                SubjectID = this.SubjectID,
                SubjectName = this.SubjectName
            };
        }

        public int CompareTo(Subject? subject)
        {
            return this.SubjectID.CompareTo(subject?.SubjectID);
        }
        #endregion
    }
}
