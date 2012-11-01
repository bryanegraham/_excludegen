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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ExcludeGenerator.xml;

namespace ExcludeGenerator.gui
{
	public partial class ExcludeDialogue : Form
	{
        private ExcludeFile mExcludeFile;
		private bool mChangesSinceGeneration;

		public ExcludeDialogue(string swfFileName)
		{
			InitializeComponent();
            mExcludeFile = new ExcludeFile(swfFileName, new ExcludeFile.XMLErrorCallback(XMLErrorHandler));
            mExcludeFile.GenerateExcludeContext();

            foreach (string classExclude in mExcludeFile.Context.ExcludeClasses)
            {
				AddExcludeClass(classExclude);
            }

            foreach (string classInclude in mExcludeFile.Context.IncludeClasses)
            {
				AddIncludeClass(classInclude);
            }
			mChangesSinceGeneration = false;
		}

		//
		//	Event Handlers
		//

        private void mExcludedClassesList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string item = mExcludedClassesList.Items[e.Index] as string;

            if (e.NewValue == CheckState.Checked)
            {
                mIncludedClassesList.Items.Add(item);
            }
            else
            {
                mIncludedClassesList.Items.Remove(item);
            }
        }

		private void mManualIncludeText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				AddIncludeClass(mManualIncludeText.Text);
			}
		}


		private void mExcludedClassesList_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Back && mExcludedClassesList.SelectedIndices.Count > 0)
			{
				DialogResult result = MessageBox.Show(this, "Are you sure you want to remove selected class(es)?", "Delete exclude", MessageBoxButtons.YesNo);

				if (DialogResult.Yes == result)
				{
					List<string> selectedClasses = new List<string>(); 

					foreach (int index in mExcludedClassesList.SelectedIndices)
					{
						selectedClasses.Add(mExcludedClassesList.Items[index].ToString());
					}

					foreach (string className in selectedClasses)
					{
						mExcludedClassesList.Items.Remove(className);
						mIncludedClassesList.Items.Remove(className);
					}
				}
			}
		}

		private void mGenerateButton_Click(object sender, EventArgs e)
		{
			mExcludeFile.Context.ExcludeClasses.Clear();
			mExcludeFile.Context.IncludeClasses.Clear();
			int numItems = mExcludedClassesList.Items.Count;

			for (int i = 0; i < numItems; ++i)
			{
				if (mExcludedClassesList.GetItemChecked(i))
				{
					mExcludeFile.Context.IncludeClasses.Add(mExcludedClassesList.Items[i].ToString());
				}
				else
				{
					mExcludeFile.Context.ExcludeClasses.Add(mExcludedClassesList.Items[i].ToString());
				}
			}

			mChangesSinceGeneration = false;
			bool result = mExcludeFile.SaveContext();

			if (result)
			{
				Close();
			}
		}


		private void mCloseButton_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void ExcludeDialogue_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (mChangesSinceGeneration)
			{
				DialogResult result = MessageBox.Show(this, "Closing the form now will lost all current change. Proceed?", "All changes will be lost", MessageBoxButtons.YesNo);
				
				if (result == DialogResult.No)
				{
					e.Cancel = true;
					return;
				}
			}
			
			Destroy();
		}

		//
		//	Helpers
		//

		private void Destroy()
		{
			mExcludeFile = null;
		}

		private void AddExcludeClass(string className)
		{
			mChangesSinceGeneration = true;

			if (mExcludedClassesList.Items.Contains(className))
			{
				int indexOfClass = mExcludedClassesList.Items.IndexOf(className);
				mExcludedClassesList.SetItemChecked(indexOfClass, true);
			}
			else
			{
				mExcludedClassesList.Items.Add(className, false);
			}

			if (mIncludedClassesList.Items.Contains(className))
			{
				mIncludedClassesList.Items.Remove(className);
			}
		}

		private void AddIncludeClass(string className)
		{
			mChangesSinceGeneration = true;

			if (mExcludedClassesList.Items.Contains(className))
			{
				if (!mIncludedClassesList.Items.Contains(className))
				{
					mIncludedClassesList.Items.Add(className);

					int indexOfClass = mExcludedClassesList.Items.IndexOf(className);
					mExcludedClassesList.SetItemChecked(indexOfClass, true);
				}

			}
			else
			{
				mExcludedClassesList.Items.Add(className, true);
			}
		}

		private void XMLErrorHandler (ErrorCodes.XMLParserError errCode, string message)
		{
			switch (errCode) 
			{
				case ErrorCodes.XMLParserError.TagReadError:
				{
					DialogResult result = MessageBox.Show("File appears to not exist, or is malformed.\n Do you want to continue with the data we managed to load thus far?", "Reading Error: ", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
					if (DialogResult.No == result)
					{
						// Clear context lists
						mExcludeFile.Context.ExcludeClasses.Clear();
						mExcludeFile.Context.ExcludeClasses.Clear();
					}
					break;
				}

				case ErrorCodes.XMLParserError.InputFileDoesNotExist:
				{
					MessageBox.Show("File does not exist and will be created", "No Exclude File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					break;
				}

				case ErrorCodes.XMLParserError.FileWriteError:
				{
					MessageBox.Show("Unable to write file, are you sure you have write permissions?\n" + message, "Error Writing File");
					break;
				}
			}
		}
	}
}
