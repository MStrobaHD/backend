using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.Custom
{
    public class UserStatistics
    {
        public int AdministratorsNumber { get; set; }
        public int TeachersNumber { get; set; }
        public int StudentsNumber { get; set; }
    }
    public class MarksStatistics
    {
        public int positiveMarksNumber { get; set; }
        public int negativeMarksNumber { get; set; }
    }

    public class VerdictsStatistics
    {
        public int AcceptedNumber { get; set; }
        public int NotAcceptedNumber { get; set; }
        public int CompilationErrorNumber { get; set; }
        public int RuntimeErrorNumber { get; set; }
        public int MemoryLimitExceededNumber { get; set; }
        public int TimeLimitExceededNumber { get; set; }
        public int LinesOfCodeLimitExceededNumber { get; set; }
    }
    public class AssetsStatistics
    {
        public int CoursesNumber { get; set; }
        public int ExamsNumber { get; set; }
        public int FlashcardsSetNumber { get; set; }
        public int AlgorithmTasksNumber { get; set; }
        public int LessonNumber { get;  set; }
    }
}
