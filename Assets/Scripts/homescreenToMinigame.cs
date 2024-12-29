using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // The name of the scene to load
    private string targetSceneName = "MiniGameScene";

    // This function is called when the button is pressed
    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
