using Spine.Unity;
using UnityEngine;

public class EnemeAnimationModel : MonoBehaviour
{
    public SkeletonGraphic View;
    public string PlayerSkin = "1";
    public string AISkin = "2";
    public AnimationLoopStateAnimationName[] AnimationLoop;
    //если не найдено состояние для анимациии в масииве будет использоваться значение из переменной
    public bool DefaultLoop = true;

    [System.Serializable]
    public struct AnimationLoopStateAnimationName
    {
        public EnemeModel.States StateForAnimation;
        //если не будет указано имя анимации будет использоваться название состояния
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
