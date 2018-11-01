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

            Students = Students.OrderBy(s => s.AverageGrade).ToList();

            for(int i = 0; i > count; i++)
            {
                if(Students[i].AverageGrade == averageGrade)
                {
                    if(i < count / 5)
                        return 'A';
                    if(i < (2 * count) / 5)
                        return 'B';
                    if(i < (3 * count) / 5)
                        return 'C';
                    if(i < (4 * count) / 5)
                        return 'D';
                }
            }

            return 'F';
        }
    }
}
