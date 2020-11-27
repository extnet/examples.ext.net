using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ext.Net.Examples
{
    public class ExampleTreeNode
    {
        public ExampleTreeNode()
        {
            Children = new List<ExampleTreeNode>();
        }

        public string Text { get; set; }
        public string IconCls { get; set; }
        public int Order { get; set; } = Example.DefaultOrder;
        public string Path { get; set; }
        public uint ExampleIndex { get; set; }
        public List<ExampleTreeNode> Children { get; set; }
        public bool Leaf { get; set; }
    }
}
