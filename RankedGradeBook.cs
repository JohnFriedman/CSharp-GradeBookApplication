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

            Students = Students.OrderByDescending(s => s.AverageGrade).ToList();

            int fifth = count / 5;

            for(int j = 0; j < 4; j++)
            {
                for(int i = j; i < fifth * (j + 1); i++)
                {
                    if(Students[i].AverageGrade == averageGrade)
                    {
                        if(j == 0)
                            return 'A';
                        if(j == 1)
                            return 'B';
                        if(j == 2)
                            return 'C';
                        if(j == 3)
                            return 'D';
                    }
                }
            }

            return 'F';
        }
    }
}
