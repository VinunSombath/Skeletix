using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Method to load Mushroom Bash scene
    public void LoadMushroomBash()
    {
        SceneManager.LoadScene("Mushroom Bash");
    }

    // Method to load ThrowDownMayhem scene
    public void LoadThrowDownMayhem()
    {
        SceneManager.LoadScene("ThrowDownMaythem");
    }

    // Method to load back to homepage scene
    public void loadHomePage()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
