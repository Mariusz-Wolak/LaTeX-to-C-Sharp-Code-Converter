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
            var myStreamReader = new System.IO.StreamReader("M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\Class1.txt");
            String sampClassString = Convert.ToString(myStreamReader);
            myStreamReader.Close();

            String RTB_txt = richTextBox1.Text;
            String fileName = richTextBox2.Text + ".cs";
            String[] RTB_txt_array = RTB_txt.Split('^');
            MessageBox.Show(RTB_txt_array[0]);
            MessageBox.Show(RTB_txt_array[1]);

            sampClassString = sampClassString.Replace("myFunction", fileName);
            sampClassString = sampClassString.Replace("double arg", "double " + RTB_txt_array[0]+ ", double " + RTB_txt_array[1]);
            //Insert index of //comment

            //sampClassString = sampClassString.Replace(" **value**", "")


            //var myStreamWriter = new System.IO.StreamWriter("M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\" + fileName);
            //myStreamWriter.Write(sampClassString);
            //myStreamWriter.Close();
        }
    }
}
