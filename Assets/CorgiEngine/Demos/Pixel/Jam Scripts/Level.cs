using MoreMountains.CorgiEngine;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // This part is only for the Editor so you can drag & drop
#if UNITY_EDITOR
    [Tooltip("Drag your scene here")]
    public UnityEditor.SceneAsset sceneAsset;
#endif

    // This is the variable the game actually uses
    [HideInInspector]
    public string sceneName;

    // This runs automatically in the Editor whenever you change values
    private void OnValidate()
    {
#if UNITY_EDITOR
        if (sceneAsset != null)
        {
            sceneName = sceneAsset.name;
        }
#endif
    }

    public LevelManager levelManager;

    public void LoadLevel()
    {
        // 1. Check if the scene name is valid
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("No scene assigned!");
            return;
        }

        // 2. Load the scene using the string name
        CorgiEngineEvent.Trigger(CorgiEngineEventTypes.UnPause);
        MMTimeScaleEvent.Trigger(MMTimeScaleMethods.Reset, 1f, 0f, false, 0f, true);
        SceneManager.LoadScene(sceneName);

       // levelManager.GotoLevel(sceneName, true, false);
    }

}
