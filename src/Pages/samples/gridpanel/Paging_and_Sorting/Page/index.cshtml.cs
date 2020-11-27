using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace Ext.Net.Examples.Pages.samples.gridpanel.paging_and_sorting.page
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        /// <summary>
        /// Action to handle the proxy request to fetch a range of rows.
        /// </summary>
        /// <param name="start">First record to return.</param>
        /// <param name="limit">Amount of records (page size).</param>
        /// <param name="sort">Sorting information: field and direction.</param>
        /// <returns></returns>
        public ContentResult OnGetReadData(int start, int limit, string sort)
        {
            var sortInfo = JsonSerializer.Deserialize<List<SortInfo>>(sort, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })[0];

            var data = Plant.PlantsPaging(
                start,
                limit,
                sortInfo.Property,
                sortInfo.Direction == "DESC" ? SortDirection.DESC : SortDirection.ASC
            );

            return Content(JsonSerializer.Serialize(data));
        }

        /// <summary>
        /// Unfolds the provided JSON representation of the sorter to apply to the list.
        /// </summary>
        public class SortInfo
        {

            public string Property { get; set; }
            public string Direction { get; set; }
        }

        /// <summary>
        /// Returned paging data structure.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Paging<T>
        {
            /// <summary>
            /// List of data entries.
            /// </summary>
            public List<T> Data { get; set; }

            /// <summary>
            /// Total amount of records so client-side paging mechanism can keep track of
            /// how many records it can request from server and to properly set up the
            /// paging toolbar.
            /// </summary>
            public int TotalRecords { get; set; }
        }

        /// <summary>
        /// Plants' example data class.
        /// </summary>
        private class Plant
        {
            public Plant(string common, string botanical, string zone, string colorCode, string light, double price, DateTime availability, bool indoor)
            {
                Common = common;
                Botanical = botanical;
                Zone = zone;
                ColorCode = colorCode;
                Light = light;
                Price = price;
                Availability = availability;
                Indoor = indoor;
            }

            public string Common { get; set; }
            public string Botanical { get; set; }
            public string Zone { get; set; }
            public string ColorCode { get; set; }
            public string Light { get; set; }
            public double Price { get; set; }
            public DateTime Availability { get; set; }
            public bool Indoor { get; set; }
            public string Notes
            {
                get => "The <b>" + Common + "</b> has the botanical name <i>" +
                    Botanical + "</i>, costing US$" + String.Format("{0:0.00}", Price) +
                    " and being more appropriate to be in a " + Light.ToLowerInvariant() +
                    " environment. It is fresh in stock, production since " + Availability.ToString("MMMM dd, yyyy") +
                    ". It is " + (Indoor ? "okay" : "<b>not recommended</b>") + " to be grown indoors." ;
            }

            /// <summary>
            /// Returns the sorted data chunk according to the paging and sorting information.
            /// </summary>
            /// <param name="start">Position in the sorted data to start the chunk.</param>
            /// <param name="limit">Amount of entries of the chunk of data.</param>
            /// <param name="sort">Sorting property name.</param>
            /// <param name="dir">Sorting direction.</param>
            /// <returns></returns>
            public static Paging<Plant> PlantsPaging(int start, int limit, string sort, SortDirection dir)
            {
                List<Plant> plants = GetPlants();

                if (!string.IsNullOrEmpty(sort))
                {
                    plants.Sort(delegate (Plant x, Plant y)
                    {
                        object a;
                        object b;

                        int direction = dir == SortDirection.DESC ? -1 : 1;

                        a = x.GetType().GetProperty(sort).GetValue(x, null);
                        b = y.GetType().GetProperty(sort).GetValue(y, null);

                        return CaseInsensitiveComparer.Default.Compare(a, b) * direction;
                    });
                }

                if ((start + limit) > plants.Count)
                {
                    limit = plants.Count - start;
                }

                List<Plant> rangePlants = (start < 0 || limit < 0) ? plants : plants.GetRange(start, limit);

                return new Paging<Plant>() { Data = rangePlants, TotalRecords = plants.Count };
            }

            private static List<Plant> GetPlants()
            {
                var year = DateTime.Now.Year - (DateTime.Now.Month <= 8 ? 1 : 0);

                return new List<Plant>
                {
                    new Plant("Bloodroot", "Sanguinaria canadensis", "4", "E7E7E7", "Mostly Shady", 2.44, new DateTime(year, 03, 15), true),
                    new Plant("Columbine", "Aquilegia canadensis", "3", "E7E7E7", "Mostly Shady", 9.37, new DateTime(year, 03, 06), true),
                    new Plant("Marsh Marigold", "Caltha palustris", "4", "F5F5F5", "Mostly Sunny", 6.81, new DateTime(year, 05, 17), false),
                    new Plant("Cowslip", "Caltha palustris", "4", "E7E7E7", "Mostly Shady", 9.90, new DateTime(year, 03, 06), true),
                    new Plant("Dutchman's-Breeches", "Dicentra cucullaria", "3", "E7E7E7", "Mostly Shady", 6.44, new DateTime(year, 01, 20), true),
                    new Plant("Ginger, Wild", "Asarum canadense", "3", "E7E7E7", "Mostly Shady", 9.03, new DateTime(year, 04, 18), true),
                    new Plant("Hepatica", "Hepatica americana", "4", "E7E7E7", "Mostly Shady", 4.45, new DateTime(year, 01, 26), true),
                    new Plant("Liverleaf", "Hepatica americana", "4", "E7E7E7", "Mostly Shady", 3.99, new DateTime(year, 01, 02), true),
                    new Plant("Jack-In-The-Pulpit", "Arisaema triphyllum", "4", "E7E7E7", "Mostly Shady", 3.23, new DateTime(year, 02, 01), true),
                    new Plant("Mayapple", "Podophyllum peltatum", "3", "E7E7E7", "Mostly Shady", 2.98, new DateTime(year, 06, 05), true),
                    new Plant("Phlox, Woodland", "Phlox divaricata", "3", "EEEEEE", "Sun or Shade", 2.80, new DateTime(year, 01, 22), false),
                    new Plant("Phlox, Blue", "Phlox divaricata", "3", "EEEEEE", "Sun or Shade", 5.59, new DateTime(year, 02, 16), false),
                    new Plant("Spring-Beauty", "Claytonia Virginica", "7", "E7E7E7", "Mostly Shady", 6.59, new DateTime(year, 02, 01), true),
                    new Plant("Trillium", "Trillium grandiflorum", "5", "EEEEEE", "Sun or Shade", 3.90, new DateTime(year, 04, 29), false),
                    new Plant("Wake Robin", "Trillium grandiflorum", "5", "EEEEEE", "Sun or Shade", 3.20, new DateTime(year, 02, 21), false),
                    new Plant("Violet, Dog-Tooth", "Erythronium americanum", "4", "E1E1E1", "Shade", 9.04, new DateTime(year, 02, 01), true),
                    new Plant("Trout Lily", "Erythronium americanum", "4", "E1E1E1", "Shade", 6.94, new DateTime(year, 03, 24), true),
                    new Plant("Adder's-Tongue", "Erythronium americanum", "4", "E1E1E1", "Shade", 9.58, new DateTime(year, 04, 13), true),
                    new Plant("Anemone", "Anemone blanda", "6", "E7E7E7", "Mostly Shady", 8.86, new DateTime(year, 12, 26), true),
                    new Plant("Grecian Windflower", "Anemone blanda", "6", "E7E7E7", "Mostly Shady", 9.16, new DateTime(year, 07, 10), true),
                    new Plant("Bee Balm", "Monarda didyma", "4", "E1E1E1", "Shade", 4.59, new DateTime(year, 05, 03), true),
                    new Plant("Bergamot", "Monarda didyma", "4", "E1E1E1", "Shade", 7.16, new DateTime(year, 04, 27), true),
                    new Plant("Black-Eyed Susan", "Rudbeckia hirta", "Annual", "FFFFFF", "Sunny", 9.80, new DateTime(year, 06, 18), false),
                    new Plant("Buttercup", "Ranunculus", "4", "E1E1E1", "Shade", 2.57, new DateTime(year, 06, 10), true),
                    new Plant("Crowfoot", "Ranunculus", "4", "E1E1E1", "Shade", 9.34, new DateTime(year, 04, 03), true),
                    new Plant("Butterfly Weed", "Asclepias tuberosa", "Annual", "FFFFFF", "Sunny", 2.78, new DateTime(year, 06, 30), false),
                    new Plant("Cinquefoil", "Potentilla", "Annual", "E1E1E1", "Shade", 7.06, new DateTime(year, 05, 25), true),
                    new Plant("Primrose", "Oenothera", "3 - 5", "FFFFFF", "Sunny", 6.56, new DateTime(year, 01, 30), false),
                    new Plant("Gentian", "Gentiana", "4", "EEEEEE", "Sun or Shade", 7.81, new DateTime(year, 05, 18), false),
                    new Plant("Blue Gentian", "Gentiana", "4", "EEEEEE", "Sun or Shade", 8.56, new DateTime(year, 05, 02), false),
                    new Plant("Jacob's Ladder", "Polemonium caeruleum", "Annual", "E1E1E1", "Shade", 9.26, new DateTime(year, 02, 21), true),
                    new Plant("Greek Valerian", "Polemonium caeruleum", "Annual", "E1E1E1", "Shade", 4.36, new DateTime(year, 07, 14), true),
                    new Plant("California Poppy", "Eschscholzia californica", "Annual", "FFFFFF", "Sunny", 7.89, new DateTime(year, 03, 27), false),
                    new Plant("Shooting Star", "Dodecatheon", "Annual", "E7E7E7", "Mostly Shady", 8.60, new DateTime(year, 05, 13), true),
                    new Plant("Snakeroot", "Cimicifuga", "Annual", "E1E1E1", "Shade", 5.63, new DateTime(year, 07, 11), true)
                };
            }
        }
    }
}
