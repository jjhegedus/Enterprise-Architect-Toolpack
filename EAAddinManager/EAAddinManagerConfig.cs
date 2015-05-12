﻿/*
 * Created by SharpDevelop.
 * User: wij
 * Date: 25/03/2015
 * Time: 4:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace EAAddinManager
{
	/// <summary>
	/// Description of EAAddinManagerConfig.
	/// </summary>
	public class EAAddinManagerConfig
	{
		protected Configuration defaultConfig {get;set;}
		protected Configuration currentConfig {get;set;}
		public EAAddinManagerConfig()
		{
		  Configuration roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
		  
		  //the roamingConfig now get a path such as C:\Users\<user>\AppData\Roaming\Sparx_Systems_Pty_Ltd\DefaultDomain_Path_2epjiwj3etsq5yyljkyqqi2yc4elkrkf\9,_2,_0,_921\user.config
		  // which I don't like. So we move up three directories and then add a directory for the EA Navigator so that we get
		  // C:\Users\<user>\AppData\Roaming\GeertBellekens\EANavigator\user.config
		  string configFileName =  System.IO.Path.GetFileName(roamingConfig.FilePath);
		  string configDirectory = System.IO.Directory.GetParent(roamingConfig.FilePath).Parent.Parent.Parent.FullName;
		  
		  string newConfigFilePath = configDirectory + @"\Bellekens\EAAddinManager\" + configFileName;
		  // Map the roaming configuration file. This
		  // enables the application to access 
		  // the configuration file using the
		  // System.Configuration.Configuration class
		  ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
		  configFileMap.ExeConfigFilename = newConfigFilePath;		
		  // Get the mapped configuration file.
		   currentConfig = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
		  //merge the default settings
		  this.mergeDefaultSettings();
		}
		private string _localAddinPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) , @"Bellekens\EAAddinManager\Addins\");
		public string localAddinPath {get {return this._localAddinPath;}}
		
		public string getLocalAddinPath (AddinConfig addinConfig)
		{
			return localAddinPath +  addinConfig.name + "\\" + addinConfig.dllPath;
		}
		public string getRemoteAddinPath (AddinConfig addinConfig, string remotePath)
		{
			return remotePath +  addinConfig.name + "\\" + addinConfig.dllPath;
		}
		                                 
		/// <summary>
		/// gets the default settings config.
		/// </summary>
		protected void getDefaultSettings()
		{
			string defaultConfigFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			defaultConfig = ConfigurationManager.OpenExeConfiguration(defaultConfigFilePath);
		}
		/// <summary>
		/// merge the default settings with the current config.
		/// </summary>
		protected void mergeDefaultSettings()
		{
			if (this.defaultConfig == null)
			{
				this.getDefaultSettings();
			}
			//defaultConfig.AppSettings.Settings["menuOwnerEnabled"].Value
			foreach ( KeyValueConfigurationElement configEntry in defaultConfig.AppSettings.Settings) 
			{
				if (!currentConfig.AppSettings.Settings.AllKeys.Contains(configEntry.Key))
				{
					currentConfig.AppSettings.Settings.Add(configEntry.Key,configEntry.Value);
				}
			}
			// save the configuration
			currentConfig.Save();
		}
		public List<string> addinSearchPaths
		{
			get
			{
				List<string> addinLocations = new List<string>();
				string configValue = this.currentConfig.AppSettings.Settings["AddinSearchPaths"].Value;
				addinLocations.AddRange(configValue.Split(';'));
			   	return addinLocations;
			}
			set
			{
				this.currentConfig.AppSettings.Settings["AddinSearchPaths"].Value = string.Join(";", value);
			}
		}
		public List<AddinConfig> addinConfigs {
			get
			{
				List<AddinConfig> configs = new List<AddinConfig>();
				foreach (ConnectionStringSettings  connectionString  in this.currentConfig.ConnectionStrings.ConnectionStrings) 
				{
					if (connectionString.ProviderName == "EA-Matic")
					{
						configs.Add(new AddinConfig(connectionString));
					}
				}
				return configs;
			}
			set
			{
				//TODO
			}
		}
		
	

		
	}
}