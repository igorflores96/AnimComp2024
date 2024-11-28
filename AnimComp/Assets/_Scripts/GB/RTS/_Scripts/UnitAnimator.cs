using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private  readonly string _miningAnimationText = "isMining";
    private  readonly string _pickingAnimationText = "isPicking";
    private  readonly string _idleAnimationText = "isIdle";
    private  readonly string _runningAnimationText = "isRunning";

    public void SetRunning()
    {
        _animator.SetTrigger(_runningAnimationText); 
    }

    public void SetIdle()
    {
        _animator.SetTrigger(_idleAnimationText); 
    }

    public void SetMining()
    {
        _animator.SetTrigger(_miningAnimationText);
    }

    public void SetPicking()
    {
        _animator.SetTrigger(_pickingAnimationText);
    }
}
