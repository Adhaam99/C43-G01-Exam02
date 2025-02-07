using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Question_Classes;

namespace Exam.Questions_Classes
{
    internal class Question : ICloneable , IComparable<Question>
    {

        #region Properties
        public string? HeaderOfTheQuestion { get; set; }
        public string? BodyOfTheQuestion { get; set; }
        public int Mark { get; set; }
        public List<Answer>? Answers { get; set; }
        public int RightAnswerID { get; set; } 

        #endregion

        #region Methods

        public override string ToString()
        {
            string Ans = "";

            for (int i = 0; i < Answers?.Count ; i++)
            {
                Ans += $"{Answers[i]}\n";
            }

            return $"{HeaderOfTheQuestion}\tMarks({Mark})\n{BodyOfTheQuestion}\n{Ans}\n{ new string('-' , 20)}";
        }
        public object Clone()
        {
            return new Question
            {
                HeaderOfTheQuestion = this.HeaderOfTheQuestion,
                BodyOfTheQuestion = this.BodyOfTheQuestion,
                Mark = this.Mark,
                Answers = this.Answers,
                RightAnswerID = this.RightAnswerID
            };
        }

        public int CompareTo(Question? question)
        {
            return this.Mark.CompareTo(question?.Mark);
        }

        #endregion

    }
}
