using Boards;
using UnityEngine;

public class SetMapPointInUnitMoveModelPresenter : MonoBehaviour
{
    [SerializeField] Transform[] _mapPoints;

    private void OnEnable()
    {
        UnitSpawnBoard.UnitSpawn += SetMapPointsInUnitMoveModel;
    }

    private void OnDisable()
    {
        UnitSpawnBoard.UnitSpawn -= SetMapPointsInUnitMoveModel;
    }

    private void SetMapPointsInUnitMoveModel(Vector3 pos, GameObject unit, Eneme.EnemeTypes type)
    {
        UnitMoveModel unitMoveModel = unit.transform.GetChild(0).GetComponent<UnitMoveModel>();
        unitMoveModel.MapPointsForPath = _mapPoints;
    }
}
