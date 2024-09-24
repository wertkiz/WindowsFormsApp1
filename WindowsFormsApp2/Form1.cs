using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int ugolSec = -90;
        int ugolMin = -90;
        int ugolHour = -90;
        SolidBrush SB = new SolidBrush(SystemColors.Control);
        Bitmap bmp = new Bitmap(400, 400);
        Graphics gr;
        float centr = 200;

        Pen PenTabl = new Pen(Color.Black, 4f);

        #region секунды
        int lengSec = 165;
        Pen PenSec = new Pen(Color.Black,2f);
        #endregion

        #region минуты
        int lengMin = 120;
        Pen PenMin = new Pen(Color.Black, 1f);
        #endregion

        #region Часы
        int lengHour = 80;
        Pen PenHour = new Pen(Color.Black, 3f);
        #endregion

        

        public Form1()
        {
            InitializeComponent();
            gr = Graphics.FromImage(bmp);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Очистка Picturbox1
            gr.FillRectangle(SB, new Rectangle(0, 0, 400, 400));
            #endregion

            #region рисовка циферблата

            gr.DrawLine(PenTabl, 200, 0, 200, 30);
            gr.DrawLine(PenTabl, 200, 370, 200, 400);

            gr.DrawLine(PenTabl, 0, 200, 30, 200);
            gr.DrawLine(PenTabl, 370, 200, 400, 200);

            #endregion

            #region Часы
            ugolHour = (DateTime.Now.Hour * 30) - 90;
            gr.DrawLine(PenHour, centr, centr, x2(lengHour, ugolHour), y2(lengHour, ugolHour));
            #endregion

            #region Минуты
            ugolMin = (DateTime.Now.Minute * 6) - 90;
            gr.DrawLine(PenMin, centr, centr, x2(lengMin, ugolMin), y2(lengMin, ugolMin));
            #endregion

            #region Секунды
            ugolSec = (DateTime.Now.Second * 6) - 90;
            gr.DrawLine(PenSec, centr, centr, x2(lengSec,ugolSec),y2(lengSec, ugolSec));
            #endregion

            pictureBox1.Image = bmp;
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private float x2(int len, int ug)
        {
            return centr + len * (float)(Math.Cos(Math.PI * ug / 180));
        }

        private float y2(int len, int ug)
        {
            return centr + len * (float)(Math.Sin(Math.PI * ug / 180));
        }
    }
}
