namespace projetTetris
{
    partial class formFin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFin));
            this.lblPlayerLost = new System.Windows.Forms.Label();
            this.lblNomJoueur = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblNbrLignes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLvlJoueur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayerLost
            // 
            this.lblPlayerLost.AutoSize = true;
            this.lblPlayerLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerLost.Location = new System.Drawing.Point(71, 31);
            this.lblPlayerLost.Name = "lblPlayerLost";
            this.lblPlayerLost.Size = new System.Drawing.Size(136, 20);
            this.lblPlayerLost.TabIndex = 0;
            this.lblPlayerLost.Text = "Vous avez perdu !";
            // 
            // lblNomJoueur
            // 
            this.lblNomJoueur.AutoSize = true;
            this.lblNomJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomJoueur.Location = new System.Drawing.Point(72, 73);
            this.lblNomJoueur.Name = "lblNomJoueur";
            this.lblNomJoueur.Size = new System.Drawing.Size(49, 17);
            this.lblNomJoueur.TabIndex = 1;
            this.lblNomJoueur.Text = "Nom : ";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(72, 160);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(57, 17);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Score : ";
            // 
            // lblNbrLignes
            // 
            this.lblNbrLignes.AutoSize = true;
            this.lblNbrLignes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbrLignes.Location = new System.Drawing.Point(72, 200);
            this.lblNbrLignes.Name = "lblNbrLignes";
            this.lblNbrLignes.Size = new System.Drawing.Size(62, 17);
            this.lblNbrLignes.TabIndex = 3;
            this.lblNbrLignes.Text = "Lignes : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vous avez perdu !";
            // 
            // lblLvlJoueur
            // 
            this.lblLvlJoueur.AutoSize = true;
            this.lblLvlJoueur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLvlJoueur.Location = new System.Drawing.Point(72, 118);
            this.lblLvlJoueur.Name = "lblLvlJoueur";
            this.lblLvlJoueur.Size = new System.Drawing.Size(64, 17);
            this.lblLvlJoueur.TabIndex = 4;
            this.lblLvlJoueur.Text = "Niveau : ";
            // 
            // formFin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblLvlJoueur);
            this.Controls.Add(this.lblNbrLignes);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblNomJoueur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlayerLost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formFin";
            this.Text = "Vous avez perdu !";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerLost;
        private System.Windows.Forms.Label lblNomJoueur;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblNbrLignes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLvlJoueur;
    }
}