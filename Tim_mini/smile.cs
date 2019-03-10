using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tim_mini
{
    public partial class smile : Form
    {
        public smile()
        {
            InitializeComponent();
        }


        mainwindow window;
        public smile(mainwindow my_win)
        {
            InitializeComponent();
            window = my_win;
        }

        private void smile_Load(object sender, EventArgs e)
        {

            PictureBox Ps = new PictureBox();
            Ps.Size = new Size(50, 50);
            Ps.SizeMode = PictureBoxSizeMode.Zoom;
            Ps.Image = Image.FromFile(@"test.gif");
            Ps.Location = new Point(18 , 15 );
            Ps.Cursor = Cursors.Hand;
            Ps.BackColor = Color.Transparent;
            Ps.Tag =  "test.gif";
            Ps.Click += new EventHandler(SmailPic_Click);
            this.Controls.Add(Ps);
        }

        private void SmailPic_Click(object sender, EventArgs e)
        {
            //向编辑框写入图片
            PictureBox psm = (PictureBox)sender;
            window.send_pic.Image = psm.Image;
            window.start_send_pic();
            window.smile_dlg = null;
            this.Close();
        }
    }
}
