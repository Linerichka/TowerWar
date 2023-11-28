
public class UnitAISpawnModel : UnitSpawnModel
{
    public WaveConfiguration WaveConfiguration;
    //waveId - индекс последнего элемента из конфигурации волн, который был создан
    public int WaveID;
    //количество созданных юнитов на текущей волне
    public int UnitCreatedInWave;
}
