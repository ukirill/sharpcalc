namespace CalcGUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.lResult = new System.Windows.Forms.Label();
            this.cbOper = new System.Windows.Forms.ComboBox();
            this.panTwoArgs = new System.Windows.Forms.FlowLayoutPanel();
            this.panMoreArgs = new System.Windows.Forms.Panel();
            this.tbMore = new System.Windows.Forms.RichTextBox();
            this.panTwoArgs.SuspendLayout();
            this.panMoreArgs.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(446, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Вычислить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(3, 3);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(66, 20);
            this.tbX.TabIndex = 1;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(75, 3);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(63, 20);
            this.tbY.TabIndex = 2;
            // 
            // lResult
            // 
            this.lResult.AutoSize = true;
            this.lResult.Location = new System.Drawing.Point(16, 238);
            this.lResult.Name = "lResult";
            this.lResult.Size = new System.Drawing.Size(59, 13);
            this.lResult.TabIndex = 4;
            this.lResult.Text = "Результат";
            // 
            // cbOper
            // 
            this.cbOper.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOper.FormattingEnabled = true;
            this.cbOper.Location = new System.Drawing.Point(19, 12);
            this.cbOper.Name = "cbOper";
            this.cbOper.Size = new System.Drawing.Size(135, 21);
            this.cbOper.TabIndex = 5;
            this.cbOper.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbOper_DrawItem);
            this.cbOper.SelectedIndexChanged += new System.EventHandler(this.cbOper_SelectedIndexChanged);
            // 
            // panTwoArgs
            // 
            this.panTwoArgs.Controls.Add(this.tbX);
            this.panTwoArgs.Controls.Add(this.tbY);
            this.panTwoArgs.Location = new System.Drawing.Point(16, 55);
            this.panTwoArgs.Name = "panTwoArgs";
            this.panTwoArgs.Size = new System.Drawing.Size(165, 136);
            this.panTwoArgs.TabIndex = 6;
            // 
            // panMoreArgs
            // 
            this.panMoreArgs.Controls.Add(this.tbMore);
            this.panMoreArgs.Location = new System.Drawing.Point(237, 55);
            this.panMoreArgs.Name = "panMoreArgs";
            this.panMoreArgs.Size = new System.Drawing.Size(200, 136);
            this.panMoreArgs.TabIndex = 7;
            // 
            // tbMore
            // 
            this.tbMore.Location = new System.Drawing.Point(3, 0);
            this.tbMore.Name = "tbMore";
            this.tbMore.Size = new System.Drawing.Size(194, 96);
            this.tbMore.TabIndex = 0;
            this.tbMore.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 342);
            this.Controls.Add(this.panMoreArgs);
            this.Controls.Add(this.panTwoArgs);
            this.Controls.Add(this.cbOper);
            this.Controls.Add(this.lResult);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panTwoArgs.ResumeLayout(false);
            this.panTwoArgs.PerformLayout();
            this.panMoreArgs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label lResult;
        private System.Windows.Forms.ComboBox cbOper;
        private System.Windows.Forms.FlowLayoutPanel panTwoArgs;
        private System.Windows.Forms.Panel panMoreArgs;
        private System.Windows.Forms.RichTextBox tbMore;
    }
}

