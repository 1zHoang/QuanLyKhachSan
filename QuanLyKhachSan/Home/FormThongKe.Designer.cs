namespace QuanLyKhachSan.Home
{
    partial class FormThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem7 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Guna.UI2.AnimatorNS.Animation animation7 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThongKe));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLeftMenu = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bdThang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bdNam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pDoanhThuPhong = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDTPhong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pDoanhThuDV = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDTDichVu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTongDT = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.transactionLeftMenu = new Guna.UI2.WinForms.Guna2Transition();
            this.lblThang = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblGiamNam = new System.Windows.Forms.Label();
            this.lblTangNam = new System.Windows.Forms.Label();
            this.lblTangThang = new System.Windows.Forms.Label();
            this.lblGiamThang = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNam = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNam)).BeginInit();
            this.pDoanhThuPhong.SuspendLayout();
            this.pDoanhThuDV.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
            this.panel1.Controls.Add(this.btnLeftMenu);
            this.panel1.Controls.Add(this.label1);
            this.transactionLeftMenu.SetDecoration(this.panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 88);
            this.panel1.TabIndex = 9;
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
            this.btnLeftMenu.Location = new System.Drawing.Point(25, 15);
            this.btnLeftMenu.Name = "btnLeftMenu";
            this.btnLeftMenu.Size = new System.Drawing.Size(56, 51);
            this.btnLeftMenu.TabIndex = 1;
            this.btnLeftMenu.Click += new System.EventHandler(this.btnLeftMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.label1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(124)))));
            this.label1.Location = new System.Drawing.Point(87, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            // 
            // bdThang
            // 
            chartArea13.Name = "ChartArea1";
            this.bdThang.ChartAreas.Add(chartArea13);
            this.transactionLeftMenu.SetDecoration(this.bdThang, Guna.UI2.AnimatorNS.DecorationType.None);
            legend13.Name = "Legend1";
            this.bdThang.Legends.Add(legend13);
            this.bdThang.Location = new System.Drawing.Point(10, 264);
            this.bdThang.Name = "bdThang";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series13.Legend = "Legend1";
            series13.Name = "Series1";
            this.bdThang.Series.Add(series13);
            this.bdThang.Size = new System.Drawing.Size(481, 390);
            this.bdThang.TabIndex = 10;
            this.bdThang.Text = "chart1";
            // 
            // bdNam
            // 
            chartArea14.Name = "ChartArea1";
            this.bdNam.ChartAreas.Add(chartArea14);
            this.transactionLeftMenu.SetDecoration(this.bdNam, Guna.UI2.AnimatorNS.DecorationType.None);
            legend14.CustomItems.Add(legendItem7);
            legend14.Name = "Legend1";
            this.bdNam.Legends.Add(legend14);
            this.bdNam.Location = new System.Drawing.Point(497, 280);
            this.bdNam.Name = "bdNam";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series14.Legend = "Legend1";
            series14.Name = "Series1";
            this.bdNam.Series.Add(series14);
            this.bdNam.Size = new System.Drawing.Size(755, 390);
            this.bdNam.TabIndex = 11;
            this.bdNam.Text = "chart2";
            // 
            // pDoanhThuPhong
            // 
            this.pDoanhThuPhong.BackColor = System.Drawing.Color.Yellow;
            this.pDoanhThuPhong.Controls.Add(this.lblDTPhong);
            this.pDoanhThuPhong.Controls.Add(this.label2);
            this.transactionLeftMenu.SetDecoration(this.pDoanhThuPhong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pDoanhThuPhong.Location = new System.Drawing.Point(235, 94);
            this.pDoanhThuPhong.Name = "pDoanhThuPhong";
            this.pDoanhThuPhong.Size = new System.Drawing.Size(229, 127);
            this.pDoanhThuPhong.TabIndex = 12;
            this.pDoanhThuPhong.Click += new System.EventHandler(this.pDoanhThuPhong_Click);
            // 
            // lblDTPhong
            // 
            this.lblDTPhong.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblDTPhong, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblDTPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDTPhong.ForeColor = System.Drawing.Color.White;
            this.lblDTPhong.Location = new System.Drawing.Point(11, 57);
            this.lblDTPhong.Name = "lblDTPhong";
            this.lblDTPhong.Size = new System.Drawing.Size(159, 36);
            this.lblDTPhong.TabIndex = 1;
            this.lblDTPhong.Text = "8.000.000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.label2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Doanh thu phòng";
            // 
            // pDoanhThuDV
            // 
            this.pDoanhThuDV.BackColor = System.Drawing.Color.Blue;
            this.pDoanhThuDV.Controls.Add(this.lblDTDichVu);
            this.pDoanhThuDV.Controls.Add(this.label3);
            this.transactionLeftMenu.SetDecoration(this.pDoanhThuDV, Guna.UI2.AnimatorNS.DecorationType.None);
            this.pDoanhThuDV.Location = new System.Drawing.Point(539, 94);
            this.pDoanhThuDV.Name = "pDoanhThuDV";
            this.pDoanhThuDV.Size = new System.Drawing.Size(229, 127);
            this.pDoanhThuDV.TabIndex = 13;
            this.pDoanhThuDV.Click += new System.EventHandler(this.pDoanhThuDV_Click);
            // 
            // lblDTDichVu
            // 
            this.lblDTDichVu.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblDTDichVu, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblDTDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDTDichVu.ForeColor = System.Drawing.Color.White;
            this.lblDTDichVu.Location = new System.Drawing.Point(11, 57);
            this.lblDTDichVu.Name = "lblDTDichVu";
            this.lblDTDichVu.Size = new System.Drawing.Size(159, 36);
            this.lblDTDichVu.TabIndex = 2;
            this.lblDTDichVu.Text = "8.000.000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.label3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Doanh thu dịch vụ";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Red;
            this.guna2Panel3.Controls.Add(this.lblTongDT);
            this.guna2Panel3.Controls.Add(this.lbl);
            this.transactionLeftMenu.SetDecoration(this.guna2Panel3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2Panel3.Location = new System.Drawing.Point(842, 94);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(229, 127);
            this.guna2Panel3.TabIndex = 13;
            // 
            // lblTongDT
            // 
            this.lblTongDT.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblTongDT, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblTongDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDT.ForeColor = System.Drawing.Color.White;
            this.lblTongDT.Location = new System.Drawing.Point(11, 57);
            this.lblTongDT.Name = "lblTongDT";
            this.lblTongDT.Size = new System.Drawing.Size(177, 36);
            this.lblTongDT.TabIndex = 3;
            this.lblTongDT.Text = "16.000.000";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lbl, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(48, 11);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(181, 29);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Tổng doanh thu";
            // 
            // transactionLeftMenu
            // 
            this.transactionLeftMenu.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            this.transactionLeftMenu.Cursor = null;
            animation7.AnimateOnlyDifferences = true;
            animation7.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.BlindCoeff")));
            animation7.LeafCoeff = 0F;
            animation7.MaxTime = 1F;
            animation7.MinTime = 0F;
            animation7.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.MosaicCoeff")));
            animation7.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation7.MosaicShift")));
            animation7.MosaicSize = 0;
            animation7.Padding = new System.Windows.Forms.Padding(0);
            animation7.RotateCoeff = 0F;
            animation7.RotateLimit = 0F;
            animation7.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.ScaleCoeff")));
            animation7.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.SlideCoeff")));
            animation7.TimeCoeff = 0F;
            animation7.TransparencyCoeff = 0F;
            this.transactionLeftMenu.DefaultAnimation = animation7;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblThang, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.Location = new System.Drawing.Point(260, 681);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(0, 29);
            this.lblThang.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.label6, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(838, 681);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 29);
            this.label6.TabIndex = 15;
            this.label6.Text = "Năm";
            // 
            // lblGiamNam
            // 
            this.lblGiamNam.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblGiamNam, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblGiamNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamNam.Image = global::QuanLyKhachSan.Properties.Resources.left_arrow;
            this.lblGiamNam.Location = new System.Drawing.Point(784, 673);
            this.lblGiamNam.Name = "lblGiamNam";
            this.lblGiamNam.Size = new System.Drawing.Size(48, 42);
            this.lblGiamNam.TabIndex = 20;
            this.lblGiamNam.Text = "   ";
            this.lblGiamNam.Click += new System.EventHandler(this.lblGiamNam_Click);
            // 
            // lblTangNam
            // 
            this.lblTangNam.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblTangNam, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblTangNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTangNam.Image = global::QuanLyKhachSan.Properties.Resources.right_arrow;
            this.lblTangNam.Location = new System.Drawing.Point(952, 673);
            this.lblTangNam.Name = "lblTangNam";
            this.lblTangNam.Size = new System.Drawing.Size(48, 42);
            this.lblTangNam.TabIndex = 21;
            this.lblTangNam.Text = "   ";
            this.lblTangNam.Click += new System.EventHandler(this.lblTangNam_Click);
            // 
            // lblTangThang
            // 
            this.lblTangThang.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblTangThang, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblTangThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTangThang.Image = global::QuanLyKhachSan.Properties.Resources.right_arrow;
            this.lblTangThang.Location = new System.Drawing.Point(306, 673);
            this.lblTangThang.Name = "lblTangThang";
            this.lblTangThang.Size = new System.Drawing.Size(48, 42);
            this.lblTangThang.TabIndex = 23;
            this.lblTangThang.Text = "   ";
            this.lblTangThang.Click += new System.EventHandler(this.lblTangThang_Click);
            // 
            // lblGiamThang
            // 
            this.lblGiamThang.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblGiamThang, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblGiamThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamThang.Image = global::QuanLyKhachSan.Properties.Resources.left_arrow;
            this.lblGiamThang.Location = new System.Drawing.Point(138, 673);
            this.lblGiamThang.Name = "lblGiamThang";
            this.lblGiamThang.Size = new System.Drawing.Size(48, 42);
            this.lblGiamThang.TabIndex = 22;
            this.lblGiamThang.Text = "   ";
            this.lblGiamThang.Click += new System.EventHandler(this.lblGiamThang_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.label11, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(192, 681);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 29);
            this.label11.TabIndex = 24;
            this.label11.Text = "Tháng";
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblNam, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNam.Location = new System.Drawing.Point(889, 681);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(0, 29);
            this.lblNam.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.transactionLeftMenu.SetDecoration(this.panel2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel2.Location = new System.Drawing.Point(497, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 459);
            this.panel2.TabIndex = 26;
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblNam);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTangThang);
            this.Controls.Add(this.lblGiamThang);
            this.Controls.Add(this.lblTangNam);
            this.Controls.Add(this.lblGiamNam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.pDoanhThuDV);
            this.Controls.Add(this.pDoanhThuPhong);
            this.Controls.Add(this.bdNam);
            this.Controls.Add(this.bdThang);
            this.Controls.Add(this.panel1);
            this.transactionLeftMenu.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách Sạn";
            this.Load += new System.EventHandler(this.FormThongKe_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNam)).EndInit();
            this.pDoanhThuPhong.ResumeLayout(false);
            this.pDoanhThuPhong.PerformLayout();
            this.pDoanhThuDV.ResumeLayout(false);
            this.pDoanhThuDV.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnLeftMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart bdThang;
        private System.Windows.Forms.DataVisualization.Charting.Chart bdNam;
        private Guna.UI2.WinForms.Guna2Panel pDoanhThuPhong;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Panel pDoanhThuDV;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label lbl;
        private Guna.UI2.WinForms.Guna2Transition transactionLeftMenu;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGiamNam;
        private System.Windows.Forms.Label lblTangNam;
        private System.Windows.Forms.Label lblTangThang;
        private System.Windows.Forms.Label lblGiamThang;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.Label lblDTPhong;
        private System.Windows.Forms.Label lblDTDichVu;
        private System.Windows.Forms.Label lblTongDT;
        private System.Windows.Forms.Panel panel2;
    }
}