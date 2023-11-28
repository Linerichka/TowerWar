using System;
using UnityEngine;
using Boards;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemeAttackModel : MonoBehaviour
{
    public EnemeModel EnemeModel;
    public Slider HealthBarView;
    public Action<int> EnemeHPChanged;
    [SerializeField] private int _enemeHP;
    public int EnemeHP
    {
        get => _enemeHP;
        set
        {
            if (value >= _enemeHP)
            {
                _enemeHP = value;
                HealthBarView.maxValue = value;
                HealthBarView.value = value;
                return;
            }

            if (value <= 0)
            {
                _enemeHP = 0;

                if (!(EnemeModel.State == EnemeModel.States.death_1 ||
                    EnemeModel.State == EnemeModel.States.death_2))
                {
                    AttackBoard.EnemeNullHP?.Invoke(this);
                }
                
            }
            else _enemeHP = value;

            EnemeHPChanged?.Invoke(value);
            HealthBarView.value = _enemeHP;
        }
    }

    public Action<bool> EnemeCanAttackChanged;
    private bool _enemeCanAttack;
    public bool EnemeCanAttack
    {
        get => _enemeCanAttack;
        set
        {
            _enemeCanAttack = value;
            EnemeCanAttackChanged?.Invoke(value);
        }
    }

    public bool EnemyNear = false;
    public List <EnemeAttackModel> OtherEnemeAttackModel = new List<EnemeAttackModel>();
    public string AiTag = "AI";
    public string PlayerTag = "Player";
    public float TimeSinceLastAttack;
    //если в скриптейбле нету такого типа существа по которому наносится урон, то будет пременено это значение
    public float BaseRatioDamage = 1f;
}
