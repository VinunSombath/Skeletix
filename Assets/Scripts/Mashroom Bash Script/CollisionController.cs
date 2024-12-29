using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public int playerId;
    public int goldPoints = 20;
    public int mushroomPoints = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mushroom"))
        {
            
            Destroy(collision.gameObject);

            if (gameObject.CompareTag("Player1"))
            {
                ScoreManager.instance.AddScore(1, mushroomPoints);
            }
            else if (gameObject.CompareTag("Player2"))
            {
                ScoreManager.instance.AddScore(2, mushroomPoints);
            }
        }
        else if (collision.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);

            if (gameObject.CompareTag("Player1"))
            {
                ScoreManager.instance.AddScore(1, goldPoints);
            }
            else if (gameObject.CompareTag("Player2"))
            {
                ScoreManager.instance.AddScore(2, goldPoints);
            }
        }
    }

}
