using UnityEngine;
using UnityEngine.Events;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    [SerializeField] bool _singleUse = true;
    [SerializeField] CollisionHandler _collisionHandler;

    [Header("Cleaning progress (optional)")]
    [SerializeField] CleaningProgress _progress;
    [Tooltip("Tick only on the final object that stays locked until every other interactable has been used.")]
    [SerializeField] bool _requiresAllOthers;

    [Header("Events")]
    [Tooltip("Invoked right after the interaction runs. Use it to trigger things like the ending sequence.")]
    [SerializeField] UnityEvent _onInteracted;

    bool _hasInteracted;

    public void Interact()
    {
        if (_hasInteracted) return;

        if (_requiresAllOthers && _progress != null && !_progress.IsComplete)
        {
            _progress.ShowLockedFeedback();
            return;
        }

        _hasInteracted = _singleUse;

        OnInteract();
        _onInteracted.Invoke();

        if (_singleUse && _progress != null && !_requiresAllOthers)
        {
            _progress.ReportCompleted();
        }

        if (_singleUse && _collisionHandler != null)
        {
            _collisionHandler.Disable();
        }
    }

    protected abstract void OnInteract();
}