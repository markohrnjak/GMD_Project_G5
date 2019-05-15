using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour
{
    //-- this class is from the internet, it fades in or out whatever you like, 
    //-- attach it to object with an image (it is now attached to a panel with a black image)

    #region FIELDS
    public Image fadeOutUIImage;
    public float fadeSpeed = 0.8f;
    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }
    #endregion
    #region MONOBHEAVIOR
    void OnEnable()
    {
        StartCoroutine(FadeImage(FadeDirection.In));
    }
    #endregion
    #region FADE
    private IEnumerator FadeImage(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.In) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.In) ? 0 : 1;
        if (fadeDirection == FadeDirection.In)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }
    #endregion
    #region HELPERS
    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, string sceneToLoad)
    {
        yield return FadeImage(fadeDirection);
        SceneManager.LoadScene(sceneToLoad);
    }
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.In) ? -1 : 1);
    }
    #endregion
}