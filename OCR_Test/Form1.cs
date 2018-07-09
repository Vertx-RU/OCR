
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace OCR_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static Bitmap img;
        static TesseractEngine engine;
        static Tesseract.Page page;
        public static bool closefrm = false;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            ScreenBody body = new ScreenBody();
            body.BackgroundImage = img;
            body.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = Clipboard.GetImage();
            engine = new TesseractEngine(System.Environment.CurrentDirectory + "\\tessdata", "chi_sim",EngineMode.Default);
            img = new Bitmap(pictureBox1.Image);
            page = engine.Process(img);
            textBox1.Text = page.GetText();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (closefrm)
            {
                pictureBox1.Image = Clipboard.GetImage();
                this.Refresh();
                closefrm = false;
                timer1.Stop();
            }
        }
    }
}
