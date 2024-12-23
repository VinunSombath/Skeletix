using UnityEngine;
     
public class KeepSpriteInBounds : MonoBehaviour
{
    public RectTransform canvasPanel;

    private RectTransform playerRect;

    void Start()
    {
        playerRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 playerPosition = playerRect.localPosition;
        
        float canvasMinX = canvasPanel.rect.xMin + playerRect.rect.width / 2;
        float canvasMaxX = canvasPanel.rect.xMax - playerRect.rect.width / 2;

        float canvasMinY = canvasPanel.rect.yMin + playerRect.rect.height / 2;
        float canvasMaxY = canvasPanel.rect.yMax - playerRect.rect.height / 2;

        playerPosition.x = Mathf.Clamp(playerPosition.x, canvasMinX, canvasMaxX);
        playerPosition.y = Mathf.Clamp(playerPosition.y, canvasMinY, canvasMaxY);

        playerRect.localPosition = playerPosition;
    }
}
