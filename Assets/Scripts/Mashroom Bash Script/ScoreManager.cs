using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    public static string winnerName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int player, int points)
    {
        if (player == 1)
        {
            player1Score += points;
        }
        else if (player == 2)
        {
            player2Score += points;
        }

        UpdateScoreUI();
    }

    public int GetPlayer1Score()
    {
        return player1Score;
    }

    public int GetPlayer2Score()
    {
        return player2Score;
    }

    public void DetermineWinner()
    {
        if (player1Score > player2Score)
        {
            winnerName = "1st Player Wins!";
        }
        else if (player2Score > player1Score)
        {
            winnerName = "2nd Player Wins!";
        }
        else
        {
            winnerName = "It's a Tie!";
        }
    }

    private void UpdateScoreUI()
    {
        player1ScoreText.text = "1st Player: " + player1Score;
        player2ScoreText.text = "2nd Player: " + player2Score;
    }
}
