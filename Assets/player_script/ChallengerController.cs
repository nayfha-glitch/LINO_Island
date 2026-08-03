using UnityEngine;

public class ChallengerController : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("You will start a battle");
    }
}