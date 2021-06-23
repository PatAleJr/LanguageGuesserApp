using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LanguageAppML.Model;

namespace LanguageApp
{
    public partial class Form1 : Form
    {

        public string languageGuess;


        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Make a button to switch between realtime guess and a button to guess

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string phrase = InputText.Text;

            if (phrase.Length > 0)
            {
                var input = new ModelInput() { Col0 = phrase };
                ModelOutput result = ConsumeModel.Predict(input);
                string language = result.Prediction;
                OutputText.Text = language;
            }
            else
            {
                OutputText.Text = "...";
            }
        }
    }
}
