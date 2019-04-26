using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaTeX_into_code
{
    public partial class Form1 : Form
    {
        Equation eq;
        
        public Form1()
        {
            InitializeComponent();
            eq = new Equation();
            foreach(string str in eq.latex_operators)
            {
                label5.Text += str+", ";
            }
            label5.Text = label5.Text.Substring(0, label5.Text.Length-2);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string templatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ClassTemplate\ClassTemplate.txt");
            string myClass = System.IO.File.ReadAllText(templatePath);

            FolderBrowserDialog myFolderBrowser = new FolderBrowserDialog();
            myFolderBrowser.Description = "Choose your destiny.";

            eq = new Equation();
            eq.Cs_equation = eq.Latex_equation = richTextBox1.Text;
            string className;
            string methodName;
            bool staticClass = checkBox1.Checked;
            bool staticMethod = checkBox2.Checked;
            string paramsString = "";

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
            
            getVariables(eq.Latex_equation, ref paramsString);
            eq.Latex_to_CS();

            myClass = myClass.Replace("/*insertingParams*/", paramsString);
            myClass = myClass.Replace("/*insertingReturn*/", eq.Cs_equation);
            
            if (myFolderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var myStreamWriter = new System.IO.StreamWriter(myFolderBrowser.SelectedPath + @"\" + richTextBox2.Text + ".cs");
                myStreamWriter.Write(Convert.ToString(myClass));
                myStreamWriter.Close();
                MessageBox.Show(myFolderBrowser.SelectedPath + @"\" + richTextBox2.Text + ".cs has been created.");
            }
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

        public void getVariables(string equation, ref string paramsString)
        {
            for (int i = 0; i < eq.latex_operators.Length; i++)
            {
                equation = equation.Replace(eq.latex_operators[i], " ");
            }

            string[] variablesArray = equation.Split(' ');

            double num;
            foreach (string variable in variablesArray)
            {
                if (!(variable == "")
                    && !(double.TryParse(variable, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out num))
                    && variable.Substring(0, 1) != @"\"
                    && !eq.Variables.Contains(variable))
                {
                    eq.Variables.Add(variable);
                    paramsString += ", double " + variable;
                }
            }
            paramsString = paramsString.Remove(0, 2);
        }
    }
}
