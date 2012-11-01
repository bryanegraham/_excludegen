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
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using PluginCore;

namespace ExcludeGenerator.gui
{
	public class ContextMenuItems
	{

		#region Static Members and Functions

		// Singleton Instance
		private static ContextMenuItems sInstance;


		public static ContextMenuItems Instance
		{
			get
			{
				if (null == sInstance)
				{
					sInstance = new ContextMenuItems();
				}

				return sInstance;
			}
		}
		#endregion

		#region Member Variables
		
		private string mContextMenuName;
		private ToolStripItem mLaunchExcludeGUIOption;
		private TreeNode mCurrentSeletedNode;
		
		#endregion

		private ContextMenuItems()
		{
			mContextMenuName = "Exclude Classes";
			mCurrentSeletedNode = null;
			mLaunchExcludeGUIOption = null;
		}

		#region Member Functions

		public void Initialize()
		{
			// TODO: Add Init here
		}

		public void Destroy()
		{
			// TODO: Add Destroy here
		}

		public void AddContextMenuItems(TreeView tree)
		{
			if (null != tree)
			{
				if (IsCurrentNodeSwf(tree))
				{
					if (null == mLaunchExcludeGUIOption)
					{
						Image image = null;

						// Resolve assembly path and get menu icon file stream
						System.Reflection.Assembly currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();
						System.IO.Stream imageFStream = currentAssembly.GetManifestResourceStream("ExcludeGenerator.Resources.excludeIcon.bmp");

						Debug.Assert(null != currentAssembly, "[ContextMenuItems]: Executing Assembly could not be found!");
						Debug.Assert(null != imageFStream, "[ContextMenuItems]: Unable to open image stream! Was image asset correctly embedded/present?");

						image = Image.FromStream(imageFStream);

						// Create menu object
						mLaunchExcludeGUIOption = new ToolStripMenuItem(mContextMenuName, image, new EventHandler(OnContextMenuOptionSelected));
					}
                    tree.ContextMenuStrip.Items.Add("-");
					tree.ContextMenuStrip.Items.Add(mLaunchExcludeGUIOption);
				}

                mCurrentSeletedNode = tree.SelectedNode;
			}
		}

		public bool IsCurrentNodeSwf(TreeView tree)
		{
            bool isSwf = null != tree && (tree.SelectedNode.Text.EndsWith(".swf") || tree.SelectedNode.Text.EndsWith(".SWF"));
			return isSwf;
		}

        private string GetPath()
        {
            string pathToRoot = "";
            string projectPath = "";

			projectPath = PluginBase.CurrentProject.ProjectPath;
			
			int splitIndex = projectPath.LastIndexOf('\\');
			projectPath = projectPath.Substring(0, splitIndex);

            if (mCurrentSeletedNode.Parent != null)
            {
                TreeNode currentNode = mCurrentSeletedNode.Parent;

                while (currentNode.Parent != null)
                {
                    pathToRoot = currentNode.Text + "\\" + pathToRoot;
                    currentNode = currentNode.Parent;
                }
            }
            return projectPath + "\\" + pathToRoot;
        }

		#endregion

		#region Callback Functions
		public void OnContextMenuOptionSelected(object sender, EventArgs e)
		{
            ExcludeDialogue dialogue = new ExcludeDialogue(GetPath() + mCurrentSeletedNode.Text);
			dialogue.StartPosition = FormStartPosition.CenterParent;
            dialogue.Show(PluginBase.MainForm);
		}
		#endregion
	}
}
