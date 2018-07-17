namespace InnovativeTool
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.checkedListBoxOrder = new System.Windows.Forms.CheckedListBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxOrderInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(56, 46);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "button1";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // checkedListBoxOrder
            // 
            this.checkedListBoxOrder.CheckOnClick = true;
            this.checkedListBoxOrder.FormattingEnabled = true;
            this.checkedListBoxOrder.Location = new System.Drawing.Point(34, 133);
            this.checkedListBoxOrder.Name = "checkedListBoxOrder";
            this.checkedListBoxOrder.Size = new System.Drawing.Size(178, 184);
            this.checkedListBoxOrder.TabIndex = 1;
            this.checkedListBoxOrder.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxOrder_SelectedIndexChanged);
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(69, 356);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 3;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(13, 408);
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(725, 20);
            this.textBoxLog.TabIndex = 4;
            // 
            // textBoxOrderInfo
            // 
            this.textBoxOrderInfo.Location = new System.Drawing.Point(258, 133);
            this.textBoxOrderInfo.Multiline = true;
            this.textBoxOrderInfo.Name = "textBoxOrderInfo";
            this.textBoxOrderInfo.ReadOnly = true;
            this.textBoxOrderInfo.Size = new System.Drawing.Size(234, 184);
            this.textBoxOrderInfo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Order list";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOrderInfo);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.checkedListBoxOrder);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Form1";
            this.Text = "InnovativeTool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.CheckedListBox checkedListBoxOrder;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxOrderInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

