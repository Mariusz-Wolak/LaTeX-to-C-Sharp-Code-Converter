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
        string newClass;
        string paramsLine;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            newClass = System.IO.File.ReadAllText(@"M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\Class1.txt");
           
            string RTB_txt = richTextBox1.Text;
            string fileName = richTextBox2.Text + ".cs";
            newClass = newClass.Replace("Class1", richTextBox2.Text);



            var myStreamWriter = new System.IO.StreamWriter("M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\" + fileName);
            myStreamWriter.Write(Convert.ToString(newClass));
            myStreamWriter.Close();

            //zrobic funkcje Addition, Square, Sin itd. i wykrywac case'ami w zaleznosci od znaku np "+", "^"

            //cos w stylu equality(Ac,add(multiply(2,multiply(PI,multiply(r,h))),multiply(2,multiply(PI,multiply(r,r)))))

            //wykrywanie znakow i kolejnosci dzialan (* wazniejsze niz +, chyba ze nawias), np wykryje "+", to przesyla lewa i prawa czesc do dodawania, tam w dodawaniu tez musi wykrywac i jesli jest np. "^",
            // to znowu bierze lewa i prawa, jakas rekurencja do tego moze albo przenoszenie tych stringow i pamietanie dzialan
            
        


            MessageBox.Show(fileName+" has been created.");
        }

        void insertBody(string addedCode)
        {
            int myIndex = newClass.IndexOf("//insertingBody");
            newClass = newClass.Insert(myIndex, addedCode+"\n\t\t\t");
        }

        void insertParams()
        {

        }
    }
}
