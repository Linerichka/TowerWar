using System.Linq;
using UnityEngine;

public class EnemeAttackPresenter : MonoBehaviour
{
    [SerializeField] private EnemeAttackModel _attackModel;
    [SerializeField] private EnemeModel _enemeModel;

    private void Start()
    {
        SetValue();
    }

    private void Update()
    {
        IncreaseTimeSinceLastAttack();
        CheckCanAttackTime();
    }

    private void IncreaseTimeSinceLastAttack()
    {
        _attackModel.TimeSinceLastAttack += Time.deltaTime;
    }

    private void CheckCanAttackTime()
    {
        if (!(_attackModel.EnemeModel.State == EnemeModel.States.attack_1 ||
            _attackModel.EnemeModel.State == EnemeModel.States.attack_1))
        {
            return;
        }
        if (!(_attackModel.TimeSinceLastAttack >= (1f / _enemeModel.Eneme.AtackSpeed)) || !_attackModel.EnemyNear) return;
        

        _attackModel.TimeSinceLastAttack = 0;
        _attackModel.EnemeCanAttack = true;
        Attack();
    }

    private void Attack()
    {
        EnemeAttackModel attackModel = _attackModel.OtherEnemeAttackModel[0];
        attackModel.EnemeHP -= (int)(_enemeModel.Eneme.DamageBase * GetDamageRatioByEnemeType(attackModel));
    }

    protected virtual float GetDamageRatioByEnemeType(EnemeAttackModel attackModel)
    {
        Eneme unit = attackModel.GetComponent<EnemeModel>().Eneme;
        float damageRatioOnClass =
            (from r in _attackModel.EnemeModel.Eneme.DamageRatio where unit.EnemeType == r.EnemeType select r.DamageRation)
            .DefaultIfEmpty(_attackModel.BaseRatioDamage).SingleOrDefault();
        return damageRatioOnClass;
    }

    private void SetValue()
    {
        _attackModel.EnemeHP = _enemeModel.Eneme.Health;
    }
}
