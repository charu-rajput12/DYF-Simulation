using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    public float fadeDuration = 5; // Duration of the fade-in and fade-out in seconds
    private CanvasGroup canvasGroup;

    void Start()
    {
        // Ensure there is a CanvasGroup component attached to the GameObject
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // Start with a fully transparent canvas (alpha = 0)
        canvasGroup.alpha = 0f;

        // Start the fade-in process
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += Time.deltaTime / fadeDuration;
            yield return null;
        }

        // Ensure alpha is exactly 1 at the end
        canvasGroup.alpha = 1f;

        // Wait for a moment (optional)
        yield return new WaitForSeconds(1.0f);

        // Start the fade-out process
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeDuration;
            yield return null;
        }

        // Ensure alpha is exactly 0 at the end
        canvasGroup.alpha = 0f;

        // Do something after the fade-out if needed

        // Destroy or disable the GameObject (optional)
        // gameObject.SetActive(false);

        // Alternatively, you can load a new scene or perform any other action

        // For now, let's destroy the script component (optional)
        //Destroy(this);
    }
}
