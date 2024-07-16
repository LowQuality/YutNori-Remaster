using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Management
{
    public class FadeManager : MonoBehaviour
    {
        [SerializeField] private Image fadeScreen;
        
        public static FadeManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        
        public void FadeOut(float targetAlpha, float duration)
        {
            fadeScreen.gameObject.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(FadeOutScreen(targetAlpha, duration));
        }
        
        public void FadeIn(float duration)
        {
            StopAllCoroutines();
            StartCoroutine(FadeInScreen(duration));
        }

        private IEnumerator FadeOutScreen(float targetAlpha, float duration)
        {
            if (Mathf.Approximately(duration, 0f))
            {
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, targetAlpha);
            }
            else
            {
                while (fadeScreen.color.a < targetAlpha)
                {
                    fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, fadeScreen.color.a + Time.deltaTime / duration);
                    yield return null;
                }
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, targetAlpha);
            }
        }

        private IEnumerator FadeInScreen(float duration)
        {
            if (Mathf.Approximately(duration, 0f))
            {
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 0.0f);
            }
            else
            {
                while (fadeScreen.color.a > 0.0f)
                {
                    fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, fadeScreen.color.a - Time.deltaTime / duration);
                    yield return null;
                }
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 0.0f);
            }
            fadeScreen.gameObject.SetActive(false);
        }
    }
}