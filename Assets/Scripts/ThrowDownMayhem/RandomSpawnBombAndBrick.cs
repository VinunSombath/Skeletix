using UnityEngine;

public class RandomSpawnBombAndBrick : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject brickPrefab; 
    public RectTransform canvasRect;

    public float bombSpawnInterval = 4f;
    public float brickSpawnInterval = 2f;

    void Start()
    {
        InvokeRepeating("SpawnBomb", 0f, bombSpawnInterval);
        InvokeRepeating("SpawnBrick", 0f, brickSpawnInterval);
    }


    void SpawnBomb()
    {
        SpawnObject(bombPrefab);
    }

    void SpawnBrick()
    {
        SpawnObject(brickPrefab);
    }

    void SpawnObject(GameObject prefab)
    {
        if (prefab == null) return;

        Vector2 randomPosition = GetRandomPositionInCanvas();

        GameObject spawnedObject = Instantiate(prefab, canvasRect);
        spawnedObject.transform.localPosition = randomPosition;
        // spawnedObject.transform.SetParent(null);

        Rigidbody2D rb = spawnedObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0;
        }
    }

    Vector2 GetRandomPositionInCanvas()
    {
        Vector2 minPosition = canvasRect.rect.min;
        Vector2 maxPosition = canvasRect.rect.max;

        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomY = Random.Range(minPosition.y, maxPosition.y);

        return new Vector2(randomX, randomY);
    }
}