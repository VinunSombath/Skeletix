using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    // Static variable to hold the winner's name

    private void Start()
    {
        // Display the winner's name
        Debug.Log(HealthManager.winnerName);
        if (winnerText != null)
        {
            winnerText.text = $"{HealthManager.winnerName} win!";
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("ThrowDownMaythem");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
