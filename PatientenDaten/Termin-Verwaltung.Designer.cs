namespace PatientenDaten
{
    partial class TerminVerwaltung
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAusgabePatientenName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbAnweisungUhrzeit = new System.Windows.Forms.Label();
            this.lbZurück = new MetroFramework.Controls.MetroLabel();
            this.lbTerminErstellen = new MetroFramework.Controls.MetroLabel();
            this.txtBeschreibung = new MetroFramework.Controls.MetroTextBox();
            this.txtUhrzeit = new MetroFramework.Controls.MetroTextBox();
            this.dTPDatum = new MetroFramework.Controls.MetroDateTime();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCreateTermin = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(82, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(75, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Beschreibung:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Patient:";
            // 
            // lblAusgabePatientenName
            // 
            this.lblAusgabePatientenName.AutoSize = true;
            this.lblAusgabePatientenName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusgabePatientenName.Location = new System.Drawing.Point(77, 84);
            this.lblAusgabePatientenName.Name = "lblAusgabePatientenName";
            this.lblAusgabePatientenName.Size = new System.Drawing.Size(111, 20);
            this.lblAusgabePatientenName.TabIndex = 4;
            this.lblAusgabePatientenName.Text = "Patientename";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(82, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Uhrzeit: ";
            // 
            // LblHeader
            // 
            this.LblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblHeader.AutoSize = true;
            this.LblHeader.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LblHeader.ForeColor = System.Drawing.Color.White;
            this.LblHeader.Location = new System.Drawing.Point(48, 26);
            this.LblHeader.Name = "LblHeader";
            this.LblHeader.Size = new System.Drawing.Size(452, 60);
            this.LblHeader.TabIndex = 10;
            this.LblHeader.Text = "Termin-Verwaltung";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.lbAnweisungUhrzeit);
            this.panel1.Controls.Add(this.lbZurück);
            this.panel1.Controls.Add(this.lbTerminErstellen);
            this.panel1.Controls.Add(this.txtBeschreibung);
            this.panel1.Controls.Add(this.txtUhrzeit);
            this.panel1.Controls.Add(this.dTPDatum);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.LblHeader);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnCreateTermin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-2, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 516);
            this.panel1.TabIndex = 13;
            // 
            // lbAnweisungUhrzeit
            // 
            this.lbAnweisungUhrzeit.AutoSize = true;
            this.lbAnweisungUhrzeit.ForeColor = System.Drawing.Color.White;
            this.lbAnweisungUhrzeit.Location = new System.Drawing.Point(153, 205);
            this.lbAnweisungUhrzeit.Name = "lbAnweisungUhrzeit";
            this.lbAnweisungUhrzeit.Size = new System.Drawing.Size(76, 13);
            this.lbAnweisungUhrzeit.TabIndex = 23;
            this.lbAnweisungUhrzeit.Text = "Format: XX:YY";
            // 
            // lbZurück
            // 
            this.lbZurück.AutoSize = true;
            this.lbZurück.Location = new System.Drawing.Point(419, 412);
            this.lbZurück.Name = "lbZurück";
            this.lbZurück.Size = new System.Drawing.Size(48, 19);
            this.lbZurück.TabIndex = 22;
            this.lbZurück.Text = "Zurück";
            // 
            // lbTerminErstellen
            // 
            this.lbTerminErstellen.AutoSize = true;
            this.lbTerminErstellen.Location = new System.Drawing.Point(295, 412);
            this.lbTerminErstellen.Name = "lbTerminErstellen";
            this.lbTerminErstellen.Size = new System.Drawing.Size(100, 19);
            this.lbTerminErstellen.TabIndex = 21;
            this.lbTerminErstellen.Text = "Termin erstellen";
            // 
            // txtBeschreibung
            // 
            // 
            // 
            // 
            this.txtBeschreibung.CustomButton.Image = null;
            this.txtBeschreibung.CustomButton.Location = new System.Drawing.Point(199, 1);
            this.txtBeschreibung.CustomButton.Name = "";
            this.txtBeschreibung.CustomButton.Size = new System.Drawing.Size(135, 135);
            this.txtBeschreibung.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBeschreibung.CustomButton.TabIndex = 1;
            this.txtBeschreibung.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBeschreibung.CustomButton.UseSelectable = true;
            this.txtBeschreibung.CustomButton.Visible = false;
            this.txtBeschreibung.Lines = new string[0];
            this.txtBeschreibung.Location = new System.Drawing.Point(79, 261);
            this.txtBeschreibung.MaxLength = 32767;
            this.txtBeschreibung.Multiline = true;
            this.txtBeschreibung.Name = "txtBeschreibung";
            this.txtBeschreibung.PasswordChar = '\0';
            this.txtBeschreibung.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBeschreibung.SelectedText = "";
            this.txtBeschreibung.SelectionLength = 0;
            this.txtBeschreibung.SelectionStart = 0;
            this.txtBeschreibung.ShortcutsEnabled = true;
            this.txtBeschreibung.Size = new System.Drawing.Size(335, 137);
            this.txtBeschreibung.TabIndex = 20;
            this.txtBeschreibung.UseSelectable = true;
            this.txtBeschreibung.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBeschreibung.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtUhrzeit
            // 
            // 
            // 
            // 
            this.txtUhrzeit.CustomButton.Image = null;
            this.txtUhrzeit.CustomButton.Location = new System.Drawing.Point(64, 1);
            this.txtUhrzeit.CustomButton.Name = "";
            this.txtUhrzeit.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtUhrzeit.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUhrzeit.CustomButton.TabIndex = 1;
            this.txtUhrzeit.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUhrzeit.CustomButton.UseSelectable = true;
            this.txtUhrzeit.CustomButton.Visible = false;
            this.txtUhrzeit.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtUhrzeit.Lines = new string[0];
            this.txtUhrzeit.Location = new System.Drawing.Point(156, 162);
            this.txtUhrzeit.MaxLength = 32767;
            this.txtUhrzeit.Multiline = true;
            this.txtUhrzeit.Name = "txtUhrzeit";
            this.txtUhrzeit.PasswordChar = '\0';
            this.txtUhrzeit.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUhrzeit.SelectedText = "";
            this.txtUhrzeit.SelectionLength = 0;
            this.txtUhrzeit.SelectionStart = 0;
            this.txtUhrzeit.ShortcutsEnabled = true;
            this.txtUhrzeit.Size = new System.Drawing.Size(92, 29);
            this.txtUhrzeit.TabIndex = 19;
            this.txtUhrzeit.UseSelectable = true;
            this.txtUhrzeit.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUhrzeit.WaterMarkFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUhrzeit.Enter += new System.EventHandler(this.TxtUhrzeit_Enter);
            this.txtUhrzeit.Leave += new System.EventHandler(this.TxtUhrzeit_Leave);
            // 
            // dTPDatum
            // 
            this.dTPDatum.Location = new System.Drawing.Point(156, 109);
            this.dTPDatum.MinimumSize = new System.Drawing.Size(0, 29);
            this.dTPDatum.Name = "dTPDatum";
            this.dTPDatum.Size = new System.Drawing.Size(219, 29);
            this.dTPDatum.TabIndex = 18;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LimeGreen;
            this.panel8.Location = new System.Drawing.Point(2, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(10, 586);
            this.panel8.TabIndex = 17;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::PatientenDaten.Properties.Resources.icons8_zurück_100;
            this.btnBack.Location = new System.Drawing.Point(419, 434);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(87, 73);
            this.btnBack.TabIndex = 7;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.MouseEnter += new System.EventHandler(this.BtnBack_MouseEnter);
            this.btnBack.MouseLeave += new System.EventHandler(this.BtnBack_MouseLeave);
            // 
            // btnCreateTermin
            // 
            this.btnCreateTermin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTermin.Image = global::PatientenDaten.Properties.Resources.icons8_speichern_50;
            this.btnCreateTermin.Location = new System.Drawing.Point(295, 434);
            this.btnCreateTermin.Name = "btnCreateTermin";
            this.btnCreateTermin.Size = new System.Drawing.Size(97, 73);
            this.btnCreateTermin.TabIndex = 6;
            this.btnCreateTermin.UseVisualStyleBackColor = true;
            this.btnCreateTermin.Click += new System.EventHandler(this.btnCreateTermin_Click);
            this.btnCreateTermin.MouseEnter += new System.EventHandler(this.BtnCreateTermin_MouseEnter);
            this.btnCreateTermin.MouseLeave += new System.EventHandler(this.BtnCreateTermin_MouseLeave);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LimeGreen;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(552, 10);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // TerminVerwaltung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 538);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAusgabePatientenName);
            this.Controls.Add(this.label3);
            this.Name = "TerminVerwaltung";
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "TerminAnlegen";
            this.Load += new System.EventHandler(this.TerminVerwaltung_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAusgabePatientenName;
        private System.Windows.Forms.Button btnCreateTermin;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel8;
        private MetroFramework.Controls.MetroTextBox txtBeschreibung;
        private MetroFramework.Controls.MetroTextBox txtUhrzeit;
        private MetroFramework.Controls.MetroDateTime dTPDatum;
        private MetroFramework.Controls.MetroLabel lbZurück;
        private MetroFramework.Controls.MetroLabel lbTerminErstellen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lbAnweisungUhrzeit;
    }
}