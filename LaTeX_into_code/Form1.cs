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

            //cos w stylu equality(Ac,add(multiply(2,multiply(PI,multiply(r,h))),multiply(2,multiply(PI,multiply(r,r)))))

            //wykrywanie znakow i kolejnosci dzialan (* wazniejsze niz +, chyba ze nawias), np wykryje "+", to przesyla lewa i prawa czesc do dodawania, tam w dodawaniu tez musi wykrywac i jesli jest np. "^",
            // to znowu bierze lewa i prawa, jakas rekurencja do tego moze albo przenoszenie tych stringow i pamietanie dzialan

            //robic znak po znaku, drzewo ze stringa, uzytkownik wybiera nazwe funkcji, zaznacza czy statyczna, apend jakby cos dopisac?

            //zeby bylo latwiej znak po znaku, moge zrobic Replace z /sqrt na np. P, albo sprawdzac czy jesli kolejne znaki po "/" to "sqrt", to wtedy jest
            //pierwiastek

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
