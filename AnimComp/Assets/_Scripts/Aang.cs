using UnityEngine;
using UnityEngine.InputSystem;

public class Aang : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float _animVelocidade;
    int danceOneHash;
    int danceTwoHash;
    int danceThreeHash;

    int animTreeHas;

    private AangInputs _inputs;

    private float _currentAnim = 0.0f;
    private float _targetAnim = 0.0f;

    private void Start() 
    {
        _animator = GetComponent<Animator>();
        //danceOneHash = Animator.StringToHash("One");
        //danceTwoHash = Animator.StringToHash("Two");
        //danceThreeHash = Animator.StringToHash("Three");
        //danceFourHash = Animator.StringToHash("Four");
        animTreeHas = Animator.StringToHash("Anim");
        _targetAnim = 0.0f;
        _inputs = new AangInputs();
        _inputs.AnimatorControls.Enable();

        _inputs.AnimatorControls.Trigger1.performed += DancingOne;
        _inputs.AnimatorControls.Trigger2.performed += DancingTwo;
        _inputs.AnimatorControls.Trigger3.performed += DancingThree;
        _inputs.AnimatorControls.Trigger4.performed += DancingFour;
    }

    private void Update()
    {
        _currentAnim = Mathf.Lerp(_currentAnim, _targetAnim, _animVelocidade * Time.deltaTime);
        _animator.SetFloat(animTreeHas, _currentAnim);
    }

    private void DancingOne(InputAction.CallbackContext context)
    {
        _targetAnim = 1.0f;
        //_animator.SetBool(danceOneHash, true);
        //_animator.SetBool(danceTwoHash, false);
        //_animator.SetBool(danceThreeHash, false);
        //_animator.SetBool(danceFourHash, false);
    }

    private void DancingTwo(InputAction.CallbackContext context)
    {
        _targetAnim = 2.0f;
        //_animator.SetBool(danceOneHash, false);
        //_animator.SetBool(danceTwoHash, true);
        //_animator.SetBool(danceThreeHash, false);
        //_animator.SetBool(danceFourHash, false);
    }

    private void DancingThree(InputAction.CallbackContext context)
    {
        _targetAnim = 3.0f;
        //_animator.SetBool(danceOneHash, false);
        //_animator.SetBool(danceTwoHash, false);
        //_animator.SetBool(danceThreeHash, true);
        //_animator.SetBool(danceFourHash, false);
    }

    private void DancingFour(InputAction.CallbackContext context)
    {
        _targetAnim = 4.0f;
        //_animator.SetBool(danceOneHash, false);
        //_animator.SetBool(danceTwoHash, false);
        //_animator.SetBool(danceThreeHash, true);
        //_animator.SetBool(danceFourHash, false);
    }
}
