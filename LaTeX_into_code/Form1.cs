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
            string className;
            string methodName;

            bool staticClass = checkBox1.Checked;
            bool staticMethod = checkBox2.Checked;

            if (staticClass)
            {
                className = "static class " + richTextBox2.Text;
            }
            else
            {
                className = "class " + richTextBox2.Text;
            }

            if (staticMethod)
            {
                methodName = "static double " + richTextBox3.Text;
            }
            else
            {
                methodName = "double " + richTextBox3.Text;
            }

            myClass = myClass.Replace("/*insertingClassName*/", className);
            myClass = myClass.Replace("/*insertingMethodName*/", methodName);

            

           // string[] returnString = RTB_txt.Split('+'); //wlasna metoda split zliczajaca operatory i ile tych tablic jest ostatecznie?

            //MessageBox.Show(returnString[0]);
           // MessageBox.Show(returnString[1]);
            //MessageBox.Show(returnString[2]);

            //myClass = myClass.Replace("/*insertingReturn*/", returnString);



            // apend jakby cos dopisac?
            //jesli jest "=", to bierzemy tylko prawa czesc

            myClass = myClass.Replace("/*insertingParams*/", "");
            myClass = myClass.Replace("/*insertingBody*/", "");
            myClass = myClass.Replace("/*insertingReturn*/", "");
            var myStreamWriter = new System.IO.StreamWriter("M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\" + richTextBox2.Text + ".cs");
            myStreamWriter.Write(Convert.ToString(myClass));
            myStreamWriter.Close();
            MessageBox.Show(richTextBox2.Text + ".cs has been created.");
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
