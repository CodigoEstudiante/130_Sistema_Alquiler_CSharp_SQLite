namespace Proyecto
{
    partial class frmResumen
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtinmuebledescripcion = new System.Windows.Forms.TextBox();
            this.txtinmuebletipo = new System.Windows.Forms.TextBox();
            this.txtinmueblecodigo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnclausulas = new FontAwesome.Sharp.IconButton();
            this.txtfechainicioalquiler = new System.Windows.Forms.TextBox();
            this.txtcantidadperiodo = new System.Windows.Forms.TextBox();
            this.txttipoalquiler = new System.Windows.Forms.TextBox();
            this.txttipomoneda = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtprecioalquiler = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbocodigoinmueble = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.rbcodigoinmueble = new System.Windows.Forms.RadioButton();
            this.rbcodigocontrato = new System.Windows.Forms.RadioButton();
            this.txtcodigoalquiler = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtclientenacionalidad = new System.Windows.Forms.TextBox();
            this.txtclientecorreo = new System.Windows.Forms.TextBox();
            this.txtclientetelefono = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtclientedocumento = new System.Windows.Forms.TextBox();
            this.txtclientetipodocumento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtclientenombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labeltest = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.NumeroPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaLimitePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.txtinmuebledescripcion);
            this.groupBox4.Controls.Add(this.txtinmuebletipo);
            this.groupBox4.Controls.Add(this.txtinmueblecodigo);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(26, 257);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(509, 70);
            this.groupBox4.TabIndex = 46;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "INFORMACIÓN DEL INMUEBLE";
            // 
            // txtinmuebledescripcion
            // 
            this.txtinmuebledescripcion.Location = new System.Drawing.Point(246, 36);
            this.txtinmuebledescripcion.Name = "txtinmuebledescripcion";
            this.txtinmuebledescripcion.ReadOnly = true;
            this.txtinmuebledescripcion.Size = new System.Drawing.Size(253, 20);
            this.txtinmuebledescripcion.TabIndex = 9;
            // 
            // txtinmuebletipo
            // 
            this.txtinmuebletipo.Location = new System.Drawing.Point(121, 36);
            this.txtinmuebletipo.Name = "txtinmuebletipo";
            this.txtinmuebletipo.ReadOnly = true;
            this.txtinmuebletipo.Size = new System.Drawing.Size(116, 20);
            this.txtinmuebletipo.TabIndex = 8;
            // 
            // txtinmueblecodigo
            // 
            this.txtinmueblecodigo.Location = new System.Drawing.Point(9, 36);
            this.txtinmueblecodigo.Name = "txtinmueblecodigo";
            this.txtinmueblecodigo.ReadOnly = true;
            this.txtinmueblecodigo.Size = new System.Drawing.Size(103, 20);
            this.txtinmueblecodigo.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(243, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Descripción Inmueble:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(118, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tipo Inmueble:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(6, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Código Inmueble:";
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.btnclausulas);
            this.groupBox3.Controls.Add(this.txtfechainicioalquiler);
            this.groupBox3.Controls.Add(this.txtcantidadperiodo);
            this.groupBox3.Controls.Add(this.txttipoalquiler);
            this.groupBox3.Controls.Add(this.txttipomoneda);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txtprecioalquiler);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(26, 345);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 114);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "INFORMACIÓN DEL ALQUILER";
            // 
            // btnclausulas
            // 
            this.btnclausulas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclausulas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnclausulas.IconColor = System.Drawing.Color.Black;
            this.btnclausulas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnclausulas.IconSize = 19;
            this.btnclausulas.Location = new System.Drawing.Point(121, 78);
            this.btnclausulas.Name = "btnclausulas";
            this.btnclausulas.Size = new System.Drawing.Size(116, 23);
            this.btnclausulas.TabIndex = 53;
            this.btnclausulas.Text = "Ver Cláusulas";
            this.btnclausulas.UseVisualStyleBackColor = true;
            this.btnclausulas.Click += new System.EventHandler(this.btnclausulas_Click);
            // 
            // txtfechainicioalquiler
            // 
            this.txtfechainicioalquiler.Location = new System.Drawing.Point(9, 80);
            this.txtfechainicioalquiler.Name = "txtfechainicioalquiler";
            this.txtfechainicioalquiler.ReadOnly = true;
            this.txtfechainicioalquiler.Size = new System.Drawing.Size(103, 20);
            this.txtfechainicioalquiler.TabIndex = 18;
            // 
            // txtcantidadperiodo
            // 
            this.txtcantidadperiodo.Location = new System.Drawing.Point(121, 35);
            this.txtcantidadperiodo.Name = "txtcantidadperiodo";
            this.txtcantidadperiodo.ReadOnly = true;
            this.txtcantidadperiodo.Size = new System.Drawing.Size(116, 20);
            this.txtcantidadperiodo.TabIndex = 17;
            // 
            // txttipoalquiler
            // 
            this.txttipoalquiler.Location = new System.Drawing.Point(9, 35);
            this.txttipoalquiler.Name = "txttipoalquiler";
            this.txttipoalquiler.ReadOnly = true;
            this.txttipoalquiler.Size = new System.Drawing.Size(103, 20);
            this.txttipoalquiler.TabIndex = 16;
            // 
            // txttipomoneda
            // 
            this.txttipomoneda.Location = new System.Drawing.Point(246, 35);
            this.txttipomoneda.Name = "txttipomoneda";
            this.txttipomoneda.ReadOnly = true;
            this.txttipomoneda.Size = new System.Drawing.Size(116, 20);
            this.txttipomoneda.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(6, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Fecha Inicio Alquiler:";
            // 
            // txtprecioalquiler
            // 
            this.txtprecioalquiler.Location = new System.Drawing.Point(372, 35);
            this.txtprecioalquiler.Name = "txtprecioalquiler";
            this.txtprecioalquiler.ReadOnly = true;
            this.txtprecioalquiler.Size = new System.Drawing.Size(116, 20);
            this.txtprecioalquiler.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(369, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Precio Alquiler:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(118, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Cantidad de Periodos:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(243, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Tipo Moneda:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(6, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Tipo Alquiler:";
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.lblestado);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.iconButton2);
            this.groupBox2.Controls.Add(this.rbcodigoinmueble);
            this.groupBox2.Controls.Add(this.rbcodigocontrato);
            this.groupBox2.Controls.Add(this.txtcodigoalquiler);
            this.groupBox2.Controls.Add(this.btnbuscar);
            this.groupBox2.Controls.Add(this.cbocodigoinmueble);
            this.groupBox2.Location = new System.Drawing.Point(26, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(873, 49);
            this.groupBox2.TabIndex = 52;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(726, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Estado:";
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
            this.txtcodigoalquiler.Location = new System.Drawing.Point(132, 19);
            this.txtcodigoalquiler.Name = "txtcodigoalquiler";
            this.txtcodigoalquiler.Size = new System.Drawing.Size(100, 20);
            this.txtcodigoalquiler.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtclientenacionalidad);
            this.groupBox1.Controls.Add(this.txtclientecorreo);
            this.groupBox1.Controls.Add(this.txtclientetelefono);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtclientedocumento);
            this.groupBox1.Controls.Add(this.txtclientetipodocumento);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtclientenombre);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(26, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 120);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INFORMACIÓN DEL INQUILINO";
            // 
            // txtclientenacionalidad
            // 
            this.txtclientenacionalidad.Location = new System.Drawing.Point(368, 86);
            this.txtclientenacionalidad.Name = "txtclientenacionalidad";
            this.txtclientenacionalidad.ReadOnly = true;
            this.txtclientenacionalidad.Size = new System.Drawing.Size(133, 20);
            this.txtclientenacionalidad.TabIndex = 6;
            // 
            // txtclientecorreo
            // 
            this.txtclientecorreo.Location = new System.Drawing.Point(207, 86);
            this.txtclientecorreo.Name = "txtclientecorreo";
            this.txtclientecorreo.ReadOnly = true;
            this.txtclientecorreo.Size = new System.Drawing.Size(149, 20);
            this.txtclientecorreo.TabIndex = 5;
            // 
            // txtclientetelefono
            // 
            this.txtclientetelefono.Location = new System.Drawing.Point(9, 86);
            this.txtclientetelefono.Name = "txtclientetelefono";
            this.txtclientetelefono.ReadOnly = true;
            this.txtclientetelefono.Size = new System.Drawing.Size(187, 20);
            this.txtclientetelefono.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(365, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Nacionalidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(204, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Correo Electronico:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(6, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Numero Telefono / Celular:";
            // 
            // txtclientedocumento
            // 
            this.txtclientedocumento.Location = new System.Drawing.Point(368, 37);
            this.txtclientedocumento.Name = "txtclientedocumento";
            this.txtclientedocumento.ReadOnly = true;
            this.txtclientedocumento.Size = new System.Drawing.Size(133, 20);
            this.txtclientedocumento.TabIndex = 3;
            // 
            // txtclientetipodocumento
            // 
            this.txtclientetipodocumento.Location = new System.Drawing.Point(207, 37);
            this.txtclientetipodocumento.Name = "txtclientetipodocumento";
            this.txtclientetipodocumento.ReadOnly = true;
            this.txtclientetipodocumento.Size = new System.Drawing.Size(149, 20);
            this.txtclientetipodocumento.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(365, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Número Documento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(204, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tipo Documento:";
            // 
            // txtclientenombre
            // 
            this.txtclientenombre.Location = new System.Drawing.Point(9, 37);
            this.txtclientenombre.Name = "txtclientenombre";
            this.txtclientenombre.ReadOnly = true;
            this.txtclientenombre.Size = new System.Drawing.Size(187, 20);
            this.txtclientenombre.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre Completo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 25);
            this.label4.TabIndex = 49;
            this.label4.Text = "RESUMEN DE ALQUILER";
            // 
            // labeltest
            // 
            this.labeltest.BackColor = System.Drawing.Color.White;
            this.labeltest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labeltest.Location = new System.Drawing.Point(16, 19);
            this.labeltest.Name = "labeltest";
            this.labeltest.Size = new System.Drawing.Size(890, 453);
            this.labeltest.TabIndex = 51;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.dgvdata);
            this.groupBox5.Location = new System.Drawing.Point(539, 121);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(360, 338);
            this.groupBox5.TabIndex = 48;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "HITORIAL DE PAGO";
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
            this.NumeroPeriodo,
            this.FechaLimitePago,
            this.EstadoPeriodo});
            this.dgvdata.Location = new System.Drawing.Point(9, 19);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(341, 304);
            this.dgvdata.TabIndex = 9;
            // 
            // NumeroPeriodo
            // 
            this.NumeroPeriodo.HeaderText = "Número de Periodo";
            this.NumeroPeriodo.Name = "NumeroPeriodo";
            this.NumeroPeriodo.ReadOnly = true;
            this.NumeroPeriodo.Width = 94;
            // 
            // FechaLimitePago
            // 
            this.FechaLimitePago.HeaderText = "Fecha Limite Pago";
            this.FechaLimitePago.Name = "FechaLimitePago";
            this.FechaLimitePago.ReadOnly = true;
            // 
            // EstadoPeriodo
            // 
            this.EstadoPeriodo.HeaderText = "Estado Pago";
            this.EstadoPeriodo.Name = "EstadoPeriodo";
            this.EstadoPeriodo.ReadOnly = true;
            this.EstadoPeriodo.Width = 90;
            // 
            // frmResumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1033, 499);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labeltest);
            this.Name = "frmResumen";
            this.Text = "frmResumen";
            this.Load += new System.EventHandler(this.frmResumen_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtinmuebledescripcion;
        private System.Windows.Forms.TextBox txtinmuebletipo;
        private System.Windows.Forms.TextBox txtinmueblecodigo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txttipomoneda;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtprecioalquiler;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbocodigoinmueble;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbcodigoinmueble;
        private System.Windows.Forms.RadioButton rbcodigocontrato;
        private System.Windows.Forms.TextBox txtcodigoalquiler;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtclientenacionalidad;
        private System.Windows.Forms.TextBox txtclientecorreo;
        private System.Windows.Forms.TextBox txtclientetelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtclientedocumento;
        private System.Windows.Forms.TextBox txtclientetipodocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtclientenombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labeltest;
        private System.Windows.Forms.TextBox txtcantidadperiodo;
        private System.Windows.Forms.TextBox txttipoalquiler;
        private System.Windows.Forms.TextBox txtfechainicioalquiler;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaLimitePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoPeriodo;
        private FontAwesome.Sharp.IconButton btnclausulas;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.Label label1;
    }
}