namespace Proyecto
{
    partial class frmHistorial
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
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoInmueble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoInmueble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btndescargar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btneditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btncancelar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcodigo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtfechafinalquiler = new System.Windows.Forms.DateTimePicker();
            this.txtfechainicioalquiler = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnbuscarfiltro = new FontAwesome.Sharp.IconButton();
            this.btnborrarfiltro = new FontAwesome.Sharp.IconButton();
            this.cbobuscar = new System.Windows.Forms.ComboBox();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnborrarbusqueda = new FontAwesome.Sharp.IconButton();
            this.btnbuscarbusqueda = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.CodigoAlquiler,
            this.NombreCliente,
            this.DocumentoCliente,
            this.CodigoInmueble,
            this.TipoInmueble,
            this.TipoAlquiler,
            this.Estado,
            this.btndescargar,
            this.btneditar,
            this.btncancelar});
            this.dgvdata.Location = new System.Drawing.Point(27, 184);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(866, 310);
            this.dgvdata.TabIndex = 52;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // CodigoAlquiler
            // 
            this.CodigoAlquiler.HeaderText = "Codigo Contrato";
            this.CodigoAlquiler.Name = "CodigoAlquiler";
            this.CodigoAlquiler.Width = 94;
            // 
            // NombreCliente
            // 
            this.NombreCliente.HeaderText = "Nombre Cliente";
            this.NombreCliente.Name = "NombreCliente";
            // 
            // DocumentoCliente
            // 
            this.DocumentoCliente.HeaderText = "Nro. Documento Cliente";
            this.DocumentoCliente.Name = "DocumentoCliente";
            this.DocumentoCliente.Width = 125;
            // 
            // CodigoInmueble
            // 
            this.CodigoInmueble.HeaderText = "Codigo Inmueble";
            this.CodigoInmueble.Name = "CodigoInmueble";
            this.CodigoInmueble.Width = 95;
            // 
            // TipoInmueble
            // 
            this.TipoInmueble.HeaderText = "Tipo Inmueble";
            this.TipoInmueble.Name = "TipoInmueble";
            // 
            // TipoAlquiler
            // 
            this.TipoAlquiler.HeaderText = "Tipo Alquiler";
            this.TipoAlquiler.Name = "TipoAlquiler";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Width = 90;
            // 
            // btndescargar
            // 
            this.btndescargar.HeaderText = "";
            this.btndescargar.Name = "btndescargar";
            this.btndescargar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btndescargar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btndescargar.Width = 35;
            // 
            // btneditar
            // 
            this.btneditar.HeaderText = "";
            this.btneditar.Name = "btneditar";
            this.btneditar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btneditar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btneditar.Width = 35;
            // 
            // btncancelar
            // 
            this.btncancelar.HeaderText = "";
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btncancelar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btncancelar.Width = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 25);
            this.label4.TabIndex = 53;
            this.label4.Text = "HISTORIAL DE ALQUILER";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(890, 487);
            this.label2.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(280, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "Codigo de Contrado:";
            // 
            // txtcodigo
            // 
            this.txtcodigo.Location = new System.Drawing.Point(283, 41);
            this.txtcodigo.Name = "txtcodigo";
            this.txtcodigo.Size = new System.Drawing.Size(100, 20);
            this.txtcodigo.TabIndex = 62;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.txtfechafinalquiler);
            this.groupBox1.Controls.Add(this.txtfechainicioalquiler);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnbuscarfiltro);
            this.groupBox1.Controls.Add(this.txtcodigo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnborrarfiltro);
            this.groupBox1.Location = new System.Drawing.Point(27, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 72);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // txtfechafinalquiler
            // 
            this.txtfechafinalquiler.CustomFormat = "dd/MM/yyyy";
            this.txtfechafinalquiler.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechafinalquiler.Location = new System.Drawing.Point(150, 41);
            this.txtfechafinalquiler.Name = "txtfechafinalquiler";
            this.txtfechafinalquiler.Size = new System.Drawing.Size(116, 20);
            this.txtfechafinalquiler.TabIndex = 66;
            // 
            // txtfechainicioalquiler
            // 
            this.txtfechainicioalquiler.CustomFormat = "dd/MM/yyyy";
            this.txtfechainicioalquiler.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechainicioalquiler.Location = new System.Drawing.Point(12, 41);
            this.txtfechainicioalquiler.Name = "txtfechainicioalquiler";
            this.txtfechainicioalquiler.Size = new System.Drawing.Size(116, 20);
            this.txtfechainicioalquiler.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(9, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Fecha Inicio Registro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(147, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Fecha Fin Registro:";
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
            this.btnbuscarfiltro.Location = new System.Drawing.Point(413, 38);
            this.btnbuscarfiltro.Name = "btnbuscarfiltro";
            this.btnbuscarfiltro.Size = new System.Drawing.Size(37, 23);
            this.btnbuscarfiltro.TabIndex = 59;
            this.btnbuscarfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarfiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarfiltro.UseVisualStyleBackColor = false;
            this.btnbuscarfiltro.Click += new System.EventHandler(this.btnbuscarfiltro_Click);
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
            this.btnborrarfiltro.Location = new System.Drawing.Point(456, 38);
            this.btnborrarfiltro.Name = "btnborrarfiltro";
            this.btnborrarfiltro.Size = new System.Drawing.Size(37, 23);
            this.btnborrarfiltro.TabIndex = 60;
            this.btnborrarfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnborrarfiltro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnborrarfiltro.UseVisualStyleBackColor = false;
            this.btnborrarfiltro.Click += new System.EventHandler(this.btnborrarfiltro_Click);
            // 
            // cbobuscar
            // 
            this.cbobuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbobuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbobuscar.FormattingEnabled = true;
            this.cbobuscar.Location = new System.Drawing.Point(489, 155);
            this.cbobuscar.Name = "cbobuscar";
            this.cbobuscar.Size = new System.Drawing.Size(177, 23);
            this.cbobuscar.TabIndex = 65;
            // 
            // txtbuscar
            // 
            this.txtbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbuscar.Location = new System.Drawing.Point(672, 155);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(135, 21);
            this.txtbuscar.TabIndex = 66;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(419, 158);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 64;
            this.label12.Text = "Buscar por:";
            // 
            // btnborrarbusqueda
            // 
            this.btnborrarbusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnborrarbusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnborrarbusqueda.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnborrarbusqueda.IconColor = System.Drawing.Color.Black;
            this.btnborrarbusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnborrarbusqueda.IconSize = 20;
            this.btnborrarbusqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnborrarbusqueda.Location = new System.Drawing.Point(856, 155);
            this.btnborrarbusqueda.Name = "btnborrarbusqueda";
            this.btnborrarbusqueda.Size = new System.Drawing.Size(37, 23);
            this.btnborrarbusqueda.TabIndex = 68;
            this.btnborrarbusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnborrarbusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnborrarbusqueda.UseVisualStyleBackColor = true;
            this.btnborrarbusqueda.Click += new System.EventHandler(this.btnborrarbusqueda_Click);
            // 
            // btnbuscarbusqueda
            // 
            this.btnbuscarbusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarbusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnbuscarbusqueda.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnbuscarbusqueda.IconColor = System.Drawing.Color.Black;
            this.btnbuscarbusqueda.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarbusqueda.IconSize = 18;
            this.btnbuscarbusqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnbuscarbusqueda.Location = new System.Drawing.Point(813, 155);
            this.btnbuscarbusqueda.Name = "btnbuscarbusqueda";
            this.btnbuscarbusqueda.Size = new System.Drawing.Size(37, 23);
            this.btnbuscarbusqueda.TabIndex = 67;
            this.btnbuscarbusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarbusqueda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarbusqueda.UseVisualStyleBackColor = true;
            this.btnbuscarbusqueda.Click += new System.EventHandler(this.btnbuscarbusqueda_Click);
            // 
            // frmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 609);
            this.Controls.Add(this.btnborrarbusqueda);
            this.Controls.Add(this.btnbuscarbusqueda);
            this.Controls.Add(this.cbobuscar);
            this.Controls.Add(this.txtbuscar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "frmHistorial";
            this.Text = "frmHistorial";
            this.Load += new System.EventHandler(this.frmHistorial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnborrarfiltro;
        private FontAwesome.Sharp.IconButton btnbuscarfiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcodigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtfechafinalquiler;
        private System.Windows.Forms.DateTimePicker txtfechainicioalquiler;
        private FontAwesome.Sharp.IconButton btnborrarbusqueda;
        private FontAwesome.Sharp.IconButton btnbuscarbusqueda;
        private System.Windows.Forms.ComboBox cbobuscar;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoInmueble;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoInmueble;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewButtonColumn btndescargar;
        private System.Windows.Forms.DataGridViewButtonColumn btneditar;
        private System.Windows.Forms.DataGridViewButtonColumn btncancelar;
    }
}