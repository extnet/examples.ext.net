using System.Collections.Generic;

namespace Ext.Net.Examples
{
    public class Category
    {
        public Category(string name)
        {
            Name = name;
            SubCategories = new List<Category>();
            Examples = new List<Example>();
        }

        public Category(string name, int order) : this(name)
        {
            Order = order;
        }

        public string Name { get; private set; }

        public int Order { get; private set; } = Example.DefaultOrder;

        public List<Category> SubCategories { get; set; }

        public List<Example> Examples { get; set; }
    }
}
