using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tim_mini
{
    public partial class login : Form
    {
        string student_id;
        string password;
        //Socket server;
        public static login lol = null;

        IPAddress server_address = IPAddress.Parse("166.111.140.14");
        int port = 8000;
        //TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 50000);
        //Socket client;
     

        public login()
        {
            //listener.Start();
            InitializeComponent();

            lol = this;

        }

        //定义一个委托  
        delegate void Show();

        //委托方法
        private void Show_Tim()
        {
            mainwindow main_win = new mainwindow(student_id);
            main_win.Show();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            //
            student_id = ID_text.Text.ToString();
            password = key_text.Text.ToString();

            //检查是否输入用户名及密码
            if (student_id == "" || password == "")
            {
                MessageBox.Show("用户或密码不能为空","登录提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            //
            IPEndPoint serve_port = new IPEndPoint(server_address,port);
            Socket client = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);//???
            
            //
            try
            {
               client.Connect(serve_port);
                
            }
            catch (SocketException)
            {
                MessageBox.Show("网络故障，请检查网络后重新连接", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //发送用户名及密码
            byte[] id_key = Encoding.UTF8.GetBytes(student_id+"_"+password);

            try
            {
                //client.Send(id_key, id_key.Length, SocketFlags.None);
                client.Send(id_key);
            }
            catch (Exception)
            {
                MessageBox.Show("连接超时，请重新连接", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //接收返回信息
            byte[] receive_byte = new byte[1024];
            int num = client.Receive(receive_byte);

            string receive_message = Encoding.UTF8.GetString(receive_byte , 0 ,num);//

            if (receive_message == "lol")
            {
                //MessageBox.Show("ok");
                client.Close();
               // mainwindow main_win = new mainwindow(student_id);
                //main_win.student_id = student_id;
                //Thread main_win = new Thread(() => Application.Run(new mainwindow(student_id)));
                //main_win.SetApartmentState(System.Threading.ApartmentState.STA);//单线程监听控制
               Show nT = new Show(Show_Tim);
               this.Invoke(nT);
                //this.Close();
                // main_win.Start();
              // main_win.Show();
               this.Hide();
                //lol.Hide();

            }
            else
            {
                MessageBox.Show("账号或密码错误", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        
        private void ID_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {/*
            IPAddress server_address = IPAddress.Parse("166.111.140.14");
            int port = 8000;

            IPEndPoint serve_port = new IPEndPoint(server_address, port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//???

            //开始建立连接
            try
            {
                client.Connect(serve_port);

            }
            catch (SocketException)
            {
                client.Close();
                MessageBox.Show("网络故障，请检查网络后重新连接", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] mess = Encoding.UTF8.GetBytes("logout" + student_id);

            try
            {
                client.Send(mess);
            }
            catch (Exception)
            {
                client.Close();
                MessageBox.Show("连接超时，请重新连接", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //接收注销信息
            byte[] receive_byte = new byte[1024];
            int number = client.Receive(receive_byte, receive_byte.Length, 0);

            string receive_mess = Encoding.UTF8.GetString(receive_byte, 0, number);

            if (receive_mess == "loo")
            {
                client.Close();
               MessageBox.Show("成功下线", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else
            {
                client.Close();
                MessageBox.Show("注销失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }*/
        }
    }
}
