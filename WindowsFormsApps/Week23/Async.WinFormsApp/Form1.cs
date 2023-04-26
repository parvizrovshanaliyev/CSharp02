using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Async.WinFormsApp
{
    public partial class Form1 : Form
    {
        private const int loopCount = 50;
        private Random random;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            random = new Random();
        }

        private void buttonyellow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < loopCount; i++)
            {
                this.CreateGraphics().DrawEllipse(new Pen(Brushes.Yellow, 4),
                 new Rectangle(random.Next(0, this.Width), random.Next(0, this.Height), 30, 30));

                Thread.Sleep(100);
            }
        }

        private void buttonblue_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < loopCount; i++)
            {
                this.CreateGraphics().DrawEllipse(new Pen(Brushes.Blue, 4),
                 new Rectangle(random.Next(0, this.Width), random.Next(0, this.Height), 30, 30));

                Thread.Sleep(100);
            }
        }

        private void buttonred_Click(object sender, EventArgs e)
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
