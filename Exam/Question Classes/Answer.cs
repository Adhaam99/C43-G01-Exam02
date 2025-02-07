using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Question_Classes
{
    internal class Answer : ICloneable , IComparable<Answer>
    {

        #region Properties
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }

        public object Clone()
        {
            return new Answer()
            {
                AnswerId = this.AnswerId,
                AnswerText = this.AnswerText
            };
        }
        public int CompareTo(Answer? answer)
        {
            return this.AnswerId.CompareTo(answer?.AnswerId);
        }


        #endregion

    }
}
