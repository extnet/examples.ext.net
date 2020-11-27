using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Ext.Net;

namespace Ext.Net.Examples.Pages.samples.treepanel.basic.built_in_codebehind
{
    public class IndexModel : PageModel
    {
        public TreePanel CodeTree = new TreePanel()
        {
            Id = "TreePanel1",
            Title = "Catalog",
            IconCls = "x-md md-icon-menu-book",
            Width = 480,
            Height = 600,
            Frame = true,
            Scrollable = true,
            Tbar = new List<Component>()
            {
                new Button()
                {
                    Text = "Expand All",
                    Listeners = new ButtonListenerCollection()
                    {
                        Click = new ClickListener() { Handler = "App.TreePanel1.expandAll()" }
                    }
                },
                new Button()
                {
                    Text = "Collapse All",
                    Listeners = new ButtonListenerCollection()
                    {
                        Click = new ClickListener() { Handler = "App.TreePanel1.collapseAll()" }
                    }
                }
            },
            Bbar = new List<Component>()
            {
                new Label()
                {
                    Id = "lblStatus",
                    Html = "&nbsp;"
                }
            },
            Root = BuildTree(),
            Listeners = new TreePanelListenerCollection()
            {
                ItemClick = new ItemClickListener() { Handler = "App.lblStatus.setHtml('Node Selected: <strong>' + record.get('text') + '</strong>');" },
                AfterItemExpand = new AfterItemExpandListener()
                {
                    Handler = "App.lblStatus.setHtml('Node Expanded: <strong>' + node.get('text') + '</strong>');",
                    Buffer = 30
                },
                AfterItemCollapse = new AfterItemCollapseListener()
                {
                    Handler = "App.lblStatus.setHtml('Node Collapsed: <strong>' + node.get('text') + '</strong>');",
                    Buffer = 30
                }
            }
        };

        public class Composer
        {
            public Composer(string name) { this.Name = name; }
            public string Name { get; set; }

            private List<Composition> compositions;

            public List<Composition> Compositions
            {
                get
                {
                    if (this.compositions == null)
                    {
                        this.compositions = new List<Composition>();
                    }

                    return this.compositions;
                }
            }
        }

        public class Composition
        {
            public Composition() { }

            public Composition(CompositionType type)
            {
                this.Type = type;
            }

            public CompositionType Type { get; set; }

            private List<Piece> pieces;

            public List<Piece> Pieces
            {
                get
                {
                    if (this.pieces == null)
                    {
                        this.pieces = new List<Piece>();
                    }

                    return this.pieces;
                }
            }
        }

        public class Piece
        {
            public Piece() { }

            public Piece(string title)
            {
                this.Title = title;
            }

            public string Title { get; set; }
        }

        public enum CompositionType
        {
            Concertos,
            Quartets,
            Sonatas,
            Symphonies
        }

