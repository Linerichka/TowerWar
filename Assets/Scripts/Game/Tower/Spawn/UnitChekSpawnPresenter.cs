using UnityEngine;

public class UnitChekSpawnPresenter : MonoBehaviour
{
    [SerializeField] private UnitSpawnModel _model;

    void Update()
    {
        ChekTimeForSpawn();
    }

    private void ChekTimeForSpawn()
    {
        _model.TimeLastCreation += Time.deltaTime;

        if (_model.TimeBetweenSpawn > _model.TimeLastCreation) return;

        _model.UnitCanBeCreated = true;
    }

}
