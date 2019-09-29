using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TextBox textBox = TextBoxDirectory;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileExplorer explorer = new FileExplorer(TextBoxDirectory, TextBoxFileTemplate, TextBoxKeyWords,
                TreeViewResult, ButtonStartSearch, LabelCurrentFile, LabelCurrentTime, LabelNumber);
            FormClosing += explorer.Finish;
            ButtonDirectory.Click += explorer.Open_Directory;
        }

    }
}
