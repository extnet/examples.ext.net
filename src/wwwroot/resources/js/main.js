// Example URL tracking

var getToken = function (url) {
    var host = "samples";

    return url.substr(host.length);
};

var addToken = function (tab) {
    if (tab.loader && tab.loader.url) {
        var token = getToken(tab.loader.url);

        Ext.History.add(token);
    } else if (tab.historyToken) {
        Ext.History.add(tab.historyToken);
    } else {
        Ext.History.add("");
    }
};

var checkProvidedUrl = function () {
    if (window.location.href.indexOf("#") > 0) {
        var directLink = window.location.href.substr(window.location.href.indexOf("#") + 1)
            .replace(/(\s|\<|&lt;|%22|%3C|\"|\'|&quot|&#039;|script|\/+(|[iI]ndex.cshtml)$)/gi, '');

        if (!Ext.isEmpty(directLink, false)) {
            var store = App.TreePanel.getStore(),
                match = store.findNode("path", "samples" + directLink);

            if (match !== null) {
                loadExample(match);
                selectExampleInTree(match);
            }
        }
    }
}

// Examples URL tracking (end)

var handleDirectLinkClick = function (button) {
    var panel = button.up('panel');

    if (panel && panel.loader && panel.loader.url) {
        window.open(location.href.replace(location.hash, "") + panel.loader.url);
    } else {
        Ext.toast("Error locating example URL.");
    }
}

var handleReloadClick = function (button) {
    var panel = button.up('panel');

    if (panel && panel.loader) {
        panel.loader.load();
    } else {
        Ext.toast("Error fetching example loader subsystem.");
    }
}

var handleSourceViewClick = function (button) {
    var sourcesPane = App.SourceWindowTabPanel,
        sourceWindow = App.SourceWindow;

    button.disable();
    sourcesPane.removeAll();

    if (sourcesPane.rendered) {
        sourcesPane.setLoading("Loading sources . . .");
    } else {
        sourcesPane.addListener({
            afterrender: {
                fn: function (panel) {
                    panel.setLoading("Loading sources . . .");
                },
                single: true
            }
        });
    }

    sourceWindow.show();

    var options = {
        callback: function () {
            button.enable();

            if (sourcesPane.isMasked()) {
                sourcesPane.setLoading(false);
            }
        }
    };

    App.direct.FetchExampleSources(button.up("panel").loader.url, options);
}

var handleTreeClick = function (tree, node) {
    if (node.isLeaf()) {
        loadExample(node);
    } else if (node.isExpanded()) {
        node.collapse();
    } else {
        node.expand();
    }
}

var filterTree = {
    filter: function (textField, newVal, oldVal) {
        var here = filterTree,
            tree = App.TreePanel,
            pattern = here.util.validReOrEsc(newVal),
            rootNode = tree.getRootNode();

        window.pattie = pattern;
        tree.mask("Updating...");
        tree.clearFilter();
        tree.collapseAll();

        if (newVal.length < 1) {
            tree.unmask();
            return;
        }

        rootNode.includeInFilters = here.util.eachNode(rootNode, here.util.recursiveMatch, pattern);
        tree.filterBy(function (node) {
            return node.includeInFilters
        });

        tree.unmask();
    },

    util: {
        eachNode: function (parent, task, extra_arg) {
            var retVal = false;
            for (var i = 0; i < parent.childNodes.length; i++) {
                if (task(parent.childNodes[i], extra_arg) === true) {
                    retVal = true;
                }
            }

            return retVal;
        },
        recursiveMark: function (node) {
            var here = filterTree.util;
            node.includeInFilters = true;
            here.eachNode(node, here.recursiveMark);
        },
        recursiveMatch: function (node, pattern) {
            var here = filterTree.util;

            delete node.includeInFilters;
            if (node.get("text").match(pattern)) {
                node.includeInFilters = true;
                here.recursiveMark(node, pattern);
            } else if (here.eachNode(node, here.recursiveMatch, pattern)) {
                node.includeInFilters = true;
            }

            return node.includeInFilters;
        },

        validReOrEsc: function (pattern) {
            try {
                "".match(pattern);
            }
            catch(e)
            {
                pattern = pattern.replace(/([\*\.\+\(\)\\\^\$\{\}\[\]])/g, "\\$1");
            }

            return new RegExp(pattern, "i");
        }
    }
}

var loadExample = function (record) {
    var examplesPane = App.ExamplesPane,
        isRecord = Ext.isDefined(record.get),
        name = isRecord ? record.get("text") : record["text"],
        path = isRecord ? record.get("path") : record["path"],
        existingTab = examplesPane.items.findBy(function (panel) {
            return panel.exampleKey === path;
        });

    if (existingTab === null) {
        examplesPane.addTab({
            title: name,
            tbar: {
                items: [{
                    iconCls: "x-md icon-xs md-icon-code",
                    tooltip: "Source&nbsp;code",
                    listeners: {
                        click: function () {
                            handleSourceViewClick(this);
                        }
                    }
                }, "->", {
                    iconCls: "x-md icon-xs md-icon-launch",
                    tooltip: "Open",
                    listeners: {
                        click: function () {
                            handleDirectLinkClick(this);
                        }
                    }
                }, {
                    iconCls: "x-md icon-xs md-icon-refresh",
                    tooltip: "Reload",
                    listeners: {
                        click: function () {
                            handleReloadClick(this);
                        }
                    }
                }]
            },
            loader: {
                url: path,
                autoLoad: true,
                renderer: "frame",
                listeners: {
                    beforeLoad: function (loader) {
                        if (loader.target) {
                            loader.target.mask("Loading example...");
                        }
                    },
                    load: function (loader) {
                        if (loader.target) {
                            loader.target.unmask();
                        }
                    }
                }
            },
            closable: true,
            exampleKey: path,
        })
    } else if (examplesPane.activeTab.exampleKey === path) {
        if (!examplesPane.activeTab.isMasked()) {
            examplesPane.activeTab.loader.load();
        }
    } else {
        examplesPane.setActiveTab(existingTab);
    }
}

var selectExampleInTree = function (node) {
    var tree = App.TreePanel,
        scrollAttempts = 0,
        selMdl = tree.getSelectionModel(),
        view = tree.getView();

    var delayedScrollIntoView = function (view, node) {
        if (view.getHeight() > 0) {
            view.scrollRowIntoView(node);
        } else if (scrollAttempts++ < 100) {
            Ext.defer(delayedScrollIntoView, 50, this, [view, node]);
        } else {
            Ext.toast("Unable to scroll selected example into view at the examples tree.");
        }
    }
    selMdl.select(node, false);

    if (node.parentNode) {
        node.bubble(function (currNode) { currNode.expand(); });
    }

    delayedScrollIntoView(view, node);
}

var switchTab = function (el, tab) {
    var node;

    addToken(tab);

    if (tab.loader && tab.loader.url) {
        node = App.TreePanel.getStore().findNode("path", tab.loader.url);

        if (node !== undefined) {
            selectExampleInTree(node);
        }
    }
}
var toggleRightNavMenu = function () {
    App.RightNavMenu[App.RightNavMenu.isHidden() ? "show" : "hide"]();
}

var toggleArchiveList = function (me, event) {
    event.preventDefault();
    Ext.get(me).toggleCls("expanded");
    Ext.get("archives").toggleCls("expanded");
}
