using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TTYRatServer
{
    public partial class TreeView : Form
    {
        
        
        public TreeView()
        {
            
            InitializeComponent();
            initTreeView();
        }

        private void initTreeView()
        {
                
                treeView1.Nodes.Clear();
                var stack = new Stack<TreeNode>();
                var rootDirectory = new DirectoryInfo("c:/Users/Saturne/Desktop/");
                var node = new TreeNode(rootDirectory.Name) { Tag = rootDirectory };
                stack.Push(node);
            
                while (stack.Count > 0)
                {
                    var currentNode = stack.Pop();
                    var directoryInfo = (DirectoryInfo)currentNode.Tag;
                    foreach (var directory in directoryInfo.GetDirectories())
                    {
                        var childDirectoryNode = new TreeNode(directory.Name) { Tag = directory };
                        currentNode.Nodes.Add(childDirectoryNode);
                        stack.Push(childDirectoryNode);
                    }
                    foreach (var file in directoryInfo.GetFiles())
                        currentNode.Nodes.Add(new TreeNode(file.Name));
                }
            
                treeView1.Nodes.Add(node);
            
        }

        private void helloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}