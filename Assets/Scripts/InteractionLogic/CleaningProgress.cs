using System.Collections;
using UnityEngine;

/// <summary>
/// Counts how many cleaning interactables have been used and tells the final object whether it is unlocked.
/// Also plays the "still locked" feedback (text and optional audio) when the player tries too early.
/// </summary>
public class CleaningProgress : MonoBehaviour
{
    const float DefaultLockedMessageDuration = 2.0f;

    [Tooltip("How many cleaning interactables must be used before the final object unlocks.")]
    [SerializeField] int _requiredCount;

    [Header("Locked feedback")]
    [SerializeField] GameObject _lockedMessage;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _lockedClip;
    [SerializeField] float _lockedMessageDuration = DefaultLockedMessageDuration;

    int _completedCount;
    bool _isShowingLockedMessage;

    /// <summary>True once every required cleaning interactable has been used.</summary>
    public bool IsComplete => _completedCount >= _requiredCount;

    /// <summary>Called by an interactable when it has been used.</summary>
    public void ReportCompleted()
    {
        _completedCount++;
    }

    /// <summary>Shows the locked message and plays the locked clip, ignoring repeated calls while it is showing.</summary>
    public void ShowLockedFeedback()
    {
        if (_isShowingLockedMessage)
        {
            return;
        }

        StartCoroutine(LockedFeedbackRoutine());
    }

    IEnumerator LockedFeedbackRoutine()
    {
        _isShowingLockedMessage = true;

        if (_audioSource != null && _lockedClip != null)
        {
            _audioSource.PlayOneShot(_lockedClip);
        }

        if (_lockedMessage != null)
        {
            _lockedMessage.SetActive(true);
        }

        yield return new WaitForSeconds(_lockedMessageDuration);

        if (_lockedMessage != null)
        {
            _lockedMessage.SetActive(false);
        }

        _isShowingLockedMessage = false;
    }
}
