using UnityEngine;
using UnityEngine.Localization.Components;

namespace StringManager
{
    public class VersionInformation : MonoBehaviour
    {
        [SerializeField] private LocalizeStringEvent versionLse;

        private static bool _isGlobal;
        public string version;

        private void Start()
        {
            if (_isGlobal)
            {
                Destroy(gameObject);
            }
            else
            {
                _isGlobal = true;
                DontDestroyOnLoad(gameObject);
            }
            
            version = Application.version;
            versionLse.StringReference.RefreshString();
        }
    }
}