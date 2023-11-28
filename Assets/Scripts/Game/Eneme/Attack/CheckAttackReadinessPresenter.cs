using Boards;
using UnityEngine;

public class CheckAttackReadinessPresenter : MonoBehaviour
{
    [SerializeField] private EnemeAttackModel _attackModel;
    [SerializeField] private EnemeModel _enemeModel;
    private bool _levelEnd;

    private void OnEnable()
    {
        LevelBoard.LevelEnd += LevelEndSetBool;
    }

    private void OnDisable()
    {
        LevelBoard.LevelEnd -= LevelEndSetBool;
    }
    private void Start()
    {
        SetEnemeTag();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckCollision(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckCollision(collision, false);
    }

    private void CheckCollision(Collider2D collision, bool enemeNear = true)
    {
        if (gameObject.CompareTag(_attackModel.PlayerTag))
        {
            if (!collision.CompareTag(_attackModel.AiTag)) return;
        }
        else if (gameObject.CompareTag(_attackModel.AiTag))
        {
            if (!collision.CompareTag(_attackModel.PlayerTag)) return;
        }
        else return;

        _attackModel.EnemyNear = enemeNear;
        EnemeAttackModel collisionAttackModel = collision.GetComponent<EnemeAttackModel>();
        ChangedState(enemeNear);

        if (enemeNear)
        {
            if (OtherEnemeAttackModelContainsAttackModel(_attackModel, collisionAttackModel)) return;

            _attackModel.OtherEnemeAttackModel.Add(collisionAttackModel);
        }
        else
        {
            if (!OtherEnemeAttackModelContainsAttackModel(_attackModel, collisionAttackModel)) return;

            _attackModel.OtherEnemeAttackModel.Remove(_attackModel.OtherEnemeAttackModel.Find(x => collisionAttackModel == x));
        }
    }

    private bool OtherEnemeAttackModelContainsAttackModel(EnemeAttackModel attackModel, EnemeAttackModel otherAttackModel) 
    {
        return attackModel.OtherEnemeAttackModel.Contains(otherAttackModel);
    }

    protected virtual void ChangedState(bool enemeNear)
    {
        if (_enemeModel.State == EnemeModel.States.death_1 ||
            _enemeModel.State == EnemeModel.States.death_2 || 
            _levelEnd)
        {
            return;
        }

        if (enemeNear) _enemeModel.State = EnemeModel.States.attack_1;      
        else _enemeModel.State = EnemeModel.States.idle_1;
    }

    private void SetEnemeTag()
    {
        if (_enemeModel.Player) _enemeModel.gameObject.tag = _attackModel.PlayerTag;
        else _enemeModel.gameObject.tag = _attackModel.AiTag;
    }

    private void LevelEndSetBool() => _levelEnd = true;
}
