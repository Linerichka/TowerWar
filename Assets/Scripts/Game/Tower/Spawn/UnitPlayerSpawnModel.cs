using UnityEngine.UI;
using UnityEngine;

public class UnitPlayerSpawnModel : UnitSpawnModel
{
    public ButtonsToUnit[] Buttons;
    public Image[] ReloadImage;

    [System.Serializable]
    public struct ButtonsToUnit
    {
        public Button Button;
        public Eneme.EnemeTypes Type;
    }

    protected override void SetTimeLastCreation(float newValue)
    {
        foreach (Image i in ReloadImage) i.fillAmount = Mathf.Lerp(1, 0, TimeLastCreation / TimeBetweenSpawn);
    }
}
