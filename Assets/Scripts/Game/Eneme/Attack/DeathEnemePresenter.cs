using Boards;
using UnityEngine;

public class DeathEnemePresenter : MonoBehaviour
{
    [SerializeField] EnemeAttackModel _attackModel;
    [SerializeField] DeathEnemeModel _deathEnemyModel;
    private void OnEnable()
    {
        AttackBoard.EnemeNullHP += ChangeUnitState;
    }
    private void OnDisable()
    {
        AttackBoard.EnemeNullHP += ChangeUnitState;
    }

    private void ChangeUnitState(EnemeAttackModel attackModel)
    {
        if (attackModel != this._attackModel) return;

        attackModel.EnemeModel.State = EnemeModel.States.death_1;
        AfterDeath(attackModel);
    }

    protected virtual void AfterDeath(EnemeAttackModel attackModel)
    {
        AttackBoard.EnemeDead?.Invoke(attackModel.transform.position);
        _deathEnemyModel.HealthBar.SetActive(false);
        attackModel.OtherEnemeAttackModel = new();
        Destroy(_deathEnemyModel.Collider);
    }
}
