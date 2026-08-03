using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private NPCNotice currentNPC;

    [Header("Interaction Settings")]
    public float interactRange = 1f;
    public Vector2 lastMoveDirection;

    void Update()
    {
        // التحقق من اتجاه الحركة لتحديد مكان تفاعل اللاعب
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            lastMoveDirection = new Vector2(moveX, moveY).normalized;
        }

        // عند الضغط على زر التفاعل (مثلاً زر Z أو Return)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        // استخدام OverlapCircle لكي يستطيع اللاعب التفاعل مع أي كائن أمامه (سواء NPC أو Challenger)
        Vector2 interactPos = (Vector2)transform.position + (lastMoveDirection * interactRange);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(interactPos, 0.5f);

        foreach (Collider2D collider in colliders)
        {
            // التحقق مما إذا كان الكائن يمتلك واجهة التفاعل العامة IInteractable
            IInteractable interactable = collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(); // تشغيل الأكشن الخاص بالكائن فوراً
                break; // التفاعل مع أول كائن يتم إيجاده
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NPCNotice npc = collision.GetComponent<NPCNotice>();
        if (npc != null)
        {
            currentNPC = npc;
            currentNPC.ShowNotice(true); // إظهار علامة التعجب
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        NPCNotice npc = collision.GetComponent<NPCNotice>();
        if (npc != null)
        {
            npc.ShowNotice(false); // إخفاء علامة التعجب
            if (currentNPC == npc)
            {
                currentNPC = null;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector2 interactPosition = (Vector2)transform.position + (lastMoveDirection * interactRange);
        Gizmos.DrawWireSphere(interactPosition, 0.5f);
    }
}