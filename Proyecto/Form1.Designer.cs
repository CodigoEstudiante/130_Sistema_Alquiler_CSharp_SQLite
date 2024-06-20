namespace Proyecto
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuinicio = new FontAwesome.Sharp.IconMenuItem();
            this.menumisdatos = new FontAwesome.Sharp.IconMenuItem();
            this.menuconfiguracion = new FontAwesome.Sharp.IconMenuItem();
            this.subtipoinmueble = new System.Windows.Forms.ToolStripMenuItem();
            this.subinmueble = new System.Windows.Forms.ToolStripMenuItem();
            this.subtipoalquiler = new System.Windows.Forms.ToolStripMenuItem();
            this.subtipomoneda = new System.Windows.Forms.ToolStripMenuItem();
            this.menualquiler = new FontAwesome.Sharp.IconMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menupagos = new FontAwesome.Sharp.IconMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.verHistorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuinfo = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsalir = new FontAwesome.Sharp.IconButton();
            this.lblfecha = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuinicio,
            this.menumisdatos,
            this.menuconfiguracion,
            this.menualquiler,
            this.menupagos,
            this.menureportes,
            this.menuinfo});
            this.menu.Location = new System.Drawing.Point(0, 77);
            this.menu.Name = "menu";
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menu.Size = new System.Drawing.Size(153, 556);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuinicio
            // 
            this.menuinicio.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.menuinicio.IconColor = System.Drawing.Color.Black;
            this.menuinicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuinicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuinicio.Name = "menuinicio";
            this.menuinicio.Size = new System.Drawing.Size(146, 52);
            this.menuinicio.Text = "Inicio";
            this.menuinicio.Click += new System.EventHandler(this.menuinicio_Click);
            // 
            // menumisdatos
            // 
            this.menumisdatos.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.menumisdatos.IconColor = System.Drawing.Color.Black;
            this.menumisdatos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumisdatos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumisdatos.Name = "menumisdatos";
            this.menumisdatos.Size = new System.Drawing.Size(146, 52);
            this.menumisdatos.Text = "Mis Datos";
            this.menumisdatos.Click += new System.EventHandler(this.menumisdatos_Click);
            // 
            // menuconfiguracion
            // 
            this.menuconfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subtipoinmueble,
            this.subinmueble,
            this.subtipoalquiler,
            this.subtipomoneda});
            this.menuconfiguracion.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuconfiguracion.IconColor = System.Drawing.Color.Black;
            this.menuconfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuconfiguracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuconfiguracion.Name = "menuconfiguracion";
            this.menuconfiguracion.Size = new System.Drawing.Size(146, 52);
            this.menuconfiguracion.Text = "Configuración";
            // 
            // subtipoinmueble
            // 
            this.subtipoinmueble.Name = "subtipoinmueble";
            this.subtipoinmueble.Size = new System.Drawing.Size(150, 22);
            this.subtipoinmueble.Text = "Tipo Inmueble";
            this.subtipoinmueble.Click += new System.EventHandler(this.subtipoinmueble_Click);
            // 
            // subinmueble
            // 
            this.subinmueble.Name = "subinmueble";
            this.subinmueble.Size = new System.Drawing.Size(150, 22);
            this.subinmueble.Text = "Inmueble";
            this.subinmueble.Click += new System.EventHandler(this.subinmueble_Click);
            // 
            // subtipoalquiler
            // 
            this.subtipoalquiler.Name = "subtipoalquiler";
            this.subtipoalquiler.Size = new System.Drawing.Size(150, 22);
            this.subtipoalquiler.Text = "Tipo Alquiler";
            this.subtipoalquiler.Click += new System.EventHandler(this.subtipoalquiler_Click);
            // 
            // subtipomoneda
            // 
            this.subtipomoneda.Name = "subtipomoneda";
            this.subtipomoneda.Size = new System.Drawing.Size(150, 22);
            this.subtipomoneda.Text = "Tipo Moneda";
            this.subtipomoneda.Click += new System.EventHandler(this.subtipomoneda_Click);
            // 
            // menualquiler
            // 
            this.menualquiler.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.menualquiler.IconChar = FontAwesome.Sharp.IconChar.ClipboardCheck;
            this.menualquiler.IconColor = System.Drawing.Color.Black;
            this.menualquiler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menualquiler.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menualquiler.Name = "menualquiler";
            this.menualquiler.Size = new System.Drawing.Size(146, 52);
            this.menualquiler.Text = "Alquiler";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem5.Text = "Registrar nuevo";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem6.Text = "Ver Historial";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // menupagos
            // 
            this.menupagos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.verHistorialToolStripMenuItem});
            this.menupagos.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            this.menupagos.IconColor = System.Drawing.Color.Black;
            this.menupagos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menupagos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menupagos.Name = "menupagos";
            this.menupagos.Size = new System.Drawing.Size(146, 52);
            this.menupagos.Text = "Pagos";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem7.Text = "Registrar por alquiler";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(183, 22);
            this.toolStripMenuItem8.Text = "Registrar por deuda";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // verHistorialToolStripMenuItem
            // 
            this.verHistorialToolStripMenuItem.Name = "verHistorialToolStripMenuItem";
            this.verHistorialToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.verHistorialToolStripMenuItem.Text = "Ver Historial";
            this.verHistorialToolStripMenuItem.Click += new System.EventHandler(this.verHistorialToolStripMenuItem_Click);
            // 
            // menureportes
            // 
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(146, 52);
            this.menureportes.Text = "Resumen";
            this.menureportes.Click += new System.EventHandler(this.menureportes_Click);
            // 
            // menuinfo
            // 
            this.menuinfo.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            this.menuinfo.IconColor = System.Drawing.Color.Black;
            this.menuinfo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuinfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuinfo.Name = "menuinfo";
            this.menuinfo.Size = new System.Drawing.Size(146, 52);
            this.menuinfo.Text = "Acerca de";
            this.menuinfo.Click += new System.EventHandler(this.menuinfo_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.Color.IndianRed;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(1082, 77);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // contenedor
            // 
            this.contenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(153, 77);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(929, 556);
            this.contenedor.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.IndianRed;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sistema de alquiler libre";
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.IndianRed;
            this.btnsalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.ForeColor = System.Drawing.Color.White;
            this.btnsalir.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnsalir.IconColor = System.Drawing.Color.White;
            this.btnsalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsalir.Location = new System.Drawing.Point(1012, 9);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(62, 59);
            this.btnsalir.TabIndex = 4;
            this.btnsalir.Text = "Salir";
            this.btnsalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.BackColor = System.Drawing.Color.IndianRed;
            this.lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.ForeColor = System.Drawing.Color.White;
            this.lblfecha.Location = new System.Drawing.Point(770, 41);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(57, 17);
            this.lblfecha.TabIndex = 5;
            this.lblfecha.Text = "lblfecha";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.IndianRed;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(770, 19);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(71, 17);
            this.lblusuario.TabIndex = 6;
            this.lblusuario.Text = "lblUsuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.IndianRed;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(718, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.IndianRed;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(708, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Usuario:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 633);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1098, 672);
            this.MinimumSize = new System.Drawing.Size(1098, 672);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private FontAwesome.Sharp.IconMenuItem menumisdatos;
        private FontAwesome.Sharp.IconMenuItem menuconfiguracion;
        private System.Windows.Forms.ToolStripMenuItem subtipoinmueble;
        private System.Windows.Forms.ToolStripMenuItem subinmueble;
        private System.Windows.Forms.ToolStripMenuItem subtipoalquiler;
        private System.Windows.Forms.ToolStripMenuItem subtipomoneda;
        private FontAwesome.Sharp.IconMenuItem menualquiler;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private FontAwesome.Sharp.IconMenuItem menupagos;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuinicio;
        private System.Windows.Forms.ToolStripMenuItem verHistorialToolStripMenuItem;
        private FontAwesome.Sharp.IconMenuItem menuinfo;
        private FontAwesome.Sharp.IconButton btnsalir;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

