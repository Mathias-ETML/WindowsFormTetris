namespace projetTetris
{
    partial class formJeu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            projetTetris.VariablesPrincipales.g_boolStopThread = true;

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            Invoke(new System.Action(() => base.Dispose(disposing)));
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formJeu));
            this.lblNomJoueur = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblLignes = new System.Windows.Forms.Label();
            this.panZoneJeu = new System.Windows.Forms.Panel();
            this.panNextFigure = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblNomJoueur
            // 
            this.lblNomJoueur.AutoSize = true;
            this.lblNomJoueur.Location = new System.Drawing.Point(12, 9);
            this.lblNomJoueur.Name = "lblNomJoueur";
            this.lblNomJoueur.Size = new System.Drawing.Size(64, 13);
            this.lblNomJoueur.TabIndex = 0;
            this.lblNomJoueur.Text = "PlayerName";
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Location = new System.Drawing.Point(569, 74);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(35, 13);
            this.lblPlayerScore.TabIndex = 3;
            this.lblPlayerScore.Text = "Score";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(569, 9);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(33, 13);
            this.lblLevel.TabIndex = 4;
            this.lblLevel.Text = "Level";
            // 
            // lblLignes
            // 
            this.lblLignes.AutoSize = true;
            this.lblLignes.Location = new System.Drawing.Point(569, 146);
            this.lblLignes.Name = "lblLignes";
            this.lblLignes.Size = new System.Drawing.Size(38, 13);
            this.lblLignes.TabIndex = 5;
            this.lblLignes.Text = "Lignes";
            // 
            // panZoneJeu
            // 
            this.panZoneJeu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panZoneJeu.Location = new System.Drawing.Point(148, 9);
            this.panZoneJeu.Name = "panZoneJeu";
            this.panZoneJeu.Size = new System.Drawing.Size(300, 540);
            this.panZoneJeu.TabIndex = 6;
            // 
            // panNextFigure
            // 
            this.panNextFigure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panNextFigure.Location = new System.Drawing.Point(489, 207);
            this.panNextFigure.Name = "panNextFigure";
            this.panNextFigure.Size = new System.Drawing.Size(150, 150);
            this.panNextFigure.TabIndex = 7;
            // 
            // formJeu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 625);
            this.Controls.Add(this.panNextFigure);
            this.Controls.Add(this.lblLignes);
            this.Controls.Add(this.panZoneJeu);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.lblNomJoueur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formJeu";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputUser);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.stopInputUser);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomJoueur;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLignes;
        private System.Windows.Forms.Panel panZoneJeu;
        private System.Windows.Forms.Panel panNextFigure;
    }
}

