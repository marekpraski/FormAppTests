using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestsFormApp
{
    public enum AccessType {READ_ONLY, EDIT }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            populateTreeview();
            listAllTreenodeTexts();
        }

        private void populateTreeview()
        {
            TreeNode[] parentNodes = new TreeNode[4];
            for (int i = 0; i < parentNodes.Length; i++)
            {
                TreeNode node = new TreeNode("parent " + i.ToString());
                parentNodes[i] = node;
                if(i%2 == 0)
                {
                    node.ForeColor = Color.Red;
                    node.Tag = AccessType.READ_ONLY;
                }
                else
                    node.Tag = AccessType.EDIT;
            }
            treeView1.Nodes.AddRange(parentNodes);

            int childIndex = 0;
            foreach(TreeNode parent in parentNodes)
            {
                TreeNode child = new TreeNode("child " + childIndex.ToString());
                parent.Nodes.Add(child);
                child.Tag = AccessType.EDIT;
                childIndex++;
            }
        }

        private void listAllTreenodeTexts()
        {
            List<string> treenodeTexts = new List<string>();
            foreach(TreeNode node in treeView1.Nodes)
            {
                treenodeTexts.Add(node.Text);
                treenodeTexts.AddRange(getChildren(node));
            }
        }

        private IEnumerable<string> getChildren(TreeNode node)
        {
            List<string> texts = new List<string>();
            foreach(TreeNode child in node.Nodes)
            {
                texts.Add(child.Text);
            }
            return texts;
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if ((AccessType)node.Tag == AccessType.READ_ONLY)
            {
                node.ForeColor = Color.Red;
                node.BackColor = Color.Black;
            }
        }
    }
}
