﻿using System.Collections.Generic;

namespace IronySqlParser.AstNodes
{
    internal class FieldDefListNode : SqlNode
    {
        public List<FieldDefNode> FieldDefList { get; set; }

        public override void CollectInfoFromChild() => FieldDefList = FindAllChildNodesByType<FieldDefNode>();
    }
}
