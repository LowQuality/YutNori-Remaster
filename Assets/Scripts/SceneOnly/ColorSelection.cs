using System;
using System.Collections;
using Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneOnly
{
    public class ColorSelection : MonoBehaviour
    {
        [SerializeField] private RectTransform colorSelectionScreen;
        [SerializeField] private RectTransform informationScreen;
        [SerializeField] private float moveSpeed = 1f;
        private RectTransform _thisRectTransform;
        
        private void Start()
        {
            _thisRectTransform = gameObject.GetComponent<RectTransform>();
            StartCoroutine(AnimationStart());
        }
        
        public void GoTitleButton()
        {
            StartCoroutine(GoTitle());
        }

        private IEnumerator GoTitle()
        {
            StartCoroutine(DisableButtonScreen(colorSelectionScreen));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(DisableInformation(informationScreen));
            yield return new WaitForSeconds(0.5f);
            FadeManager.GlobalInstance.FadeOut(1f, 0.5f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("Title");
        }

        private IEnumerator AnimationStart()
        {
            FadeManager.GlobalInstance.FadeIn(1f);
            yield return new WaitForSeconds(0.75f);
            StartCoroutine(EnableButtonScreen(colorSelectionScreen));
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(EnableInformation(informationScreen));
        }

        private IEnumerator EnableInformation(RectTransform buttonScreen)
        {
            buttonScreen.SetAsLastSibling();
            buttonScreen.anchoredPosition = new Vector2(_thisRectTransform.rect.xMin + buttonScreen.rect.xMin, -225);
            buttonScreen.gameObject.SetActive(true);
            
            var startPos = new Vector3(_thisRectTransform.rect.xMin + buttonScreen.rect.xMin, -225, 0);
            var endPos = new Vector3(160, -225, 0);
            var time = 0f;
            var equation = 0f;

            while (equation < 1.0f)
            {
                time += Time.deltaTime * moveSpeed;
                equation = (float)Math.Sin(time) + 1 / 1000f;
                buttonScreen.anchoredPosition = Vector3.Lerp(startPos, endPos, equation);
                yield return null;
            }
        }
        
        private IEnumerator DisableInformation(RectTransform buttonScreen)
        {
            var startPos = new Vector3(160, -225, 0);
            var endPos = new Vector3(_thisRectTransform.rect.xMin + buttonScreen.rect.xMin, -225, 0);
            var time = 0f;
            var equation = 0f;
        
            while (equation < 1.0f)
            {
                time += Time.deltaTime * moveSpeed / 2;
                equation = (float)Math.Sin(time) + 1 / 1000f;
                buttonScreen.anchoredPosition = Vector3.Lerp(startPos, endPos, equation);
                yield return null;
            }
            buttonScreen.gameObject.SetActive(false);
        }
        
        private IEnumerator EnableButtonScreen(RectTransform buttonScreen)
        {
            FadeManager.Instance.transform.SetAsLastSibling();
            FadeManager.Instance.FadeOut(0.5f, 1f);
            buttonScreen.SetAsLastSibling();
            buttonScreen.anchoredPosition = new Vector2(0, _thisRectTransform.rect.yMin + buttonScreen.rect.yMin);
            buttonScreen.gameObject.SetActive(true);
        
            var startPos = new Vector3(0, _thisRectTransform.rect.yMin + buttonScreen.rect.yMin, 0);
            var endPos = new Vector3(0, 0, 0);
            var time = 0f;
            var equation = 0f;

            while (equation < 1.0f)
            {
                time += Time.deltaTime * moveSpeed;
                equation = (float)Math.Sin(time) + 1 / 1000f;
                buttonScreen.anchoredPosition = Vector3.Lerp(startPos, endPos, equation);
                yield return null;
            }
        }
    
        private IEnumerator DisableButtonScreen(RectTransform buttonScreen)
        {
            FadeManager.Instance.FadeIn(0.5f);
            var startPos = new Vector3(0, 0, 0);
            var endPos = new Vector3(0, _thisRectTransform.rect.yMin + buttonScreen.rect.yMin, 0);
            var time = 0f;
            var equation = 0f;
        
            while (equation < 1.0f)
            {
                time += Time.deltaTime * moveSpeed;
                equation = (float)(Math.Sin(time) + 1 / 1000f);
                buttonScreen.anchoredPosition = Vector3.Lerp(startPos, endPos, equation);
                yield return null;
            }
            buttonScreen.gameObject.SetActive(false);
        }
    }
}