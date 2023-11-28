using UnityEngine;
using UnityEngine.UI;
using Boards;

public class UnitSpawnButtonPresenter : MonoBehaviour
{
    [SerializeField] UnitSpawnButtonModel _model;

    private void OnEnable()
    {
        LevelBoard.LevelEnd += ButtonEnabledOff;
    }
    private void OnDisable()
    {
        LevelBoard.LevelEnd -= ButtonEnabledOff;
    }

    private void ButtonEnabledOff() => ButtonSetEnabled(false);
    private void ButtonEnabledOn() => ButtonSetEnabled(true);

    private void ButtonSetEnabled(bool enabled)
    {
        foreach (Button button in _model.ButtonsTurnOffAtLevelEnd) button.enabled = enabled;
    }
}
