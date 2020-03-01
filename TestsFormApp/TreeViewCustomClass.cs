using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestsFormApp
{
    enum SelectHighlightColors { RED, GREEN}
    class TreeViewCustomClass : TreeView
    {

        public TreeViewCustomClass()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            TreeNodeStates state = e.State;
            Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;
            Color fore = e.Node.ForeColor;
            Color hightlightColor = getHighlightColor(e.Node);
            if (fore == Color.Empty) fore = e.Node.TreeView.ForeColor;
            if (e.Node == e.Node.TreeView.SelectedNode)
            {
                fore = SystemColors.HighlightText;
                e.Graphics.FillRectangle(new SolidBrush(hightlightColor), e.Bounds);
                ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, fore, hightlightColor);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, hightlightColor, TextFormatFlags.GlyphOverhangPadding);
            }
            else
            {
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, fore, TextFormatFlags.GlyphOverhangPadding);
            }
        }

        private Color getHighlightColor(TreeNode node)
        {
            if ((AccessType)node.Tag == AccessType.READ_ONLY)
                return Color.Red;
            return Color.Blue;
        }
    }
}
