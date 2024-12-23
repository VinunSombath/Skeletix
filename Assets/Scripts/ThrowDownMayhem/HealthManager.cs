using UnityEngine;
using System.Collections.Generic;

public class HealthManager : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>(); // List of heart objects in the order to be destroyed

    public void TakeDamage()
    {
        if (hearts.Count == 0) return; // No hearts left to destroy

        // Get the first heart and disable it
        GameObject heartToDestroy = hearts[0];
        hearts.RemoveAt(0); // Remove it from the list

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
        Debug.Log($"{gameObject.name} has no hearts left!");
        // Add your death handling logic here (e.g., respawn, game over)
    }
}
