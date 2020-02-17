using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Helpers
{
    public class SourceCodeAnalyzer
    {
        public SourceCodeAnalyzer()
        {
        }
        public string CleanCode(string sourceCode)
        {

            return sourceCode;
        }
        public string AnalyzeCode(string sourceCode)
        {
            string cyclomaticComplexity = "sdada";

            return cyclomaticComplexity;
        }

        public string CalculateElementaryOperation(string sourceCode)
        {
            string elementaryOperation = "int i = 0;";
            //string iteratelementaryOperation = "i++;";
            //string elementaryOperationResult = "Console.Writeline('Liczba operacji elementarnych = ', elementaryOperation);";

            return elementaryOperation;
        }
    }
}
