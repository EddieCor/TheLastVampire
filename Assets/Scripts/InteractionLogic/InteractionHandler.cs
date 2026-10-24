using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] Transform _rayCastOrigin;
    [SerializeField] Animator _playerAnimator;
    [SerializeField] float _interactionRange = 10.0f;

    public void OnInteract(InputValue value)
    {
        if(value.isPressed)
        {
            CheckRay();
        }
    }

    void CheckRay()
    {
        Ray ray = new Ray(_rayCastOrigin.position, _rayCastOrigin.forward);
        RaycastHit hit;

        Debug.DrawRay(_rayCastOrigin.position, _rayCastOrigin.forward * _interactionRange, Color.red, 1.0f);

        if(Physics.Raycast(ray, out hit, _interactionRange))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != null)
            {
                _playerAnimator.SetTrigger("Fixing");
                interactable.Interact();
            }
        }
    }
}
