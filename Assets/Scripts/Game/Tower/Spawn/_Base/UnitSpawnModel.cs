using System;
using UnityEngine;

public class UnitSpawnModel : MonoBehaviour
{
    public float TimeBetweenSpawn = 1;

    [SerializeField] private float _timeLastCreation = 0;
    public float TimeLastCreation
    {
        get => _timeLastCreation;
        set
        {
            _timeLastCreation = value;
            SetTimeLastCreation(value);
        }
    }
    public Transform SpawnPoint;
    public UnitTypeAndGameObject[] UnitToSpawn;
    public Transform ParentToSpawn;

    public Action<bool> UnitCanBeCreatedChanged;
    private bool _unitCanBeCreated;
    public bool UnitCanBeCreated
    {
        get => _unitCanBeCreated;      
        set
        {
            _unitCanBeCreated = value;
            UnitCanBeCreatedChanged?.Invoke(value);
        }
    }

    [System.Serializable]
    public struct UnitTypeAndGameObject
    {
        public Eneme.EnemeTypes Type;
        public GameObject Eneme;
    }

    private void OnValidate()
    {
        TimeLastCreation = _timeLastCreation;
    }

    protected virtual void SetTimeLastCreation(float newValue)
    {
        
    }
}
