using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gravity2d
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int x = 0;
        public int y = 0;
        GravityBox gb = new GravityBox(new Rectangle(300, 0, 50, 50), Color.AliceBlue);
        Rectangle floor = new Rectangle();
        Rectangle gbox = new Rectangle();
        Graphics g;
        Timer t = new Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            t.Interval = 20;
            t.Tick += new EventHandler(timer1_Tick);
            t.Start();
            floor = new Rectangle(0,200,this.Width,this.Height);
            


        }
        
private void timer1_Tick(object sender, EventArgs e)
        {
            gb.Move();
            g.Clear(Color.Black);
            g.FillRectangle(gb.GiveColor(), floor);
            g.FillRectangle(gb.GiveColor(), gb.GiveArea());
            gbox = gb.GiveArea();
            if (gbox.IntersectsWith(floor))
                gb.IsFalling();

        }

   

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            gb = new GravityBox(new Rectangle(e.X, e.Y, 50, 50), Color.AliceBlue);

            //double mclick_x = e.X;
            //double mclick_y = e.Y;
            
        }
        private class GravityBox
        {
            private Rectangle area;
            private Brush b;
            private DateTime time;
            private bool falling = true;
            public GravityBox(Rectangle Area, Color Theme)
            {
                area = Area;
                b = new SolidBrush(Theme);
                time = DateTime.Now;
            }
            public void Move()
            {
                if(falling)
                {
                    TimeSpan seconds = time - DateTime.Now;
                    double add_y = (double)9.8 * (Math.Pow(seconds.TotalSeconds, 2));
                    area.Y += (int)add_y;
                }
            }
            public Brush GiveColor()
            {
                return b;
            }
            public Rectangle GiveArea()
            {
                return area;
            }
            public void IsFalling()
            {
                falling = false;
            }

        }
    }
}
