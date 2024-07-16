using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Management
{
    public class OfflineValueManager : MonoBehaviour
    {
        [SerializeField] private Slider headCount;
        [SerializeField] private Slider horseCount;
        [SerializeField] private TextMeshProUGUI headCountText;
        [SerializeField] private TextMeshProUGUI horseCountText;
        
        private int _headCount;
        private int _horseCount;
        
        public int HeadCount
        {
            get => _headCount;
            set
            {
                _headCount = value;
                headCountText.text = $"{_headCount} / 4";
            }
        }
        
        public int HorseCount
        {
            get => _horseCount;
            set
            {
                _horseCount = value;
                horseCountText.text = $"{_horseCount} / 4";
            }
        }
        
        public static OfflineValueManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        public void Slider()
        {
            HeadCount = (int) headCount.value;
            HorseCount = (int) horseCount.value;
        }
    }
}