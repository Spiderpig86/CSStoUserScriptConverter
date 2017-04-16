using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSStoUserScript
{
    public partial class Converter : Form
    {
        //add run-at next update, add multiple includes 
        string css, fileLoc = "";
        string heading = Constants.SCRIPT_HEADING;
        string name = Constants.SCRIPT_NAME;
        string description = Constants.SCRIPT_DESCRIPTION;
        string author = Constants.SCRIPT_AUTHOR;
        string homepage = Constants.SCRIPT_HOMEPAGE;
        string include = Constants.SCRIPT_INCLUDE;
        string version = Constants.SCRIPT_VERSION;
        string endheading = Constants.SCRIPT_END_HEADING;
        string javascript = Constants.SCRIPT_CHECK;

        public Converter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox2.Text = generateScript();
        }

        private string generateScript()
        {
            if (rbChrome.Checked == true) {
            string script = "";
            string[] includeList;
            include = txtInclude.Text;
            include.Trim();
            includeList = include.Split(',');
            include = "";
            foreach (string url in includeList)
            {
                StringBuilder sb2 = new StringBuilder();
                sb2.Append(Constants.SCRIPT_INCLUDE + url + Environment.NewLine).ToString() ;
                include += sb2.ToString();
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(heading + Environment.NewLine +
                name + Environment.NewLine +
                description + Environment.NewLine +
                author + Environment.NewLine +
                homepage + Environment.NewLine +
                include + Environment.NewLine +
                version + Environment.NewLine +
                endheading + 
                css + 
                javascript);
            script = sb.ToString();
            Array.Clear(includeList, 0, includeList.Length);
            return script;
        }
        else{
            string script = "@-moz-document ";
            string[] includeList;
            include = txtInclude.Text;
            include.Trim();
            includeList = include.Split(',');
            include = "";
            foreach (string url in includeList)
            {
                StringBuilder sb2 = new StringBuilder();
                sb2.Append("url(\"" + url + "\"), ").ToString();
                include += sb2.ToString();
            }
            include.Remove(include.LastIndexOf(","));
            StringBuilder sb = new StringBuilder();
            sb.Append(script + include + Environment.NewLine + fastColoredTextBox1.Text + Environment.NewLine + "}");
            script = sb.ToString();
            Array.Clear(includeList, 0, includeList.Length);
            return script;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            name = Constants.SCRIPT_NAME + txtName.Text;
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            description = Constants.SCRIPT_DESCRIPTION + txtDesc.Text;
        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {
            author = Constants.SCRIPT_AUTHOR + txtAuthor.Text;
        }

        private void txtHomepage_TextChanged(object sender, EventArgs e)
        {
            homepage = Constants.SCRIPT_HOMEPAGE + txtHomepage.Text;
        }

        private void txtInclude_TextChanged(object sender, EventArgs e)
        {
            //add multiple includes next update
            include = txtInclude.Text ;
        }

        private void txtVersion_TextChanged(object sender, EventArgs e)
        {
            version = Constants.SCRIPT_VERSION + txtVersion.Text + Environment.NewLine;
        }

        private void fastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            css = "\"" + fastColoredTextBox1.Text.Trim().Replace("\"", "'").Replace(System.Environment.NewLine, "\"," + System.Environment.NewLine + "\"") + "\"" + Environment.NewLine + "].join(\"\\n\");";
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Converter();
            f.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileLoc != "") {
                File.WriteAllText(fileLoc, fastColoredTextBox2.Text);
            } else {
                saveAs();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAs();
        }

        private void saveAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save UserScript";
            DialogResult result = sfd.ShowDialog();

            if (result == DialogResult.OK)
            {
                string name = sfd.FileName;
                File.WriteAllText(name, fastColoredTextBox2.Text);
                fileLoc = name;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void forumPostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://greasyfork.org/en/forum/discussion/6210/css-to-script-converter");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.SelectAll();
            fastColoredTextBox1.Copy();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fastColoredTextBox2.Cut();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fastColoredTextBox2.SelectAll();
            fastColoredTextBox2.Copy();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fastColoredTextBox2.Paste();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }
    }
}
