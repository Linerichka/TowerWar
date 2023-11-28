using System;
using UnityEngine;

public class UnitMoveModel : MonoBehaviour
{
    public Action<Vector3> DirectionToMoveChanged;
    private Vector3 _directionToMove;
    public Vector3 DirectionToMove
    {
        get => _directionToMove;
        set
        {
            if (value == DirectionToMove) return;

            _directionToMove = value;
            DirectionToMoveChanged?.Invoke(value);

            if (value != DirectionNotMove) DirectionToMoveLast = value;
        }
    }
    public Vector3 DirectionToMoveLast;

    public Vector3 DirectionNotMove = Vector3.zero;
    public Transform UnitToMove;
    public int ConuntFrameLastMove;
    public Transform[] MapPointsForPath;
}
