namespace QuanLyKhachSan.Home
{
    partial class FormHoaDon
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			Guna.UI2.AnimatorNS.Animation animation1 = new Guna.UI2.AnimatorNS.Animation();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHoaDon));
			this.grvHoaDon = new Guna.UI2.WinForms.Guna2DataGridView();
			this.dtThoiGianHoaDon = new Guna.UI2.WinForms.Guna2DateTimePicker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnLeftMenu = new Guna.UI2.WinForms.Guna2Button();
			this.label1 = new System.Windows.Forms.Label();
			this.transactionLeftMenu = new Guna.UI2.WinForms.Guna2Transition();
			this.txtSearchHD = new Guna.UI2.WinForms.Guna2TextBox();
			((System.ComponentModel.ISupportInitialize)(this.grvHoaDon)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// grvHoaDon
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			this.grvHoaDon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(203)))), ((int)(((byte)(160)))));
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(161)))), ((int)(((byte)(124)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.grvHoaDon.ColumnHeadersHeight = 30;
			this.grvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.transactionLeftMenu.SetDecoration(this.grvHoaDon, Guna.UI2.AnimatorNS.DecorationType.None);
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grvHoaDon.DefaultCellStyle = dataGridViewCellStyle3;
			this.grvHoaDon.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.grvHoaDon.Location = new System.Drawing.Point(67, 186);
			this.grvHoaDon.Margin = new System.Windows.Forms.Padding(4);
			this.grvHoaDon.Name = "grvHoaDon";
			this.grvHoaDon.RowHeadersVisible = false;
			this.grvHoaDon.RowHeadersWidth = 51;
			this.grvHoaDon.RowTemplate.Height = 24;
			this.grvHoaDon.Size = new System.Drawing.Size(1140, 524);
			this.grvHoaDon.TabIndex = 3;
			this.grvHoaDon.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.grvHoaDon.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.grvHoaDon.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.grvHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.grvHoaDon.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.grvHoaDon.ThemeStyle.BackColor = System.Drawing.Color.White;
			this.grvHoaDon.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.grvHoaDon.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			this.grvHoaDon.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.grvHoaDon.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grvHoaDon.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.grvHoaDon.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.grvHoaDon.ThemeStyle.HeaderStyle.Height = 30;
			this.grvHoaDon.ThemeStyle.ReadOnly = false;
			this.grvHoaDon.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.grvHoaDon.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.grvHoaDon.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grvHoaDon.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.grvHoaDon.ThemeStyle.RowsStyle.Height = 24;
			this.grvHoaDon.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.grvHoaDon.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.grvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvHoaDon_CellClick);
			// 
			// dtThoiGianHoaDon
			// 
			this.dtThoiGianHoaDon.BackColor = System.Drawing.Color.White;
			this.dtThoiGianHoaDon.BorderRadius = 5;
			this.dtThoiGianHoaDon.Checked = true;
			this.transactionLeftMenu.SetDecoration(this.dtThoiGianHoaDon, Guna.UI2.AnimatorNS.DecorationType.None);
			this.dtThoiGianHoaDon.FillColor = System.Drawing.Color.White;
			this.dtThoiGianHoaDon.FocusedColor = System.Drawing.Color.White;
			this.dtThoiGianHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtThoiGianHoaDon.ForeColor = System.Drawing.Color.Black;
			this.dtThoiGianHoaDon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtThoiGianHoaDon.Location = new System.Drawing.Point(89, 116);
			this.dtThoiGianHoaDon.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dtThoiGianHoaDon.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dtThoiGianHoaDon.Name = "dtThoiGianHoaDon";
			this.dtThoiGianHoaDon.Size = new System.Drawing.Size(200, 45);
			this.dtThoiGianHoaDon.TabIndex = 7;
			this.dtThoiGianHoaDon.Value = new System.DateTime(2023, 10, 28, 22, 4, 17, 848);
			this.dtThoiGianHoaDon.ValueChanged += new System.EventHandler(this.ThoiGianHoaDon_ValueChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(245)))));
			this.panel1.Controls.Add(this.btnLeftMenu);
			this.panel1.Controls.Add(this.label1);
			this.transactionLeftMenu.SetDecoration(this.panel1, Guna.UI2.AnimatorNS.DecorationType.None);
			this.panel1.Location = new System.Drawing.Point(0, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1282, 88);
			this.panel1.TabIndex = 8;
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
			this.label1.Size = new System.Drawing.Size(128, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hóa Đơn";
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
			// txtSearchHD
			// 
			this.txtSearchHD.BorderRadius = 10;
			this.txtSearchHD.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.transactionLeftMenu.SetDecoration(this.txtSearchHD, Guna.UI2.AnimatorNS.DecorationType.None);
			this.txtSearchHD.DefaultText = "";
			this.txtSearchHD.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtSearchHD.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtSearchHD.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSearchHD.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSearchHD.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSearchHD.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSearchHD.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSearchHD.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearchHD.IconLeft")));
			this.txtSearchHD.IconLeftOffset = new System.Drawing.Point(5, 0);
			this.txtSearchHD.Location = new System.Drawing.Point(818, 116);
			this.txtSearchHD.Margin = new System.Windows.Forms.Padding(4);
			this.txtSearchHD.Name = "txtSearchHD";
			this.txtSearchHD.PasswordChar = '\0';
			this.txtSearchHD.PlaceholderText = "Tìm hóa đơn";
			this.txtSearchHD.SelectedText = "";
			this.txtSearchHD.Size = new System.Drawing.Size(360, 45);
			this.txtSearchHD.TabIndex = 5;
			this.txtSearchHD.TextChanged += new System.EventHandler(this.txtSearchHD_TextChanged);
			// 
			// FormHoaDon
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1282, 753);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dtThoiGianHoaDon);
			this.Controls.Add(this.txtSearchHD);
			this.Controls.Add(this.grvHoaDon);
			this.transactionLeftMenu.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormHoaDon";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormHoaDon";
			this.Load += new System.EventHandler(this.FormHoaDon_Load);
			((System.ComponentModel.ISupportInitialize)(this.grvHoaDon)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView grvHoaDon;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchHD;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtThoiGianHoaDon;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnLeftMenu;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Transition transactionLeftMenu;
	}
}