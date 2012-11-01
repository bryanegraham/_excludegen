//
//  Copyright (c) 2012 Bryan Graham <bryanegraham@gmail.com>
//  
//  This software is provided 'as-is', without any express or implied
//  warranty. In no event will the authors be held liable for any damages
//  arising from the use of this software.
//  
//  Permission is granted to anyone to use this software for any purpose,
//  including commercial applications, and to alter it and redistribute it
//  freely, subject to the following restrictions:
//  
//     1. The origin of this software must not be misrepresented; you must not
//     claim that you wrote the original software. If you use this software
//     in a product, an acknowledgment in the product documentation would be
//     appreciated but is not required.
//  
//     2. Altered source versions must be plainly marked as such, and must not be
//     misrepresented as being the original software.
//  
//     3. This notice may not be removed or altered from any source
//     distribution.
//
namespace ExcludeGenerator.gui
{
	partial class ExcludeDialogue
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
			this.mExcludedClassesList = new System.Windows.Forms.CheckedListBox();
			this.mManualIncludeText = new System.Windows.Forms.TextBox();
			this.mCheckListLabel = new System.Windows.Forms.Label();
			this.mManualIncludeLabel = new System.Windows.Forms.Label();
			this.mIncludedClassesLabel = new System.Windows.Forms.Label();
			this.mIncludedClassesList = new System.Windows.Forms.ListBox();
			this.mGenerateButton = new System.Windows.Forms.Button();
			this.mCloseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mExcludedClassesList
			// 
			this.mExcludedClassesList.CheckOnClick = true;
			this.mExcludedClassesList.FormattingEnabled = true;
			this.mExcludedClassesList.Location = new System.Drawing.Point(12, 25);
			this.mExcludedClassesList.Name = "mExcludedClassesList";
			this.mExcludedClassesList.Size = new System.Drawing.Size(322, 409);
			this.mExcludedClassesList.Sorted = true;
			this.mExcludedClassesList.TabIndex = 0;
			this.mExcludedClassesList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.mExcludedClassesList_ItemCheck);
			this.mExcludedClassesList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mExcludedClassesList_KeyPress);
			// 
			// mManualIncludeText
			// 
			this.mManualIncludeText.Location = new System.Drawing.Point(340, 385);
			this.mManualIncludeText.Name = "mManualIncludeText";
			this.mManualIncludeText.Size = new System.Drawing.Size(272, 20);
			this.mManualIncludeText.TabIndex = 1;
			this.mManualIncludeText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mManualIncludeText_KeyPress);
			// 
			// mCheckListLabel
			// 
			this.mCheckListLabel.AutoSize = true;
			this.mCheckListLabel.Location = new System.Drawing.Point(9, 9);
			this.mCheckListLabel.Name = "mCheckListLabel";
			this.mCheckListLabel.Size = new System.Drawing.Size(187, 13);
			this.mCheckListLabel.TabIndex = 2;
			this.mCheckListLabel.Text = "Check the classes you wish to include";
			// 
			// mManualIncludeLabel
			// 
			this.mManualIncludeLabel.AutoSize = true;
			this.mManualIncludeLabel.Location = new System.Drawing.Point(337, 369);
			this.mManualIncludeLabel.Name = "mManualIncludeLabel";
			this.mManualIncludeLabel.Size = new System.Drawing.Size(203, 13);
			this.mManualIncludeLabel.TabIndex = 3;
			this.mManualIncludeLabel.Text = "Manually Include Class:  (Enter to accept)";
			// 
			// mIncludedClassesLabel
			// 
			this.mIncludedClassesLabel.AutoSize = true;
			this.mIncludedClassesLabel.Location = new System.Drawing.Point(341, 9);
			this.mIncludedClassesLabel.Name = "mIncludedClassesLabel";
			this.mIncludedClassesLabel.Size = new System.Drawing.Size(87, 13);
			this.mIncludedClassesLabel.TabIndex = 4;
			this.mIncludedClassesLabel.Text = "Included Classes";
			// 
			// mIncludedClassesList
			// 
			this.mIncludedClassesList.FormattingEnabled = true;
			this.mIncludedClassesList.Location = new System.Drawing.Point(340, 25);
			this.mIncludedClassesList.Name = "mIncludedClassesList";
			this.mIncludedClassesList.Size = new System.Drawing.Size(272, 342);
			this.mIncludedClassesList.Sorted = true;
			this.mIncludedClassesList.TabIndex = 5;
			// 
			// mGenerateButton
			// 
			this.mGenerateButton.Location = new System.Drawing.Point(456, 411);
			this.mGenerateButton.Name = "mGenerateButton";
			this.mGenerateButton.Size = new System.Drawing.Size(75, 23);
			this.mGenerateButton.TabIndex = 6;
			this.mGenerateButton.Text = "Generate";
			this.mGenerateButton.UseVisualStyleBackColor = true;
			this.mGenerateButton.Click += new System.EventHandler(this.mGenerateButton_Click);
			// 
			// mCloseButton
			// 
			this.mCloseButton.Location = new System.Drawing.Point(537, 411);
			this.mCloseButton.Name = "mCloseButton";
			this.mCloseButton.Size = new System.Drawing.Size(75, 23);
			this.mCloseButton.TabIndex = 7;
			this.mCloseButton.Text = "Close";
			this.mCloseButton.UseVisualStyleBackColor = true;
			this.mCloseButton.Click += new System.EventHandler(this.mCloseButton_Click);
			// 
			// ExcludeDialogue
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 442);
			this.Controls.Add(this.mCloseButton);
			this.Controls.Add(this.mGenerateButton);
			this.Controls.Add(this.mIncludedClassesList);
			this.Controls.Add(this.mIncludedClassesLabel);
			this.Controls.Add(this.mManualIncludeLabel);
			this.Controls.Add(this.mCheckListLabel);
			this.Controls.Add(this.mManualIncludeText);
			this.Controls.Add(this.mExcludedClassesList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExcludeDialogue";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Exclude Classes";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcludeDialogue_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox mExcludedClassesList;
		private System.Windows.Forms.TextBox mManualIncludeText;
		private System.Windows.Forms.Label mCheckListLabel;
		private System.Windows.Forms.Label mManualIncludeLabel;
		private System.Windows.Forms.Label mIncludedClassesLabel;
		private System.Windows.Forms.ListBox mIncludedClassesList;
		private System.Windows.Forms.Button mGenerateButton;
		private System.Windows.Forms.Button mCloseButton;
	}
}