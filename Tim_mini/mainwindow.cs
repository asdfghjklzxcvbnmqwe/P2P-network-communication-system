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
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Threading;

namespace Tim_mini
{
    public partial class mainwindow : Form
    {
        public struct FRIEND
        {
           public string ID;
           //public string ip;
           public bool state;
        }
        

        public string student_id;
        Socket TCP_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        FRIEND[] myfriend = new FRIEND[1000];

        FRIEND current_friend;
        
        int target_port = 50000;
        Socket tcp_server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress local_ip;
        Panel pre_panel = null;
        bool mouse_wheel = false; //鼠标滑轮
        int limt, set_x; //滚动位置最大值和固定的左右的位置
        bool mouse_Press = false; //鼠标按下
        Point mouseOff; //存放当前鼠标位置
        int Fmx, Fmy; //主窗口坐标
        public smile smile_dlg = null;
        public PictureBox send_pic = new PictureBox();

        public mainwindow()
        {
            InitializeComponent();
           
        }
        //初始化
        public mainwindow(string stu_id)
        {
            InitializeComponent();
            student_id = stu_id;
            current_friend.ID = null;

            richTextBox.Focus();
            //friend_info.Visible = false;//设置好友列表不可见
            updat_friend();

            //listenr_dan();
            //得到本机IP地址
            IPAddress[] ip_list = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ipAddress in ip_list)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    local_ip = ipAddress;
                }
            }

            IPEndPoint serverIP = new IPEndPoint(local_ip, target_port);
            TCP_server.Bind(serverIP);
            TCP_server.Listen(20);
            mess_Accept(TCP_server);//接受连接套接字

            //滚动条位置定义
            set_x = ScorllHand.Location.X; //固定左右位置为当前位置
            limt = ScorllBar.Height - ScorllHand.Height; //滚动最大高度
            ScorllHand.Location = new Point(set_x, 0); //先将位置设置到最顶

            left_panel.MouseWheel += new MouseEventHandler(OnMouseWheel);
            //friend_list_panel.MouseWheel += new MouseEventHandler(OnMouseWheel);
            // left_panel.MouseWheel += new MouseEventHandler(OnMouseWheel);
            Fmx = this.Left;
            Fmy = this.Top;
        }

        //单击显示分组
        private void friend_list_panel_MouseClick(object sender, MouseEventArgs e)
        {
            friend_info.Visible = !(friend_info.Visible);
            calc_height();
           // updat_friend();
        }
        //添加好友
        private void add_sure_panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (friend_name.Text == "")
            {
                MessageBox.Show("请输入好友ID", "输入不能为空", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!(Regex.IsMatch(friend_name.Text, @"(^2016011([0-9]*)$)")))
            {
                MessageBox.Show("好友不存在，请重新输入", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (friend_name.Text.Length != 10 )
            {
                MessageBox.Show("输入学号长度有误，请重新输入", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //查询好友是否已经存在
            StreamReader sr = new StreamReader("Data/" + student_id + ".txt", Encoding.Default);
            String line;

            while ((line = sr.ReadLine()) != null)
            {
                if (line == friend_name.Text)
                {
                    MessageBox.Show("好友已存在列表中", "好友存在", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    sr.Close();
                    friend_name.Clear();
                    return;
                }
            }
            sr.Close();

            //更新本地好友列表
            StreamWriter sw = new StreamWriter("Data/" + student_id + ".txt", true);
            //开始写入
            sw.WriteLine(friend_name.Text);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();

            friend_name.Clear();

            MessageBox.Show("添加好友成功", "成功添加", MessageBoxButtons.OK, MessageBoxIcon.Information);

            updat_friend();

            calc_height();
        }
        //更新好友列表
        private void updat_friend()
        {
            string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = currPath + "/Data/";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }
            if (!File.Exists("Data/" + student_id + ".txt"))
            {
                FileStream fs1 = new FileStream("Data/" + student_id + ".txt", FileMode.Create);
                fs1.Close();
            }

            StreamReader sr = new StreamReader("Data/" + student_id + ".txt", Encoding.Default);
            String line;
            friend_info.Controls.Clear();

            while ((line = sr.ReadLine()) != null)
            {
                Panel freiend_list = new Panel();
                Label id = new Label();

                id.Text = line;
                id.Location = new Point(20, 5);
                id.Font = new Font("微软雅黑", 9);
                id.ForeColor = Color.Purple;
                freiend_list.Controls.Add(id);

                freiend_list.Height = 40;
                freiend_list.BackColor = Color.FromArgb(128, 128, 128);
                freiend_list.Dock = DockStyle.Top;
                freiend_list.Cursor = Cursors.Hand;
                friend_info.Controls.Add(freiend_list);

                id.MouseClick += new MouseEventHandler(label_MouseClick);
                freiend_list.MouseClick += new MouseEventHandler(panel_MouseClick);
            }
            sr.Close();

            friend_info.AutoSize = true;

        }
        //更新好友在线信息
        private void update_FRIEND(FRIEND current)
        {

        }
        //查询好友是否在线并返回其地址
        public string Search(string IDnumber)
        {
            IPAddress server_address = IPAddress.Parse("166.111.140.14");
            int port = 8000;

            IPEndPoint serve_port = new IPEndPoint(server_address, port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //开始建立连接
            try
            {
                client.Connect(serve_port);

            }
            catch (SocketException)
            {
                MessageBox.Show("网络故障，请检查网络后重新连接", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            byte[] mess = Encoding.UTF8.GetBytes("q" + IDnumber);

            try
            {
                client.Send(mess);
            }
            catch (Exception)
            {
                MessageBox.Show("连接超时，请重新连接", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            //接收注销信息
            byte[] receive_byte = new byte[1024];
            int number = client.Receive(receive_byte, receive_byte.Length, 0);

            string receive_mess = Encoding.UTF8.GetString(receive_byte, 0, number);
             return receive_mess;

            //client.Close();
        }

        //计算分组高度
        private void calc_height()
        {
            int scr = 0;

            if (friend_info.Visible == true)
            {
                scr += friend_info.Height;
            }

            scr += friend_list_panel.Height;
            //scr += add_friend.Height;

           if ((scr - left_panel.Height) <= 0)
            {
                mouse_wheel = false;
                content_panel.Top = 0;
                ScorllHand.Location = new Point(set_x,0);
            }
            else
            {
                mouse_wheel = true;
                
           }
        }
        //鼠标滑轮
        private void OnMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }
        private void ScorllHand_MouseMove(object sender, MouseEventArgs e)
        {
            calc_height();
            if (mouse_wheel)   //可以用滑轮
            {
                if (mouse_Press) //鼠标按下状态
                {
                    int set_y = ScorllHand.Top + e.Y - mouseOff.Y; //计算当前纵向坐标
                    if (set_y < 0)
                    {
                        set_y = 0;
                    } //超范围
                    else if (set_y > limt)
                    {
                        set_y = limt;
                    } //超范围
                    else
                    {
                        ScorllHand.Location = new Point(set_x, set_y); }
                    //滚动块的定位

                    content_panel.Top = -set_y; //装内容的panel滚动显示
                }
            }
        }
        private void ScorllHand_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_Press = false; //鼠标放开
        }
        private void ScorllHand_MouseLeave(object sender, EventArgs e)
        {
            mouse_wheel = false; //滑轮不可用
        }
        private void ScorllHand_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //鼠标左键
            {
                mouseOff.Y = e.Y;  //取当前位置
                mouse_Press = true; //鼠标按下
            }
        }
      
        //单击开始对话
        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            Label text = (Label)sender;

            string stu_id = text.Text.ToString();

            BeginTalk(stu_id);

            if (pre_panel != null)
            {
                pre_panel.BackColor = Color.FromArgb(128, 128, 128);
            }

            text.Parent.BackColor = Color.FromArgb(255, 255, 255);
            //chanel.BackColor = Color.FromArgb(255, 255, 255);

            pre_panel = (Panel)text.Parent;

            info_label.Text = "当前对话：" + stu_id;
            time_label.Text = DateTime.Now.ToString("HH:mm");

        }
        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel chanel = (Panel)sender;
            string stu_id = chanel.Controls[0].Text.ToString();
            BeginTalk(stu_id);

            if (pre_panel != null)
            {
                pre_panel.BackColor = Color.FromArgb(128, 128, 128);
            }

            chanel.BackColor = Color.FromArgb(255,255,255);

            pre_panel = chanel;

            info_label.Text = "当前对话：" + stu_id;
            time_label.Text = DateTime.Now.ToString("HH:mm");

        }
        //显示聊天记录
        private void BeginTalk(string stu_id)
        {
            talk_panel.Controls.Clear();

            //显示聊天记录
            if (File.Exists(student_id + "/" + stu_id + ".txt"))
            {
                StreamReader sr = new StreamReader(student_id + "/" + stu_id + ".txt", Encoding.UTF8);
                String line;
                
                while ((line = sr.ReadLine())!=null)
                {
                    if (line == "")
                    {

                    }
                    else
                    {
                        if (line[10] == ':')
                        {
                            string send_mess;
                            send_mess = line.Substring(11, line.Length - 11);
                            show_send_message(send_mess);
                        }
                        if (line[10] == '*')
                        {
                            string receive_mess;
                            receive_mess = line.Substring(11, line.Length - 11);
                            show_receive_mess(receive_mess,null);
                        }
                        if (line[10] == '+')
                        {
                            string pic_path;
                            pic_path = line.Substring(11, line.Length - 11);

                            string currPath = Application.StartupPath;
                           pic_path = currPath + "/" + student_id + "/" + "sendpic/" + pic_path;

                            PictureBox show_pic = new PictureBox();
                            //接收端输出图片
                            show_pic.Image = Image.FromFile(pic_path);
                            show_pic.Size = new Size(150, 150);
                            show_pic.SizeMode = PictureBoxSizeMode.Zoom;
                            show_pic.BackColor = Color.Transparent;
                            show_pic.Location = new Point(170, talk_panel.Height);

                            talk_panel.Controls.Add(show_pic);
                            talk_panel.ScrollControlIntoView(show_pic);

                        }
                        if (line[10] == '-')
                        {
                            string pic_path;
                            pic_path = line.Substring(11, line.Length - 11);

                            string currPath = Application.StartupPath;
                            pic_path = currPath + "\\" + student_id + "\\" + "receivepic\\" + pic_path;

                            PictureBox show_pic = new PictureBox();
                            //接收端输出图片
                            show_pic.Image = Image.FromFile(pic_path);
                            show_pic.Size = new Size(150, 150);
                            show_pic.SizeMode = PictureBoxSizeMode.Zoom;
                            show_pic.BackColor = Color.Transparent;
                            show_pic.Location = new Point(0, talk_panel.Height);

                            talk_panel.Controls.Add(show_pic);
                            talk_panel.ScrollControlIntoView(show_pic);
                        }
                    }
                }

                sr.Close();
            }
            
            string result = Search(stu_id);

            if (result == "n")
            {
                MessageBox.Show("好友不在线，无法发送信息", "好友不在线", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                current_friend.ID = stu_id;
                //current_friend.ip = null;
                current_friend.state = false;
            }
            else if (result == null)
            {
                current_friend.ID = stu_id;
                // current_friend.ip = null;
                current_friend.state = false;
            }
            else
            {
                current_friend.ID = stu_id;
                //current_friend.ip = result;
                current_friend.state = true;
            }

        }
        //退出TIM——mini
        private void mainwindow_FormClosing(object sender, FormClosingEventArgs e)
        {
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

            byte[] mess = Encoding.UTF8.GetBytes("logout"+student_id);

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
                login.lol.Close();
                return;
            }
            else
            {
                client.Close();
                MessageBox.Show("注销失败", "信息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            
        }
        
        //发送信息
        private void send_panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (current_friend.ID == null)
            {
                MessageBox.Show("请先选取好友","错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string result = Search(current_friend.ID);

            if (result == "n")
            {
                MessageBox.Show("好友不在线，无法发送信息", "好友不在线", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (result == null)
            {
                return;
            }
            else
            {
                string send_mess = richTextBox.Text;

                if (send_mess == "")
                {
                    MessageBox.Show("发送消息不能为空", "发送消息错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else {
                    IPAddress server_address = IPAddress.Parse(result);
                  //  MessageBox.Show(result, "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IPEndPoint serve_port = new IPEndPoint(server_address, target_port);
                    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //开始建立连接
                    try
                    {
                        client.Connect(serve_port);
                     
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return ;
                    }

                    //发送自身信息
                    byte[] name = Encoding.UTF8.GetBytes(student_id);

                    byte[] my_name = new byte[1024];
                    for (int i = 0; i < name.Length; i++)
                    {
                        my_name[i] = name[i];
                    }
                    client.Send(my_name, 1024, SocketFlags.None);

                    mess_Send(client,send_mess);

                    client.Close();
                    richTextBox.Clear();
                }


            }
        }

        //异步发送消息
        public void mess_Send(Socket tcpClient, string message)
        {
           
                    write_record(current_friend.ID + ":" + message);
                   
           
            
            byte[] data = Encoding.UTF8.GetBytes(message);
            
            tcpClient.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
            {
                 try
                {
                     //完成发送消息
                     int length = tcpClient.EndSend(asyncResult);
                 }
                 catch (Exception ex)
                 {
                    MessageBox.Show(ex.ToString(), "发送错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                //int length = tcpClient.EndSend(asyncResult);

            }, null);

            show_send_message(message);



        }
        //显示发送的信息
        private void show_send_message(string message)
        {
            Label receive_text = new Label();

            receive_text.Text = message;
            receive_text.Location = new Point(150, 5);
            receive_text.Font = new Font("微软雅黑", 9);
            receive_text.ForeColor = Color.SteelBlue;
            receive_text.Location = new Point(170, talk_panel.Height);
           // receive_text.Size = new Size(150,50*(message.Length/30 + 1));
            receive_text.AutoSize = true;
            talk_panel.Controls.Add(receive_text);

             talk_panel.ScrollControlIntoView(receive_text);

            richTextBox.Clear();
        }
        //接受连接
        public void mess_Accept(Socket tcpServer)
        {
            tcpServer.BeginAccept(asyncResult =>
            {
                Socket tcpClient = tcpServer.EndAccept(asyncResult);
                mess_Accept(tcpServer);//继续监听其余连接
                mess_Recive(tcpClient);//监听信息
            }, null);
        }
        //写入聊天记录
        private void write_record(string messsage)
        {
            //写入聊天记录
            
            //获取当前文件夹路径
            string currPath = Application.StartupPath;

            //检查是否存在文件夹
            string subPath = currPath + "/" + student_id + "/";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            string friendpath = messsage.Substring(0,10);
            string savePath = subPath + friendpath + ".txt";

            FileStream fs = new FileStream(savePath, FileMode.Append, FileAccess.Write);
           // fs.Flush();
            byte[] data = Encoding.UTF8.GetBytes(messsage+'\r'+'\n');
            // fs.WriteAsync(data,0,data.Length);
            fs.Write(data, 0, data.Length);
            fs.Close();

        }
        //接收信息
        delegate void show_message(string mess,Socket client);
        delegate void file_accept(string mess,Socket file_sender);
        delegate void pic_accept(string mess,Socket pic_sender);
        //清空聊天记录
        private void clear_panel_MouseClick(object sender, MouseEventArgs e)
        {
            //写入聊天记录
            //获取当前文件夹路径
            string currPath = Application.StartupPath;

            //检查是否存在文件夹
            string subPath = currPath + "/" + student_id + "/";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            string savePath = subPath + current_friend.ID + ".txt";

            FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
            // fs.Flush();
            //byte[] data = Encoding.UTF8.GetBytes(messsage + '\r' + '\n');
            // fs.WriteAsync(data,0,data.Length);
            //fs.Write(data, 0, data.Length);
            fs.Close();

            talk_panel.Controls.Clear();
        }
        //接收信息
        public void mess_Recive(Socket tcpClient)
        {
            //string mess;

            byte[] data = new byte[1024];
            try
            {
                tcpClient.BeginReceive(data, 0, data.Length, SocketFlags.None,
                asyncResult =>
                {
                    int length = tcpClient.EndReceive(asyncResult);
                    
                    string recieve_mess = Encoding.UTF8.GetString(data, 0, data.Length);
                    // recieve_mess += '\n';
                    recieve_mess = recieve_mess.TrimEnd('\0');//服了真的
                                                              // MessageBox.Show(recieve_mess, "发送错误", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    if (recieve_mess.Length >14 )
                    {
                        if(recieve_mess.Substring(0, 14) == "/****file****/")
                        {
                            file_accept acc = new file_accept(file_receive);
                            this.Invoke(acc, new object[] { recieve_mess, tcpClient });
                        }  
                        else if (recieve_mess.Length > 17)
                            {
                                if (recieve_mess.Substring(0, 17) == "/****picture****/")
                                {
                                pic_accept acc = new pic_accept(pic_receive);
                                this.Invoke(acc, new object[] { recieve_mess, tcpClient });
                                 }
                                else
                                {
                                show_message mess = new show_message(show_receive_mess);
                                this.Invoke(mess, new object[] { recieve_mess, tcpClient });
                                }
                            }
                            else
                            {
                                show_message mess = new show_message(show_receive_mess);
                                this.Invoke(mess, new object[] { recieve_mess, tcpClient });
                            }
                    }
                    else
                    {
                        show_message mess = new show_message(show_receive_mess);
                        this.Invoke(mess, new object[] { recieve_mess, tcpClient });
                    }
                   
                }, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //show_mess(mess);
        }//
        //信息展示
        private void show_receive_mess(string messsage,Socket Client)
        {
            if(Client ==null)
            {
                Label receive_text = new Label();

                receive_text.Text = messsage;
                //receive_text.Location = new Point(0, 5);
                receive_text.Font = new Font("微软雅黑", 9);
                //receive_text.Height = 50;
                receive_text.Location = new Point(0, talk_panel.Height);
                //  receive_text.Size = new Size(150, 50 * (messsage.Length / 30 + 1));
                receive_text.AutoSize = true;

                talk_panel.Controls.Add(receive_text);
                talk_panel.ScrollControlIntoView(receive_text);

               // richTextBox.Clear();
                return;
            }
            byte[] data = new byte[1024];
            Client.Receive(data, 1024, SocketFlags.None);

            string news = Encoding.UTF8.GetString(data, 0, data.Length);
           // news = news.TrimEnd('\n'); 
            
            write_record(messsage + "*" + news);

            if (messsage == current_friend.ID)
            {

                Label receive_text = new Label();

                receive_text.Text = news;
                receive_text.Location = new Point(0, 5);
                receive_text.Font = new Font("微软雅黑", 9);
               // receive_text.Size = new Size(150, 50 * (messsage.Length / 30 + 1));

               // receive_text.Height = 50;
                //receive_text.ForeColor = Color.SteelBlue;
                //receive_text.Dock = DockStyle.Bottom;
                receive_text.Location = new Point(0, talk_panel.Height);
                receive_text.AutoSize = true;

                // Lineheight += receive_text.Height;
                //freiend_list.Controls.Add(id);
                // MessageBox.Show(messsage, "test", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                talk_panel.Controls.Add(receive_text);

                //talk_panel.Focus();

                //MessageBox.Show(Lineheight.ToString(), "test", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //talk_panel.AutoSize = true;
                //   Point newpoint = new Point(0, talk_panel.Height - talk_panel.AutoScrollPosition.Y);
                // talk_panel.AutoScrollPosition = newpoint;
                talk_panel.ScrollControlIntoView(receive_text);

                richTextBox.Clear();
            }
            Client.Close();
        }
        //发送文件
        private void file_trans_MouseClick(object sender, MouseEventArgs e)
        {
            if (current_friend.ID == null)
            {
                MessageBox.Show("请先选取好友", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string result = Search(current_friend.ID);

            if (result == "n")
            {
                MessageBox.Show("好友不在线，无法发送信息", "好友不在线", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (result == null)
            {
                return;
            }
            else
            {
                //选择文件
                //成功打开文件
                OpenFileDialog filechose_Dialog = new OpenFileDialog();
                if (filechose_Dialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = filechose_Dialog.FileName;
                    //byte[] data = Encoding.UTF8.GetBytes("/****file****/");
                    byte[] file_name = Encoding.UTF8.GetBytes(filename);

                    byte[] my_filename = new byte[1024];
                    for (int i = 0; i < file_name.Length; i++)
                    {
                        my_filename[i] = file_name[i];
                    }
                    IPAddress server_address = IPAddress.Parse(result);
                    IPEndPoint serve_port = new IPEndPoint(server_address, target_port);
                    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //开始建立连接
                    try
                    {
                        client.Connect(serve_port);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    
                    FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);              
                    int single = 0;
                    int total= 0;
                    byte[] fileData = new byte[1024];
                    // file.Flush();
                   // int k =(int) ((file.Length) / 1024) + 1;

                    byte[] pre_data = Encoding.UTF8.GetBytes("/****file****/" + student_id + file.Length.ToString());
                    byte[] data = new byte[1024];
                    for (int i = 0; i < pre_data.Length; i++)
                    {
                        data[i] = pre_data[i];
                    }
                    client.Send(data,1024,SocketFlags.None);
                    //byte_Send(client, data);
                    //发送自身信息
                    // byte[] name = Encoding.UTF8.GetBytes(student_id);
                    /*
                    byte[] my_name = new byte[1010];
                    for (int i = 0; i < name.Length; i++)
                    {
                        my_name[i] = name[i];
                    }
                    client.Send(my_name, 1024, SocketFlags.None);
                    */
                    // byte_Send(client,name);
                    client.Send(my_filename, 1024, SocketFlags.None);

                    while (total < file.Length)
                    {
                        //file.Flush();
                        single = file.Read(fileData,0,1024);
                        byte_Send(client,fileData);
                        //client.Send(fileData, SocketFlags.None);
                      //  client.Send(fileData,fileData.Length,SocketFlags.None);
                        total += single;
                     }
                    

                    file.Close();
                   
                   // client.SendFile(filename, null, null, TransmitFileOptions.UseDefaultWorkerThread);

                    show_send_message("文件成功发送");
                    write_record(student_id +":文件成功发送");
                }
                else
                {
                    show_send_message("文件选取失败，请重新检查");

                }

            }
           
        }
     
        //发送字节
        //异步发送消息
        private void byte_Send(Socket tcpClient, byte[] data)
        {
           // byte[] data = Encoding.UTF8.GetBytes(message);
            tcpClient.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
            {
                try
                {
                    //完成发送消息
                   int length = tcpClient.EndSend(asyncResult);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "发送错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }, null);

            //show_send_message(message);

        }
        //接收文件
        private void file_receive(string mess,Socket tcpclient)
        {
            /*
            byte[] namedata = new byte[1024];
         
            tcpclient.Receive(namedata, 1024, SocketFlags.None);

            string name = Encoding.UTF8.GetString(namedata, 0, 1024);

            name = name.TrimEnd('\0');
            */
            byte[] input = new byte[1024];
            int single_bytes;
           
            tcpclient.Receive(input, 1024,SocketFlags.None);
           
            string filename = Encoding.UTF8.GetString(input, 0, 1024);
            
            filename = filename.Trim('\0');
            string path = System.IO.Path.GetFileName(filename);
            string extension = System.IO.Path.GetExtension(filename);
            string path_without_extension = System.IO.Path.GetFileNameWithoutExtension(filename);

            string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = currPath + "\\file\\";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            string filepath = subPath+path;//文件保存路径
            if (File.Exists(filepath))
            {
                for (int i = 1; ; i++)
                {
                    if (!File.Exists(subPath+ path_without_extension+"("+i.ToString()+")"+extension))
                    {
                        filepath =subPath+ path_without_extension + "(" + i.ToString() + ")" + extension;
                        break;
                    }
                }
            }
                 FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            // total_bytes = 0;
            byte[] pass = new byte[1024];
            string k = mess.Substring(24, mess.Length-24);
            int j = int.Parse(k);
            single_bytes = 0;
            int total = 0;
            //single_bytes = tcpclient.Receive(pass, pass.Length, SocketFlags.None);
            /*while ((single_bytes = tcpclient.Receive(pass, pass.Length, SocketFlags.None)) > 0)
                {
                  // single_bytes = tcpclient.Receive(pass, pass.Length, SocketFlags.None);
                // string get = Encoding.ASCII.GetString(pass, 0, single_bytes);


                    fs.Write(pass, 0, single_bytes);
                  //fs.Flush();
                // total_bytes = total_bytes + single_bytes;
                    //get = get.TrimEnd('\0');
                    //single_bytes = Encoding.ASCII.GetByteCount(get);
                    
                 }*/
            while(total +1024 < j)
            {
                single_bytes = tcpclient.Receive(pass, pass.Length, SocketFlags.None);
                fs.Write(pass, 0, single_bytes);
                total += single_bytes;
            }       
                single_bytes = tcpclient.Receive(pass, j - total, SocketFlags.None);
                fs.Write(pass, 0, single_bytes);

            fs.Close();
            
            show_receive_mess("文件成功接收",null);

            write_record(mess.Substring(14,10) + "*" + "文件成功接收");
            tcpclient.Close();
        }
        //显示表情窗口
        private void mainwindow_LocationChanged(object sender, EventArgs e)
        {
            Fmx = this.Left;
            Fmy = this.Top;
            if (smile_dlg != null)
            {
                smile_dlg.Left = Fmx + 80;
                smile_dlg.Top = Fmy + 113;
            }
        }
        private void smlie_panel_MouseClick(object sender, MouseEventArgs e)
        {
            if (smile_dlg == null)
            {
                smile_dlg = new smile(this);
                smile_dlg.Left = Fmx + 80;
                smile_dlg.Top = Fmy + 113;
                smile_dlg.Show();

              // SENDPIC pcs = new SENDPIC(start_send_pic);
              // this.Invoke(pcs);
             
                return;
            }
            if (smile_dlg != null)
            {
                smile_dlg.Close();
                smile_dlg = null;
                return;
            }
        }
        //发送表情
        //定义一个委托  
        delegate void SENDPIC();
        //发送图片
        public void start_send_pic()
        {
            if (send_pic == null)
            {
                return;
            }
            //发送图片
            if (current_friend.ID == null)
            {
                MessageBox.Show("请先选取好友", "错误", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string result = Search(current_friend.ID);

            if (result == "n")
            {
                MessageBox.Show("好友不在线，无法发送信息", "好友不在线", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            else if (result == null)
            {
                return;
            }
            else
            {
                    IPAddress server_address = IPAddress.Parse(result);
                    IPEndPoint serve_port = new IPEndPoint(server_address, target_port);
                    Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    //开始建立连接
                    try
                    {
                        client.Connect(serve_port);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                // mess_Send(client, "/****picture****/"+student_id);
                MemoryStream ms = new MemoryStream();
                string format = GetFormat(send_pic.Image);
               
                send_pic.Image.Save(ms, GetImageFormat(send_pic.Image));
                byte[] data = ms.GetBuffer();

                byte[] pre_data = Encoding.UTF8.GetBytes("/****picture****/" + student_id + data.Length.ToString());
                byte[] send_data = new byte[1024];
                for (int i = 0; i < pre_data.Length; i++)
                {
                    send_data[i] = pre_data[i];
                }
                byte_Send(client, send_data);
               
               
                // send_pic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
               

                // send_pic.Image = null;
                byte[] format_info = Encoding.UTF8.GetBytes(format);
                byte[] send_format = new byte[1024];
                for (int i = 0; i < format_info.Length; i++)
                {
                   send_format[i] = format_info[i];
                }
                client.Send(send_format,1024,SocketFlags.None);
                
                byte_Send(client,data);

               // client.Close();
               // show_send_message("文件成功发送");
               
            }

            PictureBox show_pic = new PictureBox();
            //发送端输出图片
            show_pic.Image = send_pic.Image;
            show_pic.Size = new Size(150, 150);
            show_pic.SizeMode = PictureBoxSizeMode.Zoom;
            show_pic.BackColor = Color.Transparent;
            show_pic.Location = new Point(180, talk_panel.Height);

            talk_panel.Controls.Add(show_pic);
            talk_panel.ScrollControlIntoView(show_pic);

            
            //将图片保存至发送图片
            string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = currPath + "/" + student_id + "/"+"sendpic/";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            string picpath;//文件保存路径
            //int savenum;
            string my_format = GetFormat(send_pic.Image);
            for (int i = 1; ; i++)
            {
                if (!File.Exists(subPath + i.ToString() +my_format))
                {
                    picpath = subPath + i.ToString() + my_format;
                    //savenum = i;
                    //保存至聊天记录
                    write_record(current_friend.ID + "+" + i.ToString() + my_format);
                    break;
                }
            }
            FileStream fs = new FileStream(picpath, FileMode.Create, FileAccess.Write);

            send_pic.Image.Save(fs, GetImageFormat(send_pic.Image));
            send_pic.Image = null;

        }
        //判断图片格式
        private System.Drawing.Imaging.ImageFormat GetImageFormat(Image _img)
        {
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
            {
               // format = ".jpg";
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
            {
               // format = ".gif";
                return System.Drawing.Imaging.ImageFormat.Gif;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
            {
               // format = ".png";
                return System.Drawing.Imaging.ImageFormat.Png;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
            {
              //  format = ".bmp";
                return System.Drawing.Imaging.ImageFormat.Bmp;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
            {
               // format = "ico";
                return System.Drawing.Imaging.ImageFormat.Bmp;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Wmf))
            {
               // format = ".wmf";
                return System.Drawing.Imaging.ImageFormat.Bmp;
            }
          //  format = string.Empty;
            return null;
        }

        //输出图片格式
        private string GetFormat(Image _img)
        {
            string format;

            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
            {
                format = ".jpg";
                return format;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Gif))
            {
                format = ".gif";
                return format;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png))
            {
                format = ".png";
                return format;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
            {
                format = ".bmp";
                return format;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Icon))
            {
                format = "ico";
                return format;
            }
            if (_img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Wmf))
            {
                format = ".wmf";
                return format;

            }
            format = string.Empty;
            return format;

        }
        //接收图片
        private void pic_receive(string mess,Socket tcpclient)
        {
            string sender = mess.Substring(17, 10);

            byte[] format_name = new byte[1024];

            tcpclient.Receive(format_name, 1024, SocketFlags.None);

            string format = Encoding.UTF8.GetString(format_name, 0, 1024); ;

            format = format.TrimEnd('\0');
            
            string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = currPath + "/" + student_id + "/receivepic/";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            string picpath;//文件保存路径
            //int savenum;
            for (int i = 1; ; i++)
            {
                if (!File.Exists(subPath + i.ToString() + format))
                {
                    picpath = subPath + i.ToString() + format;
                    // savenum = i;
                    //保存至聊天记录
                    write_record(sender + "-" + i.ToString() + format);
                    break;
                }
            }
            
            FileStream fs = new FileStream(picpath, FileMode.Create, FileAccess.Write);
            // total_bytes = 0;
         /*   byte[] pass = new byte[1024];
            int single_bytes = 0;
            while (true)
            {
                single_bytes = tcpclient.Receive(pass, 1024, SocketFlags.None);

                fs.Write(pass, 0, single_bytes);
                //fs.Flush();
                if (single_bytes < 1024)//分片结束，接收完毕
                {
                    break;
                }
            }
            fs.Close();
            */
            byte[] pass = new byte[1024];
            string k = mess.Substring(27, mess.Length - 27);
            int j = int.Parse(k);
           int  single_bytes = 0;
            int total = 0;
            
            while (total + 1024 < j)
            {
                single_bytes = tcpclient.Receive(pass, pass.Length, SocketFlags.None);
                fs.Write(pass, 0, single_bytes);
                total += single_bytes;
            }
            single_bytes = tcpclient.Receive(pass, j - total, SocketFlags.None);
            fs.Write(pass, 0, single_bytes);

            fs.Close();

            if (sender == current_friend.ID)
            {
                PictureBox show_pic = new PictureBox();
                //接收端输出图片
                show_pic.Image = Image.FromFile(picpath);
                show_pic.Size = new Size(150, 150);
                show_pic.SizeMode = PictureBoxSizeMode.Zoom;
                show_pic.BackColor = Color.Transparent;
                show_pic.Location = new Point(0, talk_panel.Height);

                talk_panel.Controls.Add(show_pic);
                talk_panel.ScrollControlIntoView(show_pic);
            }
            // show_receive_mess("文件成功接收");
            // write_record(current_friend.ID + "*" + "文件成功接收");
            tcpclient.Close();
        }
    }
}
