using ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ESA_api.Services.Judge.CodeAnalyzeService
{
    public class CodeAnalyzeService : ICodeAnalyzeService
    {
        public CodeAnalyzeService()
        {
        }

        public List<MethodNode> CreateControlFlowGraph(string source)
        {
            List<MethodNode> listOfMethods = new List<MethodNode>();
            CSharpParseOptions options = CSharpParseOptions.Default
           .WithFeatures(new[] { new KeyValuePair<string, string>("flow-analysis", "") });

            var tree = CSharpSyntaxTree.ParseText(source, options);
            var compilation = CSharpCompilation.Create("c", new[] { tree });
            var test = compilation.GetSemanticModel(tree);

            //var test82 = SyntaxFactory.ParseStatement(source);
            //var test3 = SyntaxFactory.ParseArgumentList(source);
            var model = compilation.GetSemanticModel(tree, ignoreAccessibility: true);
            var methodBodySyntax = tree.GetCompilationUnitRoot().DescendantNodes().OfType<BaseMethodDeclarationSyntax>().ToList();


            foreach (var method in methodBodySyntax)
            {
                var methodName = GetNameOfMethod(method.ToString());
                var controlFlowGraph = ControlFlowGraph.Create(method, model);
                var nodesWithConnection = GetNodesWithConnections(controlFlowGraph);
                listOfMethods.Add(new MethodNode(methodName, nodesWithConnection));
            }



            return listOfMethods;
        }
        private string GetNameOfMethod(string methodCode)
        {
            string firstString = "MethodDeclarationSyntax";
            string lastString = "{";

            return methodCode.Substring(methodCode.IndexOf(firstString) - 22 + firstString.Length)
                           .Split(lastString.ToCharArray()).First();
        }
        // Method that return nodes with linked nodes based on control flow graph 
        private List<Node> GetNodesWithConnections(ControlFlowGraph controlFlowGraph)
        {
            List<Node> nodesWithConnection = new List<Node>();
            List<int> linkedNodes = new List<int>();
            List<string> nodesOperations = new List<string>();
            string nodeDecision = null;

            foreach (var node in controlFlowGraph.Blocks)
            {
                foreach (var operation in node.Operations)
                {
                    nodesOperations.Add(operation.Syntax.ToString());
                }
                if (node.BranchValue != null)
                {
                    nodeDecision = node.BranchValue.Syntax.ToString();
                }
                if (node.ConditionalSuccessor != null)
                {
                    linkedNodes.Add(node.ConditionalSuccessor.Destination.Ordinal);
                }
                if (node.FallThroughSuccessor != null)
                {
                    linkedNodes.Add(node.FallThroughSuccessor.Destination.Ordinal);
                }
                nodesWithConnection.Add(new Node(node.Ordinal, nodesOperations, nodeDecision, linkedNodes));
                linkedNodes = new List<int>();
                nodesOperations = new List<string>();
                nodeDecision = null;
            }
            return nodesWithConnection;
        }

        public Metrics GetMetricsAsync(string code)
        {
            int cyclomaticComplexity = CountCyclomaticComplexity(code);
            int linesOfCode = CountAllLinesOfCode(code);
            int numberOfAssignment = CountAssignment(code);
            int numberOfDecision = CountDecision(code);
            int linesOfUncommentedLines = GetUncommentedLines(code);

            // Tokens
            var tokens = GetTokens(code);
            int numberOfUniqueTokens = GetNumberOfUniqueTokens(code);
            int numberOfTokens = GetNumberOfTokens(code);

            int uniqueOperators = GetUniqueOperators(code);
            int operators = GetAllOperators(code);
            int operands = numberOfTokens - operators;
            int uniqueOperands = GetUniqueOperands(code);

            // HALSTEAD METRICS

            int n1 = uniqueOperators; // Number of distinct operators.
            int n2 = uniqueOperands; // Number of distinct operands.
            int N1 = operators; // Total number of occurrences of operators.
            int N2 = operands; // Total number of occurrences of operands.

            // Halstead Program Length – The total number of operator occurrences and the total number of operand occurrences. N = N1 + N2
            int N = N1 + N2;
            // Halstead Vocabulary – The total number of unique operator and unique operand occurrences. n = n1 + n2
            int n = n1 + n2;
            // Program Volume V = Size * (log2 vocabulary) = N * log2(n)
            double V = N * Math.Log(Convert.ToDouble(n), Convert.ToDouble(2));
            // Program Difficulty – This parameter shows how difficult to handle the program is.D = (n1 / 2) * (N2 / n2) || D = 1 / L
            double D = (n1 / 2) * (N2 / n2);
            // Program Level – To rank the programming languages, the level of abstraction provided by the programming language,
            // Program Level (L) is considered. The higher the level of a language, the less effort it takes to develop a program using that language. 
            double L = 1 / D;
            //Programming Effort – Measures the amount of mental activity needed to translate the existing algorithm into implementation in the specified program language.
            //E = V / L = D * V = Difficulty * Volume
            double E = D * V;
            // Language Level – Shows the algorithm implementation program language level. The same algorithm demands additional effort if it is written in a low-level program language. For example, it is easier to program in Pascal than in Assembler.
            // L’ = V / D / D lambda = L * V * = L2 * V
            double L_prim = V / D / D;
            // Intelligence Content – Determines the amount of intelligence presented (stated) in the program This parameter provides a measurement of program complexity, independently of the program language in which it was implemented.
            //I = V / D
            double I = V / D;
            // Programming Time – Shows time (in minutes) needed to translate the existing algorithm into implementation in the specified program language.
            // T = E / (f * S)
            int f = 60; // seconds - to - minutes factor
            int S = 18; // Stroud moment per seconds
            double T = E / f ;
            //int elementaryOperation = GetElementaryOperation(code);

            Metrics metrics = new Metrics(cyclomaticComplexity,
                                            linesOfCode,
                                            linesOfUncommentedLines,
                                            numberOfDecision,
                                            numberOfAssignment,
                                            numberOfTokens,
                                            numberOfUniqueTokens,
                                            uniqueOperators,
                                            operators,
                                            uniqueOperands,
                                            operands,
                                            N, n, V, D, L, E, L_prim, I, T);

            return metrics;
        }

        private int GetNumberOfTokens(string code)
        {
            var tokens = SyntaxFactory.ParseTokens(code);
            return tokens.Count();
        }

        private int GetNumberOfUniqueTokens(string code)
        {
            return WriteUniqueTokensToList(code).Count;
        }

        private List<string> WriteUniqueTokensToList(string code)
        {
            List<string> tokenTextValues = new List<string>();
            var tokens = SyntaxFactory.ParseTokens(code);

            foreach (var token in tokens)
            {
                var tokenTextValue = token.ValueText;

                if (!tokenTextValues.Contains(tokenTextValue))
                {
                    tokenTextValues.Add(tokenTextValue);
                }
            }
            return tokenTextValues;
        }
        private List<string> WriteTokensToList(string code)
        {
            List<string> tokenTextValues = new List<string>();
            var tokens = SyntaxFactory.ParseTokens(code);

            foreach (var token in tokens)
            {
                var tokenTextValue = token.ValueText;
                tokenTextValues.Add(tokenTextValue);

            }
            return tokenTextValues;
        }

        private int GetAllOperators(string code)
        {
            List<string> allOperators = new List<string>();
            var uniqueOperators = ExtractUniqueOperators(code);
            var tokens = WriteTokensToList(code);

            foreach (var token in tokens)
            {
                if (uniqueOperators.Contains(token))
                {
                    allOperators.Add(token);
                }
            }

            return allOperators.Count;
        }

        private int GetUniqueOperators(string code)
        {
            return ExtractUniqueOperators(code).Count;
        }

        private List<string> ExtractUniqueOperators(string code)
        {
            string path = Directory.GetCurrentDirectory() + "\\Services\\Judge\\CodeAnalyzeService\\CodeAnalyzeModels\\operators.txt";
            List<string> operators = new List<string>();

            var tokens = WriteTokensToList(code);

            string text = System.IO.File.ReadAllText(path);
            var operatorsFromFile = text.Split(';');

            foreach (var token in tokens)
            {
                if (operatorsFromFile.Contains(token) && !operators.Contains(token))
                {
                    operators.Add(token);
                }
            }


            return operators;
        }

        private int GetUniqueOperands(string code)
        {
            // int uniqueOperands = 0;
            List<string> uniqeOperands = new List<string>();
            List<string> operands = new List<string>();
            var tokens = WriteTokensToList(code);
            string path = Directory.GetCurrentDirectory() + "\\Services\\Judge\\CodeAnalyzeService\\CodeAnalyzeModels\\operators.txt"; List<string> operators = new List<string>();
            string text = System.IO.File.ReadAllText(path);
            var operatorsFromFile = text.Split(';');

            foreach (var token in tokens)
            {
                if (!operatorsFromFile.Contains(token))
                {
                    operands.Add(token);
                }
            }

            foreach (var token in tokens)
            {
                if (operands.Contains(token) && !uniqeOperands.Contains(token))
                {
                    uniqeOperands.Add(token);
                }
            }

            return uniqeOperands.Count;
        }

        private object GetTokens(string code)
        {
            var tokens = SyntaxFactory.ParseTokens(code);
            return tokens;
        }

        private int GetUncommentedLines(string code)
        {
            int numberOfLines = 0;
            string[] codeArray = code.Split(new string[] { "\n" }, StringSplitOptions.None);
            numberOfLines += (from line in codeArray
                              where !line.Contains("//") && !line.Equals("")
                              select line).Count();
            return numberOfLines;
        }

        private int CountAllLinesOfCode(string code)
        {
            int numberOfLines = 0;
            string[] codeArray = code.Split(new string[] { "\n" }, StringSplitOptions.None);
            numberOfLines += (from line in codeArray
                              where line.Length > 0
                              select line).Count();
            return numberOfLines;
        }

        private int CountDecision(string code)
        {
            var nodesWithConnection = CreateControlFlowGraph(code);
            return (from method in nodesWithConnection
                    from decision in method.node
                    where decision.nodeDecision != null
                    select method).Count();
        }

        private int CountAssignment(string code)
        {
            var nodesWithConnection = CreateControlFlowGraph(code);
            return (from method in nodesWithConnection
                    from node in method.node
                    where node.nodeOperation != null
                    from operation in node.nodeOperation
                    select node).Count();
        }

        private int CountCyclomaticComplexity(string code)
        {
            int cyclomaticComplexity = CountDecision(code);
            return cyclomaticComplexity + 1; // cyclomatic complexity is equal number of decision + 1
        }

        public List<CFG> CreateControlFlowGraphForDisplay(string code)
        {
            CFG cfg;
            List<CFG> CFGs = new List<CFG>();
            List<Nodes> nodes = new List<Nodes>();
            List<List<Nodes>> methodNodes = new List<List<Nodes>>();
            List<Edges> edges = new List<Edges>();
            List<List<Edges>> methodEdges = new List<List<Edges>>();

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            //var nodesWithLinks = CreateControlFlowGraph(code);
            var nodesWithLinksByMethod = CreateControlFlowGraph(code);

            foreach (var method in nodesWithLinksByMethod)
            {
                foreach (var node in method.node)
                {
                    if (node.nodeDecision != null)
                    {
                        nodes.Add(new Nodes(alpha[node.nodeNumber].ToString(), node.nodeDecision));
                    }
                    else if (node.nodeOperation != null)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var operations in node.nodeOperation)
                        {
                            sb.Append(operations);
                        }

                        nodes.Add(new Nodes(alpha[node.nodeNumber].ToString(), sb.ToString()));
                    }
                }
                methodNodes.Add(nodes);
                nodes = new List<Nodes>();
            }
            foreach (var method in nodesWithLinksByMethod)
            {
                foreach (var node in method.node)
                {
                    foreach (var linkedNode in node.linkedNodes)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(alpha[node.nodeNumber].ToString());
                        sb.Append(alpha[linkedNode].ToString());
                        edges.Add(new Edges(sb.ToString(), alpha[node.nodeNumber].ToString(), alpha[linkedNode].ToString(), "Jest połączony z"));
                    }
                }
                methodEdges.Add(edges);
                edges = new List<Edges>();
            }
            for (int index = 0; index < methodNodes.Count; index++)
            {
                cfg = new CFG(nodesWithLinksByMethod[index].methodName, methodNodes[index], methodEdges[index]);
                CFGs.Add(cfg);

            }
            return CFGs;
        }
    }
}
