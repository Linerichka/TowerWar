using UnityEngine;


[CreateAssetMenu(fileName = "Eneme", menuName = "ScriptableObjects/Eneme", order = 1)]
public class Eneme : ScriptableObject
{
    public EnemeTypes EnemeType;
    public enum EnemeTypes
    {
        swordsman,
        spearman,
        horseman,
        tower
    }
    public float Speed = 1;
    public int Health = 50;
    public float AtackSpeed = 1f;
    public float DamageBase = 10;  
    public DamageRatioOnClass[] DamageRatio;

    [System.Serializable]
    public struct DamageRatioOnClass
    {
        public EnemeTypes EnemeType;
        public float DamageRation;
    }
    
}
