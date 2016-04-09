using ConditionGraphPOC.Model.Edges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionGraphPOC.Model
{
    public class ClosingColor
    {
        public readonly string Name;
        public readonly ClosingColorDateEdge[] Dates;

        public ClosingColor(string name, DateNode[] dates)
        {
            Name = name;
        }
    }
}
