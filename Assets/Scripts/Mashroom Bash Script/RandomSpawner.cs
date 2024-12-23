using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public RectTransform canvasRect;
    public float spawnInterval = 1f;
    public float spawnDuration = 59f; 

    private float timer = 0f;
    private List<GameObject> spawnedObjects = new List<GameObject>(); 



    void Start()
    {
        InvokeRepeating("SpawnRandomObject", 0f, spawnInterval);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Stop spawning object
        if (timer >= spawnDuration)
        {
            CancelInvoke("SpawnRandomObject");
            HideAllSpawnedObjects();
        }
    }

    void SpawnRandomObject()
    {
        GameObject randomObject = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

        Vector2 randomPosition = GetRandomPositionInCanvas();

        GameObject spawnedObject = Instantiate(randomObject, canvasRect);
        spawnedObject.transform.localPosition = randomPosition;

        spawnedObjects.Add(spawnedObject);

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

    void HideAllSpawnedObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
