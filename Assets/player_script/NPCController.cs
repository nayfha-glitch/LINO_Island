using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    public void Interact() {
        Debug.Log("You will talk to this NPC");
    }
}