using System.IO;
using UnityEditor;
using UnityEngine;


namespace DannyG
{
	
	public static class ProjectSetup
	{
		[MenuItem("Tools/Project Setup/Create Default Folders")]
		public static void CreateDefaultFolders()
		{
			AddRootAssetFolders();
			AddScriptFolders();
		}

		private static void AddRootAssetFolders()
		{
			CreateFoldersInDirectory("", "_Scripts", "Art", "Prefabs", "Audio");
		}

		private static void AddScriptFolders()
		{
			CreateFoldersInDirectory("_Scripts", "Editor");
		}

		private static void CreateFoldersInDirectory(string directory, params string[] folders)
		{
			var fullPath = Path.Combine(Application.dataPath, directory);
			foreach (var folder in folders)
			{
				Directory.CreateDirectory(Path.Combine(fullPath, folder));
			}
		}
	}
}
