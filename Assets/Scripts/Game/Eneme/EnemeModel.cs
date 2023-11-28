using System;
using UnityEngine;

public class EnemeModel : MonoBehaviour
{
    public Eneme Eneme;
    public bool Player;

    public Action<States> StateChanged;
    [SerializeField] private States _state;
    public States State
    {
        get => _state;
        set
        {
            if (_state == value) return;

            //Debug.LogWarning(value, this);
            _state = value;
            StateChanged?.Invoke(value);
        }
    }
    public enum States
    {
        attack_1,
        attack_2,
        death_1,
        death_2,
        idle_1,
        idle_2,
        run_1,
        run_2,
    }
}
