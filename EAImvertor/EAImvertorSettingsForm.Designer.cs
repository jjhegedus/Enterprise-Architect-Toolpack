﻿/*
 * Created by SharpDevelop.
 * User: LaptopGeert
 * Date: 9/07/2016
 * Time: 6:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace EAImvertor
{
	partial class EAImvertorSettingsForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label ImvertorURLLabel;
		private System.Windows.Forms.TextBox ImvertorURLTextbox;
		private System.Windows.Forms.TextBox defaultPinTextBox;
		private System.Windows.Forms.Label defaultPinLabel;
		private System.Windows.Forms.Button applyButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.TextBox defaultPropertiesPathTextBox;
		private System.Windows.Forms.Label DefaultPropertiesPathLabel;
		private System.Windows.Forms.ComboBox defaultPropertiesTextBox;
		private System.Windows.Forms.Label defaultPropertiesLabel;
		private System.Windows.Forms.Button browseDefaultPropertiesFileButton;
		private System.Windows.Forms.ComboBox defaultProcessTextBox;
		private System.Windows.Forms.Label defaultProcessLabel;
		private System.Windows.Forms.Button browseDefaultHistoryFileButton;
		private System.Windows.Forms.TextBox defaultHistoryFileTextBox;
		private System.Windows.Forms.Label defaultHistoryFileLabel;
		private System.Windows.Forms.NumericUpDown timeOutUpDown;
		private System.Windows.Forms.Label timeoutLabel;
		private System.Windows.Forms.Label retryLabel;
		private System.Windows.Forms.NumericUpDown retryIntervalUpDown;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EAImvertorSettingsForm));
			this.ImvertorURLLabel = new System.Windows.Forms.Label();
			this.ImvertorURLTextbox = new System.Windows.Forms.TextBox();
			this.defaultPinTextBox = new System.Windows.Forms.TextBox();
			this.defaultPinLabel = new System.Windows.Forms.Label();
			this.applyButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.defaultPropertiesPathTextBox = new System.Windows.Forms.TextBox();
			this.DefaultPropertiesPathLabel = new System.Windows.Forms.Label();
			this.defaultPropertiesTextBox = new System.Windows.Forms.ComboBox();
			this.defaultPropertiesLabel = new System.Windows.Forms.Label();
			this.browseDefaultPropertiesFileButton = new System.Windows.Forms.Button();
			this.defaultProcessTextBox = new System.Windows.Forms.ComboBox();
			this.defaultProcessLabel = new System.Windows.Forms.Label();
			this.browseDefaultHistoryFileButton = new System.Windows.Forms.Button();
			this.defaultHistoryFileTextBox = new System.Windows.Forms.TextBox();
			this.defaultHistoryFileLabel = new System.Windows.Forms.Label();
			this.timeOutUpDown = new System.Windows.Forms.NumericUpDown();
			this.timeoutLabel = new System.Windows.Forms.Label();
			this.retryLabel = new System.Windows.Forms.Label();
			this.retryIntervalUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.timeOutUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.retryIntervalUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// ImvertorURLLabel
			// 
			this.ImvertorURLLabel.Location = new System.Drawing.Point(12, 15);
			this.ImvertorURLLabel.Name = "ImvertorURLLabel";
			this.ImvertorURLLabel.Size = new System.Drawing.Size(141, 23);
			this.ImvertorURLLabel.TabIndex = 0;
			this.ImvertorURLLabel.Text = "Imvertor URL";
			// 
			// ImvertorURLTextbox
			// 
			this.ImvertorURLTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.ImvertorURLTextbox.Location = new System.Drawing.Point(159, 12);
			this.ImvertorURLTextbox.Name = "ImvertorURLTextbox";
			this.ImvertorURLTextbox.Size = new System.Drawing.Size(225, 20);
			this.ImvertorURLTextbox.TabIndex = 1;
			// 
			// defaultPinTextBox
			// 
			this.defaultPinTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.defaultPinTextBox.Location = new System.Drawing.Point(159, 36);
			this.defaultPinTextBox.MinimumSize = new System.Drawing.Size(153, 20);
			this.defaultPinTextBox.Name = "defaultPinTextBox";
			this.defaultPinTextBox.Size = new System.Drawing.Size(225, 20);
			this.defaultPinTextBox.TabIndex = 2;
			// 
			// defaultPinLabel
			// 
			this.defaultPinLabel.Location = new System.Drawing.Point(12, 39);
			this.defaultPinLabel.Name = "defaultPinLabel";
			this.defaultPinLabel.Size = new System.Drawing.Size(141, 23);
			this.defaultPinLabel.TabIndex = 2;
			this.defaultPinLabel.Text = "Default PIN";
			// 
			// applyButton
			// 
			this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.applyButton.Location = new System.Drawing.Point(309, 231);
			this.applyButton.Name = "applyButton";
			this.applyButton.Size = new System.Drawing.Size(75, 23);
			this.applyButton.TabIndex = 9;
			this.applyButton.Text = "Apply";
			this.applyButton.UseVisualStyleBackColor = true;
			this.applyButton.Click += new System.EventHandler(this.ApplyButtonClick);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(228, 231);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 8;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(147, 231);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 7;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// defaultPropertiesPathTextBox
			// 
			this.defaultPropertiesPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.defaultPropertiesPathTextBox.Location = new System.Drawing.Point(159, 114);
			this.defaultPropertiesPathTextBox.MinimumSize = new System.Drawing.Size(153, 20);
			this.defaultPropertiesPathTextBox.Name = "defaultPropertiesPathTextBox";
			this.defaultPropertiesPathTextBox.Size = new System.Drawing.Size(195, 20);
			this.defaultPropertiesPathTextBox.TabIndex = 5;
			// 
			// DefaultPropertiesPathLabel
			// 
			this.DefaultPropertiesPathLabel.Location = new System.Drawing.Point(12, 117);
			this.DefaultPropertiesPathLabel.Name = "DefaultPropertiesPathLabel";
			this.DefaultPropertiesPathLabel.Size = new System.Drawing.Size(141, 23);
			this.DefaultPropertiesPathLabel.TabIndex = 10;
			this.DefaultPropertiesPathLabel.Text = "Default Properties File";
			// 
			// defaultPropertiesTextBox
			// 
			this.defaultPropertiesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.defaultPropertiesTextBox.Location = new System.Drawing.Point(159, 88);
			this.defaultPropertiesTextBox.Name = "defaultPropertiesTextBox";
			this.defaultPropertiesTextBox.Size = new System.Drawing.Size(225, 20);
			this.defaultPropertiesTextBox.TabIndex = 4;
			// 
			// defaultPropertiesLabel
			// 
			this.defaultPropertiesLabel.Location = new System.Drawing.Point(12, 91);
			this.defaultPropertiesLabel.Name = "defaultPropertiesLabel";
			this.defaultPropertiesLabel.Size = new System.Drawing.Size(141, 23);
			this.defaultPropertiesLabel.TabIndex = 8;
			this.defaultPropertiesLabel.Text = "Default Processing Mode";
			// 
			// browseDefaultPropertiesFileButton
			// 
			this.browseDefaultPropertiesFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseDefaultPropertiesFileButton.Location = new System.Drawing.Point(360, 113);
			this.browseDefaultPropertiesFileButton.Name = "browseDefaultPropertiesFileButton";
			this.browseDefaultPropertiesFileButton.Size = new System.Drawing.Size(24, 20);
			this.browseDefaultPropertiesFileButton.TabIndex = 6;
			this.browseDefaultPropertiesFileButton.Text = "...";
			this.browseDefaultPropertiesFileButton.UseVisualStyleBackColor = true;
			this.browseDefaultPropertiesFileButton.Click += new System.EventHandler(this.BrowseDefaultPropertiesFileButtonClick);
			// 
			// defaultProcessTextBox
			// 
			this.defaultProcessTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.defaultProcessTextBox.Location = new System.Drawing.Point(159, 62);
			this.defaultProcessTextBox.MinimumSize = new System.Drawing.Size(153, 20);
			this.defaultProcessTextBox.Name = "defaultProcessTextBox";
			this.defaultProcessTextBox.Size = new System.Drawing.Size(225, 20);
			this.defaultProcessTextBox.TabIndex = 3;
			// 
			// defaultProcessLabel
			// 
			this.defaultProcessLabel.Location = new System.Drawing.Point(12, 65);
			this.defaultProcessLabel.Name = "defaultProcessLabel";
			this.defaultProcessLabel.Size = new System.Drawing.Size(141, 23);
			this.defaultProcessLabel.TabIndex = 15;
			this.defaultProcessLabel.Text = "Default Process";
			// 
			// browseDefaultHistoryFileButton
			// 
			this.browseDefaultHistoryFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseDefaultHistoryFileButton.Location = new System.Drawing.Point(360, 142);
			this.browseDefaultHistoryFileButton.Name = "browseDefaultHistoryFileButton";
			this.browseDefaultHistoryFileButton.Size = new System.Drawing.Size(24, 20);
			this.browseDefaultHistoryFileButton.TabIndex = 17;
			this.browseDefaultHistoryFileButton.Text = "...";
			this.browseDefaultHistoryFileButton.UseVisualStyleBackColor = true;
			this.browseDefaultHistoryFileButton.Click += new System.EventHandler(this.BrowseDefaultHistoryFileButtonClick);
			// 
			// defaultHistoryFileTextBox
			// 
			this.defaultHistoryFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.defaultHistoryFileTextBox.Location = new System.Drawing.Point(159, 143);
			this.defaultHistoryFileTextBox.MinimumSize = new System.Drawing.Size(153, 20);
			this.defaultHistoryFileTextBox.Name = "defaultHistoryFileTextBox";
			this.defaultHistoryFileTextBox.Size = new System.Drawing.Size(195, 20);
			this.defaultHistoryFileTextBox.TabIndex = 16;
			// 
			// defaultHistoryFileLabel
			// 
			this.defaultHistoryFileLabel.Location = new System.Drawing.Point(12, 146);
			this.defaultHistoryFileLabel.Name = "defaultHistoryFileLabel";
			this.defaultHistoryFileLabel.Size = new System.Drawing.Size(141, 23);
			this.defaultHistoryFileLabel.TabIndex = 18;
			this.defaultHistoryFileLabel.Text = "Default History File";
			// 
			// timeOutUpDown
			// 
			this.timeOutUpDown.Increment = new decimal(new int[] {
			30,
			0,
			0,
			0});
			this.timeOutUpDown.Location = new System.Drawing.Point(159, 170);
			this.timeOutUpDown.Maximum = new decimal(new int[] {
			3600,
			0,
			0,
			0});
			this.timeOutUpDown.Name = "timeOutUpDown";
			this.timeOutUpDown.Size = new System.Drawing.Size(63, 20);
			this.timeOutUpDown.TabIndex = 19;
			// 
			// timeoutLabel
			// 
			this.timeoutLabel.Location = new System.Drawing.Point(12, 172);
			this.timeoutLabel.Name = "timeoutLabel";
			this.timeoutLabel.Size = new System.Drawing.Size(129, 23);
			this.timeoutLabel.TabIndex = 20;
			this.timeoutLabel.Text = "Timeout (seconds)";
			// 
			// retryLabel
			// 
			this.retryLabel.Location = new System.Drawing.Point(12, 195);
			this.retryLabel.Name = "retryLabel";
			this.retryLabel.Size = new System.Drawing.Size(141, 23);
			this.retryLabel.TabIndex = 22;
			this.retryLabel.Text = "Rrefresh interval (seconds)";
			// 
			// retryIntervalUpDown
			// 
			this.retryIntervalUpDown.Increment = new decimal(new int[] {
			3,
			0,
			0,
			0});
			this.retryIntervalUpDown.Location = new System.Drawing.Point(159, 193);
			this.retryIntervalUpDown.Maximum = new decimal(new int[] {
			999,
			0,
			0,
			0});
			this.retryIntervalUpDown.Name = "retryIntervalUpDown";
			this.retryIntervalUpDown.Size = new System.Drawing.Size(63, 20);
			this.retryIntervalUpDown.TabIndex = 21;
			// 
			// EAImvertorSettingsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(393, 266);
			this.Controls.Add(this.retryLabel);
			this.Controls.Add(this.retryIntervalUpDown);
			this.Controls.Add(this.timeoutLabel);
			this.Controls.Add(this.timeOutUpDown);
			this.Controls.Add(this.browseDefaultHistoryFileButton);
			this.Controls.Add(this.defaultHistoryFileTextBox);
			this.Controls.Add(this.defaultHistoryFileLabel);
			this.Controls.Add(this.defaultProcessTextBox);
			this.Controls.Add(this.defaultProcessLabel);
			this.Controls.Add(this.browseDefaultPropertiesFileButton);
			this.Controls.Add(this.defaultPropertiesPathTextBox);
			this.Controls.Add(this.DefaultPropertiesPathLabel);
			this.Controls.Add(this.defaultPropertiesTextBox);
			this.Controls.Add(this.defaultPropertiesLabel);
			this.Controls.Add(this.applyButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.defaultPinTextBox);
			this.Controls.Add(this.defaultPinLabel);
			this.Controls.Add(this.ImvertorURLTextbox);
			this.Controls.Add(this.ImvertorURLLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(375, 242);
			this.Name = "EAImvertorSettingsForm";
			this.Text = "EA Imvertor settings";
			((System.ComponentModel.ISupportInitialize)(this.timeOutUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.retryIntervalUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
