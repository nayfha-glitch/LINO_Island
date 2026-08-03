using UnityEngine;

public class ChallengerController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // النتيجة عند التفاعل مع المقاتل/العدو
        Debug.Log("You will start a battle");
    }
}