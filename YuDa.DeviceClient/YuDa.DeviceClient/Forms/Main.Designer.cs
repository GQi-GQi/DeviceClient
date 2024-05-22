
namespace YuDa.DeviceClient
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btn_Clean = new System.Windows.Forms.Button();
            this.lab_Send = new System.Windows.Forms.Label();
            this.lab_Receive = new System.Windows.Forms.Label();
            this.txb_Log = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_VirtualSerialPort = new System.Windows.Forms.Label();
            this.btn_NetworkSpeed = new System.Windows.Forms.Button();
            this.cbx_StopBits = new System.Windows.Forms.ComboBox();
            this.cbx_DataBits = new System.Windows.Forms.ComboBox();
            this.cbx_Parity = new System.Windows.Forms.ComboBox();
            this.cbx_BaudRate = new System.Windows.Forms.ComboBox();
            this.txb_IdentificationCode = new System.Windows.Forms.TextBox();
            this.cbx_Com = new System.Windows.Forms.ComboBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.txb_Code = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_CopyFormClipboard = new System.Windows.Forms.Button();
            this.emi_Label1 = new EASkins.Emi_Label();
            this.materialDivider1 = new EASkins.Controls.MaterialDivider();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Clean
            // 
            this.btn_Clean.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Clean.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(141)))), ((int)(((byte)(107)))));
            this.btn_Clean.Location = new System.Drawing.Point(308, 443);
            this.btn_Clean.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(94, 26);
            this.btn_Clean.TabIndex = 19;
            this.btn_Clean.TabStop = false;
            this.btn_Clean.Text = "清除打印窗口";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // lab_Send
            // 
            this.lab_Send.AutoSize = true;
            this.lab_Send.BackColor = System.Drawing.Color.Transparent;
            this.lab_Send.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Send.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lab_Send.Location = new System.Drawing.Point(97, 447);
            this.lab_Send.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_Send.Name = "lab_Send";
            this.lab_Send.Size = new System.Drawing.Size(30, 19);
            this.lab_Send.TabIndex = 16;
            this.lab_Send.Text = "S:0";
            // 
            // lab_Receive
            // 
            this.lab_Receive.AutoSize = true;
            this.lab_Receive.BackColor = System.Drawing.Color.Transparent;
            this.lab_Receive.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab_Receive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lab_Receive.Location = new System.Drawing.Point(193, 447);
            this.lab_Receive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lab_Receive.Name = "lab_Receive";
            this.lab_Receive.Size = new System.Drawing.Size(32, 19);
            this.lab_Receive.TabIndex = 17;
            this.lab_Receive.Text = "R:0";
            // 
            // txb_Log
            // 
            this.txb_Log.AcceptsReturn = true;
            this.txb_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txb_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_Log.Dock = System.Windows.Forms.DockStyle.Top;
            this.txb_Log.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.txb_Log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(186)))), ((int)(((byte)(186)))));
            this.txb_Log.HideSelection = false;
            this.txb_Log.Location = new System.Drawing.Point(0, 0);
            this.txb_Log.Margin = new System.Windows.Forms.Padding(97, 118, 4, 142);
            this.txb_Log.Multiline = true;
            this.txb_Log.Name = "txb_Log";
            this.txb_Log.ReadOnly = true;
            this.txb_Log.Size = new System.Drawing.Size(582, 437);
            this.txb_Log.TabIndex = 1;
            this.txb_Log.TabStop = false;
            this.txb_Log.Text = "请先选择串口信息，输入机器识别码和验证码，再点击连接透传服务端";
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel2.Controls.Add(this.txb_Log);
            this.panel2.Controls.Add(this.btn_NetworkSpeed);
            this.panel2.Controls.Add(this.lab_Receive);
            this.panel2.Controls.Add(this.lab_Send);
            this.panel2.Controls.Add(this.btn_Clean);
            this.panel2.Location = new System.Drawing.Point(-1, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 478);
            this.panel2.TabIndex = 27;
            // 
            // lbl_VirtualSerialPort
            // 
            this.lbl_VirtualSerialPort.AutoSize = true;
            this.lbl_VirtualSerialPort.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VirtualSerialPort.Font = new System.Drawing.Font("微软雅黑", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl_VirtualSerialPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lbl_VirtualSerialPort.Location = new System.Drawing.Point(36, 449);
            this.lbl_VirtualSerialPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_VirtualSerialPort.Name = "lbl_VirtualSerialPort";
            this.lbl_VirtualSerialPort.Size = new System.Drawing.Size(93, 20);
            this.lbl_VirtualSerialPort.TabIndex = 38;
            this.lbl_VirtualSerialPort.Text = "虚拟串口号：";
            // 
            // btn_NetworkSpeed
            // 
            this.btn_NetworkSpeed.BackColor = System.Drawing.Color.Transparent;
            this.btn_NetworkSpeed.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_NetworkSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(141)))), ((int)(((byte)(107)))));
            this.btn_NetworkSpeed.Location = new System.Drawing.Point(479, 442);
            this.btn_NetworkSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.btn_NetworkSpeed.Name = "btn_NetworkSpeed";
            this.btn_NetworkSpeed.Size = new System.Drawing.Size(73, 27);
            this.btn_NetworkSpeed.TabIndex = 36;
            this.btn_NetworkSpeed.Text = "测速";
            this.btn_NetworkSpeed.UseVisualStyleBackColor = false;
            this.btn_NetworkSpeed.Visible = false;
            this.btn_NetworkSpeed.Click += new System.EventHandler(this.btn_NetworkSpeed_Click);
            // 
            // cbx_StopBits
            // 
            this.cbx_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_StopBits.FormattingEnabled = true;
            this.cbx_StopBits.Location = new System.Drawing.Point(102, 361);
            this.cbx_StopBits.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_StopBits.Name = "cbx_StopBits";
            this.cbx_StopBits.Size = new System.Drawing.Size(134, 25);
            this.cbx_StopBits.TabIndex = 13;
            this.cbx_StopBits.TabStop = false;
            // 
            // cbx_DataBits
            // 
            this.cbx_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DataBits.FormattingEnabled = true;
            this.cbx_DataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbx_DataBits.Location = new System.Drawing.Point(102, 211);
            this.cbx_DataBits.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_DataBits.Name = "cbx_DataBits";
            this.cbx_DataBits.Size = new System.Drawing.Size(134, 25);
            this.cbx_DataBits.TabIndex = 11;
            this.cbx_DataBits.TabStop = false;
            // 
            // cbx_Parity
            // 
            this.cbx_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Parity.FormattingEnabled = true;
            this.cbx_Parity.Location = new System.Drawing.Point(102, 260);
            this.cbx_Parity.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_Parity.Name = "cbx_Parity";
            this.cbx_Parity.Size = new System.Drawing.Size(134, 25);
            this.cbx_Parity.TabIndex = 15;
            this.cbx_Parity.TabStop = false;
            // 
            // cbx_BaudRate
            // 
            this.cbx_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_BaudRate.FormattingEnabled = true;
            this.cbx_BaudRate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "115200",
            "128000",
            "230400",
            "256000",
            "460800",
            "500000",
            "512000",
            "600000",
            "750000",
            "921600",
            "1000000",
            "1500000",
            "2000000"});
            this.cbx_BaudRate.Location = new System.Drawing.Point(102, 310);
            this.cbx_BaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_BaudRate.Name = "cbx_BaudRate";
            this.cbx_BaudRate.Size = new System.Drawing.Size(134, 25);
            this.cbx_BaudRate.TabIndex = 9;
            this.cbx_BaudRate.TabStop = false;
            // 
            // txb_IdentificationCode
            // 
            this.txb_IdentificationCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txb_IdentificationCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_IdentificationCode.Font = new System.Drawing.Font("微软雅黑", 13.33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.txb_IdentificationCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txb_IdentificationCode.Location = new System.Drawing.Point(100, 28);
            this.txb_IdentificationCode.Margin = new System.Windows.Forms.Padding(4);
            this.txb_IdentificationCode.Name = "txb_IdentificationCode";
            this.txb_IdentificationCode.Size = new System.Drawing.Size(134, 25);
            this.txb_IdentificationCode.TabIndex = 0;
            this.txb_IdentificationCode.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_KeyDown);
            // 
            // cbx_Com
            // 
            this.cbx_Com.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Com.FormattingEnabled = true;
            this.cbx_Com.Items.AddRange(new object[] {
            "232",
            "485"});
            this.cbx_Com.Location = new System.Drawing.Point(102, 410);
            this.cbx_Com.Margin = new System.Windows.Forms.Padding(4);
            this.cbx_Com.Name = "cbx_Com";
            this.cbx_Com.Size = new System.Drawing.Size(134, 25);
            this.cbx_Com.TabIndex = 28;
            this.cbx_Com.TabStop = false;
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.Color.Transparent;
            this.btn_Connect.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Connect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(141)))), ((int)(((byte)(107)))));
            this.btn_Connect.Location = new System.Drawing.Point(174, 130);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(112, 27);
            this.btn_Connect.TabIndex = 2;
            this.btn_Connect.Text = "透传连接";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // txb_Code
            // 
            this.txb_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.txb_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_Code.Font = new System.Drawing.Font("微软雅黑", 13.33F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.txb_Code.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txb_Code.Location = new System.Drawing.Point(100, 78);
            this.txb_Code.Margin = new System.Windows.Forms.Padding(4);
            this.txb_Code.Name = "txb_Code";
            this.txb_Code.Size = new System.Drawing.Size(134, 25);
            this.txb_Code.TabIndex = 1;
            this.txb_Code.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Control_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.lbl_VirtualSerialPort);
            this.panel1.Controls.Add(this.btn_CopyFormClipboard);
            this.panel1.Controls.Add(this.emi_Label1);
            this.panel1.Controls.Add(this.materialDivider1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txb_Code);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btn_Connect);
            this.panel1.Controls.Add(this.cbx_Com);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txb_IdentificationCode);
            this.panel1.Controls.Add(this.cbx_BaudRate);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cbx_Parity);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbx_DataBits);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbx_StopBits);
            this.panel1.Location = new System.Drawing.Point(581, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 478);
            this.panel1.TabIndex = 32;
            // 
            // btn_CopyFormClipboard
            // 
            this.btn_CopyFormClipboard.BackColor = System.Drawing.Color.Transparent;
            this.btn_CopyFormClipboard.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CopyFormClipboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(141)))), ((int)(((byte)(107)))));
            this.btn_CopyFormClipboard.Location = new System.Drawing.Point(19, 130);
            this.btn_CopyFormClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CopyFormClipboard.Name = "btn_CopyFormClipboard";
            this.btn_CopyFormClipboard.Size = new System.Drawing.Size(116, 27);
            this.btn_CopyFormClipboard.TabIndex = 37;
            this.btn_CopyFormClipboard.Text = "从剪切板粘贴";
            this.btn_CopyFormClipboard.UseVisualStyleBackColor = false;
            this.btn_CopyFormClipboard.Click += new System.EventHandler(this.btn_CopyFormClipboard_Click);
            // 
            // emi_Label1
            // 
            this.emi_Label1.AutoSize = true;
            this.emi_Label1.BackColor = System.Drawing.Color.Transparent;
            this.emi_Label1.Font = new System.Drawing.Font("微软雅黑", 13.33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.emi_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.emi_Label1.Location = new System.Drawing.Point(102, 175);
            this.emi_Label1.Name = "emi_Label1";
            this.emi_Label1.Size = new System.Drawing.Size(93, 19);
            this.emi_Label1.TabIndex = 35;
            this.emi_Label1.Text = "串口信息选择";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.Gray;
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(2, 184);
            this.materialDivider1.MouseState = EASkins.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(295, 3);
            this.materialDivider1.TabIndex = 34;
            this.materialDivider1.TabStop = false;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::YuDa.DeviceClient.Properties.Resources.Identification_code;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(19, 28);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 33;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::YuDa.DeviceClient.Properties.Resources.Verification_Code;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(19, 79);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 23);
            this.button1.TabIndex = 32;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label16.Location = new System.Drawing.Point(49, 28);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 20);
            this.label16.TabIndex = 3;
            this.label16.Text = "识别码";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label15.Location = new System.Drawing.Point(50, 80);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "验证码";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label14.Location = new System.Drawing.Point(37, 411);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "对端串口";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label12.Location = new System.Drawing.Point(49, 311);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "波特率";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label11.Location = new System.Drawing.Point(49, 212);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "数据位";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label9.Location = new System.Drawing.Point(36, 261);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "奇偶校验";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 13.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.label8.Location = new System.Drawing.Point(49, 362);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "停止位";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(880, 502);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宇达数字透传工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.Label lab_Send;
        private System.Windows.Forms.Label lab_Receive;
        private System.Windows.Forms.TextBox txb_Log;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbx_StopBits;
        private System.Windows.Forms.ComboBox cbx_DataBits;
        private System.Windows.Forms.ComboBox cbx_Parity;
        private System.Windows.Forms.ComboBox cbx_BaudRate;
        private System.Windows.Forms.TextBox txb_IdentificationCode;
        private System.Windows.Forms.ComboBox cbx_Com;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox txb_Code;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private EASkins.Emi_Label emi_Label1;
        private EASkins.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.Button btn_NetworkSpeed;
        private System.Windows.Forms.Button btn_CopyFormClipboard;
        private System.Windows.Forms.Label lbl_VirtualSerialPort;
    }
}