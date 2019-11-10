﻿using System.Collections.Generic;

namespace IronySqlParser.AstNodes
{
    internal class AssignmentListNode : SqlNode
    {
        public List<AssignmentNode> Assignments { get; set; }

        public override void CollectInfoFromChild() => Assignments = FindAllChildNodesByType<AssignmentNode>();
    }
}
