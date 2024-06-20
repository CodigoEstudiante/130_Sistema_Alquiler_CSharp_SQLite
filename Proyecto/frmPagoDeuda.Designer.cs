namespace Proyecto
{
    partial class frmPagoDeuda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.rbcodigoinmueble = new System.Windows.Forms.RadioButton();
            this.rbcodigocontrato = new System.Windows.Forms.RadioButton();
            this.txtcodigoalquiler = new System.Windows.Forms.TextBox();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.cbocodigoinmueble = new System.Windows.Forms.ComboBox();
            this.txtidalquiler = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labeltest = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoDeuda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoDeuda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnpagar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btndescargar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lblestado);
            this.groupBox2.Controls.Add(this.iconButton2);
            this.groupBox2.Controls.Add(this.rbcodigoinmueble);
            this.groupBox2.Controls.Add(this.rbcodigocontrato);
            this.groupBox2.Controls.Add(this.txtcodigoalquiler);
            this.groupBox2.Controls.Add(this.btnbuscar);
            this.groupBox2.Controls.Add(this.cbocodigoinmueble);
            this.groupBox2.Location = new System.Drawing.Point(26, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 49);
            this.groupBox2.TabIndex = 61;
            this.groupBox2.TabStop = false;
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblestado.Location = new System.Drawing.Point(770, 24);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(0, 13);
            this.lblestado.TabIndex = 61;
            // 
            // iconButton2
            // 
            this.iconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 20;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iconButton2.Location = new System.Drawing.Point(559, 17);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(37, 23);
            this.iconButton2.TabIndex = 59;
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // rbcodigoinmueble
            // 
            this.rbcodigoinmueble.AutoSize = true;
            this.rbcodigoinmueble.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbcodigoinmueble.Location = new System.Drawing.Point(249, 20);
            this.rbcodigoinmueble.Name = "rbcodigoinmueble";
            this.rbcodigoinmueble.Size = new System.Drawing.Size(122, 17);
            this.rbcodigoinmueble.TabIndex = 12;
            this.rbcodigoinmueble.Text = "Codigo de Inmueble:";
            this.rbcodigoinmueble.UseVisualStyleBackColor = true;
            this.rbcodigoinmueble.CheckedChanged += new System.EventHandler(this.rbcodigoinmueble_CheckedChanged);
            // 
            // rbcodigocontrato
            // 
            this.rbcodigocontrato.AutoSize = true;
            this.rbcodigocontrato.Checked = true;
            this.rbcodigocontrato.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbcodigocontrato.Location = new System.Drawing.Point(9, 20);
            this.rbcodigocontrato.Name = "rbcodigocontrato";
            this.rbcodigocontrato.Size = new System.Drawing.Size(119, 17);
            this.rbcodigocontrato.TabIndex = 11;
            this.rbcodigocontrato.TabStop = true;
            this.rbcodigocontrato.Text = "Codigo de Contrato:";
            this.rbcodigocontrato.UseVisualStyleBackColor = true;
            this.rbcodigocontrato.CheckedChanged += new System.EventHandler(this.rbcodigocontrato_CheckedChanged);
            // 
            // txtcodigoalquiler
            // 
            this.txtcodigoalquiler.BackColor = System.Drawing.Color.White;
            this.txtcodigoalquiler.Location = new System.Drawing.Point(132, 19);
            this.txtcodigoalquiler.Name = "txtcodigoalquiler";
            this.txtcodigoalquiler.Size = new System.Drawing.Size(100, 20);
            this.txtcodigoalquiler.TabIndex = 0;
            // 
            // btnbuscar
            // 
            this.btnbuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscar.IconSize = 19;
            this.btnbuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnbuscar.Location = new System.Drawing.Point(511, 17);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(37, 23);
            this.btnbuscar.TabIndex = 10;
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // cbocodigoinmueble
            // 
            this.cbocodigoinmueble.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbocodigoinmueble.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocodigoinmueble.FormattingEnabled = true;
            this.cbocodigoinmueble.Location = new System.Drawing.Point(374, 18);
            this.cbocodigoinmueble.Name = "cbocodigoinmueble";
            this.cbocodigoinmueble.Size = new System.Drawing.Size(116, 21);
            this.cbocodigoinmueble.TabIndex = 13;
            // 
            // txtidalquiler
            // 
            this.txtidalquiler.Location = new System.Drawing.Point(217, 38);
            this.txtidalquiler.Name = "txtidalquiler";
            this.txtidalquiler.Size = new System.Drawing.Size(25, 20);
            this.txtidalquiler.TabIndex = 64;
            this.txtidalquiler.Text = "0";
            this.txtidalquiler.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 25);
            this.label4.TabIndex = 60;
            this.label4.Text = "PAGO DE DEUDAS";
            // 
            // labeltest
            // 
            this.labeltest.BackColor = System.Drawing.Color.White;
            this.labeltest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labeltest.Location = new System.Drawing.Point(16, 19);
            this.labeltest.Name = "labeltest";
            this.labeltest.Size = new System.Drawing.Size(890, 326);
            this.labeltest.TabIndex = 62;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dgvdata);
            this.groupBox1.Location = new System.Drawing.Point(26, 127);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 208);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Historial de deudas";
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.IdPeriodo,
            this.NumeroPeriodo,
            this.MontoDeuda,
            this.EstadoDeuda,
            this.btnpagar,
            this.btndescargar,
            this.FechaPago});
            this.dgvdata.Location = new System.Drawing.Point(9, 19);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(600, 178);
            this.dgvdata.TabIndex = 32;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // IdPeriodo
            // 
            this.IdPeriodo.HeaderText = "IdPeriodo";
            this.IdPeriodo.Name = "IdPeriodo";
            this.IdPeriodo.ReadOnly = true;
            this.IdPeriodo.Visible = false;
            // 
            // NumeroPeriodo
            // 
            this.NumeroPeriodo.HeaderText = "Numero Periodo";
            this.NumeroPeriodo.Name = "NumeroPeriodo";
            this.NumeroPeriodo.ReadOnly = true;
            this.NumeroPeriodo.Width = 150;
            // 
            // MontoDeuda
            // 
            this.MontoDeuda.HeaderText = "Monto Deuda";
            this.MontoDeuda.Name = "MontoDeuda";
            this.MontoDeuda.ReadOnly = true;
            this.MontoDeuda.Width = 150;
            // 
            // EstadoDeuda
            // 
            this.EstadoDeuda.HeaderText = "Estado Deuda";
            this.EstadoDeuda.Name = "EstadoDeuda";
            this.EstadoDeuda.ReadOnly = true;
            this.EstadoDeuda.Width = 150;
            // 
            // btnpagar
            // 
            this.btnpagar.HeaderText = "";
            this.btnpagar.Name = "btnpagar";
            this.btnpagar.ReadOnly = true;
            this.btnpagar.Width = 35;
            // 
            // btndescargar
            // 
            this.btndescargar.HeaderText = "";
            this.btndescargar.Name = "btndescargar";
            this.btndescargar.ReadOnly = true;
            this.btndescargar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btndescargar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btndescargar.Width = 35;
            // 
            // FechaPago
            // 
            this.FechaPago.HeaderText = "FechaPago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.ReadOnly = true;
            this.FechaPago.Visible = false;
            // 
            // txtcodigo
            // 
            this.txtcodigo.BackColor = System.Drawing.Color.White;
            this.txtcodigo.Location = new System.Drawing.Point(248, 38);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(100, 20);
            this.txtcodigo.TabIndex = 62;
            this.txtcodigo.Visible = false;
            // 
            // frmPagoDeuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 561);
            this.Controls.Add(this.txtcodigo);
            this.Controls.Add(this.txtidalquiler);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labeltest);
            this.Name = "frmPagoDeuda";
            this.Text = "frmPagoDeuda";
            this.Load += new System.EventHandler(this.frmPagoDeuda_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtidalquiler;
        private System.Windows.Forms.Label lblestado;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.RadioButton rbcodigoinmueble;
        private System.Windows.Forms.RadioButton rbcodigocontrato;
        private System.Windows.Forms.TextBox txtcodigoalquiler;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.ComboBox cbocodigoinmueble;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labeltest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoDeuda;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDeuda;
        private System.Windows.Forms.DataGridViewButtonColumn btnpagar;
        private System.Windows.Forms.DataGridViewButtonColumn btndescargar;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
    }
}