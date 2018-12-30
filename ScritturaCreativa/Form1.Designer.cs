namespace Esecutore
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.Esegui = new System.Windows.Forms.Button();
            this.argomento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.risultato = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lunghezza = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.fonti = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.lunghezza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fonti)).BeginInit();
            this.SuspendLayout();
            // 
            // Esegui
            // 
            this.Esegui.Location = new System.Drawing.Point(12, 35);
            this.Esegui.Name = "Esegui";
            this.Esegui.Size = new System.Drawing.Size(98, 30);
            this.Esegui.TabIndex = 0;
            this.Esegui.Text = "Esegui";
            this.Esegui.UseVisualStyleBackColor = true;
            this.Esegui.Click += new System.EventHandler(this.Esegui_Click);
            // 
            // argomento
            // 
            this.argomento.Location = new System.Drawing.Point(99, 12);
            this.argomento.Name = "argomento";
            this.argomento.Size = new System.Drawing.Size(132, 22);
            this.argomento.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Argomento:";
            // 
            // risultato
            // 
            this.risultato.Location = new System.Drawing.Point(15, 89);
            this.risultato.Multiline = true;
            this.risultato.Name = "risultato";
            this.risultato.Size = new System.Drawing.Size(680, 594);
            this.risultato.TabIndex = 3;
            this.risultato.MouseClick += new System.Windows.Forms.MouseEventHandler(this.risultato_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lunghezza:";
            // 
            // lunghezza
            // 
            this.lunghezza.Location = new System.Drawing.Point(351, 13);
            this.lunghezza.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lunghezza.Name = "lunghezza";
            this.lunghezza.Size = new System.Drawing.Size(120, 22);
            this.lunghezza.TabIndex = 5;
            this.lunghezza.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fonti:";
            // 
            // fonti
            // 
            this.fonti.Location = new System.Drawing.Point(527, 13);
            this.fonti.Name = "fonti";
            this.fonti.Size = new System.Drawing.Size(120, 22);
            this.fonti.TabIndex = 7;
            this.fonti.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 651);
            this.Controls.Add(this.fonti);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lunghezza);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.risultato);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.argomento);
            this.Controls.Add(this.Esegui);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lunghezza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fonti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Esegui;
        private System.Windows.Forms.TextBox argomento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox risultato;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown lunghezza;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown fonti;
    }
}

