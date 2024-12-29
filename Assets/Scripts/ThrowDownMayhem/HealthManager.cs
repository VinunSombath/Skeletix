using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>();
    public string playerName; // Name of the player
    public static string winnerName; // Name of the winner to display in the finish screen
    public static List<HealthManager> players = new List<HealthManager>(); // Tracks all players in the game

    private void Awake()
    {
        // Add this player to the list of players if not already added
        if (!players.Contains(this))
        {
            players.Add(this);
        }
    }

    public void TakeDamage()
    {
        if (hearts.Count == 0) return; // No hearts left to destroy

        GameObject heartToDestroy = hearts[0];
        hearts.RemoveAt(0);

        if (heartToDestroy != null)
        {
            heartToDestroy.SetActive(false);
        }

        // Check if there are no hearts left
        if (hearts.Count == 0)
        {
            PlayerDied();
        }
    }

    private void PlayerDied()
    {
        // Debug.Log($"{playerName} has no hearts left!");
        // players.Remove(this); // Remove the player from the active players list

        // Determine the winner (the last player left in the game)
        // if (players.Count == 1)
        // {
        //     winnerName = players[0].playerName; // The remaining player's name is the winner
        //     // Debug.Log($"{winnerName} wins!");
        // }
        // else
        // {
        //     winnerName = "No Winner"; // In case all players die simultaneously
        // }

        if(playerName == "1st Player"){
            winnerName = "2nd Player";
        }else {
            winnerName = "1st Player";
        }

        // Load the Finish Game scene
        SceneManager.LoadScene("End Throw Down Mayhem");
    }
}
