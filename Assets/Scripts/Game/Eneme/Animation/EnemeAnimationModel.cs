using Spine.Unity;
using UnityEngine;

public class EnemeAnimationModel : MonoBehaviour
{
    public SkeletonGraphic View;
    public string PlayerSkin = "1";
    public string AISkin = "2";
    public AnimationLoopStateAnimationName[] AnimationLoop;
    //���� �� ������� ��������� ��� ��������� � ������� ����� �������������� �������� �� ����������
    public bool DefaultLoop = true;

    [System.Serializable]
    public struct AnimationLoopStateAnimationName
    {
        public EnemeModel.States StateForAnimation;
        //���� �� ����� ������� ��� �������� ����� �������������� �������� ���������
        public string AnimationName;
        public bool Loop;

        public AnimationLoopStateAnimationName(EnemeModel.States state, string animationName, bool loop)
        {
            this.StateForAnimation = state;
            this.AnimationName = animationName;
            this.Loop = loop;
        }
    }
}
