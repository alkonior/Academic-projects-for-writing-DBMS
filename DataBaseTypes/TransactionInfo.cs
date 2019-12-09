﻿using System;
using System.Collections.Generic;
using System.Text;

using TransactionManagement;
using ProtoBuf;

namespace DataBaseType
{
    [ProtoContract]
    public class TransactionInfo
    {
        [ProtoMember(1)]
        public virtual List<string> Name { get; set; }

        [ProtoMember(2)]
        public virtual Guid Guid { get; set; }

        [ProtoMember(3)]
        public virtual DateTime StartTime { get; set; }

        [ProtoMember(4)]
        public virtual DateTime EndTime { get; set; }

        [ProtoMember(5)]
        public virtual List<OperationResult<Table>> OperationsResults { get; set; }

        [ProtoMember(6)]
        public virtual TransactionLocksInfo LocksInfo { get; set; }

        public TransactionInfo (TransactionLocksInfo transactionLocksInfo) => LocksInfo = transactionLocksInfo
            ?? throw new ArgumentNullException(nameof(transactionLocksInfo));

        public TransactionInfo (List<string> name,
                               Guid guid,
                               DateTime startTime,
                               DateTime endTime,
                               List<OperationResult<Table>> operationsResults,
                               TransactionLocksInfo locksInfo)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Guid = guid;
            StartTime = startTime;
            EndTime = endTime;
            OperationsResults = operationsResults ?? throw new ArgumentNullException(nameof(operationsResults));
            LocksInfo = locksInfo ?? throw new ArgumentNullException(nameof(locksInfo));
        }

        public TransactionInfo ()
        {
        }

        public override string ToString ()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("Name:");

            foreach (var simpleId in Name)
            {
                stringBuilder.Append(simpleId);
                stringBuilder.Append(".");
            }
            stringBuilder.Append("\n");
            stringBuilder.Append($"Guid {Guid}\n");
            stringBuilder.Append($"Start Time {StartTime}\n");
            stringBuilder.Append($"End Time {EndTime}\n");

            foreach (var opResult in OperationsResults)
            {
                stringBuilder.Append($"{opResult}\n");
            }

            return stringBuilder.ToString();
        }
    }

    [ProtoContract]
    public class SqlSequenceResult
    {
        [ProtoMember(1)]
        public List<TransactionInfo> Answer { get; private set; }

        public SqlSequenceResult () => Answer = new List<TransactionInfo>();

        public SqlSequenceResult (List<TransactionInfo> answer) => Answer = answer ?? throw new ArgumentNullException(nameof(answer));

        public override string ToString ()
        {
            var stringBuilder = new StringBuilder();

            foreach (var trInf in Answer)
            {
                stringBuilder.Append(trInf.ToString() + "\n");
            }

            return stringBuilder.ToString();
        }
    }
}