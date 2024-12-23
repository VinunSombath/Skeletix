using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    public Slider progressSlider; // Assign via Inspector
    public string sceneToLoad = "HomeScene"; // Set your target scene name
    public Gradient gradient; // Assign a gradient via Inspector for the fill color
    public Image fillImage; // Reference to the slider's fill image

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        // Begin loading the scene asynchronously
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        
        // Prevent automatic activation until progress reaches 100%
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Update slider value based on loading progress
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            UpdateSliderColor(progress);

            // Allow scene activation when progress is complete
            if (operation.progress >= 0.9f)
            {
                progressSlider.value = 1.0f;
                UpdateSliderColor(1.0f); // Ensure the final color matches the gradient end
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    private void UpdateSliderColor(float progress)
    {
        // Update slider value and fill image color
        progressSlider.value = progress;
        fillImage.color = gradient.Evaluate(progress); // Color change based on progress
    }
}
