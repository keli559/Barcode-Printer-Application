namespace ZebraBarPrintApp
{
    partial class FormMysql
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMysql));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RetailTextBox = new System.Windows.Forms.TextBox();
            this.StockTextBox = new System.Windows.Forms.TextBox();
            this.BarcodeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ItemTextBox = new System.Windows.Forms.TextBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PrintReviewButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BarcodeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CopiesComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BarcodePrintPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.BarcodePrintDocument = new System.Drawing.Printing.PrintDocument();
            this.ZplCodeTextBox = new System.Windows.Forms.TextBox();
            this.AreaComboBox = new System.Windows.Forms.ComboBox();
            this.ItemTextBoxToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 93);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(479, 278);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RetailTextBox
            // 
            this.RetailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetailTextBox.Location = new System.Drawing.Point(142, 430);
            this.RetailTextBox.Name = "RetailTextBox";
            this.RetailTextBox.ReadOnly = true;
            this.RetailTextBox.Size = new System.Drawing.Size(156, 26);
            this.RetailTextBox.TabIndex = 3;
            // 
            // StockTextBox
            // 
            this.StockTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockTextBox.Location = new System.Drawing.Point(142, 468);
            this.StockTextBox.Name = "StockTextBox";
            this.StockTextBox.ReadOnly = true;
            this.StockTextBox.Size = new System.Drawing.Size(156, 26);
            this.StockTextBox.TabIndex = 4;
            // 
            // BarcodeTextBox
            // 
            this.BarcodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarcodeTextBox.Location = new System.Drawing.Point(142, 506);
            this.BarcodeTextBox.Name = "BarcodeTextBox";
            this.BarcodeTextBox.Size = new System.Drawing.Size(156, 26);
            this.BarcodeTextBox.TabIndex = 5;
            this.BarcodeTextBox.TextChanged += new System.EventHandler(this.BarCodeTextBox_TextChanged);
            this.BarcodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarCodeTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Item:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Retail: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(58, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Bar Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(58, 471);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Stock:";
            // 
            // ItemTextBox
            // 
            this.ItemTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemTextBox.Location = new System.Drawing.Point(142, 392);
            this.ItemTextBox.Name = "ItemTextBox";
            this.ItemTextBox.Size = new System.Drawing.Size(156, 26);
            this.ItemTextBox.TabIndex = 11;
            this.ItemTextBoxToolTip.SetToolTip(this.ItemTextBox, "Enter text to search.");
            this.ItemTextBox.TextChanged += new System.EventHandler(this.ItemTextBox_TextChanged);
            this.ItemTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemTextBox_KeyDown);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.Image = global::ZebraBarPrintApp.Properties.Resources.system_exit;
            this.ExitButton.Location = new System.Drawing.Point(376, 560);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(125, 67);
            this.ExitButton.TabIndex = 14;
            this.ExitButton.Text = "Exit";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PrintReviewButton
            // 
            this.PrintReviewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintReviewButton.Image = global::ZebraBarPrintApp.Properties.Resources.Print_Preview_icon_1106065314;
            this.PrintReviewButton.Location = new System.Drawing.Point(376, 393);
            this.PrintReviewButton.Name = "PrintReviewButton";
            this.PrintReviewButton.Size = new System.Drawing.Size(125, 67);
            this.PrintReviewButton.TabIndex = 13;
            this.PrintReviewButton.Text = "Print Review";
            this.PrintReviewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PrintReviewButton.UseVisualStyleBackColor = true;
            this.PrintReviewButton.Click += new System.EventHandler(this.PrintReviewButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrintButton.Image = global::ZebraBarPrintApp.Properties.Resources.print;
            this.PrintButton.Location = new System.Drawing.Point(376, 475);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(125, 67);
            this.PrintButton.TabIndex = 12;
            this.PrintButton.Text = "Print";
            this.PrintButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 539);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Bar Code Type";
            // 
            // BarcodeTypeComboBox
            // 
            this.BarcodeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BarcodeTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarcodeTypeComboBox.FormattingEnabled = true;
            this.BarcodeTypeComboBox.Items.AddRange(new object[] {
            "",
            "Aztec Code",
            "Code 39",
            "Code 128",
            "Code 128 | 1/2\" x 2-1/4\"",
            "Codabar",
            "U.P.C"});
            this.BarcodeTypeComboBox.Location = new System.Drawing.Point(62, 565);
            this.BarcodeTypeComboBox.Name = "BarcodeTypeComboBox";
            this.BarcodeTypeComboBox.Size = new System.Drawing.Size(236, 28);
            this.BarcodeTypeComboBox.TabIndex = 17;
            this.BarcodeTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.BarCodeTypeComboBox_SelectedIndexChanged);
            // 
            // CopiesComboBox
            // 
            this.CopiesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopiesComboBox.FormattingEnabled = true;
            this.CopiesComboBox.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.CopiesComboBox.Location = new System.Drawing.Point(179, 601);
            this.CopiesComboBox.Name = "CopiesComboBox";
            this.CopiesComboBox.Size = new System.Drawing.Size(119, 28);
            this.CopiesComboBox.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 604);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Copies";
            // 
            // stockBindingSource
            // 
            this.stockBindingSource.CurrentChanged += new System.EventHandler(this.stockBindingSource_CurrentChanged);
            // 
            // BarcodePrintPreviewDialog
            // 
            this.BarcodePrintPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.BarcodePrintPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.BarcodePrintPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.BarcodePrintPreviewDialog.Enabled = true;
            this.BarcodePrintPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("BarcodePrintPreviewDialog.Icon")));
            this.BarcodePrintPreviewDialog.Name = "BarcodePrintPreviewDialog";
            this.BarcodePrintPreviewDialog.Visible = false;
            // 
            // ZplCodeTextBox
            // 
            this.ZplCodeTextBox.Location = new System.Drawing.Point(534, 93);
            this.ZplCodeTextBox.Multiline = true;
            this.ZplCodeTextBox.Name = "ZplCodeTextBox";
            this.ZplCodeTextBox.ReadOnly = true;
            this.ZplCodeTextBox.Size = new System.Drawing.Size(225, 534);
            this.ZplCodeTextBox.TabIndex = 20;
            this.ZplCodeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // AreaComboBox
            // 
            this.AreaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AreaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AreaComboBox.FormattingEnabled = true;
            this.AreaComboBox.Location = new System.Drawing.Point(289, 29);
            this.AreaComboBox.Name = "AreaComboBox";
            this.AreaComboBox.Size = new System.Drawing.Size(210, 28);
            this.AreaComboBox.TabIndex = 21;
            this.AreaComboBox.SelectedIndexChanged += new System.EventHandler(this.AreaComboBox_SelectedIndexChanged);
            // 
            // ItemTextBoxToolTip
            // 
            this.ItemTextBoxToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.ItemTextBoxToolTip_Popup);
            // 
            // FormMysql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 657);
            this.Controls.Add(this.AreaComboBox);
            this.Controls.Add(this.ZplCodeTextBox);
            this.Controls.Add(this.CopiesComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BarcodeTypeComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PrintReviewButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.ItemTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BarcodeTextBox);
            this.Controls.Add(this.StockTextBox);
            this.Controls.Add(this.RetailTextBox);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMysql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMysql";
            this.Load += new System.EventHandler(this.FormMysql_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox RetailTextBox;
        private System.Windows.Forms.TextBox StockTextBox;
        private System.Windows.Forms.TextBox BarcodeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ItemTextBox;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button PrintReviewButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox BarcodeTypeComboBox;
        private System.Windows.Forms.ComboBox CopiesComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource stockBindingSource;
        private System.Windows.Forms.PrintPreviewDialog BarcodePrintPreviewDialog;
        private System.Drawing.Printing.PrintDocument BarcodePrintDocument;
        private System.Windows.Forms.TextBox ZplCodeTextBox;
        private System.Windows.Forms.ComboBox AreaComboBox;
        private System.Windows.Forms.ToolTip ItemTextBoxToolTip;
    }
}

