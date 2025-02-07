using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Questions_Classes;

namespace Exam.Exam_Classes
{
    internal abstract class Exam : IComparable<Exam>
    {
        #region Properties
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question>? Questions { get; set; }
        public Subject? Subject { get; set; }

        #endregion

        #region Methods

        public abstract void StartExam();

        public override string ToString()
        {
            return $"Time of the Exam : {TimeOfExam}\nNumber Of Questions : {NumberOfQuestions}\nSubject Name : {Subject?.SubjectName}";
        }

        //public object Clone()
        //{
        //    return new Exam()
        //    {
        //        TimeOfExam = this.TimeOfExam,
        //        NumberOfQuestions = this.NumberOfQuestions,
        //        Subject = this.Subject
        //    };
        //}

        public int CompareTo(Exam? exam)
        {

            return this.NumberOfQuestions.CompareTo(exam?.NumberOfQuestions);
            
        }

        #endregion


    }
}
