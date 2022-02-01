using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloApp
{
    public partial class Form1 : Form
    {

        Point moveStart;

        public Form1()
        {
            InitializeComponent();
            Text = "🦋天官赐福，百无禁忌 🦋";
            //this.Load += LoadEvent;
            //this.BackColor = Color.DarkRed;
            //this.BackgroundImage = Image.FromFile("C:\\Users\\natya\\OneDrive\\Изображения\\цч.jpg");
            //this.Width = 400;
            //this.Height = 600;
            //this.StartPosition = FormStartPosition.CenterScreen;
            //button1.Click += button1_Click;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.DarkRed;
            Button button1 = new Button
            {
                Location = new Point
                {
                    X = this.Width / 3,
                    Y = this.Height / 3
                }
            };
            button1.Text = "Закрыть";
            button1.Click += button1_Click;
            this.Controls.Add(button1); // добавляем кнопку на форму
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("🔥人間盡逍遙🔥");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newForm1 = new Form1();
            newForm1.Show();

            Form2 newForm2 = new Form2(newForm1);
            newForm2.Show();

            MessageBox.Show("🔥人間盡逍遙🔥");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(0, 0, this.Width, this.Height);
            Region myRegion = new Region(myPath);
            this.Region = myRegion;
        }

        //private void LoadEvent(object sender, EventArgs e)
        //{
        //this.BackColor = Color.DarkCyan;
        //}

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши
            if ((e.Button & MouseButtons.Left) != 0)
            {
                // получаем новую точку положения формы
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                // устанавливаем положение формы
                this.Location = new Point(this.Location.X + deltaPos.X,
                  this.Location.Y + deltaPos.Y);
            }
        }
    }
}
