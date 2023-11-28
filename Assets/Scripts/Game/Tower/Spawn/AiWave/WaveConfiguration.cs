using UnityEngine;

[CreateAssetMenu(fileName = "LevelWaveConfig", menuName = "ScriptableObjects/LevelWaveConfig", order = 2)]
public class WaveConfiguration : ScriptableObject
{
    public WaveAndUnitTypeAndCountUnit[] WaveConfig;

    [System.Serializable]
    public struct WaveAndUnitTypeAndCountUnit
    {
        public Eneme.EnemeTypes Type;
        public int CountUnit;
    }
}
