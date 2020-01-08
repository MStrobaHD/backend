using ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESA_api.Services.Judge.CodeAnalyzeService
{
    public class CodeAnalyzeService : ICodeAnalyzeService
    {
        public CodeAnalyzeService()
        {
        }

        public List<Node> CreateControlFlowGraph(string source)
        {
            CSharpParseOptions options = CSharpParseOptions.Default
           .WithFeatures(new[] { new KeyValuePair<string, string>("flow-analysis", "") });

            var tree = CSharpSyntaxTree.ParseText(source, options);
            var compilation = CSharpCompilation.Create("c", new[] { tree });
            var model = compilation.GetSemanticModel(tree, ignoreAccessibility: true);
            var methodBodySyntax = tree.GetCompilationUnitRoot().DescendantNodes().OfType<BaseMethodDeclarationSyntax>().Last();
            var controlFlowGraph = ControlFlowGraph.Create(methodBodySyntax, model);
            var nodesWithConnection = GetNodesWithConnections(controlFlowGraph);

            return nodesWithConnection;
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
            //int linesOfCode = CountLinesOfCode(code);
            int numberOfAssignment = CountAssignment(code);
            int numberOfDecision = CountDecision(code);
            int linesOfUncommentedLines = GetUncommentedLines(code);
            //int elementaryOperation = GetElementaryOperation(code);

            Metrics metrics = new Metrics(cyclomaticComplexity, linesOfCode, linesOfUncommentedLines, numberOfDecision, numberOfAssignment);

            return metrics;
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
            return (from node in nodesWithConnection
                    where node.nodeDecision != null
                    select node).Count();
        }

        private int CountAssignment(string code)
        {
            var nodesWithConnection = CreateControlFlowGraph(code);
            return (from node in nodesWithConnection
                    where node.nodeOperation != null
                    from operation in node.nodeOperation
                    select node).Count();
        }

        private int CountCyclomaticComplexity(string code)
        {
            int cyclomaticComplexity = CountDecision(code);
            return cyclomaticComplexity + 1; // cyclomatic complexity is equal number of decision + 1
        }

        public CFG CreateControlFlowGraphForDisplay(string code)
        {
            List<Nodes> nodes = new List<Nodes>();
            List<Edges> edges = new List<Edges>();
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            var nodesWithLinks = CreateControlFlowGraph(code);

            foreach (var node in nodesWithLinks)
            {
                if (node.nodeDecision != null)
                {
                    nodes.Add(new Nodes(alpha[node.nodeNumber].ToString(), node.nodeDecision));
                } else if (node.nodeOperation != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var operations in node.nodeOperation)
                    {
                        sb.Append(operations);
                    }
                    
                    nodes.Add(new Nodes(alpha[node.nodeNumber].ToString(), sb.ToString()));
                }
            }
            foreach (var node in nodesWithLinks)
            {
                foreach (var linkedNode in node.linkedNodes)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(alpha[node.nodeNumber].ToString());
                    sb.Append(alpha[linkedNode].ToString());
                    edges.Add(new Edges(sb.ToString(), alpha[node.nodeNumber].ToString(), alpha[linkedNode].ToString(), "Jest połączony z"));
                }
            }

            CFG cfg = new CFG(nodes, edges);
            return cfg;
        }
    }
}
