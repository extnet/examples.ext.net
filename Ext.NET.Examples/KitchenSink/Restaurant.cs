namespace Ext.Net.Examples.KitchenSink
{
    public class Restaurant
    {
        public Restaurant(string desc, int rate, string nme, string cuis)
        {
            Description = desc;
            Rating = rate;
            Name = nme;
            Cuisine = cuis;
        }

        public string Description { get; private set; }
        public int Rating { get; private set; }
        public string Name { get; private set; }
        public string Cuisine { get; private set; }
    }
}
