using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public int goldPoints = 20;       
    public int mushroomPoints = 10;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Mushroom"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.AddScore(mushroomPoints);
           

        }
        else if (collision.CompareTag("Gold"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.AddScore(goldPoints);
            
        }
    }
}
