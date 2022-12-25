namespace Variant8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.Name = "MDI";
            f.MdiParent = this;

            PictureBox pictureBox = new PictureBox();
            f.Controls.Add(pictureBox);
            f.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] form = MdiChildren;
            foreach(Form f in form)
                f.Close();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = this.ActiveMdiChild.Controls[0] as RichTextBox;
            rtb.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = this.ActiveMdiChild.Controls[0] as RichTextBox;
            rtb.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = this.ActiveMdiChild.Controls[0] as RichTextBox;
            rtb.Paste();
        }
    }
}