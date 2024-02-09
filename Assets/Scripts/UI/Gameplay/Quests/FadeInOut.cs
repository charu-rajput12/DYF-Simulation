using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    [Tooltip("the image you want to fade, assign in inspector")]
    [SerializeField] private Image img;
    public static FadeInOut instance;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        //StartCoroutine(FadeInAndOut());
        img.color = new Color(0, 0, 0, 0);
    }
    public void FadeInNOut()
    {
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }

        //Temp to Fade Out
        yield return new WaitForSeconds(1);

        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
}
