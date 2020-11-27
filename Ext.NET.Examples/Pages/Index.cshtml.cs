using Ext.Net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ext.Net.Examples.Pages
{
    [DirectModel]
    public class IndexModel : PageModel
    {
        public TreeStore ExamplesTree;

        public void OnGet()
        {
            ExamplesTree = new TreeStore()
            {
                Sorters = new ItemCollection<Sorter>()
                {
                    new Sorter() { Property = "order" },
                    new Sorter() { Property = "text" }
                }
            };

            ExamplesTree.Root = new TreeBuilder().GetTreeStoreData();
        }

        [Direct]
        public IActionResult OnPostFetchExampleSources(string exampleRoot)
        {
            if (string.IsNullOrWhiteSpace(exampleRoot))
            {
                this.X().Toast("No example specified.");
            }
            else
            {
                var safeExampleRoot = exampleRoot.Replace("\\", "/");
                var curDir = Directory.GetCurrentDirectory();
                var fullPath = Path.Combine(curDir, "Pages", safeExampleRoot);
                var fullStaticPath = Path.Combine(curDir, "wwwroot", safeExampleRoot);

                if (safeExampleRoot.Contains(".."))
                {
                    this.X().Toast("Invalid example path: " + exampleRoot);
                }
                else if (!Directory.Exists(fullPath))
                {
                    this.X().Toast("Unable to find example path: " + exampleRoot);
                }
                else
                {
                    bool hasFiles = false;

                    var fileList = Directory.EnumerateFiles(fullPath).ToList();
                    if (Directory.Exists(fullStaticPath))
                    {
                        fileList.AddRange(Directory.EnumerateFiles(fullStaticPath));
                    }

                    foreach (var fileFullPath in fileList)
                    {
                        var prismLanguage = string.Empty;
                        var fileName = Path.GetFileName(fileFullPath);

                        if (fileName.EndsWith(".js"))
                        {
                            prismLanguage = "javascript";
                        }
                        else if (fileName.EndsWith(".cs"))
                        {
                            prismLanguage = "csharp";
                        }
                        else if (fileName.EndsWith(".cshtml"))
                        {
                            prismLanguage = "markup";
                        }

                        if (prismLanguage != string.Empty)
                        {
                            hasFiles = true;
                            this.X().AddScript("App.SourceWindowTabPanel.addTab({ " + "" +
                                "title: \"" + fileName + "\", " +
                                "scrollable: true, " +
                                "rounded: false, " +
                                "bodyPadding: 18, " +
                                "bodyStyle: \"background-color: #1f1f26\", " +
                                "html: \"<pre class=\\\"prism-highlight language-" + prismLanguage + " line-numbers\\\"><code>" +
                                GetSourceCode(fileFullPath) + "</code></pre>\" });");
                        }
                    }

                    if (hasFiles)
                    {
                        this.X().AddScript("Prism.highlightAllUnder(App.SourceWindowTabPanel.getBody().dom);");
                        this.X().AddScript("App.SourceWindowTabPanel.setActiveItem(0);");
                    }
                    else
                    {
                        this.X().Toast("Example has no source files! (??)");
                    }
                }
            }

            return this.Direct();
        }

        private string GetSourceCode(string path)
        {
            if (!path.StartsWith(Path.Combine(Directory.GetCurrentDirectory(), "Pages")) ||
                !System.IO.File.Exists(path))
            {
                return "access denied (invalid path)";
            }

            return System.IO.File.ReadAllText(path)
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "")
                .Replace("\n", "\\n")
                .Replace("<", "&lt;");
        }
    }
}
