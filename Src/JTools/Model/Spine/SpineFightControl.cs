using Spine;
using Spine.Unity;
using UnityEngine;

namespace TierneyJohn.MiChangSheng.JTools.Model.Spine;

public class SpineFightControl : MonoBehaviour
{
    #region 字段属性

    private Animator _animator;

    private AnimatorState NowState
    {
        get => _nowState;
        set
        {
            if (_nowState == value) return;
            _nowState = value;
            ChangeAnimation();
        }
    }

    private SkeletonGraphic _skeletonGraphic;

    private AnimatorState _nowState = AnimatorState.Idle;

    #endregion

    #region Unity 事件函数

    private void Awake()
    {
        _animator = transform.parent.parent.gameObject.GetComponent<Animator>();
        _skeletonGraphic = transform.GetComponentInChildren<SkeletonGraphic>();
    }

    private void Start() { _skeletonGraphic.AnimationState.Complete += SpineComplete; }

    private void Update() { OnAnimator(); }

    #endregion

    #region Animator 事件监听

    private void OnAnimator()
    {
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Die")) NowState = AnimatorState.Die;
        else if (stateInfo.IsName("Hit")) NowState = AnimatorState.Hit;
        else if (stateInfo.IsName("Idle")) NowState = AnimatorState.Idle;
        else if (stateInfo.IsName("Punch")) NowState = AnimatorState.Punch;
        else if (stateInfo.IsName("Stop")) NowState = AnimatorState.Stop;
        else if (stateInfo.IsName("Talk")) NowState = AnimatorState.Talk;
        else NowState = AnimatorState.Idle;
    }

    #endregion

    #region Spine 动画状态切换

    private void SpineComplete(TrackEntry entry)
    {
        if (!entry.Animation.Name.Equals("Idle_0"))
        {
            _skeletonGraphic.AnimationState.SetAnimation(0, "Idle_0", true);
        }
    }

    private void ChangeAnimation()
    {
        if (NowState == AnimatorState.Idle) return;

        var animationName = _skeletonGraphic.AnimationState.GetCurrent(0).Animation.Name;
        if (GetStateName().Equals(animationName)) return;

        _skeletonGraphic.AnimationState.SetAnimation(0, GetStateName(), false);
    }

    private string GetStateName() { return $"{System.Enum.GetName(typeof(AnimatorState), NowState)}_0"; }

    #endregion
}

public enum AnimatorState
{
    Die,
    Hit,
    Idle,
    Punch,
    Stop,
    Talk
}