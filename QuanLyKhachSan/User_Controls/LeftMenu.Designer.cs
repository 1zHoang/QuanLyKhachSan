namespace QuanLyKhachSan.User_Controls
{
    partial class LeftMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.AnimatorNS.Animation animation4 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeftMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAn = new Guna.UI2.WinForms.Guna2Button();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.flpDanhMuc = new System.Windows.Forms.FlowLayoutPanel();
            this.transactionLeftMenu = new Guna.UI2.WinForms.Guna2Transition();
            this.lblDangXuat = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(124)))));
            this.panel1.Controls.Add(this.lblDangXuat);
            this.panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.btnAn);
            this.panel1.Controls.Add(this.lblTenNhanVien);
            this.transactionLeftMenu.SetDecoration(this.panel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 185);
            this.panel1.TabIndex = 0;
            // 
            // guna2CirclePictureBox1
            // 
            this.transactionLeftMenu.SetDecoration(this.guna2CirclePictureBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(75, 17);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(120, 120);
            this.guna2CirclePictureBox1.TabIndex = 7;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.transactionLeftMenu.SetDecoration(this.flowLayoutPanel1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 183);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 568);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // btnAn
            // 
            this.transactionLeftMenu.SetDecoration(this.btnAn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnAn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(124)))));
            this.btnAn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAn.ForeColor = System.Drawing.Color.White;
            this.btnAn.Image = global::QuanLyKhachSan.Properties.Resources.arrow_left;
            this.btnAn.Location = new System.Drawing.Point(201, 4);
            this.btnAn.Name = "btnAn";
            this.btnAn.Size = new System.Drawing.Size(60, 45);
            this.btnAn.TabIndex = 5;
            this.btnAn.Text = "     ";
            this.btnAn.Click += new System.EventHandler(this.btnAn_Click_2);
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblTenNhanVien, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblTenNhanVien.Location = new System.Drawing.Point(62, 150);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(147, 20);
            this.lblTenNhanVien.TabIndex = 4;
            this.lblTenNhanVien.Text = "Nguyễn Thành Đạt";
            // 
            // flpDanhMuc
            // 
            this.transactionLeftMenu.SetDecoration(this.flpDanhMuc, Guna.UI2.AnimatorNS.DecorationType.None);
            this.flpDanhMuc.Location = new System.Drawing.Point(0, 182);
            this.flpDanhMuc.Name = "flpDanhMuc";
            this.flpDanhMuc.Size = new System.Drawing.Size(261, 569);
            this.flpDanhMuc.TabIndex = 1;
            // 
            // transactionLeftMenu
            // 
            this.transactionLeftMenu.AnimationType = Guna.UI2.AnimatorNS.AnimationType.HorizSlide;
            this.transactionLeftMenu.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 0F;
            this.transactionLeftMenu.DefaultAnimation = animation4;
            // 
            // lblDangXuat
            // 
            this.lblDangXuat.AutoSize = true;
            this.transactionLeftMenu.SetDecoration(this.lblDangXuat, Guna.UI2.AnimatorNS.DecorationType.None);
            this.lblDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangXuat.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDangXuat.Location = new System.Drawing.Point(4, 17);
            this.lblDangXuat.Name = "lblDangXuat";
            this.lblDangXuat.Size = new System.Drawing.Size(84, 20);
            this.lblDangXuat.TabIndex = 8;
            this.lblDangXuat.Text = "Đăng xuất";
            this.lblDangXuat.Click += new System.EventHandler(this.lblDangXuat_Click);
            // 
            // LeftMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flpDanhMuc);
            this.Controls.Add(this.panel1);
            this.transactionLeftMenu.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LeftMenu";
            this.Size = new System.Drawing.Size(260, 755);
            this.Load += new System.EventHandler(this.LeftMenu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTenNhanVien;
        private Guna.UI2.WinForms.Guna2Button btnAn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpDanhMuc;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Transition transactionLeftMenu;
        private System.Windows.Forms.Label lblDangXuat;
    }
}
