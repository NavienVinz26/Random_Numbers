using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labtest5
{
    public partial class Form1 : Form
    {
        int guesses = 0;
        List<Int32> ListNumber = new List<Int32>();
        int secretNumber = 0, index = 0, chosen = 0;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void btnPlay_Click(object sender, EventArgs e)
        {
            guesses = 0;
            chosen = 0;
            lb3.Text = "";
            ListNumber.Clear();
            lb1.Items.Clear();
            for(int i=1;i<50;i++)
            {
                ListNumber.Add(i);
                lb1.Items.Add(i);
            }
            btnPlay.Enabled = false;
            btnExit.Enabled = false;
            lb1.Enabled = true;

            Random rand = new Random();
            secretNumber = rand.Next(1, 51);

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            for (int i = 1; i < 51; i++)
            {
                ListNumber.Add(i);
                lb1.Items.Add(i);
            }
            Random rand = new Random();
            secretNumber = rand.Next(1, 51);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            double sum = 0;
            foreach(int item in lb2.Items)
            {
                sum = guesses;
            }
            double avg = sum / lb2.Items.Count;

            MessageBox.Show("You played" + lb2.Items.Count + "rounds" + "Your average is" + avg +"Per round.\n" + "Thank you for playing##");
            Application.Exit();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //remove chose number
            ListNumber.Remove(Convert.ToInt32(lb1.SelectedItem));
            //select the current number
            chosen = Convert.ToInt32(lb1.SelectedItem);
            ///clear listbox and load list
            lb1.Items.Clear();
            for(int i=0;i<ListNumber.Count;i++)
            {
                lb1.Items.Add(ListNumber[i]);
            }

            //compare the number
            if(chosen>secretNumber)
            {
                lb3.Text = "You choose" + chosen + ".Choose a smaller number";
                guesses++;
            }
            else if(chosen==secretNumber)
            {
                lb3.Text = "You choose" + chosen + ".You are absolutely correct!!!";
                lb2.Items.Add(guesses);
                lb1.Enabled = false;
                btnPlay.Enabled = true;
                btnExit.Enabled = true;

            }
            else
            {
                lb3.Text = "You choose" + chosen + ".Choose a big number";
                guesses++;
            }
        }
    }
}
