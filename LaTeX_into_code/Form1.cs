﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaTeX_into_code
{
    public partial class Form1 : Form
    {
        string[] operators = { "+", "-" };
        List<string> variables = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string myClass = System.IO.File.ReadAllText(@"M:\\M\\zgrywane\\programowanie\\C#\\LaTeX_into_code\\LaTeX_into_code\\ClassTemplate.txt");
            string RTB_txt = richTextBox1.Text;
            string className;
            string methodName;
            bool staticClass = checkBox1.Checked;
            bool staticMethod = checkBox2.Checked;
            string[] splitString;
            string paramsString = "";
            string bodyString = "";

            // \frac{1}{2n},  \sum^n_{l=0}(-1)^{l}


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
            
            getVariables(RTB_txt, ref paramsString, ref bodyString);

            //if nothing to be splitted, rewrite "str" (jesli nie ma operatora *, to stringa mi nie podzieli tlyko pominie np. samego "x")
            // MOGE ZAMIENIC WSZYSTKIE OPERATORY NA NP. SPACJE I POZNIEJ ZROBIC SPLITA WEDLUG SPACJI I MAM SAME ZMIENNE???
            // w tym celu moge albo poszukac splita wedlug stringa (np. "myOperator") albo zamienic wszystkie operatory na jednoznakowe, np "sqrt" jako
            // "S" i wpisac, ze to jest operator i by tego nie uzywac w rownaniu jako zmiennej;

            //lista na operatory latecha (np "/times") i kazde po kolei zamieniac na np Q i robic splita wedlug Q

            //mozna dodac liste slow kluczowych (np. "\begin", "\end") i je wyrzucic ze stringa






            // zeby dzialal split na wszystko, moge najpierw przeksztalcic rownanie na operatory z jednym znakiem (np sqrt to S) i podzielic, wyjac zmienne
            // a pozniej zamienic znowu
            // apend jakby cos dopisac?
            //jesli jest "=", to bierzemy tylko prawa czesc
            myClass = myClass.Replace("/*insertingParams*/", paramsString);
            myClass = myClass.Replace("/*insertingBody*/", bodyString);
            myClass = myClass.Replace("/*insertingReturn*/", RTB_txt);
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

        void getVariables(string equation, ref string paramsString, ref string bodyString)
        {
            for (int i = 0; i < operators.Length; i++)
            {
                equation = equation.Replace(operators[i], " ");
            }

            // equation.Replace("  ", " "); // 2 spaces
            // equation.Replace("   ", " "); // 3 spaces
            //equation.Replace("    ", " "); // 4 spaces
            //equation.Replace("    ", " "); // 5 spaces

            string[] variablesArray = equation.Split(' ');
            double num;

            foreach (string variable in variablesArray)
            {
                if(!(variable == "") && !(double.TryParse(variable, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out num)))
                {
                    variables.Add(variable);
                    paramsString += ", double " + variable;
                    bodyString += ", " + variable;
                }
            }

            paramsString = paramsString.Remove(0, 2);
            bodyString = bodyString.Remove(0, 2);
            bodyString = "double " + bodyString + ";";
        }
    }
}
