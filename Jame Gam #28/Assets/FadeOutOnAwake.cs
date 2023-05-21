using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutOnAwake : MonoBehaviour
{
    public Image imageToFade;
    public float fadeDuration = 1.0f;

    void Awake()
    {
        // Ensure that the required components are attached
        if (imageToFade == null)
        {
            Debug.LogError("Image to fade is not assigned!");
            return;
        }

        // Set the initial alpha value to 1 (fully opaque)
        Color initialColor = imageToFade.color;
        initialColor.a = 1f;
        imageToFade.color = initialColor;

        // Start the fading coroutine
        StartCoroutine(FadeOut());
    }

    private void Update()
    {
        if (imageToFade.color.a == 0f)
        {
            var tempColor = imageToFade.color;
            tempColor.a = 1f;
            imageToFade.color = tempColor;
            this.gameObject.SetActive(false);
        }          
    }

    private System.Collections.IEnumerator FadeOut()
    {
        // Wait for a short delay before starting the fade
        yield return new WaitForSeconds(0.5f);

        // Calculate the target color with alpha set to 0 (fully transparent)
        Color targetColor = imageToFade.color;
        targetColor.a = 0f;

        // Calculate the rate at which the image will fade
        float fadeRate = 1.0f / fadeDuration;

        // Gradually decrease the alpha value of the image until it reaches 0
        while (imageToFade.color.a > 0f)
        {
            Color currentColor = imageToFade.color;
            currentColor.a -= fadeRate * Time.deltaTime;
            imageToFade.color = currentColor;
            yield return null;
        }

        // Ensure the image is fully transparent at the end
        Color finalColor = imageToFade.color;
        finalColor.a = 0f;
        imageToFade.color = finalColor;
    }
}
