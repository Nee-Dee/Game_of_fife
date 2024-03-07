
namespace Game_of_fife
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_density = new System.Windows.Forms.NumericUpDown();
            this.checkBox_grid = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_rules = new System.Windows.Forms.Button();
            this.button_info = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.checkBox_myself = new System.Windows.Forms.CheckBox();
            this.checkBox_random = new System.Windows.Forms.CheckBox();
            this.numericUpDown_size = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_density)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown_density);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_grid);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button_rules);
            this.splitContainer1.Panel1.Controls.Add(this.button_info);
            this.splitContainer1.Panel1.Controls.Add(this.button_stop);
            this.splitContainer1.Panel1.Controls.Add(this.button_start);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_myself);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_random);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown_size);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(941, 542);
            this.splitContainer1.SplitterDistance = 115;
            this.splitContainer1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 39);
            this.label3.TabIndex = 11;
            this.label3.Text = "Плотность населения";
            // 
            // numericUpDown_density
            // 
            this.numericUpDown_density.Location = new System.Drawing.Point(21, 124);
            this.numericUpDown_density.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_density.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_density.Name = "numericUpDown_density";
            this.numericUpDown_density.Size = new System.Drawing.Size(71, 23);
            this.numericUpDown_density.TabIndex = 10;
            this.numericUpDown_density.Value = new decimal(new int[] {
            27,
            0,
            0,
            0});
            // 
            // checkBox_grid
            // 
            this.checkBox_grid.AutoSize = true;
            this.checkBox_grid.Checked = true;
            this.checkBox_grid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_grid.Location = new System.Drawing.Point(11, 257);
            this.checkBox_grid.Name = "checkBox_grid";
            this.checkBox_grid.Size = new System.Drawing.Size(57, 19);
            this.checkBox_grid.TabIndex = 9;
            this.checkBox_grid.Text = "Сетка";
            this.checkBox_grid.UseVisualStyleBackColor = true;
            this.checkBox_grid.CheckedChanged += new System.EventHandler(this.checkBox_grid_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Режим размещения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Размер клетки";
            // 
            // button_rules
            // 
            this.button_rules.Location = new System.Drawing.Point(9, 486);
            this.button_rules.Name = "button_rules";
            this.button_rules.Size = new System.Drawing.Size(99, 35);
            this.button_rules.TabIndex = 6;
            this.button_rules.Text = "Правила";
            this.button_rules.UseVisualStyleBackColor = true;
            this.button_rules.Click += new System.EventHandler(this.button_rules_Click);
            // 
            // button_info
            // 
            this.button_info.Location = new System.Drawing.Point(9, 445);
            this.button_info.Name = "button_info";
            this.button_info.Size = new System.Drawing.Size(99, 35);
            this.button_info.TabIndex = 5;
            this.button_info.Text = "О программе";
            this.button_info.UseVisualStyleBackColor = true;
            this.button_info.Click += new System.EventHandler(this.button_info_Click);
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(9, 333);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(99, 35);
            this.button_stop.TabIndex = 4;
            this.button_stop.Text = "Стоп";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(9, 292);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(99, 35);
            this.button_start.TabIndex = 3;
            this.button_start.Text = "Старт";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // checkBox_myself
            // 
            this.checkBox_myself.AutoSize = true;
            this.checkBox_myself.Location = new System.Drawing.Point(11, 221);
            this.checkBox_myself.Name = "checkBox_myself";
            this.checkBox_myself.Size = new System.Drawing.Size(71, 19);
            this.checkBox_myself.TabIndex = 2;
            this.checkBox_myself.Text = "Самому";
            this.checkBox_myself.UseVisualStyleBackColor = true;
            this.checkBox_myself.CheckedChanged += new System.EventHandler(this.checkBox_myself_CheckedChanged);
            // 
            // checkBox_random
            // 
            this.checkBox_random.AutoSize = true;
            this.checkBox_random.Checked = true;
            this.checkBox_random.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_random.Location = new System.Drawing.Point(11, 196);
            this.checkBox_random.Name = "checkBox_random";
            this.checkBox_random.Size = new System.Drawing.Size(81, 19);
            this.checkBox_random.TabIndex = 1;
            this.checkBox_random.Text = "Случайно";
            this.checkBox_random.UseVisualStyleBackColor = true;
            this.checkBox_random.CheckedChanged += new System.EventHandler(this.checkBox_random_CheckedChanged);
            // 
            // numericUpDown_size
            // 
            this.numericUpDown_size.Location = new System.Drawing.Point(21, 48);
            this.numericUpDown_size.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_size.Name = "numericUpDown_size";
            this.numericUpDown_size.Size = new System.Drawing.Size(71, 23);
            this.numericUpDown_size.TabIndex = 0;
            this.numericUpDown_size.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_size.ValueChanged += new System.EventHandler(this.numericUpDown_size_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(820, 540);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 542);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game of Life";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_density)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.CheckBox checkBox_myself;
        private System.Windows.Forms.CheckBox checkBox_random;
        private System.Windows.Forms.NumericUpDown numericUpDown_size;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_rules;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox_grid;
        private System.Windows.Forms.NumericUpDown numericUpDown_density;
        private System.Windows.Forms.Label label3;
    }
}

