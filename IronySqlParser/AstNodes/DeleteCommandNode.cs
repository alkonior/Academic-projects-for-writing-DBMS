﻿using System.Collections.Generic;

using DataBaseType;

using TransactionManagement;

namespace IronySqlParser.AstNodes
{
    public class DeleteCommandNode : SqlCommandNode
    {
        public Id TableName { get; set; }
        public WhereClauseNode WhereClauseNode { get; set; }

        public override void CollectDataFromChildren ()
        {
            TableName = FindFirstChildNodeByType<IdNode>().Id;
            WhereClauseNode = FindFirstChildNodeByType<WhereClauseNode>();
        }

        public override List<TableLock> GetTableLocks () => new List<TableLock>() { new TableLock(LockType.Update, TableName.SimpleIds.ToString(), new System.Threading.ManualResetEvent(false)) };
    }
}
