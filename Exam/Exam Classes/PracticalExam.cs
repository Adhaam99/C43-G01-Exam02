using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Exam_Classes
{
    internal class PracticalExam : Exam
    {
        
        public override void StartExam()
        {

            if (Questions is null || Questions.Count == 0) return;
            
            int totalMarks = 0;

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

  

                Console.Write("======================================================\n\n");

                if (Questions[i]?.RightAnswerID == answerID) 
                     totalMarks += Questions[i]?.Mark ?? 0; 
            }

            Console.Clear() ;

            Console.WriteLine("Questions And The Right Answers");

            for (int i = 0;i < Questions?.Count; i++)
            {
                string? rightAnswerText = " ";

                for (int j = 0; j < Questions[i]?.Answers?.Count; j++)
                    if (Questions[i]?.Answers[j]?.AnswerId == Questions[i].RightAnswerID)
                    {
                        rightAnswerText = $"{Questions[i]?.Answers[j]}";
                    }

                Console.WriteLine($"Q{i + 1}) {Questions[i].BodyOfTheQuestion}{new string(' ' , 10)} { rightAnswerText }");
            }
        }
    }
}
