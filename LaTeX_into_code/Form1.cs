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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string defaultClass = System.IO.File.ReadAllText(@"M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\Class1.txt");
           
            string RTB_txt = richTextBox1.Text;
            string fileName = richTextBox2.Text + ".cs";

            //String[] RTB_txt_array = RTB_txt.Split('^');
            
            string newClass = defaultClass.Replace("Class1", richTextBox2.Text);
            int myIndex = newClass.IndexOf("//insertingHere");
            newClass = newClass.Insert(myIndex, "przerobione na kod\n");
            newClass = newClass.Insert(myIndex, "przerobione na kod2\n");
            newClass = newClass.Insert(myIndex, "przerobione na kod3\n");



            var myStreamWriter = new System.IO.StreamWriter("M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\" + fileName);
            myStreamWriter.Write(Convert.ToString(newClass));
            myStreamWriter.Close();





            MessageBox.Show("Your file has been created.");
        }

        void insertCode()
        {

        }
    }
}
