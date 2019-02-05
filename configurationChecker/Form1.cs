using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace configurationChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //J:\dna
            string filepath = textBox1.Text;

            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                int counter = 0;
                // int pFrom = St.IndexOf("key : ") + "key : ".Length;
                //int pTo = St.LastIndexOf(" - ");
                
                //line = reader.ReadLine();
                
                
                
                try
                {
                    
                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        counter++;
                        string newline = line.Split('=', '>')[1];

                        if (!line.Contains("o.profile"))
                        {
                            if (newline.Contains("/") || newline.Contains(@"\") || newline.Contains(">") || newline.Contains("#") || newline.Contains("<"))
                            {
                                listBox1.Items.Add("Line " + counter + ":[Invalid character(s)]: " + newline);
                            }

                            if (newline.Length > 63)
                            {
                                listBox1.Items.Add("Line " + counter + ":[Invalid length]: " + newline);
                            }
                            // /  \  > # . <
                        }

                    }
                } // try

                catch
                {

                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                textBox1.Text = fileName;
                
            }
        }
    }
}
