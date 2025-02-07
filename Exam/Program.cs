using Exam.Question_Classes;
using Exam.Questions_Classes;
using Exam.Exam_Classes;
using System.Diagnostics;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Answer A01 = new Answer() { AnswerId = 1, AnswerText = "Adham" };
            //Answer A02 = new Answer() { AnswerId = 2, AnswerText = "Mahmoud" };
            //Answer A03 = new Answer() { AnswerId = 3, AnswerText = "Mohamed" };


            //Question Q01 = new Question() { HeaderOfTheQuestion = "MCQ", BodyOfTheQuestion = "Whats Your name", Mark = 2, Answers = new List<Answer>([A01, A02, A03]), RightAnswerID = 1 };

            //Question Q02 = new Question() { HeaderOfTheQuestion = "True Or False", BodyOfTheQuestion = "Your Father name is Yehia?", Mark = 2, Answers = new List<Answer>([new Answer() { AnswerId = 1, AnswerText = "True" }, new Answer() { AnswerId = 2, AnswerText = "False" }]), RightAnswerID = 1 };

            //Exam_Classes.Exam finalExam = new FinalExam() { NumberOfQuestions = 2, Questions = new List<Question>([Q01, Q02]) };

            //finalExam.StartExam();

            Subject S01 = new Subject() { SubjectID = 10, SubjectName = "C++" };

            S01.CreateExam();

            Console.Clear();

            YesOrNoEnum yesOrNoEnum;
            bool flag;

            do
            {

                Console.WriteLine("Do You Want To Start The Exam ( Press Y For Yes | Press N For No) ");
                flag = Enum.TryParse(Console.ReadLine(), out yesOrNoEnum);
            } while (!flag);

            Console.Clear();

            if (yesOrNoEnum == (YesOrNoEnum)1)
            {
                Stopwatch SW = new Stopwatch();
                SW.Start();
                S01?.Exam?.StartExam();
                Console.WriteLine($"Time Elapsed : {SW.Elapsed}");
            }

        }
    }
}
