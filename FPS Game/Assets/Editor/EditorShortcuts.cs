using UnityEditor;
using UnityEditor.SceneManagement;

public static class EditorShortcuts
{
	[MenuItem("NoodleGore/StartGame %#.", priority = -1000)]
	public static void StartGame()
	{
		if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
		{
			EditorSceneManager.OpenScene(EditorBuildSettings.scenes[0].path);
			EditorApplication.isPlaying = true;
		}
	}

	[MenuItem("NoodleGore/OpenGameScene %.", priority = -1000)]
	public static void OpenGameScene()
	{
		if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
		{
			EditorSceneManager.OpenScene(EditorBuildSettings.scenes[1].path);
			//EditorApplication.isPlaying = true;
		}
	}
}
