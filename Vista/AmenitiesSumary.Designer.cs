namespace Vista
{
    partial class AmenitiesSumary
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtBoooking = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DTServiciosCabinType = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnGeneratePDF = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DTServiciosCabinType)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.Green;
            this.btnOK.Location = new System.Drawing.Point(701, 22);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 36);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtBoooking
            // 
            this.txtBoooking.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoooking.Location = new System.Drawing.Point(111, 27);
            this.txtBoooking.Name = "txtBoooking";
            this.txtBoooking.Size = new System.Drawing.Size(567, 27);
            this.txtBoooking.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Flight ID :";
            // 
            // DTServiciosCabinType
            // 
            this.DTServiciosCabinType.AllowUserToAddRows = false;
            this.DTServiciosCabinType.AllowUserToDeleteRows = false;
            this.DTServiciosCabinType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTServiciosCabinType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DTServiciosCabinType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTServiciosCabinType.Location = new System.Drawing.Point(13, 71);
            this.DTServiciosCabinType.Name = "DTServiciosCabinType";
            this.DTServiciosCabinType.ReadOnly = true;
            this.DTServiciosCabinType.Size = new System.Drawing.Size(775, 312);
            this.DTServiciosCabinType.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(432, 402);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(190, 36);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnGeneratePDF
            // 
            this.btnGeneratePDF.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGeneratePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneratePDF.ForeColor = System.Drawing.Color.Green;
            this.btnGeneratePDF.Location = new System.Drawing.Point(232, 402);
            this.btnGeneratePDF.Name = "btnGeneratePDF";
            this.btnGeneratePDF.Size = new System.Drawing.Size(185, 36);
            this.btnGeneratePDF.TabIndex = 6;
            this.btnGeneratePDF.Text = "Generate Report";
            this.btnGeneratePDF.UseVisualStyleBackColor = true;
            this.btnGeneratePDF.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // saveFile
            // 
            this.saveFile.Filter = "File PDF|*.pdf";
            // 
            // AmenitiesSumary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DTServiciosCabinType);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGeneratePDF);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBoooking);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AmenitiesSumary";
            this.Text = "AmenitiesSumary";
            this.Load += new System.EventHandler(this.AmenitiesSumary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DTServiciosCabinType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtBoooking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DTServiciosCabinType;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnGeneratePDF;
        private System.Windows.Forms.SaveFileDialog saveFile;
    }
}