using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels
{
    public class Node
    {
        public Node(int nodeNumber, List<string> nodeOperation, string nodeDecision, List<int> linkedNodes)
        {
            this.nodeNumber = nodeNumber;
            this.nodeOperation = nodeOperation;
            this.nodeDecision = nodeDecision;
            this.linkedNodes = linkedNodes;
        }

        public int nodeNumber { get; set; }
        public List<string> nodeOperation { get; set; }
        public string nodeDecision { get; set; }
        public List<int> linkedNodes { get; set; }
    }
    public class MethodNode
    {
        public MethodNode(string methodName, List<Node> node)
        {
            this.methodName = methodName;
            this.node = node;
        }

        public string methodName { get; set; }
        public List<Node> node { get; set; }
    }
}
