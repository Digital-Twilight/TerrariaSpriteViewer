﻿using TerrariaSpriteViewer.Classes;

namespace TerrariaSpriteViewer
{
    partial class MainForm
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
            this.SpritePictureBox = new System.Windows.Forms.PictureBox();
            this.ArmorToggleButton = new System.Windows.Forms.Button();
            this.AnimationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.StopAnimationButton = new System.Windows.Forms.Button();
            this.PlayAnimationButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ArmorHeadSelector = new System.Windows.Forms.ComboBox();
            this.ArmorBodySelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ArmorLegsSelector = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ChangeBackgroundButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.FrameTimeTrackbar = new TerrariaSpriteViewer.Classes.NoFocusTrackBar();
            this.ReloadFilesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SpritePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameTimeTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // SpritePictureBox
            // 
            this.SpritePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpritePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SpritePictureBox.Location = new System.Drawing.Point(12, 230);
            this.SpritePictureBox.MaximumSize = new System.Drawing.Size(200, 280);
            this.SpritePictureBox.MinimumSize = new System.Drawing.Size(200, 280);
            this.SpritePictureBox.Name = "SpritePictureBox";
            this.SpritePictureBox.Size = new System.Drawing.Size(200, 280);
            this.SpritePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SpritePictureBox.TabIndex = 0;
            this.SpritePictureBox.TabStop = false;
            // 
            // ArmorToggleButton
            // 
            this.ArmorToggleButton.Location = new System.Drawing.Point(12, 12);
            this.ArmorToggleButton.Name = "ArmorToggleButton";
            this.ArmorToggleButton.Size = new System.Drawing.Size(200, 23);
            this.ArmorToggleButton.TabIndex = 1;
            this.ArmorToggleButton.Text = "Armor toggle";
            this.ArmorToggleButton.UseVisualStyleBackColor = true;
            this.ArmorToggleButton.Click += new System.EventHandler(this.ArmorToggleButton_Click);
            // 
            // AnimationTypeComboBox
            // 
            this.AnimationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnimationTypeComboBox.FormattingEnabled = true;
            this.AnimationTypeComboBox.Items.AddRange(new object[] {
            "Idle",
            "Running",
            "Mining",
            "Jumping/Flying",
            "Falling",
            "Grappling hook (Up)",
            "Grappling hook (Side)",
            "Grappling hook (Down)"});
            this.AnimationTypeComboBox.Location = new System.Drawing.Point(12, 174);
            this.AnimationTypeComboBox.Name = "AnimationTypeComboBox";
            this.AnimationTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.AnimationTypeComboBox.TabIndex = 2;
            this.AnimationTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.AnimationTypeComboBox_SelectedIndexChanged);
            // 
            // StopAnimationButton
            // 
            this.StopAnimationButton.Location = new System.Drawing.Point(154, 201);
            this.StopAnimationButton.Name = "StopAnimationButton";
            this.StopAnimationButton.Size = new System.Drawing.Size(58, 23);
            this.StopAnimationButton.TabIndex = 3;
            this.StopAnimationButton.Text = "Stop";
            this.StopAnimationButton.UseVisualStyleBackColor = true;
            this.StopAnimationButton.Click += new System.EventHandler(this.StopAnimation);
            // 
            // PlayAnimationButton
            // 
            this.PlayAnimationButton.Location = new System.Drawing.Point(12, 201);
            this.PlayAnimationButton.Name = "PlayAnimationButton";
            this.PlayAnimationButton.Size = new System.Drawing.Size(58, 23);
            this.PlayAnimationButton.TabIndex = 4;
            this.PlayAnimationButton.Text = "Play";
            this.PlayAnimationButton.UseVisualStyleBackColor = true;
            this.PlayAnimationButton.Click += new System.EventHandler(this.StartAnimation);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Head";
            // 
            // ArmorHeadSelector
            // 
            this.ArmorHeadSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ArmorHeadSelector.FormattingEnabled = true;
            this.ArmorHeadSelector.Location = new System.Drawing.Point(12, 54);
            this.ArmorHeadSelector.Name = "ArmorHeadSelector";
            this.ArmorHeadSelector.Size = new System.Drawing.Size(200, 21);
            this.ArmorHeadSelector.TabIndex = 6;
            this.ArmorHeadSelector.SelectedIndexChanged += new System.EventHandler(this.ArmorHeadSelector_SelectedIndexChanged);
            // 
            // ArmorBodySelector
            // 
            this.ArmorBodySelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ArmorBodySelector.FormattingEnabled = true;
            this.ArmorBodySelector.Location = new System.Drawing.Point(12, 94);
            this.ArmorBodySelector.Name = "ArmorBodySelector";
            this.ArmorBodySelector.Size = new System.Drawing.Size(200, 21);
            this.ArmorBodySelector.TabIndex = 8;
            this.ArmorBodySelector.SelectedIndexChanged += new System.EventHandler(this.ArmorBodySelector_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Body";
            // 
            // ArmorLegsSelector
            // 
            this.ArmorLegsSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ArmorLegsSelector.FormattingEnabled = true;
            this.ArmorLegsSelector.Location = new System.Drawing.Point(12, 134);
            this.ArmorLegsSelector.Name = "ArmorLegsSelector";
            this.ArmorLegsSelector.Size = new System.Drawing.Size(200, 21);
            this.ArmorLegsSelector.TabIndex = 10;
            this.ArmorLegsSelector.SelectedIndexChanged += new System.EventHandler(this.ArmorLegsSelector_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Legs";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Animation";
            // 
            // ChangeBackgroundButton
            // 
            this.ChangeBackgroundButton.Location = new System.Drawing.Point(12, 580);
            this.ChangeBackgroundButton.Name = "ChangeBackgroundButton";
            this.ChangeBackgroundButton.Size = new System.Drawing.Size(200, 23);
            this.ChangeBackgroundButton.TabIndex = 12;
            this.ChangeBackgroundButton.Text = "Change background color";
            this.ChangeBackgroundButton.UseVisualStyleBackColor = true;
            this.ChangeBackgroundButton.Click += new System.EventHandler(this.ChangeBackgroundButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 513);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Frame time";
            // 
            // FrameTimeTrackbar
            // 
            this.FrameTimeTrackbar.Location = new System.Drawing.Point(12, 529);
            this.FrameTimeTrackbar.Maximum = 50;
            this.FrameTimeTrackbar.Minimum = 1;
            this.FrameTimeTrackbar.Name = "FrameTimeTrackbar";
            this.FrameTimeTrackbar.Size = new System.Drawing.Size(200, 45);
            this.FrameTimeTrackbar.TabIndex = 13;
            this.FrameTimeTrackbar.Value = 1;
            this.FrameTimeTrackbar.ValueChanged += new System.EventHandler(this.FrameTimeTrackbar_ValueChanged);
            // 
            // ReloadFilesButton
            // 
            this.ReloadFilesButton.Location = new System.Drawing.Point(76, 201);
            this.ReloadFilesButton.Name = "ReloadFilesButton";
            this.ReloadFilesButton.Size = new System.Drawing.Size(72, 23);
            this.ReloadFilesButton.TabIndex = 15;
            this.ReloadFilesButton.Text = "Reload files";
            this.ReloadFilesButton.UseVisualStyleBackColor = true;
            this.ReloadFilesButton.Click += new System.EventHandler(this.ReloadFilesButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 615);
            this.Controls.Add(this.ReloadFilesButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FrameTimeTrackbar);
            this.Controls.Add(this.ChangeBackgroundButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ArmorLegsSelector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ArmorBodySelector);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ArmorHeadSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayAnimationButton);
            this.Controls.Add(this.StopAnimationButton);
            this.Controls.Add(this.AnimationTypeComboBox);
            this.Controls.Add(this.ArmorToggleButton);
            this.Controls.Add(this.SpritePictureBox);
            this.Name = "MainForm";
            this.Text = "Terraria Sprite Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpritePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrameTimeTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SpritePictureBox;
        private System.Windows.Forms.Button ArmorToggleButton;
        private System.Windows.Forms.ComboBox AnimationTypeComboBox;
        private System.Windows.Forms.Button StopAnimationButton;
        private System.Windows.Forms.Button PlayAnimationButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ArmorHeadSelector;
        private System.Windows.Forms.ComboBox ArmorBodySelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ArmorLegsSelector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ChangeBackgroundButton;
        private NoFocusTrackBar FrameTimeTrackbar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ReloadFilesButton;
    }
}
