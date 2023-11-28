using UnityEngine;
using Boards;
using System.Linq;

public class UnitSpawnPresenter : MonoBehaviour
{
    [SerializeField] protected UnitSpawnModel _model;

    protected virtual GameObject SpawnLogic(Eneme.EnemeTypes unitTypeToSpawn)
    {
        if (!_model.UnitCanBeCreated) return null;

        return SpawnUnit(unitTypeToSpawn);
    }

    private GameObject SpawnUnit(Eneme.EnemeTypes unitTypeToSpawn)
    {
        GameObject unit = Instantiate((from tg in _model.UnitToSpawn 
                                      where tg.Type == unitTypeToSpawn
                                      select tg.Eneme).Single(), 
            _model.SpawnPoint.position, _model.SpawnPoint.rotation, _model.ParentToSpawn);

        _model.UnitCanBeCreated = false;
        _model.TimeLastCreation = 0;
        SetUnitModelValueAfterSpawn(unit.transform.GetChild(0).gameObject);
        UnitSpawnBoard.UnitSpawn?.Invoke(_model.SpawnPoint.position, unit, unitTypeToSpawn);
        return unit;
    }
    protected virtual void SetUnitModelValueAfterSpawn(GameObject unit)
    {
        if (unit == null) return;
    }
}
