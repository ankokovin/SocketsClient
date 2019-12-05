namespace Sockets
{
    partial class frmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.cbServerIp = new System.Windows.Forms.ComboBox();
            this.bLoadServerList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(260, 90);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 26);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(72, 94);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(181, 20);
            this.tbMessage.TabIndex = 1;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 13);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(70, 26);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "Выберите IP\r\nсервера";
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(263, 53);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(91, 29);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(4, 97);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Сообщение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите \r\nникнейм";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(75, 53);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(181, 20);
            this.tbName.TabIndex = 0;
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(7, 120);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.Size = new System.Drawing.Size(344, 194);
            this.rtbMessages.TabIndex = 4;
            this.rtbMessages.Text = "";
            // 
            // cbServerIp
            // 
            this.cbServerIp.FormattingEnabled = true;
            this.cbServerIp.Location = new System.Drawing.Point(88, 13);
            this.cbServerIp.Name = "cbServerIp";
            this.cbServerIp.Size = new System.Drawing.Size(165, 21);
            this.cbServerIp.TabIndex = 5;
            // 
            // bLoadServerList
            // 
            this.bLoadServerList.Location = new System.Drawing.Point(263, 13);
            this.bLoadServerList.Name = "bLoadServerList";
            this.bLoadServerList.Size = new System.Drawing.Size(88, 26);
            this.bLoadServerList.TabIndex = 6;
            this.bLoadServerList.Text = "Загрузить список";
            this.bLoadServerList.UseVisualStyleBackColor = true;
            this.bLoadServerList.Click += new System.EventHandler(this.bLoadServerList_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 326);
            this.Controls.Add(this.bLoadServerList);
            this.Controls.Add(this.cbServerIp);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.ComboBox cbServerIp;
        private System.Windows.Forms.Button bLoadServerList;
    }
}

