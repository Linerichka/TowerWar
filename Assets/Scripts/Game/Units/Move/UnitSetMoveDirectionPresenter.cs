using System;
using System.Drawing;
using Unity.Mathematics;
using UnityEngine;

public class UnitSetMoveDirectionPresenter : MonoBehaviour
{
    [SerializeField] private UnitModel _unitModel;
    [SerializeField] private UnitMoveModel _moveModel;

    private void Update()
    {
        SetDirection();
    }

    private void SetDirection()
    {
        if (!(_unitModel.State == UnitModel.States.run_1 ||
            _unitModel.State == UnitModel.States.run_2))
        {
            _moveModel.DirectionToMove = _moveModel.DirectionNotMove;
            return;
        }
        _moveModel.DirectionToMove = GetDirection();
        SetUnitStateInDirection(_moveModel.DirectionToMove);
    }

    protected virtual Vector3 GetDirection()
    {
        Vector3 direction;
        int indexNearestPoint = 0;
        Vector3 unitPos = _unitModel.transform.position;
        float closestDistanceSqr = Mathf.Infinity;

        for (int i = 0; i < _moveModel.MapPointsForPath.Length; i++)
        {
            float distanceSqr = (_moveModel.MapPointsForPath[i].position - unitPos).sqrMagnitude;

            if (distanceSqr < closestDistanceSqr)
            {
                closestDistanceSqr = distanceSqr;
                indexNearestPoint = i;
            }
        }

        //точки пути начинаются от игрока, поэтому игрок двигается вперёд по ним, для ии наоборот
        if (_unitModel.Player)
        {
            direction = (_moveModel.MapPointsForPath[indexNearestPoint + 1].position - unitPos).normalized;
        }
        else
        {
            direction = (_moveModel.MapPointsForPath[indexNearestPoint - 1].position - unitPos).normalized;
        }

        return direction;
    }

    private void SetUnitStateInDirection(Vector3 direction)
    {
        if (direction.y > 0.1) _unitModel.State = UnitModel.States.run_2;
        else _unitModel.State = UnitModel.States.run_1;
    }
}
