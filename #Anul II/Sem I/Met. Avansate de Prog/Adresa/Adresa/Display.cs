using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adresa
{
    public partial class Display : UserControl
    {
        Adresa adr;

        public Display(Adresa adr)
        {
            this.adr = adr;
            InitializeComponent();
        }

        private void Display_Load(object sender, EventArgs e)
        {
            switch(adr.type)
            {
                case TipAdresa.simpla:
                    {
                        textBox1.Text = adr.nume;
                        textBox2.Text = adr.telefon;

                        panel1.Visible = true;
                        panel2.Visible = false;
                        panel3.Visible = false;

                        this.Height = 60;

                        break;
                    }
                case TipAdresa.medie:
                    {
                        textBox1.Text = adr.nume;
                        textBox2.Text = adr.telefon;

                        foreach(string s in (adr as AdresaMedie).locatie)
                            listBox1.Items.Add(s);

                        panel1.Visible = true;
                        panel2.Visible = true;
                        panel3.Visible = false;

                        this.Height = 145;

                        break;
                    }
                case TipAdresa.extinsa:
                    {
                        textBox1.Text = adr.nume;
                        textBox2.Text = adr.telefon;

                        foreach (string s in (adr as AdresaExtinsa).locatie)
                            listBox1.Items.Add(s);

                        textBox3.Text = (adr as AdresaExtinsa).email;

                        foreach (string s in (adr as AdresaExtinsa).dateComp)
                            listBox2.Items.Add(s);

                        panel1.Visible = true;
                        panel2.Visible = true;
                        panel3.Visible = true;

                        this.Height = 250;

                        break;
                    }
            }
        }
    }
}
