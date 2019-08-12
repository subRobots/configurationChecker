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

        public int errorCount;

        public Form1()
        {
            InitializeComponent();
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            // Clear Listbox
            listBox1.Items.Clear();
            errorCount = 0;

            string filepath = textBox1.Text;

            // Load file
            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                int counter = 0;
                

                try
                {
                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        counter++;
                        string newline = line.Split('=', '>')[1];

                        if (!line.Contains("o.profile"))
                        {
                            if (newline.Contains(@"/") || newline.Contains(@"\") || newline.Contains(">") || newline.Contains("#") || newline.Contains("<"))
                            {
                                listBox1.Items.Add("Line [" + counter + "]:[Invalid character(s)]: " + newline);
                                errorCount++;
                            }
                            else
                            {
                                listBox1.Items.Add("Line: ["+ counter.ToString() + "][Character check... Passed]");
                            }

                            if (newline.Length > 63)
                            {
                                listBox1.Items.Add("Line [" + counter + "]:[Invalid length]: " + newline);
                                errorCount++;
                            }
                            else
                            {
                                listBox1.Items.Add("Line: [" + counter.ToString() + "] Length check... Passed]");
                            }
                            // /  \  > # . <
                        }

                    }
                } // try

                catch
                {
                    listBox1.Items.Add("[An error has occurred]");
                }
            }
            lblErrors.Text = errorCount.ToString();

            if (errorCount > 0 )
            {
                lblErrors.ForeColor = Color.Red;
            }
            else
            {
                lblErrors.ForeColor = Color.Green;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            //dlg.InitialDirectory = @"C:\";
            dlg.Title = "Browse to configuration file...";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                textBox1.Text = fileName;                
            }
        }
    }
}
