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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
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
            this.label6.Location = new System.Drawing.Point(335, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "kappa";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 265);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "o";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(283, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "var";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(338, 324);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(218, 324);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 17);
            this.label13.TabIndex = 18;
            this.label13.Text = "kappaTimeDif";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(283, 303);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "cor";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(335, 303);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 17);
            this.label15.TabIndex = 19;
            this.label15.Text = "cor";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(483, 201);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 17);
            this.label16.TabIndex = 21;
            this.label16.Text = "expectation in";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(602, 201);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 17);
            this.label17.TabIndex = 22;
            this.label17.Text = "expectation out";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(483, 228);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 17);
            this.label18.TabIndex = 23;
            this.label18.Text = "label18";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(602, 228);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 17);
            this.label19.TabIndex = 24;
            this.label19.Text = "label19";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}

