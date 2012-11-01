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
using System.Text;
using System.Windows.Forms;
using ExcludeGenerator.Resources;
using PluginCore.Localization;
using PluginCore;
using PluginCore.Utilities;
using PluginCore.Managers;
using PluginCore.Helpers;

namespace ExcludeGenerator
{
	public class PluginMain : PluginCore.IPlugin
	{
		
		private String mPluginName = "Exclude Generator";
		private String mPluginGuid = "43e69a31-fe59-4ef1-99cc-a76f5fdc96e6";
		private String mPluginHelp = "www.flashdevelop.org/community/";
		private String mPluginDesc = "Localization Error";
		private String mPluginAuth = "Bryan Graham";
		private Settings mSettings;

		#region Required Properties

		/// <summary>
		/// Api level of the plugin
		/// </summary>
		public Int32 Api
		{
			get { return 1; }
		}

		/// <summary>
		/// Name of the plugin
		/// </summary> 
		public String Name
		{
			get { return this.mPluginName; }
		}

		/// <summary>
		/// GUID of the plugin
		/// </summary>
		public String Guid
		{
			get { return this.mPluginGuid; }
		}

		/// <summary>
		/// Author of the plugin
		/// </summary> 
		public String Author
		{
			get { return this.mPluginAuth; }
		}

		/// <summary>
		/// Description of the plugin
		/// </summary> 
		public String Description
		{
			get { return this.mPluginDesc; }
		}

		/// <summary>
		/// Web address for help
		/// </summary> 
		public String Help
		{
			get { return this.mPluginHelp; }
		}

		/// <summary>
		/// Object that contains the settings
		/// </summary>
		[Browsable(false)]
		public Object Settings
		{
			get { return mSettings; }
		}

		#endregion

		#region Required Methods

		/// <summary>
		/// Initializes the plugin
		/// </summary>
		public void Initialize()
		{
			this.InitBasics();
			this.AddEventHandlers();
			this.InitLocalization();
		}

		public void Dispose()
		{
            gui.ContextMenuItems.Instance.Destroy();
		}
			
		public void HandleEvent(Object sender, NotifyEvent e, HandlingPriority prority)
		{
			DataEvent dataEvent = e as DataEvent;
            
			string action = dataEvent.Action;

			if (action == "ProjectManager.TreeSelectionChanged")
			{
				TreeView explorerControl = sender as TreeView;
				gui.ContextMenuItems.Instance.AddContextMenuItems(explorerControl);
			}
		}

		#endregion

		#region Custom Methods

		public void InitBasics()
		{
			gui.ContextMenuItems.Instance.Initialize();
		}

		public void AddEventHandlers()
		{
			// Set events you want to listen (combine as flags)
			EventManager.AddEventHandler(this, EventType.Command);
		}

		public void InitLocalization()
		{
			LocaleVersion locale = PluginBase.MainForm.Settings.LocaleVersion;
			switch (locale)
			{
				default:
					// Default to English
					LocaleHelper.Initialize(LocaleVersion.en_US);
					break;
			}
			this.mPluginDesc = LocaleHelper.GetString("Info.Description");
		}


		#endregion

		#region Plugin Initizalization Functions

		public PluginMain()
		{
			mSettings = new Settings();
		}

		#endregion

	}
}
