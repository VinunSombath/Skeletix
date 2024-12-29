using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FinishGameManager : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    private void Start()
    {
        if (winnerText != null)
        {
            winnerText.text = ScoreManager.winnerName;
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Mushroom Bash");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("HomeScene");
    }
}
