using System;
using System.Collections.Generic;
using System.Linq;

namespace Ext.Net.Examples.KitchenSink
{
    public class Restaurants
    {
        public static List<object> GetAllRestaurants()
        {
            const string DESCRIPTION = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed egestas gravida nibh, quis porttitor felis venenatis id. Nam sodales mollis quam eget venenatis. Aliquam metus lorem, tincidunt ut egestas imperdiet, convallis lacinia tortor.";
            Random random = new Random();

            return new List<Restaurant>
            {
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Cheesecake Factory", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "University Cafe", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Slider Bar", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Shokolaat", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Gordon Biersch", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Crepevine", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Creamery", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Old Pro", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Nola\'s", "Cajun"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "House of Bagels", "Bagels"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "The Prolific Oven", "Sandwiches"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "La Strada", "Italian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Buca di Beppo", "Italian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Pasta?", "Italian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Madame Tam", "Asian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Sprout Cafe", "Salad"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Pluto\'s", "Salad"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Junoon", "Indian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Bistro Maxine", "French"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Three Seasons", "Vietnamese"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Sancho\'s Taquira", "Mexican"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Reposado", "Mexican"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Siam Royal", "Thai"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Krung Siam", "Thai"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Thaiphoon", "Thai"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Tamarine", "Vietnamese"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Joya", "Tapas"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Jing Jing", "Chinese"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Patxi\'s Pizza", "Pizza"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Evvia Estiatorio", "Mediterranean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Cafe 220", "Mediterranean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Cafe Renaissance", "Mediterranean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Kan Zeman", "Mediterranean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Gyros-Gyros", "Mediterranean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Mango Caribbean Cafe", "Caribbean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Coconuts Caribbean Restaurant & Bar", "Caribbean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Rose & Crown", "English"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Baklava", "Mediterranean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Mandarin Gourmet", "Chinese"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Bangkok Cuisine", "Thai"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Darbar Indian Cuisine", "Indian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Mantra", "Indian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Janta", "Indian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Hyderabad House", "Indian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Starbucks", "Coffee"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Peet\'s Coffee", "Coffee"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Coupa Cafe", "Coffee"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Lytton Coffee Company", "Coffee"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Il Fornaio", "Italian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Lavanda", "Mediterranean"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "MacArthur Park", "American"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "St Michael\'s Alley", "Californian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Cafe Renzo", "Italian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Osteria", "Italian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Vero", "Italian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Cafe Renzo", "Italian"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Miyake", "Sushi"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Sushi Tomo", "Sushi"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Kanpai", "Sushi"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Pizza My Heart", "Pizza"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "New York Pizza", "Pizza"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "California Pizza Kitchen", "Pizza"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Round Table", "Pizza"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Loving Hut", "Vegan"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Garden Fresh", "Vegan"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Cafe Epi", "French"),
                new Restaurant(DESCRIPTION, random.Next(0, 6), "Tai Pan", "Chinese")
            }.ToList<object>();
        }
    }
}
