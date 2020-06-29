namespace projetTetris
{
    partial class formLaunch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLaunch));
            this.lblNomJoueur = new System.Windows.Forms.Label();
            this.txtBoxInputJoueur = new System.Windows.Forms.TextBox();
            this.btnJoueurInputNom = new System.Windows.Forms.Button();
            this.checkBoxDifficile = new System.Windows.Forms.CheckBox();
            this.checkBoxFacile = new System.Windows.Forms.CheckBox();
            this.checkBoxMoyen = new System.Windows.Forms.CheckBox();
            this.checkBoxMusique = new System.Windows.Forms.CheckBox();
            this.checkBoxSoftColor = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNomJoueur
            // 
            this.lblNomJoueur.AutoSize = true;
            this.lblNomJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomJoueur.Location = new System.Drawing.Point(71, 47);
            this.lblNomJoueur.Name = "lblNomJoueur";
            this.lblNomJoueur.Size = new System.Drawing.Size(138, 20);
            this.lblNomJoueur.TabIndex = 0;
            this.lblNomJoueur.Text = "Entrez votre nom !";
            // 
            // txtBoxInputJoueur
            // 
            this.txtBoxInputJoueur.Location = new System.Drawing.Point(88, 88);
            this.txtBoxInputJoueur.MaxLength = 30;
            this.txtBoxInputJoueur.Name = "txtBoxInputJoueur";
            this.txtBoxInputJoueur.Size = new System.Drawing.Size(100, 20);
            this.txtBoxInputJoueur.TabIndex = 1;
            this.txtBoxInputJoueur.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputUser);
            // 
            // btnJoueurInputNom
            // 
            this.btnJoueurInputNom.Location = new System.Drawing.Point(97, 131);
            this.btnJoueurInputNom.Name = "btnJoueurInputNom";
            this.btnJoueurInputNom.Size = new System.Drawing.Size(78, 31);
            this.btnJoueurInputNom.TabIndex = 2;
            this.btnJoueurInputNom.Text = "Jouer !";
            this.btnJoueurInputNom.UseVisualStyleBackColor = true;
            this.btnJoueurInputNom.Click += new System.EventHandler(this.btnJoueurInputNom_Click);
            // 
            // checkBoxDifficile
            // 
            this.checkBoxDifficile.AutoSize = true;
            this.checkBoxDifficile.Location = new System.Drawing.Point(108, 226);
            this.checkBoxDifficile.Name = "checkBoxDifficile";
            this.checkBoxDifficile.Size = new System.Drawing.Size(60, 17);
            this.checkBoxDifficile.TabIndex = 5;
            this.checkBoxDifficile.Text = "Difficile";
            this.checkBoxDifficile.UseVisualStyleBackColor = true;
            this.checkBoxDifficile.CheckedChanged += new System.EventHandler(this.checkBoxDifficile_CheckedChanged);
            this.checkBoxDifficile.Click += new System.EventHandler(this.checkBoxChangeCheck);
            // 
            // checkBoxFacile
            // 
            this.checkBoxFacile.AutoSize = true;
            this.checkBoxFacile.Location = new System.Drawing.Point(108, 180);
            this.checkBoxFacile.Name = "checkBoxFacile";
            this.checkBoxFacile.Size = new System.Drawing.Size(54, 17);
            this.checkBoxFacile.TabIndex = 5;
            this.checkBoxFacile.Text = "Facile";
            this.checkBoxFacile.UseVisualStyleBackColor = true;
            this.checkBoxFacile.CheckedChanged += new System.EventHandler(this.checkBoxFacile_CheckedChanged);
            this.checkBoxFacile.Click += new System.EventHandler(this.checkBoxChangeCheck);
            // 
            // checkBoxMoyen
            // 
            this.checkBoxMoyen.AutoSize = true;
            this.checkBoxMoyen.Checked = true;
            this.checkBoxMoyen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMoyen.Location = new System.Drawing.Point(108, 203);
            this.checkBoxMoyen.Name = "checkBoxMoyen";
            this.checkBoxMoyen.Size = new System.Drawing.Size(58, 17);
            this.checkBoxMoyen.TabIndex = 6;
            this.checkBoxMoyen.Text = "Moyen";
            this.checkBoxMoyen.UseVisualStyleBackColor = true;
            this.checkBoxMoyen.CheckedChanged += new System.EventHandler(this.checkBoxMoyen_CheckedChanged);
            this.checkBoxMoyen.Click += new System.EventHandler(this.checkBoxChangeCheck);
            // 
            // checkBoxMusique
            // 
            this.checkBoxMusique.AutoSize = true;
            this.checkBoxMusique.Location = new System.Drawing.Point(108, 249);
            this.checkBoxMusique.Name = "checkBoxMusique";
            this.checkBoxMusique.Size = new System.Drawing.Size(66, 17);
            this.checkBoxMusique.TabIndex = 7;
            this.checkBoxMusique.Text = "Musique";
            this.checkBoxMusique.UseVisualStyleBackColor = true;
            this.checkBoxMusique.CheckedChanged += new System.EventHandler(this.checkBoxMusique_CheckedChanged);
            // 
            // checkBoxSoftColor
            // 
            this.checkBoxSoftColor.AutoSize = true;
            this.checkBoxSoftColor.Checked = true;
            this.checkBoxSoftColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSoftColor.Location = new System.Drawing.Point(108, 272);
            this.checkBoxSoftColor.Name = "checkBoxSoftColor";
            this.checkBoxSoftColor.Size = new System.Drawing.Size(102, 17);
            this.checkBoxSoftColor.TabIndex = 8;
            this.checkBoxSoftColor.Text = "Couleur Douces";
            this.checkBoxSoftColor.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(97, 319);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(78, 31);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Aide";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // formLaunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.checkBoxSoftColor);
            this.Controls.Add(this.checkBoxMusique);
            this.Controls.Add(this.checkBoxMoyen);
            this.Controls.Add(this.checkBoxFacile);
            this.Controls.Add(this.checkBoxDifficile);
            this.Controls.Add(this.btnJoueurInputNom);
            this.Controls.Add(this.txtBoxInputJoueur);
            this.Controls.Add(this.lblNomJoueur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formLaunch";
            this.Text = "Tetris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomJoueur;
        private System.Windows.Forms.TextBox txtBoxInputJoueur;
        private System.Windows.Forms.Button btnJoueurInputNom;
        private System.Windows.Forms.CheckBox checkBoxDifficile;
        private System.Windows.Forms.CheckBox checkBoxFacile;
        private System.Windows.Forms.CheckBox checkBoxMoyen;
        private System.Windows.Forms.CheckBox checkBoxMusique;
        private System.Windows.Forms.CheckBox checkBoxSoftColor;
        private System.Windows.Forms.Button btnHelp;
    }
}