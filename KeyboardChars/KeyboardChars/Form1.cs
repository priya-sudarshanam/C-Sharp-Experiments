using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace KeyboardChars
{
    public partial class Form1 : Form
    {
        private int current = -1; 
        private int se, correct, incorrect;
        private Button b = new Button();
        private SoundPlayer sp;
       
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            char[] c = richTextBox1.Text.ToCharArray();
            current++;
            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                if (this.panel1.Controls[i].Name.Length <= 4)
                  if (this.panel1.Controls[i].Name.Substring(0, 4).ToLower().CompareTo(
                    "bnt" + key.ToString().ToLower()) == 0)
                      ChangeColor((Button)this.panel1.Controls[i], c, current, key);
            }

            //check symbols: ',~!, @ #, $ %,...

            if ((int)key == 33) ChangeColor(bnt1, c, current, key);
            if ((int)key == 64) ChangeColor(bnt2, c, current, key);
            if ((int)key == 35) ChangeColor(bnt3, c, current, key);
            if ((int)key == 36) ChangeColor(bnt4, c, current, key);
            if ((int)key == 37) ChangeColor(bnt5, c, current, key);
            if ((int)key == 94) ChangeColor(bnt6, c, current, key);
            if ((int)key == 38) ChangeColor(bnt7, c, current, key);
            if ((int)key == 42) ChangeColor(bnt8, c, current, key);
            if ((int)key == 40) ChangeColor(bnt9, c, current, key);
            if ((int)key == 41) ChangeColor(bnt0, c, current, key);
            if ((int)key == 126 || (int)key == 96) ChangeColor(bntaccent, c, current, key);
            if ((int)key == 123 || (int)key == 91) ChangeColor(bntopenbrace, c, current, key);
            if ((int)key == 125 || (int)key == 93) ChangeColor(bntclosebrace, c, current, key);
            if ((int)key == 58 || (int)key == 59) ChangeColor(bntsemi, c, current, key);
            if ((int)key == 34 || (int)key == 39) ChangeColor(bntquote, c, current, key);
            if ((int)key == 60 || (int)key == 44) ChangeColor(bntcomma, c, current, key);
            if ((int)key == 62 || (int)key == 46) ChangeColor(bntpoint, c, current, key);
            if ((int)key == 63 || (int)key == 47) ChangeColor(bntbackslash, c, current, key);
            if ((int)key == 124 || (int)key == 92) ChangeColor(bntforwardslash, c, current, key);
            if ((int)key == 95 || (int)key == 45) ChangeColor(bntminus, c, current, key);
            if ((int)key == 43 || (int)key == 61) ChangeColor(bntequal, c, current, key);

            //check spacebar and enter keys
            if ((int)key == 32) ChangeColor(bntspacebar, c, current, key);
            if ((int)key == 13) ChangeColor(bntenter, c, current, key);
        }
        private void ChangeColor(Button currButton, char[] c, int curr, char key)
        {
             b.BackColor = Color.White;
           
            try
            {
                if ((int)key == 13 && (int)c[current] == 10)
                {
                    bntenter.BackColor = Color.Green;
                    b = bntenter;
                    correct++;
                } else if ((int)key == (int)c[current]) {
                    currButton.BackColor = Color.Green;
                    b = currButton;
                    richTextBox1.SelectionStart = curr;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectionColor = Color.Green;
                    correct++;
                    correctTextBox.Text = correct.ToString();
                } else {
                    currButton.BackColor = Color.Red;
                    b = currButton;
                    richTextBox1.SelectionStart = curr;
                    richTextBox1.SelectionLength = 1;
                    richTextBox1.SelectionColor = Color.Red;
                    incorrect++;
                    incorrectTextBox.Text = incorrect.ToString();
                }

               
            } catch(Exception e) {
                throw e;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.LightBlue;
           // richTextBox1.TabIndex = 0;
            correct = 0;
            incorrect = 0;
            richTextBox1.Text = loadtext("lesson1.txt");
       
            
        }

        private string loadtext(string fileName)
        {
            FileStream fs = null;
            string content = "";

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                using(TextReader tr = new StreamReader(fs)){
                    content =tr.ReadToEnd();
                }                                
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
            return content;
        }

       
        private void menuLesson2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = loadtext("lesson2.txt");
        }

       
        private void menuLesson1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = loadtext("lesson1.txt");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void minimizeMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            lessonNumber.Visible = true;
            lessonNumberTextBox.Visible = true;
            lessonNumberTextBox.Enabled = true;
            btnSubmit.Visible = true;
            btnSubmit.Enabled = true;                    
        }

        private void bntpause_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        
        private void LessonNumber(int val=0)
        {
            richTextBox1.Clear();
            b.BackColor = Color.White;
            current = -1;
            correct = 0;
            incorrect = 0;
            textBox1.Focus();
            correctTextBox.Clear();

            if (val == 1)
            {                
                richTextBox1.Text = loadtext("lesson1.txt");
                
            }
             else if (val == 2)
            {
                richTextBox1.Text = loadtext("lesson2.txt");
            }
            lessonNumber.Visible = false;
            lessonNumberTextBox.Clear();
            lessonNumberTextBox.Visible = false;
            btnSubmit.Visible = false;
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(lessonNumberTextBox.Text)))
            {
                int lessonNumber = Int16.Parse(lessonNumberTextBox.Text);
                LessonNumber(lessonNumber);
            }
        }
        
       
    }
}
