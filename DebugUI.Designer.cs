namespace Lead.Tool.SktClient
{
    partial class DebugUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.richTextBoxRecive = new System.Windows.Forms.RichTextBox();
            this.richTextBoxSend = new System.Windows.Forms.RichTextBox();
            this.发送 = new System.Windows.Forms.Label();
            this.接收 = new System.Windows.Forms.Label();
            this.ButtonInit = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonTerminate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // richTextBoxRecive
            // 
            this.richTextBoxRecive.Location = new System.Drawing.Point(636, 150);
            this.richTextBoxRecive.Name = "richTextBoxRecive";
            this.richTextBoxRecive.Size = new System.Drawing.Size(439, 330);
            this.richTextBoxRecive.TabIndex = 4;
            this.richTextBoxRecive.Text = "";
            // 
            // richTextBoxSend
            // 
            this.richTextBoxSend.Location = new System.Drawing.Point(32, 150);
            this.richTextBoxSend.Name = "richTextBoxSend";
            this.richTextBoxSend.Size = new System.Drawing.Size(425, 327);
            this.richTextBoxSend.TabIndex = 5;
            this.richTextBoxSend.Text = "";
            // 
            // 发送
            // 
            this.发送.AutoSize = true;
            this.发送.Location = new System.Drawing.Point(68, 132);
            this.发送.Name = "发送";
            this.发送.Size = new System.Drawing.Size(37, 15);
            this.发送.TabIndex = 6;
            this.发送.Text = "发送";
            // 
            // 接收
            // 
            this.接收.AutoSize = true;
            this.接收.Location = new System.Drawing.Point(660, 132);
            this.接收.Name = "接收";
            this.接收.Size = new System.Drawing.Size(37, 15);
            this.接收.TabIndex = 7;
            this.接收.Text = "接收";
            // 
            // ButtonInit
            // 
            this.ButtonInit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonInit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonInit.Location = new System.Drawing.Point(258, 36);
            this.ButtonInit.Name = "ButtonInit";
            this.ButtonInit.Size = new System.Drawing.Size(122, 46);
            this.ButtonInit.TabIndex = 14;
            this.ButtonInit.Text = "初始化";
            this.ButtonInit.UseVisualStyleBackColor = true;
            this.ButtonInit.Click += new System.EventHandler(this.ButtonInit_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStart.Location = new System.Drawing.Point(501, 36);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(122, 46);
            this.buttonStart.TabIndex = 13;
            this.buttonStart.Text = "启动";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonTerminate
            // 
            this.buttonTerminate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTerminate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTerminate.Location = new System.Drawing.Point(770, 36);
            this.buttonTerminate.Name = "buttonTerminate";
            this.buttonTerminate.Size = new System.Drawing.Size(112, 46);
            this.buttonTerminate.TabIndex = 12;
            this.buttonTerminate.Text = "终止";
            this.buttonTerminate.UseVisualStyleBackColor = true;
            this.buttonTerminate.Click += new System.EventHandler(this.buttonTerminate_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(481, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "发送";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DebugUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonInit);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonTerminate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.接收);
            this.Controls.Add(this.发送);
            this.Controls.Add(this.richTextBoxSend);
            this.Controls.Add(this.richTextBoxRecive);
            this.Name = "DebugUI";
            this.Size = new System.Drawing.Size(1107, 585);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RichTextBox richTextBoxRecive;
        private System.Windows.Forms.RichTextBox richTextBoxSend;
        private System.Windows.Forms.Label 发送;
        private System.Windows.Forms.Label 接收;
        private System.Windows.Forms.Button ButtonInit;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonTerminate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
