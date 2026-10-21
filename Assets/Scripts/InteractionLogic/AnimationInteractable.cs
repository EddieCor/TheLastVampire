using UnityEngine;

public class AnimationInteractable : InteractableBase
{
    [SerializeField] Animator _animator;
    [SerializeField] string _triggerName = "Interact";

    protected override void OnInteract()
    {
        _animator.SetTrigger(_triggerName);
    }
}
