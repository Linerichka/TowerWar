using UnityEngine;
using Boards;

public class EnemeStateChangerPresenter : MonoBehaviour
{
    [SerializeField] private EnemeModel _model;
    [SerializeField] private EnemeAttackModel _attackModel;

    private bool _gameEnd = false;

    private void OnEnable()
    {
        _model.StateChanged += ChangeStateIfConditionTrue;
        LevelBoard.LevelEnd += GameEndSetEnemeState;
    }

    private void OnDisable()
    {
        _model.StateChanged -= ChangeStateIfConditionTrue;
        LevelBoard.LevelEnd -= GameEndSetEnemeState;
    }

    private void ChangeStateIfConditionTrue(EnemeModel.States state)
    {
        //если существо имеет состояние idle и у него нет врагов поблизости, а так же
        //игра не закончена, то переключить состояние на бег
        if ((state == EnemeModel.States.idle_1 || state == EnemeModel.States.idle_2) &&
            !_attackModel.EnemyNear && !_gameEnd)
        {
            _model.State = EnemeModel.States.run_1;
        }
    }

    private void GameEndSetEnemeState()
    {
        _gameEnd = true;
        if (_model.State != EnemeModel.States.death_1 && _model.State != EnemeModel.States.death_2)
        {
            _model.State = EnemeModel.States.idle_1;
        }
    }
}
