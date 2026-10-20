using System.Collections;
using UnityEngine;

public class CoverUpInteractable : InteractableBase
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] float _swapDelay;
    [SerializeField] GameObject[] _objectsToDeactivate;
    [SerializeField] GameObject[] _objectsToActivate;

    protected override void OnInteract()
    {
        _particleSystem.Play();
        StartCoroutine(SwapRoutine());
    }

    IEnumerator SwapRoutine()
    {
        yield return new WaitForSeconds(_swapDelay);

        foreach(GameObject obj in _objectsToDeactivate)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in _objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}