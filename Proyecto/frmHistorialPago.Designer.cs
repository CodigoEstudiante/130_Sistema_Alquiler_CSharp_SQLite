namespace Proyecto
{
    partial class frmHistorialPago
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtidalquiler = new System.Windows.Forms.TextBox();
            this.btnbuscarfiltro = new FontAwesome.Sharp.IconButton();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnborrarfiltro = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaLimitePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btndescargar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.txtidalquiler);
            this.groupBox1.Controls.Add(this.btnbuscarfiltro);
            this.groupBox1.Controls.Add(this.txtcodigo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnborrarfiltro);
            this.groupBox1.Location = new System.Drawing.Point(25, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 72);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // txtidalquiler
            // 
            this.txtidalquiler.Location = new System.Drawing.Point(241, 38);
            this.txtidalquiler.Name = "txtidalquiler";
            this.txtidalquiler.Size = new System.Drawing.Size(41, 20);
            this.txtidalquiler.TabIndex = 63;
            this.txtidalquiler.Text = "0";
            this.txtidalquiler.Visible = false;
            // 
            // btnbuscarfiltro
            // 
            this.btnbuscarfiltro.BackColor = System.Drawing.Color.White;
            this.btnbuscarfiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarfiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnbuscarfiltro.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnbuscarfiltro.IconColor = System.Drawing.Color.Black;
            this.btnbuscarfiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarfiltro.IconSize = 18;
            this.btnbuscarfiltro.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnbuscarfiltro.Location = new System.Drawing.Point(141, 35);
            this.btnbuscarfiltro.Name = "btnbuscarfiltro";
            this.btnbuscarfiltro.Size = new System.Drawing.Size(37, 23);
            this.btnbuscarfiltro.TabIndex = 59;
            this.btnbuscarfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarfiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarfiltro.UseVisualStyleBackColor = false;
            this.btnbuscarfiltro.Click += new System.EventHandler(this.btnbuscarfiltro_Click);
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(11, 38);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(100, 20);
            this.txtcodigo.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Codigo de Contrado:";
            // 
            // btnborrarfiltro
            // 
            this.btnborrarfiltro.BackColor = System.Drawing.Color.White;
            this.btnborrarfiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnborrarfiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnborrarfiltro.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnborrarfiltro.IconColor = System.Drawing.Color.Black;
            this.btnborrarfiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnborrarfiltro.IconSize = 20;
            this.btnborrarfiltro.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnborrarfiltro.Location = new System.Drawing.Point(184, 35);
            this.btnborrarfiltro.Name = "btnborrarfiltro";
            this.btnborrarfiltro.Size = new System.Drawing.Size(37, 23);
            this.btnborrarfiltro.TabIndex = 60;
            this.btnborrarfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnborrarfiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnborrarfiltro.UseVisualStyleBackColor = false;
            this.btnborrarfiltro.Click += new System.EventHandler(this.btnborrarfiltro_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 25);
            this.label4.TabIndex = 70;
            this.label4.Text = "HISTORIAL DE PAGOS";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(890, 487);
            this.label2.TabIndex = 71;
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NumeroPeriodo,
            this.FechaLimitePago,
            this.EstadoPeriodo,
            this.FechaPago,
            this.Monto,
            this.btndescargar});
            this.dgvdata.Location = new System.Drawing.Point(25, 164);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(868, 330);
            this.dgvdata.TabIndex = 78;
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
            // NumeroPeriodo
            // 
            this.NumeroPeriodo.HeaderText = "Número de Periodo";
            this.NumeroPeriodo.Name = "NumeroPeriodo";
            this.NumeroPeriodo.ReadOnly = true;
            this.NumeroPeriodo.Width = 150;
            // 
            // FechaLimitePago
            // 
            this.FechaLimitePago.HeaderText = "Fecha Limite Pago";
            this.FechaLimitePago.Name = "FechaLimitePago";
            this.FechaLimitePago.ReadOnly = true;
            this.FechaLimitePago.Width = 150;
            // 
            // EstadoPeriodo
            // 
            this.EstadoPeriodo.HeaderText = "Estado Pago";
            this.EstadoPeriodo.Name = "EstadoPeriodo";
            this.EstadoPeriodo.ReadOnly = true;
            this.EstadoPeriodo.Width = 150;
            // 
            // FechaPago
            // 
            this.FechaPago.HeaderText = "FechaPago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.ReadOnly = true;
            this.FechaPago.Visible = false;
            // 
            // Monto
            // 
            this.Monto.HeaderText = "Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Visible = false;
            // 
            // btndescargar
            // 
            this.btndescargar.HeaderText = "";
            this.btndescargar.Name = "btndescargar";
            this.btndescargar.ReadOnly = true;
            this.btndescargar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btndescargar.Width = 35;
            // 
            // frmHistorialPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 640);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "frmHistorialPago";
            this.Text = "frmHistorialPago";
            this.Load += new System.EventHandler(this.frmHistorialPago_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnbuscarfiltro;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnborrarfiltro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.TextBox txtidalquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaLimitePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewButtonColumn btndescargar;
    }
}