using HighlightPlus;
using UnityEngine;

public class PoliteCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Hello, Player! Hope you're having a great day! (^_^)");
        GetComponentInChildren<CollisionHandler>().SetHighlight(false);
    }
}