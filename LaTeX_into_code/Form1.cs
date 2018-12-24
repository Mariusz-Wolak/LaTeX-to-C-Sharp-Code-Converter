using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaTeX_into_code
{
    public partial class Form1 : Form
    {
        string myClass; 

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            myClass = System.IO.File.ReadAllText(@"M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\ClassTemplate.txt");
           
            string RTB_txt = richTextBox1.Text;
            string filename = richTextBox2.Text;
            string methodName = richTextBox3.Text;

            myClass = myClass.Replace("/*insertingClassName*/", filename);
            myClass = myClass.Replace("/*insertingMethodName*/", methodName);


            


            // apend jakby cos dopisac?
            //jesli jest "=", to bierzemy tylko prawa czesc

            var myStreamWriter = new System.IO.StreamWriter("M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\" + filename+".cs");
            myStreamWriter.Write(Convert.ToString(myClass));
            myStreamWriter.Close();
            MessageBox.Show(filename+".cs has been created.");
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = true;
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Checked = false;
                checkBox2.Enabled = true;
            }
        }
    }
}
