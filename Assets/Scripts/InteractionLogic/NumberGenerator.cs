using UnityEngine;

public class NumberGenerator : InteractableBase
{
    protected override void OnInteract()
    {
        Debug.Log(Random.Range(0, 100));
        GetComponentInChildren<CollisionHandler>().SetHighlight(false);
    }
}