using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    public partial class Form1 : Form
    {
        int count = 0;
        int second, second1;
        int Num;
        int Num2;
        int sum = 0;
        Color[] co = { Color.Transparent,Color.Blue, Color.BlueViolet,
            Color.Orange, Color.Red, Color.DeepSkyBlue, Color.DeepPink,
            Color.LawnGreen, Color.Yellow, Color.Blue, Color.BlueViolet,
            Color.Orange, Color.Red, Color.DeepSkyBlue, Color.DeepPink,
            Color.LawnGreen, Color.Yellow };
        Button[] bt = new Button[17]; 
        int[] state = new int[17]; 
        int[] TF = { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bt[1] = button1;
            bt[2] = button2;
            bt[3] = button3;
            bt[4] = button4;
            bt[5] = button5;
            bt[6] = button6;
            bt[7] = button7;
            bt[8] = button8;
            bt[9] = button9;
            bt[10] = button10;
            bt[11] = button11;
            bt[12] = button12;
            bt[13] = button13;
            bt[14] = button14;
            bt[15] = button15;
            bt[16] = button16;
            end.Enabled = false;
            timer1.Enabled = false;
            for(int i = 1; i <= 16; i++)
            {
                bt[i].Enabled = false;
            }
        }

        private void start_Click(object sender, EventArgs e)
        {
            count = 0;
            sum = 0;
            second = 0;
            start.Enabled = false;
            end.Enabled = true;
            timer1.Enabled = true;
            for(int i = 1; i <= 16; i++)
            {
                TF[i] = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            label1.Text = "秒數:" +second.ToString() + "秒";
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            second1++;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            if (count == 0)
            {
                Button btnHit = (Button)sender;
                Num = int.Parse(btnHit.Text);
                TF[Num] = 1;
                bt[Num].BackgroundImage = null;
                count++;
            }
            else if (count == 1)
            {
                Button btnHit = (Button)sender;
                Num2 = int.Parse(btnHit.Text);
                bt[Num2].BackgroundImage = null;
                TF[Num2] = 1;
                count++;
                if (Num == Num2) { count = 1; TF[Num2] = 0; }
            }
            else if (count == 2)
            {
                count = 0;
                if (bt[Num].BackColor != bt[Num2].BackColor)
                {
                    bt[Num].BackgroundImage = final.Properties.Resources.b;
                    bt[Num2].BackgroundImage = final.Properties.Resources.b;
                    TF[Num] = 0;
                    TF[Num2] = 0;
                }
                else
                {
                    bt[Num].Enabled = false;
                    bt[Num2].Enabled = false;
                }
            }
            for (int i = 1; i <= 16; i++)
            {
                sum += TF[i];
            }
            if (sum==16)
            {
                timer1.Enabled = false;
                MessageBox.Show("你贏了,共花了"+second.ToString()+"秒", "翻牌遊戲");
                for (int i = 1; i <= 16; i++)
                {
                    bt[i].Enabled = false;
                }
            }
            else
            {
                sum = 0;
            }
            
        }

        private void start_MouseDown(object sender, MouseEventArgs e)
        {
            
            Random rn = new Random();
            for (int i = 1; i <= 16; i++)
            {
                bt[i].Enabled = true;
                state[i] = rn.Next(1, 17);
                for (int j = 1; j < i; j++)
                {
                    while (state[i] == state[j])
                    {
                        j = 0;
                        state[i] = rn.Next(1, 17);
                    }
                }
                bt[i].BackColor = co[state[i]];
                bt[i].BackgroundImage = null;
            }
        }

        private void start_MouseUp(object sender, MouseEventArgs e)
        {
            
            for (int i = 1; i <= 16; i++)
            {
                bt[i].BackgroundImage = final.Properties.Resources.b;
            }
        }

        private void end_Click(object sender, EventArgs e)
        {
            start.Enabled = true;
            end.Enabled = false;
            timer1.Enabled = false;
            for (int i=1; i <= 16; i++)
            {
                bt[i].Enabled = false;
                bt[i].BackgroundImage = final.Properties.Resources.b;
            }
            second = 0;
            label1.Text = "秒數:" + second.ToString() + "秒";
        }


    }
}
