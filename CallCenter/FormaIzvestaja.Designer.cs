namespace CallCenter
{
    partial class FormaIzvestaja
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
            this.button1 = new System.Windows.Forms.Button();
            this.GridViewIzvestaja = new System.Windows.Forms.DataGridView();
            this.ProsecnoVreme = new System.Windows.Forms.Label();
            this.ProsecnoVremeValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIzvestaja)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(430, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Zatvori izvestaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GridViewIzvestaja
            // 
            this.GridViewIzvestaja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewIzvestaja.Location = new System.Drawing.Point(12, 12);
            this.GridViewIzvestaja.Name = "GridViewIzvestaja";
            this.GridViewIzvestaja.Size = new System.Drawing.Size(574, 362);
            this.GridViewIzvestaja.TabIndex = 1;
            // 
            // ProsecnoVreme
            // 
            this.ProsecnoVreme.AutoSize = true;
            this.ProsecnoVreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProsecnoVreme.Location = new System.Drawing.Point(9, 394);
            this.ProsecnoVreme.Name = "ProsecnoVreme";
            this.ProsecnoVreme.Size = new System.Drawing.Size(293, 18);
            this.ProsecnoVreme.TabIndex = 2;
            this.ProsecnoVreme.Text = "Prosecno radno vreme resavanja problema";
            // 
            // ProsecnoVremeValue
            // 
            this.ProsecnoVremeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProsecnoVremeValue.Location = new System.Drawing.Point(308, 391);
            this.ProsecnoVremeValue.Name = "ProsecnoVremeValue";
            this.ProsecnoVremeValue.ReadOnly = true;
            this.ProsecnoVremeValue.Size = new System.Drawing.Size(100, 24);
            this.ProsecnoVremeValue.TabIndex = 3;
            // 
            // FormaIzvestaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 478);
            this.Controls.Add(this.ProsecnoVremeValue);
            this.Controls.Add(this.ProsecnoVreme);
            this.Controls.Add(this.GridViewIzvestaja);
            this.Controls.Add(this.button1);
            this.Name = "FormaIzvestaja";
            this.Text = "FormaIzvestaja";
            ((System.ComponentModel.ISupportInitialize)(this.GridViewIzvestaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView GridViewIzvestaja;
        private System.Windows.Forms.Label ProsecnoVreme;
        private System.Windows.Forms.TextBox ProsecnoVremeValue;
    }
}