using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async.WinFormsApp
{
    public partial class Form2 : Form
    {
        private const int loopCount = 50;
        private Random random;
        private Thread thread1;
        private Thread thread2;
        private Thread thread3;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            random = new Random();
        }
        private void buttonyellow_Click(object sender, EventArgs e)
        {
            thread1= new Thread(Yellow);
            thread1.Start();

        }

        private void buttonblue_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(Blue);
            thread2.Start();
        }

        

        private void buttonred_Click(object sender, EventArgs e)
        {
            thread3 = new Thread(Red);
            thread3.Start();
        }



        private void Yellow()
        {
            for (int i = 0; i < loopCount; i++)
            {
                this.CreateGraphics().DrawEllipse(new Pen(Brushes.Yellow, 4),
                    new Rectangle(random.Next(0, this.Width), random.Next(0, this.Height), 30, 30));

                Thread.Sleep(100);
            }
        }
        private void Blue()
        {
            for (int i = 0; i < loopCount; i++)
            {
                this.CreateGraphics().DrawEllipse(new Pen(Brushes.Blue, 4),
                    new Rectangle(random.Next(0, this.Width), random.Next(0, this.Height), 30, 30));

                Thread.Sleep(100);
            }
        }
        private void Red()
        {
            for (int i = 0; i < loopCount; i++)
            {
                this.CreateGraphics().DrawEllipse(new Pen(Brushes.Red, 4),
                    new Rectangle(random.Next(0, this.Width), random.Next(0, this.Height), 30, 30));

                Thread.Sleep(100);
            }
        }
    }
}
