using System.Linq;
using UnityEngine;

public class EnemeAnimationPresenter : MonoBehaviour
{
    [SerializeField] private EnemeModel _enemeModel;
    [SerializeField] private EnemeAnimationModel _animationModel;
    

    private void OnEnable()
    {
        _enemeModel.StateChanged += SetAnimation;
    }

    private void OnDisable()
    {
        _enemeModel.StateChanged -= SetAnimation;
    }

    void Start()
    {
        SetValue();
    }

    private void SetValue()
    {
        _animationModel.View.initialFlipX = !_enemeModel.Player;
        _animationModel.View.initialSkinName = _enemeModel.Player ? _animationModel.PlayerSkin : _animationModel.AISkin;
        SetAnimation(_enemeModel.State);
    }

    private void SetAnimation(EnemeModel.States state)
    {
        _animationModel.View.Initialize(true);
        EnemeAnimationModel.AnimationLoopStateAnimationName animation =
            (from ab in _animationModel.AnimationLoop
             where ab.StateForAnimation == state
             select ab)
             .DefaultIfEmpty(new EnemeAnimationModel.AnimationLoopStateAnimationName(state, "", _animationModel.DefaultLoop))
             .FirstOrDefault();
        bool loop = animation.Loop;
        string animationName = animation.AnimationName != "" ? animation.AnimationName : state.ToString();
        _animationModel.View.AnimationState.SetAnimation(0, animationName, loop);
    }
}
