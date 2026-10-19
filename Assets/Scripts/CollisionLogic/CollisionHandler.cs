using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject _interactionText;

    void OnTriggerEnter(Collider other)
    {
        _interactionText.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        _interactionText.SetActive(false);
    }
}
