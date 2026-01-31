using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using MoreMountains.Tools;

namespace MoreMountains.CorgiEngine
{
	/// <summary>
	/// This component allows the definition of a level that can then be accessed and loaded. Used mostly in the level map scene.
	/// </summary>
	public class LevelSelector : CorgiMonoBehaviour
	{
		public enum Modes { Direct, LevelManager }
		
		/// the exact name of the target level
		[Tooltip("the exact name of the target level")]
		public string LevelName;
		/// whether or not changing level should trigger a fade
		[Tooltip("whether or not changing level should trigger a fade")]
		public bool Fade = true;
		/// whether or not changing level should trigger a save event
		[Tooltip("whether or not changing level should trigger a save event")]
		public bool Save = true;
		/// the mode we should use to change levels (either via a direct loading scene call, or via the LevelManager)
		[Tooltip("the mode we should use to change levels (either via a direct loading scene call, or via the LevelManager)")]
		public Modes Mode = Modes.Direct;
		/// in Direct mode, the name of the loading scene to use
		[Tooltip("in Direct mode, the name of the loading scene to use")]
		[MMEnumCondition("Mode", (int)Modes.Direct)]
		public string LoadingSceneName = "LoadingScreen";

			protected virtual bool IsSceneInBuild(string sceneName)
			{
				if (string.IsNullOrEmpty(sceneName)) { return false; }
				for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
				{
					var scenePath = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
					var name = System.IO.Path.GetFileNameWithoutExtension(scenePath);
					if (name == sceneName) { return true; }
				}
				return false;
			}


		/// <summary>
		/// Loads the level specified in the inspector
		/// </summary>
		public virtual void GoToLevel()
		{
			if (Mode == Modes.Direct)
			{
					if (IsSceneInBuild(LoadingSceneName))
					{
						MMSceneLoadingManager.LoadScene(LevelName, LoadingSceneName);
					}
					else
					{
						SceneManager.LoadScene(LevelName);
					}
			}
			else
			{
				LevelManager.Instance.GotoLevel(LevelName, Fade, Save);
			}
		}

		/// <summary>
		/// Restarts the current level
		/// </summary>
		public virtual void RestartLevel()
		{
			if (Mode == Modes.Direct)
			{
					var current = SceneManager.GetActiveScene().name;
					if (IsSceneInBuild(LoadingSceneName))
					{
						MMSceneLoadingManager.LoadScene(current, LoadingSceneName);
					}
					else
					{
						SceneManager.LoadScene(current);
					}
			}
			else
			{
				LevelManager.Instance.GotoLevel(SceneManager.GetActiveScene().name, Fade, Save);
			}
		}		
	}
}