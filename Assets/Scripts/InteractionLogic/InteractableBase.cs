using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    [SerializeField] bool _singleUse = true;
    [SerializeField] CollisionHandler _collisionHandler;

    bool _hasInteracted;

    public void Interact()
    {
        if (_hasInteracted) return;

        _hasInteracted = _singleUse;

        OnInteract();

        if (_singleUse && _collisionHandler != null)
        {
            _collisionHandler.Disable();
        }
    }

    protected abstract void OnInteract();
}