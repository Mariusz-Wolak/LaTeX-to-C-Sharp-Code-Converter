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
        string[] operations = { "*", "+" };
        int addOperatorsNum = 0;
        string[] splitString;
        string[] wholeAdditionArray;

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

            insertBody(parse(RTB_txt));

            

            

            // , zaznacza czy statyczna, apend jakby cos dopisac?
            

            MessageBox.Show(fileName+" has been created.");
        }

        void insertHeader()
        {

        }

        void insertBody(string codeToAdd)
        {
            int myIndex = newClass.IndexOf("//insertingBody");
            newClass = newClass.Insert(myIndex, codeToAdd+"\n\t\t\t");
        }
        
        string parse(string latexToParse)
        {
            string declarationString;
            string returnString;
            
            
            //addition (add to Addition in MathOperations?)
            //if (latexToParse.Contains("+"))
            //{
            splitString = latexToParse.Split('+');
            addOperatorsNum++;

            //for(int i=0; i < splitString.Length; i++)
            //{
            //    wholeAdditionArray[i] = splitString[i];
            //}

            MessageBox.Show("splitString[0] = " + splitString[0]);

            while (splitString[addOperatorsNum].Contains("+"))
            {
                MessageBox.Show("jest plus, prawa strona splitStringa: "+splitString[addOperatorsNum]);
                
                splitString = splitString[addOperatorsNum].Split('+');
                
                addOperatorsNum++;
                MessageBox.Show("Po kolejnym splicie: " + splitString[addOperatorsNum]);
            }
            //}

            
            //jesli jest "=", to bierzemy tylko prawa czesc
            //switch albo if albo bool do wykrycia z txtParse jakie sa znaki i na podstawie tego wykonac dzialanie (zadbac o kolejnosc matematyczna)
            

            

            string doTestu="";

            for(int i=0; i<addOperatorsNum; i++)
            {
                doTestu += "/n"+splitString[i];
            }

            

            return doTestu;
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

        //void additionCounter(string toParse, char search)
        //{
        //    foreach (char c in toParse)
        //    {
        //        if (c == search)
        //        {
        //            addOperatorsNum++;
        //        }
        //    }

        //    for (int i = 0; i < addOperatorsNum; i++)
        //    {
        //        splitString[addOperatorsNum] = 
        //    }
        //}
    }
}
