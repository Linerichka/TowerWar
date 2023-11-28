using UnityEngine;
using static UnitPlayerSpawnModel;

public class UnitPlayerSpawnPresenter : UnitSpawnPresenter
{

    protected void OnEnable()
    {
        foreach (ButtonsToUnit buttonsToUnit in ((UnitPlayerSpawnModel)_model).Buttons)
        {
            buttonsToUnit.Button.onClick.AddListener(() => SpawnLogic(buttonsToUnit.Type));
        }
    }

    protected override GameObject SpawnLogic(Eneme.EnemeTypes unitTypeToSpawn)
    {
        return base.SpawnLogic(unitTypeToSpawn);
    }

    protected override void SetUnitModelValueAfterSpawn(GameObject unit)
    {
        base.SetUnitModelValueAfterSpawn(unit);
        unit.GetComponent<UnitModel>().Player = true;
    }
}
