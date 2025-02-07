using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Question_Classes;

namespace Exam.Exam_Classes
{
    internal class FinalExam : Exam
    {

        public override void StartExam()
        {
            if (Questions is null || Questions.Count == 0) return;

            int totalMark = 0;

            List<Answer> userAnswers = new List<Answer>();

            for (int i = 0; i < Questions?.Count; i++)
            {
                Console.WriteLine(Questions[i]);

                int answerID;
                bool flag;

                do
                {
                    Console.Write("Insert the number of your Answer : ");

                    flag = int.TryParse(Console.ReadLine(), out answerID);

                } while (!flag);

                for (int j = 0; j < Questions[i]?.Answers?.Count; j++)
                    if (Questions[i]?.Answers[j]?.AnswerId == answerID)
                        userAnswers.Add(Questions[i]?.Answers[j] ?? new Answer());

                Console.Write("======================================================\n");

                if (Questions[i]?.RightAnswerID == answerID)
                    totalMark += Questions[i]?.Mark ?? 0;
            }

            Console.Clear();

            Console.WriteLine("Your Answers : ");

            int examMarks = 0; 

            for (int i = 0; i < Questions?.Count; i++)
            {
                Console.WriteLine($"Q{i + 1})\t{Questions[i].BodyOfTheQuestion} : {userAnswers[i].AnswerText}");
                examMarks += Questions[i].Mark;
            }

            Console.WriteLine($"Your Exam Grade is {totalMark} From {examMarks}");
        }
    }
}
