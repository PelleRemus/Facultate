using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicentaDemo
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        int index;

        private void HelpForm_Load(object sender, EventArgs e)
        {
            load();
        }

        void load()
        {
            listBox1.Items.Clear();
            label1.Text = Engine.helpPages[index].title;
            foreach (Paragraph p in Engine.helpPages[index].content)
            {
                foreach (string str in p.content)
                    listBox1.Items.Add(str);
            }
            label2.Text = (index + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
                index = 0;
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            index++;
            if (index == Engine.helpPages.Count)
                index = Engine.helpPages.Count - 1;
            load();
        }
    }
}
