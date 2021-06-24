
namespace proyecto
{
    partial class form_recuperar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_recuperar));
            this.txtUsuarioRec = new System.Windows.Forms.TextBox();
            this.txtResRec = new System.Windows.Forms.TextBox();
            this.btnRecuperar = new System.Windows.Forms.Button();
            this.txtPassRec = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lblPregRec = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPortapapeles = new System.Windows.Forms.Label();
            this.lblUsuarioHover = new System.Windows.Forms.Label();
            this.lblRespuestaHover = new System.Windows.Forms.Label();
            this.pctCopy = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsuarioRec
            // 
            this.txtUsuarioRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuarioRec.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.txtUsuarioRec.Location = new System.Drawing.Point(98, 63);
            this.txtUsuarioRec.Name = "txtUsuarioRec";
            this.txtUsuarioRec.Size = new System.Drawing.Size(302, 22);
            this.txtUsuarioRec.TabIndex = 5;
            this.txtUsuarioRec.Text = "Usuario";
            this.txtUsuarioRec.TextChanged += new System.EventHandler(this.txtUsuarioRec_TextChanged);
            this.txtUsuarioRec.Enter += new System.EventHandler(this.txtUsuarioRec_Enter);
            this.txtUsuarioRec.Leave += new System.EventHandler(this.txtUsuarioRec_Leave);
            // 
            // txtResRec
            // 
            this.txtResRec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResRec.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.txtResRec.Location = new System.Drawing.Point(95, 170);
            this.txtResRec.Name = "txtResRec";
            this.txtResRec.Size = new System.Drawing.Size(305, 22);
            this.txtResRec.TabIndex = 15;
            this.txtResRec.Text = "Respuesta";
            this.txtResRec.Visible = false;
            this.txtResRec.Enter += new System.EventHandler(this.txtResRec_Enter);
            this.txtResRec.Leave += new System.EventHandler(this.txtResRec_Leave);
            // 
            // btnRecuperar
            // 
            this.btnRecuperar.BackColor = System.Drawing.Color.Transparent;
            this.btnRecuperar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.btnRecuperar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(210)))), ((int)(((byte)(207)))));
            this.btnRecuperar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(237)))));
            this.btnRecuperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecuperar.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.btnRecuperar.ForeColor = System.Drawing.Color.Black;
            this.btnRecuperar.Location = new System.Drawing.Point(123, 217);
            this.btnRecuperar.Name = "btnRecuperar";
            this.btnRecuperar.Size = new System.Drawing.Size(260, 35);
            this.btnRecuperar.TabIndex = 7;
            this.btnRecuperar.Text = "Recuperar contraseña";
            this.btnRecuperar.UseVisualStyleBackColor = false;
            this.btnRecuperar.Visible = false;
            this.btnRecuperar.Click += new System.EventHandler(this.btnRecuperar_Click);
            // 
            // txtPassRec
            // 
            this.txtPassRec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.txtPassRec.Location = new System.Drawing.Point(146, 281);
            this.txtPassRec.Name = "txtPassRec";
            this.txtPassRec.ReadOnly = true;
            this.txtPassRec.Size = new System.Drawing.Size(203, 20);
            this.txtPassRec.TabIndex = 17;
            this.txtPassRec.Visible = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(95, 96);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(115, 13);
            this.lblUsuario.TabIndex = 19;
            this.lblUsuario.Text = "Usuario no encontrado";
            this.lblUsuario.Visible = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Enabled = false;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 98;
            this.lineShape1.X2 = 399;
            this.lineShape1.Y1 = 88;
            this.lineShape1.Y2 = 88;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(510, 313);
            this.shapeContainer1.TabIndex = 21;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Enabled = false;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.Visible = false;
            this.lineShape2.X1 = 99;
            this.lineShape2.X2 = 399;
            this.lineShape2.Y1 = 195;
            this.lineShape2.Y2 = 195;
            // 
            // lblPregRec
            // 
            this.lblPregRec.Font = new System.Drawing.Font("Malgun Gothic", 12F);
            this.lblPregRec.Location = new System.Drawing.Point(95, 122);
            this.lblPregRec.Name = "lblPregRec";
            this.lblPregRec.ReadOnly = true;
            this.lblPregRec.Size = new System.Drawing.Size(305, 29);
            this.lblPregRec.TabIndex = 22;
            this.lblPregRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblPregRec.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 36);
            this.panel1.TabIndex = 23;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lblPortapapeles
            // 
            this.lblPortapapeles.AutoSize = true;
            this.lblPortapapeles.Location = new System.Drawing.Point(157, 265);
            this.lblPortapapeles.Name = "lblPortapapeles";
            this.lblPortapapeles.Size = new System.Drawing.Size(180, 13);
            this.lblPortapapeles.TabIndex = 27;
            this.lblPortapapeles.Text = "Contraseña copiada al portapapeles!";
            this.lblPortapapeles.Visible = false;
            // 
            // lblUsuarioHover
            // 
            this.lblUsuarioHover.AutoSize = true;
            this.lblUsuarioHover.Location = new System.Drawing.Point(363, 45);
            this.lblUsuarioHover.Name = "lblUsuarioHover";
            this.lblUsuarioHover.Size = new System.Drawing.Size(108, 13);
            this.lblUsuarioHover.TabIndex = 28;
            this.lblUsuarioHover.Text = "Introduzca su usuario";
            this.lblUsuarioHover.Visible = false;
            // 
            // lblRespuestaHover
            // 
            this.lblRespuestaHover.AutoSize = true;
            this.lblRespuestaHover.Location = new System.Drawing.Point(363, 153);
            this.lblRespuestaHover.Name = "lblRespuestaHover";
            this.lblRespuestaHover.Size = new System.Drawing.Size(117, 13);
            this.lblRespuestaHover.TabIndex = 29;
            this.lblRespuestaHover.Text = "Introduzca la respuesta";
            this.lblRespuestaHover.Visible = false;
            // 
            // pctCopy
            // 
            this.pctCopy.Image = global::proyecto.Properties.Resources.copy_solid;
            this.pctCopy.Location = new System.Drawing.Point(354, 276);
            this.pctCopy.Name = "pctCopy";
            this.pctCopy.Size = new System.Drawing.Size(31, 26);
            this.pctCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctCopy.TabIndex = 26;
            this.pctCopy.TabStop = false;
            this.pctCopy.Visible = false;
            this.pctCopy.Click += new System.EventHandler(this.pctCopy_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::proyecto.Properties.Resources.key_solid;
            this.pictureBox3.Location = new System.Drawing.Point(369, 168);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.pictureBox3.MouseHover += new System.EventHandler(this.pictureBox3_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::proyecto.Properties.Resources.user_solid;
            this.pictureBox2.Location = new System.Drawing.Point(369, 61);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::proyecto.Properties.Resources.logo;
            this.pictureBox4.Location = new System.Drawing.Point(12, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.btnCerrar.Image = global::proyecto.Properties.Resources.times_solid;
            this.btnCerrar.Location = new System.Drawing.Point(480, 8);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(27, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 20;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(223)))), ((int)(((byte)(251)))));
            this.pictureBox1.Image = global::proyecto.Properties.Resources.minus_solid;
            this.pictureBox1.Location = new System.Drawing.Point(447, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(414, 8);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(27, 20);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 18;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // form_recuperar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 313);
            this.Controls.Add(this.lblRespuestaHover);
            this.Controls.Add(this.lblUsuarioHover);
            this.Controls.Add(this.lblPortapapeles);
            this.Controls.Add(this.pctCopy);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblPregRec);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtPassRec);
            this.Controls.Add(this.btnRecuperar);
            this.Controls.Add(this.txtResRec);
            this.Controls.Add(this.txtUsuarioRec);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_recuperar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_recuperar";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUsuarioRec;
        private System.Windows.Forms.TextBox txtResRec;
        private System.Windows.Forms.Button btnRecuperar;
        private System.Windows.Forms.TextBox txtPassRec;
        private System.Windows.Forms.Label lblUsuario;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.TextBox lblPregRec;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pctCopy;
        private System.Windows.Forms.Label lblPortapapeles;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblUsuarioHover;
        private System.Windows.Forms.Label lblRespuestaHover;
    }
}