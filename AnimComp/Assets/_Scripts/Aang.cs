using UnityEngine;
using UnityEngine.InputSystem;

public class Aang : MonoBehaviour
{
    Animator _animator;

    int danceOneHash;
    int danceTwoHash;
    int danceThreeHash;
    int danceFourHash;

    private AangInputs _inputs;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
        danceOneHash = Animator.StringToHash("One");
        danceTwoHash = Animator.StringToHash("Two");
        danceThreeHash = Animator.StringToHash("Three");
        danceFourHash = Animator.StringToHash("Four");

        _inputs = new AangInputs();
        _inputs.AnimatorControls.Enable();

        _inputs.AnimatorControls.Trigger1.performed += DancingOne;
        _inputs.AnimatorControls.Trigger2.performed += DancingTwo;
        _inputs.AnimatorControls.Trigger3.performed += DancingThree;
        _inputs.AnimatorControls.Trigger4.performed += DancingFour;
    }

    private void DancingOne(InputAction.CallbackContext context)
    {
        _animator.SetBool(danceOneHash, true);
        _animator.SetBool(danceTwoHash, false);
        _animator.SetBool(danceThreeHash, false);
        _animator.SetBool(danceFourHash, false);
    }

    private void DancingTwo(InputAction.CallbackContext context)
    {
        _animator.SetBool(danceOneHash, false);
        _animator.SetBool(danceTwoHash, true);
        _animator.SetBool(danceThreeHash, false);
        _animator.SetBool(danceFourHash, false);
        
    }

    private void DancingThree(InputAction.CallbackContext context)
    {
        _animator.SetBool(danceOneHash, false);
        _animator.SetBool(danceTwoHash, false);
        _animator.SetBool(danceThreeHash, true);
        _animator.SetBool(danceFourHash, false);
        
    }

    private void DancingFour(InputAction.CallbackContext context)
    {
        _animator.SetBool(danceOneHash, false);
        _animator.SetBool(danceTwoHash, false);
        _animator.SetBool(danceThreeHash, false);
        _animator.SetBool(danceFourHash, true);
        
    }
}
