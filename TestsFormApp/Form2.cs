using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TestsFormApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            populateTreeview();
        }



        private void populateTreeview()
        {
            string path = @"C:/Turow";

            this.treeView1.Nodes.Add(getSubdirectories(path));

        }


        private TreeNode getSubdirectories(string path)
        {
            TreeNode result = new TreeNode(Path.GetFileName(path));
            foreach (var subdirectory in Directory.GetDirectories(path))
            {
                result.Nodes.Add(getSubdirectories(subdirectory));
            }

            return result;
        }


    }
}
