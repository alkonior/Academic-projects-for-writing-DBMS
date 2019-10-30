﻿using System.Collections.Generic;

namespace IronySqlParser.AstNodes
{
    class SelectNode : SqlNode
    {

        public List<List<string>> ColumnIdList { get; set; }
        public List<List<string>> TableIdList { get; set; }
        public ExpressionNode WhereExpression { get; set; }

        public override void CollectInfoFromChild()
        {
            ColumnIdList = FindChildNodesByType<SelListNode>()[0].IdList;
            TableIdList = FindChildNodesByType<FromClauseNode>()[0].IdList;
            WhereExpression = FindChildNodesByType<WhereClauseNode>()[0].Expression;
        }
    }
}

