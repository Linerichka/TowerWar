using UnityEngine;

public class UnitPresenter : MonoBehaviour
{
    [SerializeField] private UnitModel _model;

    void Start()
    {
        SetValue();
    }

    private void SetValue()
    {
        SetStartUnitState();
    }

    private void SetStartUnitState()
    {
        _model.State = UnitModel.States.run_1;
    }
}
