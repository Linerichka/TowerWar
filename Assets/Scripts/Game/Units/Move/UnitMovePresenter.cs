using System.Collections;
using UnityEngine;

public class UnitMovePresenter : MonoBehaviour
{
    [SerializeField] private UnitModel _unitModel;
    [SerializeField] private UnitMoveModel _moveModel;


    private void OnEnable()
    {
        _moveModel.DirectionToMoveChanged += LastMoveUnitInDirection;
    }
    private void OnDisable()
    {
        _moveModel.DirectionToMoveChanged -= LastMoveUnitInDirection;
    }

    void Update()
    {
        MoveUnitInDirection(_moveModel.DirectionToMove);
    }

    private void MoveUnitInDirection(Vector3 moveDirection)
    {
        Vector3 unitPosition = _moveModel.UnitToMove.position;
        Vector3 unitNewPosition = unitPosition + (moveDirection * _unitModel.Eneme.Speed * Time.deltaTime);
        _moveModel.UnitToMove.position = unitNewPosition;
    }

    //пусть подвинутся чтобы далеко друг от друга не стояли
    private void LastMoveUnitInDirection(Vector3 moveDirection)
    {
        if (moveDirection != _moveModel.DirectionNotMove) return;

        StartCoroutine(MoveUnitEveryFrame());
    }

    private IEnumerator MoveUnitEveryFrame()
    {
        for (int i = 0; i < _moveModel.ConuntFrameLastMove; i++)
        {
            yield return new WaitForEndOfFrame();
            MoveUnitInDirection(_moveModel.DirectionToMoveLast);
        }
    }
}
