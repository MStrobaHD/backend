using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels
{
    public class Metrics
    {
        public Metrics(int cyclomaticComplexity, int linesOfCode, int linesOfNonCommentedCode, int numberOfDecision, int numberOfAssignment)
        {
            CyclomaticComplexity = cyclomaticComplexity;
            LinesOfCode = linesOfCode;
            LinesOfNonCommentedCode = linesOfNonCommentedCode;
            NumberOfDecision = numberOfDecision;
            NumberOfAssignment = numberOfAssignment;
        }

        public int CyclomaticComplexity { get; set; }
        public int LinesOfCode { get; set; }
        public int LinesOfNonCommentedCode { get; set; }
        public int NumberOfDecision { get; set; }
        public int NumberOfAssignment { get; set; }
    }
}
