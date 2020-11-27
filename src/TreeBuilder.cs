using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;

namespace Ext.Net.Examples
{
    public class TreeBuilder
    {
        private static TextInfo TextInfoInstance;

        public static string PrettifyValue(string value)
        {
            var retVal = value.Replace('_', ' ');

            if (TextInfoInstance == null)
            {
                TextInfoInstance = new CultureInfo("en-US", false).TextInfo;
            }
            return TextInfoInstance.ToTitleCase(retVal);
        }

        private Category EnumerateExamples()
        {
            var examples = new Category("Examples");

            var webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "Pages");
            var examplesRootPath = Path.Combine(webRootPath, "samples");

            var globalExampleIndex = 1u;

            var categoryOrdering = getOrder(examplesRootPath);

            foreach (var dir in Directory.EnumerateDirectories(examplesRootPath))
            {
                var cat = Path.GetFileName(dir);
                var prettyCat = PrettifyValue(cat);
                var order = categoryOrdering.IndexOf(cat.ToLowerInvariant());
                var category = order < 0 ? new Category(prettyCat) : new Category(prettyCat, order);

                var subcategoryOrdering = getOrder(dir);

                foreach (var subDir in Directory.EnumerateDirectories(dir))
                {
                    var subCat = Path.GetFileName(subDir);
                    var prettySubCat = PrettifyValue(subCat);
                    var subOrder = subcategoryOrdering.IndexOf(subCat.ToLowerInvariant());
                    var subCategory = subOrder < 0 ? new Category(prettySubCat) : new Category(prettySubCat, subOrder);

                    var exampleOrdering = getOrder(subDir);

                    foreach (var exampleDir in Directory.EnumerateDirectories(subDir))
                    {
                        var exampleName = Path.GetFileName(exampleDir);
                        var prettyExampleName = PrettifyValue(exampleName);
                        var exampleRelativePath = exampleDir.Substring(webRootPath.Length + 1).Replace(Path.DirectorySeparatorChar, '/');
                        if (File.Exists(Path.Combine(exampleDir, "index.cshtml")))
                        {
                            var exampleOrder = exampleOrdering.IndexOf(exampleName.ToLowerInvariant());

                            if (exampleOrder < 0)
                            {
                                subCategory.Examples.Add(new Example(
                                    prettyExampleName,
                                    exampleRelativePath,
                                    globalExampleIndex++
                                ));
                            }
                            else
                            {
                                subCategory.Examples.Add(new Example(
                                    prettyExampleName,
                                    exampleRelativePath,
                                    globalExampleIndex++,
                                    exampleOrder
                                ));
                            }
                        }
                    }

                    if (subCategory.Examples.Count > 0)
                    {
                        category.SubCategories.Add(subCategory);
                    }
                }

                if (category.Examples.Count > 0 || category.SubCategories.Count > 0)
                {
                    examples.SubCategories.Add(category);
                }
            }

            return examples;
        }

        private ExampleTreeNode MapExamples(Category category)
        {
            var node = new ExampleTreeNode()
            {
                Text = category.Name,
                IconCls = "x-md",
                Order = category.Order,
                Leaf = false
            };

            foreach (var subCategory in category.SubCategories)
            {
                node.Children.Add(MapExamples(subCategory));
            }

            foreach (var example in category.Examples)
            {
                node.Children.Add(new ExampleTreeNode()
                {
                    Leaf = true,
                    IconCls = "x-md",
                    Order = example.Order,
                    Text = example.Name,
                    Path = example.WebPath,
                    ExampleIndex = example.Index
                });
            }

            return node;
        }

        private List<string> getOrder(string path)
        {
            var ordering = new List<string>();

            var configxml = Path.Combine(path, "config.xml");
            if (File.Exists(configxml))
            {
                var xml = new XmlDocument();
                xml.Load(configxml);

                var orderTag = xml.DocumentElement.SelectSingleNode("/example/order");

                if (orderTag != null)
                {
                    foreach (XmlNode node in orderTag.ChildNodes)
                    {
                        if (node.Name.ToLowerInvariant() == "folder" && node.Attributes["name"] != null)
                        {
                            ordering.Add(node.Attributes["name"].Value.ToLowerInvariant());
                        }
                    }
                }
            }

            return ordering;
        }

        public ExampleTreeNode GetTreeStoreData() => MapExamples(EnumerateExamples());
    }
}
