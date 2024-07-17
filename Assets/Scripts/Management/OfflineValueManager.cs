using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Management
{
    public class OfflineValueManager : MonoBehaviour
    {
        [SerializeField] private Slider headCount;
        [SerializeField] private Slider horseCount;
        [SerializeField] private Slider botCount;
        [SerializeField] private TextMeshProUGUI headCountText;
        [SerializeField] private TextMeshProUGUI horseCountText;
        [SerializeField] private TextMeshProUGUI botCountText;
        [SerializeField] private TextMeshProUGUI simulationSpeed;
        
        public static int HeadCountV = 1;
        public static int HorseCountV = 1;
        public static int BotCountV;
        public static int SimulationSpeedV = 1;
        public static List<string> PickColor = new();

        private static bool _disableSlider;

        private int HeadCount
        {
            get => HeadCountV;
            set
            {
                HeadCountV = value;
                headCount.value = value;
                headCountText.text = $"{value} / 4";
            }
        }
        
        private int HorseCount
        {
            get => HorseCountV;
            set
            {
                HorseCountV = value;
                horseCount.value = value;
                horseCountText.text = $"{value} / 4";
            }
        }
        
        private int BotCount
        {
            get => BotCountV;
            set
            {
                BotCountV = value;
                botCount.value = value;
                botCountText.text = $"{value} / 3";
            }
        }
        
        private int SimulationSpeed
        {
            get => SimulationSpeedV;
            set
            {
                if (value is < 1 or > 4) return;
                SimulationSpeedV = value;
                simulationSpeed.text = $"x{value}";
            }
        }

        private void Start()
        {
            _disableSlider = true;
            HeadCount = HeadCountV;
            HorseCount = HorseCountV;
            BotCount = BotCountV;
            SimulationSpeed = SimulationSpeedV;
            _disableSlider = false;
        }

        public void Slider()
        {
            if (_disableSlider) return;
            if (headCount.value + botCount.value > 4)
            {
                if (!Mathf.Approximately(HeadCount, headCount.value))
                {
                    BotCount = (int)(botCount.value - 1);
                }
                else if (!Mathf.Approximately(BotCount, botCount.value))
                {
                    HeadCount = (int)(headCount.value - 1);
                }
            }
            
            HeadCount = (int) headCount.value;
            HorseCount = (int) horseCount.value;
            BotCount = (int) botCount.value;
        }
        
        public void SimulationSpeedUpButton()
        {
            SimulationSpeed++;
        }
        
        public void SimulationSpeedDownButton()
        {
            SimulationSpeed--;
        }
    }
}