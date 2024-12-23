using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public float gameDuration = 10f; 
    private float timeRemaining;

    void Start()
    {
        timeRemaining = gameDuration;
    }

    void Update()
    {
        if (timeRemaining > 1)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }   
        else
        {
            EndGame();
        }
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.FloorToInt(timeRemaining);
        timerText.text = seconds.ToString(); 
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
    }
}
