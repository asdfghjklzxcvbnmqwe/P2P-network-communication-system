namespace Tim_mini
{
    partial class mainwindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainwindow));
            this.top_panel = new System.Windows.Forms.Panel();
            this.time_label = new System.Windows.Forms.Label();
            this.info_label = new System.Windows.Forms.Label();
            this.add_friend = new System.Windows.Forms.Panel();
            this.add_sure_panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.friend_name = new System.Windows.Forms.TextBox();
            this.bottom_panel = new System.Windows.Forms.Panel();
            this.left_panel = new System.Windows.Forms.Panel();
            this.ScorllBar = new System.Windows.Forms.Panel();
            this.ScorllHand = new System.Windows.Forms.Panel();
            this.content_panel = new System.Windows.Forms.Panel();
            this.friend_info = new System.Windows.Forms.Panel();
            this.friend_list_panel = new System.Windows.Forms.Panel();
            this.my_friend_label = new System.Windows.Forms.Label();
            this.right_panel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.mid_panel = new System.Windows.Forms.Panel();
            this.talk_panel = new System.Windows.Forms.Panel();
            this.input_panel = new System.Windows.Forms.Panel();
            this.send_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.edit_panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clear_label = new System.Windows.Forms.Label();
            this.smlie_panel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.clear_panel = new System.Windows.Forms.Panel();
            this.file_trans = new System.Windows.Forms.PictureBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.top_panel.SuspendLayout();
            this.add_friend.SuspendLayout();
            this.add_sure_panel.SuspendLayout();
            this.left_panel.SuspendLayout();
            this.ScorllBar.SuspendLayout();
            this.content_panel.SuspendLayout();
            this.friend_list_panel.SuspendLayout();
            this.right_panel.SuspendLayout();
            this.mid_panel.SuspendLayout();
            this.input_panel.SuspendLayout();
            this.send_panel.SuspendLayout();
            this.edit_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.smlie_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.file_trans)).BeginInit();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.Controls.Add(this.time_label);
            this.top_panel.Controls.Add(this.info_label);
            this.top_panel.Controls.Add(this.add_friend);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(682, 44);
            this.top_panel.TabIndex = 0;
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Location = new System.Drawing.Point(397, 26);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(0, 15);
            this.time_label.TabIndex = 2;
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.Location = new System.Drawing.Point(154, 26);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(82, 15);
            this.info_label.TabIndex = 0;
            this.info_label.Text = "当前对话：";
            // 
            // add_friend
            // 
            this.add_friend.Controls.Add(this.add_sure_panel);
            this.add_friend.Controls.Add(this.friend_name);
            this.add_friend.Location = new System.Drawing.Point(532, 18);
            this.add_friend.Name = "add_friend";
            this.add_friend.Size = new System.Drawing.Size(150, 26);
            this.add_friend.TabIndex = 1;
            // 
            // add_sure_panel
            // 
            this.add_sure_panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.add_sure_panel.Controls.Add(this.label3);
            this.add_sure_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.add_sure_panel.Location = new System.Drawing.Point(100, 0);
            this.add_sure_panel.Name = "add_sure_panel";
            this.add_sure_panel.Size = new System.Drawing.Size(50, 26);
            this.add_sure_panel.TabIndex = 1;
            this.add_sure_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.add_sure_panel_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "添加";
            this.label3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.add_sure_panel_MouseClick);
            // 
            // friend_name
            // 
            this.friend_name.Dock = System.Windows.Forms.DockStyle.Left;
            this.friend_name.Location = new System.Drawing.Point(0, 0);
            this.friend_name.Name = "friend_name";
            this.friend_name.Size = new System.Drawing.Size(108, 25);
            this.friend_name.TabIndex = 0;
            // 
            // bottom_panel
            // 
            this.bottom_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottom_panel.Location = new System.Drawing.Point(0, 431);
            this.bottom_panel.Name = "bottom_panel";
            this.bottom_panel.Size = new System.Drawing.Size(682, 16);
            this.bottom_panel.TabIndex = 3;
            // 
            // left_panel
            // 
            this.left_panel.Controls.Add(this.ScorllBar);
            this.left_panel.Controls.Add(this.content_panel);
            this.left_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_panel.Location = new System.Drawing.Point(0, 44);
            this.left_panel.Name = "left_panel";
            this.left_panel.Size = new System.Drawing.Size(150, 387);
            this.left_panel.TabIndex = 4;
            // 
            // ScorllBar
            // 
            this.ScorllBar.Controls.Add(this.ScorllHand);
            this.ScorllBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.ScorllBar.Location = new System.Drawing.Point(140, 0);
            this.ScorllBar.Name = "ScorllBar";
            this.ScorllBar.Size = new System.Drawing.Size(10, 387);
            this.ScorllBar.TabIndex = 0;
            // 
            // ScorllHand
            // 
            this.ScorllHand.BackColor = System.Drawing.SystemColors.Info;
            this.ScorllHand.Location = new System.Drawing.Point(0, 24);
            this.ScorllHand.Name = "ScorllHand";
            this.ScorllHand.Size = new System.Drawing.Size(10, 35);
            this.ScorllHand.TabIndex = 0;
            this.ScorllHand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScorllHand_MouseDown);
            this.ScorllHand.MouseLeave += new System.EventHandler(this.ScorllHand_MouseLeave);
            this.ScorllHand.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScorllHand_MouseMove);
            this.ScorllHand.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScorllHand_MouseUp);
            // 
            // content_panel
            // 
            this.content_panel.AutoSize = true;
            this.content_panel.Controls.Add(this.friend_info);
            this.content_panel.Controls.Add(this.friend_list_panel);
            this.content_panel.Location = new System.Drawing.Point(0, 0);
            this.content_panel.Name = "content_panel";
            this.content_panel.Size = new System.Drawing.Size(144, 136);
            this.content_panel.TabIndex = 2;
            // 
            // friend_info
            // 
            this.friend_info.Dock = System.Windows.Forms.DockStyle.Top;
            this.friend_info.Location = new System.Drawing.Point(0, 54);
            this.friend_info.Name = "friend_info";
            this.friend_info.Size = new System.Drawing.Size(144, 15);
            this.friend_info.TabIndex = 1;
            // 
            // friend_list_panel
            // 
            this.friend_list_panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.friend_list_panel.Controls.Add(this.my_friend_label);
            this.friend_list_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.friend_list_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.friend_list_panel.Location = new System.Drawing.Point(0, 0);
            this.friend_list_panel.Name = "friend_list_panel";
            this.friend_list_panel.Size = new System.Drawing.Size(144, 54);
            this.friend_list_panel.TabIndex = 1;
            this.friend_list_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.friend_list_panel_MouseClick);
            // 
            // my_friend_label
            // 
            this.my_friend_label.AutoSize = true;
            this.my_friend_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.my_friend_label.ForeColor = System.Drawing.Color.SteelBlue;
            this.my_friend_label.Location = new System.Drawing.Point(39, 24);
            this.my_friend_label.Name = "my_friend_label";
            this.my_friend_label.Size = new System.Drawing.Size(69, 20);
            this.my_friend_label.TabIndex = 0;
            this.my_friend_label.Text = "我的好友";
            this.my_friend_label.MouseClick += new System.Windows.Forms.MouseEventHandler(this.friend_list_panel_MouseClick);
            // 
            // right_panel
            // 
            this.right_panel.Controls.Add(this.label2);
            this.right_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.right_panel.Location = new System.Drawing.Point(609, 44);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(73, 387);
            this.right_panel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 230);
            this.label2.TabIndex = 0;
            this.label2.Text = "广告位招租";
            // 
            // mid_panel
            // 
            this.mid_panel.BackColor = System.Drawing.Color.White;
            this.mid_panel.Controls.Add(this.talk_panel);
            this.mid_panel.Controls.Add(this.input_panel);
            this.mid_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mid_panel.Location = new System.Drawing.Point(150, 44);
            this.mid_panel.Name = "mid_panel";
            this.mid_panel.Size = new System.Drawing.Size(459, 387);
            this.mid_panel.TabIndex = 6;
            // 
            // talk_panel
            // 
            this.talk_panel.AutoScroll = true;
            this.talk_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.talk_panel.Location = new System.Drawing.Point(0, 0);
            this.talk_panel.Name = "talk_panel";
            this.talk_panel.Size = new System.Drawing.Size(459, 308);
            this.talk_panel.TabIndex = 1;
            // 
            // input_panel
            // 
            this.input_panel.BackColor = System.Drawing.Color.Transparent;
            this.input_panel.Controls.Add(this.send_panel);
            this.input_panel.Controls.Add(this.edit_panel);
            this.input_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.input_panel.Location = new System.Drawing.Point(0, 311);
            this.input_panel.Name = "input_panel";
            this.input_panel.Size = new System.Drawing.Size(459, 76);
            this.input_panel.TabIndex = 0;
            // 
            // send_panel
            // 
            this.send_panel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.send_panel.Controls.Add(this.label1);
            this.send_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_panel.Location = new System.Drawing.Point(350, 0);
            this.send_panel.Name = "send_panel";
            this.send_panel.Size = new System.Drawing.Size(102, 76);
            this.send_panel.TabIndex = 1;
            this.send_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.send_panel_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "发送";
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.send_panel_MouseClick);
            // 
            // edit_panel
            // 
            this.edit_panel.Controls.Add(this.pictureBox1);
            this.edit_panel.Controls.Add(this.clear_label);
            this.edit_panel.Controls.Add(this.smlie_panel);
            this.edit_panel.Controls.Add(this.clear_panel);
            this.edit_panel.Controls.Add(this.file_trans);
            this.edit_panel.Controls.Add(this.richTextBox);
            this.edit_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.edit_panel.Location = new System.Drawing.Point(0, 0);
            this.edit_panel.Name = "edit_panel";
            this.edit_panel.Size = new System.Drawing.Size(305, 76);
            this.edit_panel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Tim_mini.pixtures.file2;
            this.pictureBox1.Location = new System.Drawing.Point(7, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 33);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.file_trans_MouseClick);
            // 
            // clear_label
            // 
            this.clear_label.AutoSize = true;
            this.clear_label.BackColor = System.Drawing.Color.White;
            this.clear_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clear_label.Location = new System.Drawing.Point(204, 5);
            this.clear_label.Name = "clear_label";
            this.clear_label.Size = new System.Drawing.Size(99, 20);
            this.clear_label.TabIndex = 0;
            this.clear_label.Text = "清空聊天记录";
            this.clear_label.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clear_panel_MouseClick);
            // 
            // smlie_panel
            // 
            this.smlie_panel.BackColor = System.Drawing.Color.Transparent;
            this.smlie_panel.Controls.Add(this.pictureBox2);
            this.smlie_panel.Location = new System.Drawing.Point(53, 0);
            this.smlie_panel.Name = "smlie_panel";
            this.smlie_panel.Size = new System.Drawing.Size(56, 33);
            this.smlie_panel.TabIndex = 3;
            this.smlie_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.smlie_panel_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Tim_mini.pixtures.smile;
            this.pictureBox2.Location = new System.Drawing.Point(3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 28);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.smlie_panel_MouseClick);
            // 
            // clear_panel
            // 
            this.clear_panel.Location = new System.Drawing.Point(204, 3);
            this.clear_panel.Name = "clear_panel";
            this.clear_panel.Size = new System.Drawing.Size(98, 22);
            this.clear_panel.TabIndex = 2;
            this.clear_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clear_panel_MouseClick);
            // 
            // file_trans
            // 
            this.file_trans.BackColor = System.Drawing.Color.Transparent;
            this.file_trans.Location = new System.Drawing.Point(7, 3);
            this.file_trans.Name = "file_trans";
            this.file_trans.Size = new System.Drawing.Size(40, 22);
            this.file_trans.TabIndex = 1;
            this.file_trans.TabStop = false;
            this.file_trans.MouseClick += new System.Windows.Forms.MouseEventHandler(this.file_trans_MouseClick);
            // 
            // richTextBox
            // 
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox.Location = new System.Drawing.Point(0, 31);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(303, 45);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 447);
            this.Controls.Add(this.mid_panel);
            this.Controls.Add(this.right_panel);
            this.Controls.Add(this.left_panel);
            this.Controls.Add(this.bottom_panel);
            this.Controls.Add(this.top_panel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "mainwindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mainwindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainwindow_FormClosing);
            this.LocationChanged += new System.EventHandler(this.mainwindow_LocationChanged);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            this.add_friend.ResumeLayout(false);
            this.add_friend.PerformLayout();
            this.add_sure_panel.ResumeLayout(false);
            this.add_sure_panel.PerformLayout();
            this.left_panel.ResumeLayout(false);
            this.left_panel.PerformLayout();
            this.ScorllBar.ResumeLayout(false);
            this.content_panel.ResumeLayout(false);
            this.friend_list_panel.ResumeLayout(false);
            this.friend_list_panel.PerformLayout();
            this.right_panel.ResumeLayout(false);
            this.mid_panel.ResumeLayout(false);
            this.input_panel.ResumeLayout(false);
            this.send_panel.ResumeLayout(false);
            this.send_panel.PerformLayout();
            this.edit_panel.ResumeLayout(false);
            this.edit_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.smlie_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.file_trans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel bottom_panel;
        private System.Windows.Forms.Panel left_panel;
        private System.Windows.Forms.Panel right_panel;
        private System.Windows.Forms.Panel mid_panel;
        private System.Windows.Forms.Panel friend_info;
        private System.Windows.Forms.Panel friend_list_panel;
        private System.Windows.Forms.Label my_friend_label;
        private System.Windows.Forms.Panel input_panel;
        private System.Windows.Forms.Panel send_panel;
        private System.Windows.Forms.Panel edit_panel;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Panel add_friend;
        private System.Windows.Forms.Panel add_sure_panel;
        private System.Windows.Forms.TextBox friend_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label info_label;
        private System.Windows.Forms.Panel ScorllBar;
        private System.Windows.Forms.Panel ScorllHand;
        private System.Windows.Forms.Panel content_panel;
        private System.Windows.Forms.PictureBox file_trans;
        private System.Windows.Forms.Panel talk_panel;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label clear_label;
        private System.Windows.Forms.Panel clear_panel;
        private System.Windows.Forms.Panel smlie_panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}