        public static List<Composer> GetData()
        {
            Composer beethoven = new Composer("Beethoven");

            Composition beethovenConcertos = new Composition(CompositionType.Concertos);
            Composition beethovenQuartets = new Composition(CompositionType.Quartets);
            Composition beethovenSonatas = new Composition(CompositionType.Sonatas);
            Composition beethovenSymphonies = new Composition(CompositionType.Symphonies);

            beethovenConcertos.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "No. 1 - C" },
                new Piece{ Title = "No. 2 - B-Flat Major" },
                new Piece{ Title = "No. 3 - C Minor" },
                new Piece{ Title = "No. 4 - G Major" },
                new Piece{ Title = "No. 5 - E-Flat Major" }
            });

            beethovenQuartets.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "Six String Quartets" },
                new Piece{ Title = "Three String Quartets" },
                new Piece{ Title = "Grosse Fugue for String Quartets" }
            });

            beethovenSonatas.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "Sonata in A Minor" },
                new Piece{ Title = "sonata in F Major" }
            });

            beethovenSymphonies.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "No. 1 - C Major" },
                new Piece{ Title = "No. 2 - D Major" },
                new Piece{ Title = "No. 3 - E-Flat Major" },
                new Piece{ Title = "No. 4 - B-Flat Major" },
                new Piece{ Title = "No. 5 - C Minor" },
                new Piece{ Title = "No. 6 - F Major" },
                new Piece{ Title = "No. 7 - A Major" },
                new Piece{ Title = "No. 8 - F Major" },
                new Piece{ Title = "No. 9 - D Minor" }
            });

            beethoven.Compositions.AddRange(new List<Composition>
            {
                beethovenConcertos,
                beethovenQuartets,
                beethovenSonatas,
                beethovenSymphonies
            });

            Composer brahms = new Composer("Brahms");

            Composition brahmsConcertos = new Composition(CompositionType.Concertos);
            Composition brahmsQuartets = new Composition(CompositionType.Quartets);
            Composition brahmsSonatas = new Composition(CompositionType.Sonatas);
            Composition brahmsSymphonies = new Composition(CompositionType.Symphonies);

            brahmsConcertos.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "Violin Concerto" },
                new Piece{ Title = "Double Concerto - A Minor" },
                new Piece{ Title = "Piano Concerto No. 1 - D Minor" },
                new Piece{ Title = "Piano Concerto No. 2 - B-Flat Major" }
            });

            brahmsQuartets.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "Piano Quartet No. 1 - G Minor" },
                new Piece{ Title = "Piano Quartet No. 2 - A Major" },
                new Piece{ Title = "Piano Quartet No. 3 - C Minor" },
                new Piece{ Title = "Piano Quartet No. 3 - B-Flat Minor" }
            });

            brahmsSonatas.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "Two Sonatas for Clarinet - F Minor" },
                new Piece{ Title = "Two Sonatas for Clarinet - E-Flat Major" }
            });

            brahmsSymphonies.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "No. 1 - C Minor" },
                new Piece{ Title = "No. 2 - D Minor" },
                new Piece{ Title = "No. 3 - F Major" },
                new Piece{ Title = "No. 4 - E Minor" }
            });

            brahms.Compositions.AddRange(new List<Composition>
            {
                brahmsConcertos,
                brahmsQuartets,
                brahmsSonatas,
                brahmsSymphonies
            });

            Composer mozart = new Composer("Mozart");

            Composition mozartConcertos = new Composition(CompositionType.Concertos);

            mozartConcertos.Pieces.AddRange(new List<Piece>
            {
                new Piece{ Title = "Piano Concerto No. 12" },
                new Piece{ Title = "Piano Concerto No. 17" },
                new Piece{ Title = "Clarinet Concerto" },
                new Piece{ Title = "Violin Concerto No. 5" },
                new Piece{ Title = "Violin Concerto No. 4" }
            });

            mozart.Compositions.Add(mozartConcertos);

            return new List<Composer> { beethoven, brahms, mozart };
        }

        public static TreeNode BuildTree()
        {
            var rootNode = new TreeNode()
            {
                Text = "Composers",
                Expanded = true,
                Children = new List<TreeNode>()
            };

            foreach (Composer composer in GetData())
            {
                var composerNode = new TreeNode()
                {
                    Text = composer.Name,
                    IconCls = "x-md md-icon-person",
                    Children = new List<TreeNode>()
                };

                rootNode.Children.Add(composerNode);

                foreach (Composition composition in composer.Compositions)
                {
                    var compositionNode = new TreeNode()
                    {
                        Text = composition.Type.ToString(),
                        Children = new List<TreeNode>()
                    };

                    composerNode.Children.Add(compositionNode);

                    foreach (Piece piece in composition.Pieces)
                    {
                        var pieceNode = new TreeNode()
                        {
                            Text = piece.Title,
                            IconCls = "x-md md-icon-music-note",
                            Leaf = true
                        };

                        compositionNode.Children.Add(pieceNode);
                    }
                }
            }

            return rootNode;
        }

        public void OnGet()
        {
        }
    }
}
