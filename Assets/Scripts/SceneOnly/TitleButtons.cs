using System;
using System.Collections;
using Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneOnly
{
    public class TitleButtons : MonoBehaviour
    {
        [SerializeField] private RectTransform onlineButtonScreen;
        [SerializeField] private RectTransform offlineButtonScreen;
        [SerializeField] private RectTransform settingsButtonScreen;
        [SerializeField] private float moveSpeed = 1f;
        private RectTransform _thisRectTransform;
        private RectTransform _enabled;

        private void Start()
        {
            _thisRectTransform = gameObject.GetComponent<RectTransform>();
            FadeManager.GlobalInstance.FadeIn(0.5f);
        }

        public void OnlineButton()
        {
            StartCoroutine(EnableButtonScreen(onlineButtonScreen));
        }
    
        public void OfflineButton()
        {
            
            StartCoroutine(EnableButtonScreen(offlineButtonScreen));
        }
    
        public void SettingsButton()
        {
            StartCoroutine(EnableButtonScreen(settingsButtonScreen));
        }
    
        public void CloseButton()
        {
            StartCoroutine(DisableButtonScreen(_enabled));
        }

        public void StartOfflineGameButton()
        {
            StartCoroutine(StartOfflineGame());
        }
    
        private IEnumerator EnableButtonScreen(RectTransform buttonScreen)
        {
            FadeManager.Instance.transform.SetAsLastSibling();
            FadeManager.Instance.FadeOut(0.5f, 1f);
            buttonScreen.SetAsLastSibling();
            buttonScreen.anchoredPosition = new Vector2(0, _thisRectTransform.rect.yMin + buttonScreen.rect.yMin);
            buttonScreen.gameObject.SetActive(true);
            _enabled = buttonScreen;
        
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
                time += Time.deltaTime * moveSpeed * 2;
                equation = (float)(Math.Sin(time) + 1 / 1000f);
                buttonScreen.anchoredPosition = Vector3.Lerp(startPos, endPos, equation);
                yield return null;
            }
            buttonScreen.gameObject.SetActive(false);
        }
    
        private IEnumerator StartOfflineGame()
        {
            StartCoroutine(DisableButtonScreen(offlineButtonScreen));
            FadeManager.GlobalInstance.FadeOut(1f, 0.5f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("ColorSelection");
        }
    }
}
