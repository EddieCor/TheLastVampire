using UnityEngine;

public class PoliteCube : InteractableBase
{
    protected override void OnInteract()
    {
        Debug.Log("Hello, Player! Hope you're having a great day! (^_^)");
    }
}