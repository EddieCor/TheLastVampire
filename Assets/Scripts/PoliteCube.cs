using UnityEngine;

public class PoliteCube : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        GreetPlayer();
    }

    void GreetPlayer()
    {
        Debug.Log("Hello, Player! Hope you're having a great day! (^_^)");
    }
}
