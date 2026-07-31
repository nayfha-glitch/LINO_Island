using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // النتيجة عند التفاعل مع الـ NPC
        Debug.Log("You will talk to this NPC");
    }
}