using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float gameDuration = 60f;
    private float timeRemaining;

    public AudioSource gameAudio;

    private void Start()
    {
        timeRemaining = gameDuration;

       
        if (gameAudio != null)
        {
            gameAudio.Play();
        }
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            EndGame();
        }
    }

    private void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = seconds.ToString();
    }

    private void EndGame()
    {
        timeRemaining = 0;
        timerText.text = "0";

        if (gameAudio != null && gameAudio.isPlaying)
        {
            gameAudio.Stop();
        }

        ScoreManager.instance.DetermineWinner();

        SceneManager.LoadScene("Finish Game");
    }
}
