namespace GetProject2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLocalhost = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.dgvVeriTabani = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriTabani)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLocalhost
            // 
            this.btnLocalhost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLocalhost.Location = new System.Drawing.Point(514, 318);
            this.btnLocalhost.Name = "btnLocalhost";
            this.btnLocalhost.Size = new System.Drawing.Size(200, 64);
            this.btnLocalhost.TabIndex = 2;
            this.btnLocalhost.Text = "Ses Kayıt Sayfası";
            this.btnLocalhost.UseVisualStyleBackColor = true;
            this.btnLocalhost.Click += new System.EventHandler(this.btnLocalhost_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(754, 318);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(200, 64);
            this.btnKaydet.TabIndex = 3;
            this.btnKaydet.Text = "Veri Tabanına Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // dgvVeriTabani
            // 
            this.dgvVeriTabani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVeriTabani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVeriTabani.Location = new System.Drawing.Point(0, 0);
            this.dgvVeriTabani.Name = "dgvVeriTabani";
            this.dgvVeriTabani.RowTemplate.Height = 24;
            this.dgvVeriTabani.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVeriTabani.Size = new System.Drawing.Size(1000, 300);
            this.dgvVeriTabani.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvVeriTabani);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 300);
            this.panel1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 395);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnLocalhost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Json Data Grid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVeriTabani)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLocalhost;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.DataGridView dgvVeriTabani;
        private System.Windows.Forms.Panel panel1;
    }
}

