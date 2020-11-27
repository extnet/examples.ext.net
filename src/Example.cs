using System.Collections.Generic;

namespace Ext.Net.Examples
{
    public class Example
    {
        public static readonly int DefaultOrder = 9999;
        public Example(string name, string path, uint idx)
        {
            Name = name;
            Path = path;
            Index = idx;
        }

        public Example(string name, string path, uint idx, int order) : this (name, path, idx)
        {
            Order = order;
        }

        public Example(string name, string path, uint idx, List<string> extra) : this(name, path, idx)
        {
            ExtraFiles = extra;
        }

        public Example(string name, string path, uint idx, List<string> extra, int order) : this(name, path, idx, extra)
        {
            Order = order;
        }

        public string Name { get; private set; }
        public string Path { get; private set; }
        public uint Index { get; private set; }
        public int Order { get; private set; } = DefaultOrder;

        public string SystemPath { get => "currentDirectory/" + WebPath; }
        public string WebPath { get => Path; }
        public string IndexFile { get => "Index.cshtml"; }
        public string CodeBehindFile { get => IndexFile + ".cs"; }
        public List<string> ExtraFiles { get; private set; }
    }
}
