using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Questions_Classes;

namespace Exam.Question_Classes
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion()
        {
            HeaderOfTheQuestion = "True | False Question";
            Answers = new List<Answer>([new Answer() { AnswerId = 1, AnswerText = "True" }, new Answer() { AnswerId = 2, AnswerText = "False" }]); ; 
        }

    }
}
