using Boards;
using UnityEngine;

public class UnitAISpawnPresenter : UnitSpawnPresenter
{
    private void OnEnable()
    {
        _model.UnitCanBeCreatedChanged += UnitCanBeCreatedHandler;
    }

    private void OnDisable()
    {
        _model.UnitCanBeCreatedChanged -= UnitCanBeCreatedHandler;
    }

    private void UnitCanBeCreatedHandler(bool canCreated)
    {
        //прокладка для подписки на событие, переменная unitTypeToSpawn будет изменена,
        //поэтому её значение на момент вызова может быть любым
        SpawnLogic(0); 
    }

    protected override GameObject SpawnLogic(Eneme.EnemeTypes unitTypeToSpawn)
    {
        UnitAISpawnModel model = (UnitAISpawnModel)_model;
       
        if (model.WaveID >= model.WaveConfiguration.WaveConfig.Length) return null;

        WaveConfiguration.WaveAndUnitTypeAndCountUnit unitTupeAndCount =
            model.WaveConfiguration.WaveConfig[model.WaveID];


        unitTypeToSpawn = unitTupeAndCount.Type;
        model.UnitCreatedInWave++;

        if (unitTupeAndCount.CountUnit < model.UnitCreatedInWave)
        {
            model.UnitCreatedInWave = 0;
            model.WaveID++;
        }

        if (model.WaveID == model.WaveConfiguration.WaveConfig.Length - 1) LevelBoard.UnitsCreateRunOut?.Invoke();

        return base.SpawnLogic(unitTypeToSpawn);
    }

    protected override void SetUnitModelValueAfterSpawn(GameObject unit)
    {
        base.SetUnitModelValueAfterSpawn(unit);
        unit.GetComponent<UnitModel>().Player = false;
    }
}
