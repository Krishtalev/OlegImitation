namespace ImitationOleg
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
            this.arrivalParamInput = new System.Windows.Forms.NumericUpDown();
            this.serviceParamInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SimulateButton = new System.Windows.Forms.Button();
            this.breakParamInput = new System.Windows.Forms.NumericUpDown();
            this.repairParamInput = new System.Windows.Forms.NumericUpDown();
            this.waitParamInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalParamInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceParamInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakParamInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairParamInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitParamInput)).BeginInit();
            this.SuspendLayout();
            // 
            // arrivalParamInput
            // 
            this.arrivalParamInput.DecimalPlaces = 2;
            this.arrivalParamInput.Location = new System.Drawing.Point(123, 72);
            this.arrivalParamInput.Name = "arrivalParamInput";
            this.arrivalParamInput.Size = new System.Drawing.Size(120, 22);
            this.arrivalParamInput.TabIndex = 0;
            this.arrivalParamInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // serviceParamInput
            // 
            this.serviceParamInput.DecimalPlaces = 2;
            this.serviceParamInput.Location = new System.Drawing.Point(123, 114);
            this.serviceParamInput.Name = "serviceParamInput";
            this.serviceParamInput.Size = new System.Drawing.Size(120, 22);
            this.serviceParamInput.TabIndex = 1;
            this.serviceParamInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "lambda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "mu";
            // 
            // SimulateButton
            // 
            this.SimulateButton.Location = new System.Drawing.Point(123, 313);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(75, 23);
            this.SimulateButton.TabIndex = 4;
            this.SimulateButton.Text = "Start";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // breakParamInput
            // 
            this.breakParamInput.DecimalPlaces = 2;
            this.breakParamInput.Location = new System.Drawing.Point(123, 162);
            this.breakParamInput.Name = "breakParamInput";
            this.breakParamInput.Size = new System.Drawing.Size(120, 22);
            this.breakParamInput.TabIndex = 5;
            this.breakParamInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // repairParamInput
            // 
            this.repairParamInput.DecimalPlaces = 2;
            this.repairParamInput.Location = new System.Drawing.Point(123, 212);
            this.repairParamInput.Name = "repairParamInput";
            this.repairParamInput.Size = new System.Drawing.Size(120, 22);
            this.repairParamInput.TabIndex = 6;
            this.repairParamInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // waitParamInput
            // 
            this.waitParamInput.DecimalPlaces = 6;
            this.waitParamInput.Location = new System.Drawing.Point(123, 265);
            this.waitParamInput.Name = "waitParamInput";
            this.waitParamInput.Size = new System.Drawing.Size(120, 22);
            this.waitParamInput.TabIndex = 7;
            this.waitParamInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "a1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "a2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "sigma";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.waitParamInput);
            this.Controls.Add(this.repairParamInput);
            this.Controls.Add(this.breakParamInput);
            this.Controls.Add(this.SimulateButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serviceParamInput);
            this.Controls.Add(this.arrivalParamInput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.arrivalParamInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceParamInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakParamInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairParamInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitParamInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown arrivalParamInput;
        private System.Windows.Forms.NumericUpDown serviceParamInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SimulateButton;
        private System.Windows.Forms.NumericUpDown breakParamInput;
        private System.Windows.Forms.NumericUpDown repairParamInput;
        private System.Windows.Forms.NumericUpDown waitParamInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

