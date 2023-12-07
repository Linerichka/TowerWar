using System.Collections.Generic;
using UnityEngine;
using Boards;

public class GameResultCheckerPresenter : MonoBehaviour
{
    [SerializeField] private EnemeModel[] _enemesOnScenBeforeStart;
    [SerializeField] private GameObject _restartWindow;
    private List<EnemeAttackModel> _playerEnemes;
    private List<EnemeAttackModel> _AIEnemes;

    private bool _unitsCreateRunOut = false;

    private void OnEnable()
    {
        UnitSpawnBoard.UnitSpawn += GetComponentsFromEneme;
        LevelBoard.UnitsCreateRunOut += SetTrueUnitCreateRunOut;
        AttackBoard.EnemeDead += CheckLivingEnemesInBothTeams;
    }

    private void OnDisable()
    {
        UnitSpawnBoard.UnitSpawn -= GetComponentsFromEneme;
        LevelBoard.UnitsCreateRunOut -= SetTrueUnitCreateRunOut;
        AttackBoard.EnemeDead -= CheckLivingEnemesInBothTeams;
    }

    void Start()
    {
        SetValue();
    }

    private void SetValue()
    {
        _playerEnemes = new();
        _AIEnemes = new();

        foreach (EnemeModel eneme in _enemesOnScenBeforeStart)
        {
            EnemeAttackModel model = eneme.gameObject.GetComponent<EnemeAttackModel>();
            Debug.Log(model);
            bool player = eneme.Player;
            AddEnemeInListByPlayerBool(model, player);
        }
    }

    private void GetComponentsFromEneme(Vector3 position, GameObject eneme, Eneme.EnemeTypes enemeType)
    {
        EnemeAttackModel enemeAttackModel = eneme.transform.GetChild(0).GetComponent<EnemeAttackModel>();
        bool player = eneme.transform.GetChild(0).GetComponent<EnemeModel>().Player;
        AddEnemeInListByPlayerBool(enemeAttackModel, player);
    }

    private void AddEnemeInListByPlayerBool(EnemeAttackModel model, bool player)
    {
        if (player) _playerEnemes.Add(model);
        else _AIEnemes.Add(model);
    }

    private void CheckLivingEnemesInBothTeams(Vector3 enemeDeadPosition)
    {
        //��� ������� ���������� ����: ���� ��������� �� � ������, ���� ��������� ����� ������
        bool AIEnemesAlive = false;

        foreach (EnemeAttackModel attackModel in _playerEnemes)
        {
            //������� ������������� ������

            if (attackModel.EnemeModel.Eneme.EnemeType == Eneme.EnemeTypes.tower &&
                !EnemeAlive(attackModel))
            {
                LevelEnd();
                return;
            }
        }
        foreach (EnemeAttackModel attackModel in _AIEnemes)
        {
            //������� ������ ��
            if (attackModel.EnemeModel.Eneme.EnemeType == Eneme.EnemeTypes.tower &&
                !EnemeAlive(attackModel))
            {
                LevelEnd();
                return;
            }
            //������� ������ ��
            if (attackModel.EnemeModel.Eneme.EnemeType != Eneme.EnemeTypes.tower &&
                EnemeAlive(attackModel))
            {
                AIEnemesAlive = true;
            }
        }

        Debug.Log($"eneme Alive: {AIEnemesAlive}  unitsrunout: {_unitsCreateRunOut}");
        //���� ��� ����� �� ������ � �� ����� ������ ������� - ������ ������� ���������� ����
        if (!AIEnemesAlive && _unitsCreateRunOut)
        {
            LevelEnd();
            return;
        }
    }

    private bool EnemeAlive(EnemeAttackModel enemeAttackModel)
    {
        return enemeAttackModel.EnemeModel.State != EnemeModel.States.death_1 &&
               enemeAttackModel.EnemeModel.State != EnemeModel.States.death_2;
    }

    private void LevelEnd()
    {
        LevelBoard.LevelEnd?.Invoke();
        RestartMenuSetActive(true);
    }

    private void RestartMenuSetActive(bool active)
    {
        _restartWindow.SetActive(active);
    }

    private void SetTrueUnitCreateRunOut() => _unitsCreateRunOut = true;
}
