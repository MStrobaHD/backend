using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Metrics
    {
        public int Id { get; set; }
        public int CyclomaticComplexity { get; set; }
        public int LinesOfCode { get; set; }
        public int LinesOfNonCommentedCode { get; set; }
        public int NumberOfDecision { get; set; }
        public int NumberOfAssignment { get; set; }
        public int NumberOfTokens { get; set; }
        public int NumberOfUniqueTokens { get; set; }
        public int NumberOfUniqueOperators { get; set; }
        public int NumberOfOperators { get; set; }
        public int NumberOfUniqueOperands { get; set; }
        public int NumberOfOperands { get; set; }
        public decimal HalsteadProgramLenght { get; set; }
        public decimal HalsteadVocabulary { get; set; }
        public decimal ProgramVolume { get; set; }
        public decimal ProgramDifficulty { get; set; }
        public decimal ProgramLevel { get; set; }
        public decimal ProgrammingEffort { get; set; }
        public decimal LanguageLevel { get; set; }
        public decimal InteligenceContent { get; set; }
        public decimal ProgrammingTime { get; set; }
        public int VerdictId { get; set; }

        public virtual Verdict Verdict { get; set; }
    }
}
