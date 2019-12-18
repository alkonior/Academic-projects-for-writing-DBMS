﻿using System.Collections.Generic;

using DataBaseType;

using TransactionManagement;

namespace IronySqlParser.AstNodes
{
    public class CreateTableCommandNode : SqlCommandNode
    {
        public Id TableName { get; set; }
        public List<FieldDefNode> FieldDefList { get; set; }

        public override void CollectDataFromChildren ()
        {
            TableName = new Id(FindFirstChildNodeByType<IdNode>().Id);
            FieldDefList = FindFirstChildNodeByType<FieldDefListNode>().FieldDefList;
        }

        public override List<TableLock> GetTableLocks () => new List<TableLock>() { };
    }
}
