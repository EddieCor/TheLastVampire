using UnityEngine;

public class DialogueTriggerZone : MonoBehaviour
{
    [SerializeField] GameObject _dialogueText;

    void OnTriggerEnter(Collider other)
    {
        _dialogueText.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        _dialogueText.SetActive(false);
    }
}
