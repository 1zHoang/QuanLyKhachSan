namespace QuanLyKhachSan.Home
{
    partial class FormDanhSachPhong
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
            Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDanhSachPhong));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTimPhong = new Guna.UI2.WinForms.Guna2Button();
            this.txtTenPhong = new Guna.UI2.WinForms.Guna2TextBox();
            this.dateTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnLeftMenu = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoAllLoaiPhong = new System.Windows.Forms.RadioButton();
            this.rdoGiaDinh = new System.Windows.Forms.RadioButton();
            this.rdoDoi = new System.Windows.Forms.RadioButton();
            this.rdoDon = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoAllTrangThai = new System.Windows.Forms.RadioButton();
            this.rdoPhongThue = new System.Windows.Forms.RadioButton();
            this.rdoPhongDat = new System.Windows.Forms.RadioButton();
            this.rdoPhongTrong = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pListPhong = new Guna.UI2.WinForms.Guna2Panel();
            this.transactionLeftMenu = new Guna.UI2.WinForms.Guna2Transition();
            this.panel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.btnTimPhong);
            this.panel1.Controls.Add(this.txtTenPhong);
            this.panel1.Controls.Add(this.dateTime);
            this.panel1.Controls.Add(this.btnLeftMenu);
            this.panel1.Controls.Add(this.label1);
            this.transactionLeftMenu.SetDecoration(this.panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1481, 98);
            this.panel1.TabIndex = 4;
            // 
            // btnTimPhong
            // 
            this.transactionLeftMenu.SetDecoration(this.btnTimPhong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnTimPhong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimPhong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimPhong.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.btnTimPhong.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimPhong.ForeColor = System.Drawing.Color.White;
            this.btnTimPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnTimPhong.Image")));
            this.btnTimPhong.ImageSize = new System.Drawing.Size(40, 40);
            this.btnTimPhong.Location = new System.Drawing.Point(988, 22);
            this.btnTimPhong.Name = "btnTimPhong";
            this.btnTimPhong.Size = new System.Drawing.Size(56, 48);
            this.btnTimPhong.TabIndex = 4;
            this.btnTimPhong.Click += new System.EventHandler(this.btnTimPhong_Click);
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.BorderRadius = 10;
            this.txtTenPhong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.transactionLeftMenu.SetDecoration(this.txtTenPhong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.txtTenPhong.DefaultText = "";
            this.txtTenPhong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenPhong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenPhong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhong.ForeColor = System.Drawing.Color.Black;
            this.txtTenPhong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenPhong.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtTenPhong.IconLeft")));
            this.txtTenPhong.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtTenPhong.Location = new System.Drawing.Point(621, 23);
            this.txtTenPhong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.PasswordChar = '\0';
            this.txtTenPhong.PlaceholderText = "Tìm Phòng";
            this.txtTenPhong.SelectedText = "";
            this.txtTenPhong.Size = new System.Drawing.Size(360, 47);
            this.txtTenPhong.TabIndex = 3;
            this.txtTenPhong.TextChanged += new System.EventHandler(this.txtTenPhong_TextChanged);
            // 
            // dateTime
            // 
            this.dateTime.BorderRadius = 10;
            this.dateTime.Checked = true;
            this.dateTime.CustomFormat = "dd/MM/yyyy";
            this.transactionLeftMenu.SetDecoration(this.dateTime, Guna.UI2.AnimatorNS.DecorationType.None);
            this.dateTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.dateTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime.Location = new System.Drawing.Point(24, 50);
            this.dateTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(200, 36);
            this.dateTime.TabIndex = 2;
            this.dateTime.Value = new System.DateTime(2023, 11, 4, 18, 17, 3, 0);
            this.dateTime.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);
            // 
            // btnLeftMenu
            // 
            this.transactionLeftMenu.SetDecoration(this.btnLeftMenu, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnLeftMenu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLeftMenu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLeftMenu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLeftMenu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLeftMenu.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.btnLeftMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLeftMenu.ForeColor = System.Drawing.Color.White;
            this.btnLeftMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnLeftMenu.Image")));
            this.btnLeftMenu.Location = new System.Drawing.Point(24, 3);
            this.btnLeftMenu.Name = "btnLeftMenu";
            this.btnLeftMenu.Size = new System.Drawing.Size(56, 48);
            this.btnLeftMenu.TabIndex = 1;
            this.btnLeftMenu.Click += new System.EventHandler(this.btnLeftMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.label1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(86, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phòng";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.panel3);
            this.guna2Panel1.Controls.Add(this.panel2);
            this.guna2Panel1.Controls.Add(this.label11);
            this.guna2Panel1.Controls.Add(this.label2);
            this.transactionLeftMenu.SetDecoration(this.guna2Panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 104);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(250, 663);
            this.guna2Panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.panel3.Controls.Add(this.rdoAllLoaiPhong);
            this.panel3.Controls.Add(this.rdoGiaDinh);
            this.panel3.Controls.Add(this.rdoDoi);
            this.panel3.Controls.Add(this.rdoDon);
            this.transactionLeftMenu.SetDecoration(this.panel3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel3.Location = new System.Drawing.Point(28, 316);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(195, 201);
            this.panel3.TabIndex = 24;
            // 
            // rdoAllLoaiPhong
            // 
            this.rdoAllLoaiPhong.AutoSize = true;
            this.rdoAllLoaiPhong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.rdoAllLoaiPhong.Checked = true;
            this.transactionLeftMenu.SetDecoration(this.rdoAllLoaiPhong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rdoAllLoaiPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAllLoaiPhong.Location = new System.Drawing.Point(17, 135);
            this.rdoAllLoaiPhong.Name = "rdoAllLoaiPhong";
            this.rdoAllLoaiPhong.Size = new System.Drawing.Size(148, 29);
            this.rdoAllLoaiPhong.TabIndex = 22;
            this.rdoAllLoaiPhong.TabStop = true;
            this.rdoAllLoaiPhong.Text = "Tất cả phòng";
            this.rdoAllLoaiPhong.UseVisualStyleBackColor = false;
            this.rdoAllLoaiPhong.Click += new System.EventHandler(this.CheckedLoaiPhong);
            // 
            // rdoGiaDinh
            // 
            this.rdoGiaDinh.AutoSize = true;
            this.rdoGiaDinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.transactionLeftMenu.SetDecoration(this.rdoGiaDinh, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rdoGiaDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoGiaDinh.Location = new System.Drawing.Point(17, 89);
            this.rdoGiaDinh.Name = "rdoGiaDinh";
            this.rdoGiaDinh.Size = new System.Drawing.Size(163, 29);
            this.rdoGiaDinh.TabIndex = 21;
            this.rdoGiaDinh.TabStop = true;
            this.rdoGiaDinh.Text = "Phòng gia đình";
            this.rdoGiaDinh.UseVisualStyleBackColor = false;
            this.rdoGiaDinh.Click += new System.EventHandler(this.CheckedLoaiPhong);
            // 
            // rdoDoi
            // 
            this.rdoDoi.AutoSize = true;
            this.rdoDoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.transactionLeftMenu.SetDecoration(this.rdoDoi, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rdoDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDoi.Location = new System.Drawing.Point(17, 45);
            this.rdoDoi.Name = "rdoDoi";
            this.rdoDoi.Size = new System.Drawing.Size(121, 29);
            this.rdoDoi.TabIndex = 20;
            this.rdoDoi.TabStop = true;
            this.rdoDoi.Text = "Phòng đôi";
            this.rdoDoi.UseVisualStyleBackColor = false;
            this.rdoDoi.Click += new System.EventHandler(this.CheckedLoaiPhong);
            // 
            // rdoDon
            // 
            this.rdoDon.AutoSize = true;
            this.rdoDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.transactionLeftMenu.SetDecoration(this.rdoDon, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rdoDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDon.Location = new System.Drawing.Point(17, 5);
            this.rdoDon.Name = "rdoDon";
            this.rdoDon.Size = new System.Drawing.Size(128, 29);
            this.rdoDon.TabIndex = 19;
            this.rdoDon.TabStop = true;
            this.rdoDon.Text = "Phòng đơn";
            this.rdoDon.UseVisualStyleBackColor = false;
            this.rdoDon.CheckedChanged += new System.EventHandler(this.CheckedLoaiPhong);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.panel2.Controls.Add(this.rdoAllTrangThai);
            this.panel2.Controls.Add(this.rdoPhongThue);
            this.panel2.Controls.Add(this.rdoPhongDat);
            this.panel2.Controls.Add(this.rdoPhongTrong);
            this.transactionLeftMenu.SetDecoration(this.panel2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel2.Location = new System.Drawing.Point(29, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 188);
            this.panel2.TabIndex = 23;
            // 
            // rdoAllTrangThai
            // 
            this.rdoAllTrangThai.AutoSize = true;
            this.rdoAllTrangThai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.rdoAllTrangThai.Checked = true;
            this.transactionLeftMenu.SetDecoration(this.rdoAllTrangThai, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rdoAllTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAllTrangThai.Location = new System.Drawing.Point(16, 128);
            this.rdoAllTrangThai.Name = "rdoAllTrangThai";
            this.rdoAllTrangThai.Size = new System.Drawing.Size(148, 29);
            this.rdoAllTrangThai.TabIndex = 18;
            this.rdoAllTrangThai.TabStop = true;
            this.rdoAllTrangThai.Text = "Tất cả phòng";
            this.rdoAllTrangThai.UseVisualStyleBackColor = false;
            this.rdoAllTrangThai.Click += new System.EventHandler(this.CheckedTrangThai);
            // 
            // rdoPhongThue
            // 
            this.rdoPhongThue.AutoSize = true;
            this.rdoPhongThue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.transactionLeftMenu.SetDecoration(this.rdoPhongThue, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rdoPhongThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPhongThue.Location = new System.Drawing.Point(16, 88);
            this.rdoPhongThue.Name = "rdoPhongThue";
            this.rdoPhongThue.Size = new System.Drawing.Size(182, 29);
            this.rdoPhongThue.TabIndex = 17;
            this.rdoPhongThue.Text = "Phòng đang thuê";
            this.rdoPhongThue.UseVisualStyleBackColor = false;
            this.rdoPhongThue.Click += new System.EventHandler(this.CheckedTrangThai);
            // 
            // rdoPhongDat
            // 
            this.rdoPhongDat.AutoSize = true;
            this.rdoPhongDat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.transactionLeftMenu.SetDecoration(this.rdoPhongDat, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rdoPhongDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPhongDat.Location = new System.Drawing.Point(16, 44);
            this.rdoPhongDat.Name = "rdoPhongDat";
            this.rdoPhongDat.Size = new System.Drawing.Size(149, 29);
            this.rdoPhongDat.TabIndex = 16;
            this.rdoPhongDat.Text = "Phòng đã đặt";
            this.rdoPhongDat.UseVisualStyleBackColor = false;
            this.rdoPhongDat.Click += new System.EventHandler(this.CheckedTrangThai);
            // 
            // rdoPhongTrong
            // 
            this.rdoPhongTrong.AutoSize = true;
            this.rdoPhongTrong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.transactionLeftMenu.SetDecoration(this.rdoPhongTrong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.rdoPhongTrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPhongTrong.Location = new System.Drawing.Point(16, 4);
            this.rdoPhongTrong.Name = "rdoPhongTrong";
            this.rdoPhongTrong.Size = new System.Drawing.Size(139, 29);
            this.rdoPhongTrong.TabIndex = 15;
            this.rdoPhongTrong.Text = "Phòng trống";
            this.rdoPhongTrong.UseVisualStyleBackColor = false;
            this.rdoPhongTrong.Click += new System.EventHandler(this.CheckedTrangThai);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.transactionLeftMenu.SetDecoration(this.label11, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(124)))));
            this.label11.Location = new System.Drawing.Point(19, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 29);
            this.label11.TabIndex = 10;
            this.label11.Text = "Loại phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.transactionLeftMenu.SetDecoration(this.label2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(124)))));
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trạng thái";
            // 
            // pListPhong
            // 
            this.pListPhong.AutoScroll = true;
            this.transactionLeftMenu.SetDecoration(this.pListPhong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pListPhong.Location = new System.Drawing.Point(256, 103);
            this.pListPhong.Name = "pListPhong";
            this.pListPhong.Size = new System.Drawing.Size(1185, 650);
            this.pListPhong.TabIndex = 6;
            this.pListPhong.Paint += new System.Windows.Forms.PaintEventHandler(this.pListPhong_Paint);
            // 
            // transactionLeftMenu
            // 
            this.transactionLeftMenu.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            this.transactionLeftMenu.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.transactionLeftMenu.DefaultAnimation = animation1;
            // 
            // FormDanhSachPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1412, 753);
            this.Controls.Add(this.pListPhong);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panel1);
            this.transactionLeftMenu.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDanhSachPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách Sạn";
            this.Load += new System.EventHandler(this.FormDanhSachPhong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnLeftMenu;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dateTime;
        private Guna.UI2.WinForms.Guna2TextBox txtTenPhong;
        private Guna.UI2.WinForms.Guna2Button btnTimPhong;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rdoGiaDinh;
        private System.Windows.Forms.RadioButton rdoDoi;
        private System.Windows.Forms.RadioButton rdoDon;
        private System.Windows.Forms.RadioButton rdoAllTrangThai;
        private System.Windows.Forms.RadioButton rdoPhongThue;
        private System.Windows.Forms.RadioButton rdoPhongDat;
        private System.Windows.Forms.RadioButton rdoPhongTrong;
        private Guna.UI2.WinForms.Guna2Panel pListPhong;
        private Guna.UI2.WinForms.Guna2Transition transactionLeftMenu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoAllLoaiPhong;
    }
}