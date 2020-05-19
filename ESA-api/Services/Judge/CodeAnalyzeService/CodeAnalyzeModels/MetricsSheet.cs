using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels
{
    public class MetricsSheet
    {
        public MetricsSheet(int cyclomaticComplexity, int linesOfCode, int linesOfNonCommentedCode, int numberOfDecision, int numberOfAssignment, int numberOfTokens, int numberOfUniqueTokens, int numberOfUniqueOperators, int numberOfOperators, int numberOfUniqueOperands, int numberOfOperands, double halsteadProgramLenght, double halsteadVocabulary, double programVolume, double programDifficulty, double programLevel, double programmingEffort, double languageLevel, double inteligenceContent, double programmingTime)
        {
            CyclomaticComplexity = cyclomaticComplexity;
            LinesOfCode = linesOfCode;
            LinesOfNonCommentedCode = linesOfNonCommentedCode;
            NumberOfDecision = numberOfDecision;
            NumberOfAssignment = numberOfAssignment;
            NumberOfTokens = numberOfTokens;
            NumberOfUniqueTokens = numberOfUniqueTokens;
            NumberOfUniqueOperators = numberOfUniqueOperators;
            NumberOfOperators = numberOfOperators;
            NumberOfUniqueOperands = numberOfUniqueOperands;
            NumberOfOperands = numberOfOperands;
            HalsteadProgramLenght = halsteadProgramLenght;
            HalsteadVocabulary = halsteadVocabulary;
            ProgramVolume = programVolume;
            ProgramDifficulty = programDifficulty;
            ProgramLevel = programLevel;
            ProgrammingEffort = programmingEffort;
            LanguageLevel = languageLevel;
            InteligenceContent = inteligenceContent;
            ProgrammingTime = programmingTime;
        }

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
        public double HalsteadProgramLenght { get; set; }
        public double HalsteadVocabulary { get; set; }
        public double ProgramVolume { get; set; }
        public double ProgramDifficulty { get; set; }
        public double ProgramLevel { get; set; }
        public double ProgrammingEffort { get; set; }
        public double LanguageLevel { get; set; }
        public double InteligenceContent { get; set; }
        public double ProgrammingTime { get; set; }

    }
}
