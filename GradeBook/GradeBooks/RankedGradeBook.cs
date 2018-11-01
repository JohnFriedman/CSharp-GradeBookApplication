using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
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

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
             if(Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
