namespace DX.CCRMainWindow
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_state_s = new System.Windows.Forms.TextBox();
            this.btn_restart_service = new System.Windows.Forms.Button();
            this.btn_stop_service = new System.Windows.Forms.Button();
            this.btn_start_service = new System.Windows.Forms.Button();
            this.btn_uninstall_service = new System.Windows.Forms.Button();
            this.btn_install_service = new System.Windows.Forms.Button();
            this.btn_view_log = new System.Windows.Forms.Button();
            this.btn_view_pictures = new System.Windows.Forms.Button();
            this.btn_show_image = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(709, 527);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_state_s);
            this.groupBox1.Controls.Add(this.btn_restart_service);
            this.groupBox1.Controls.Add(this.btn_stop_service);
            this.groupBox1.Controls.Add(this.btn_start_service);
            this.groupBox1.Controls.Add(this.btn_uninstall_service);
            this.groupBox1.Controls.Add(this.btn_install_service);
            this.groupBox1.Location = new System.Drawing.Point(743, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 279);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "滑橇号在线识别服务";
            // 
            // tb_state_s
            // 
            this.tb_state_s.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tb_state_s.Location = new System.Drawing.Point(17, 49);
            this.tb_state_s.Name = "tb_state_s";
            this.tb_state_s.Size = new System.Drawing.Size(152, 28);
            this.tb_state_s.TabIndex = 2;
            this.tb_state_s.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_restart_service
            // 
            this.btn_restart_service.Location = new System.Drawing.Point(191, 122);
            this.btn_restart_service.Name = "btn_restart_service";
            this.btn_restart_service.Size = new System.Drawing.Size(152, 47);
            this.btn_restart_service.TabIndex = 0;
            this.btn_restart_service.Text = "重启";
            this.btn_restart_service.UseVisualStyleBackColor = true;
            this.btn_restart_service.Click += new System.EventHandler(this.btn_restart_service_Click);
            // 
            // btn_stop_service
            // 
            this.btn_stop_service.Location = new System.Drawing.Point(191, 204);
            this.btn_stop_service.Name = "btn_stop_service";
            this.btn_stop_service.Size = new System.Drawing.Size(152, 47);
            this.btn_stop_service.TabIndex = 0;
            this.btn_stop_service.Text = "停止";
            this.btn_stop_service.UseVisualStyleBackColor = true;
            this.btn_stop_service.Click += new System.EventHandler(this.btn_stop_service_Click);
            // 
            // btn_start_service
            // 
            this.btn_start_service.Location = new System.Drawing.Point(191, 40);
            this.btn_start_service.Name = "btn_start_service";
            this.btn_start_service.Size = new System.Drawing.Size(152, 47);
            this.btn_start_service.TabIndex = 0;
            this.btn_start_service.Text = "启动";
            this.btn_start_service.UseVisualStyleBackColor = true;
            this.btn_start_service.Click += new System.EventHandler(this.btn_start_service_Click);
            // 
            // btn_uninstall_service
            // 
            this.btn_uninstall_service.Location = new System.Drawing.Point(365, 205);
            this.btn_uninstall_service.Name = "btn_uninstall_service";
            this.btn_uninstall_service.Size = new System.Drawing.Size(152, 47);
            this.btn_uninstall_service.TabIndex = 0;
            this.btn_uninstall_service.Text = "卸载服务";
            this.btn_uninstall_service.UseVisualStyleBackColor = true;
            this.btn_uninstall_service.Click += new System.EventHandler(this.btn_uninstall_service_Click);
            // 
            // btn_install_service
            // 
            this.btn_install_service.Location = new System.Drawing.Point(365, 40);
            this.btn_install_service.Name = "btn_install_service";
            this.btn_install_service.Size = new System.Drawing.Size(152, 47);
            this.btn_install_service.TabIndex = 0;
            this.btn_install_service.Text = "安装服务";
            this.btn_install_service.UseVisualStyleBackColor = true;
            this.btn_install_service.Click += new System.EventHandler(this.btn_install_service_Click);
            // 
            // btn_view_log
            // 
            this.btn_view_log.Location = new System.Drawing.Point(934, 324);
            this.btn_view_log.Name = "btn_view_log";
            this.btn_view_log.Size = new System.Drawing.Size(152, 47);
            this.btn_view_log.TabIndex = 0;
            this.btn_view_log.Text = "查看日志";
            this.btn_view_log.UseVisualStyleBackColor = true;
            this.btn_view_log.Click += new System.EventHandler(this.btn_view_log_Click);
            // 
            // btn_view_pictures
            // 
            this.btn_view_pictures.Location = new System.Drawing.Point(1108, 324);
            this.btn_view_pictures.Name = "btn_view_pictures";
            this.btn_view_pictures.Size = new System.Drawing.Size(152, 47);
            this.btn_view_pictures.TabIndex = 0;
            this.btn_view_pictures.Text = "历史图片";
            this.btn_view_pictures.UseVisualStyleBackColor = true;
            this.btn_view_pictures.Click += new System.EventHandler(this.btn_view_pictures_Click);
            // 
            // btn_show_image
            // 
            this.btn_show_image.Location = new System.Drawing.Point(760, 324);
            this.btn_show_image.Name = "btn_show_image";
            this.btn_show_image.Size = new System.Drawing.Size(152, 47);
            this.btn_show_image.TabIndex = 2;
            this.btn_show_image.Text = "显示画面";
            this.btn_show_image.UseVisualStyleBackColor = true;
            this.btn_show_image.Click += new System.EventHandler(this.btn_show_image_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 559);
            this.Controls.Add(this.btn_show_image);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_view_pictures);
            this.Controls.Add(this.btn_view_log);
            this.Name = "MainForm";
            this.Text = "中控室-底漆滑橇号实时检测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_state_s;
        private System.Windows.Forms.Button btn_restart_service;
        private System.Windows.Forms.Button btn_stop_service;
        private System.Windows.Forms.Button btn_start_service;
        private System.Windows.Forms.Button btn_uninstall_service;
        private System.Windows.Forms.Button btn_install_service;
        private System.Windows.Forms.Button btn_view_log;
        private System.Windows.Forms.Button btn_view_pictures;
        private System.Windows.Forms.Button btn_show_image;
        private System.Windows.Forms.Timer timer1;
    }
}

