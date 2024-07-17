using Management;
using UnityEngine;
using UnityEngine.Localization.Components;

public class GameInformation : MonoBehaviour
{
    [SerializeField] private LocalizeStringEvent headCountLse;
    [SerializeField] private LocalizeStringEvent horseCountLse;
    [SerializeField] private LocalizeStringEvent botCountLse;
    [SerializeField] private LocalizeStringEvent simulationSpeedLse;

    public int headCount;
    public int horseCount;
    public int botCount;
    public int simulationSpeed;

    private void Start()
    {
        headCount = OfflineValueManager.HeadCountV;
        horseCount = OfflineValueManager.HorseCountV;
        botCount = OfflineValueManager.BotCountV;
        simulationSpeed = OfflineValueManager.SimulationSpeedV;
        
        headCountLse.StringReference.RefreshString();
        horseCountLse.StringReference.RefreshString();
        botCountLse.StringReference.RefreshString();
        simulationSpeedLse.StringReference.RefreshString();
    }
}