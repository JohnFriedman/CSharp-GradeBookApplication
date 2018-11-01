using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int count = Students.Count;
            if(count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            List<double> averageGrades = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            int index = averageGrades.FindIndex(a => a == averageGrade);

            int increment = count / 5;

            if(index < increment)
                return 'A';
            if(index < increment * 2)
                return 'B';
            if(index < increment * 3)
                return 'C';
            if(index < increment * 4)
                return 'D';

            return 'F';
        }
    }
}
