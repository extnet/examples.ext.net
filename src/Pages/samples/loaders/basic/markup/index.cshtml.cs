using Ext.Net.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Ext.Net.Examples.Pages.samples.loaders.basic.markup
{
    public class IndexModel : PageModel
    {
        public IndexModel(ISerializationService serializer)
        {
            _serializer = serializer;
        }

        public void OnGet()
        {
        }

        private ISerializationService _serializer;

        public IActionResult OnGetComponent()
        {
            var button = new Button()
            {
                Text = "Dynamic Button",
                Handler = "Ext.toast('Clicked dynamic button generated at " + DateTime.Now.ToLongTimeString() + "')"
            };

            var serializedButton = new StringBuilder();

            using (var writer = new StringWriter(serializedButton))
            {
                _serializer.Serialize<Button>(button, writer);
            }

            return Content(serializedButton.ToString(), "application/json", Encoding.UTF8);
        }

        public IActionResult OnGetHtmlContent()
        {
            var htmlResult = "<b>Dynamic, bold content generated at " + DateTime.Now.ToLongTimeString() + ".</b>";

            return Content(htmlResult, "text/html", Encoding.UTF8);
        }

        public IActionResult OnGetJsonContent()
        {
            var dataJson = "{ \"LastUpdate\": \"" + DateTime.Now.ToLongTimeString() + "\", \"Cast\": [ { \"FirstName\": \"Homer\", \"LastName\": \"Simpson\" }, { \"FirstName\": \"Marjorie\", \"LastName\": \"Simpson\" }, { \"FirstName\": \"Bart\", \"LastName\": \"Simpson\" }, { \"FirstName\": \"Lisa\", \"LastName\": \"Simpson\" } ] }";

            var data = new
            {
                LastUpdate = DateTime.Now.ToLongTimeString(),
                Cast = new[]
                {
                    new { FirstName = "Homer", LastName = "Simpson" },
                    new { FirstName = "Marge", LastName = "Simpson" },
                    new { FirstName = "Bart", LastName = "Simpson" },
                    new { FirstName = "Lisa", LastName = "Simpson" },
                    new { FirstName = "Maggie", LastName = "Simpson" },
                    new { FirstName = "Abraham", LastName = "Simpson" },
                    new { FirstName = "Apu", LastName = "Nahasapeemapetilon" },
                    new { FirstName = "Barney", LastName = "Gumble" },
                    new { FirstName = "Clancy", LastName = "Wiggum" },
                    new { FirstName = "Dewey", LastName = "Largo" },
                    new { FirstName = "Edna", LastName = "Krabappel" },
                    new { FirstName = "Janey", LastName = "Powell" },
                    new { FirstName = "Jasper", LastName = "Beardly" },
                    new { FirstName = "Kent", LastName = "Brockman" },
                    new { FirstName = "Lenny", LastName = "Leonard" },
                    new { FirstName = "Moe", LastName = "Szyslak" },
                    new { FirstName = "Ned", LastName = "Flanders" },
                    new { FirstName = "Patty", LastName = "Bouvier" },
                    new { FirstName = "Ralph", LastName = "Wiggum" },
                    new { FirstName = "Timothy", LastName = "Lovejoy" }
                }
            };

            return Content(JsonSerializer.Serialize(data), "application/json", Encoding.UTF8);
        }
    }
}
