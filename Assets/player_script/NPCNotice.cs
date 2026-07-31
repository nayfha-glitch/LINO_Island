using UnityEngine;

public class NPCNotice : MonoBehaviour
{
    public string npcName = "القروي";
    [TextArea(3, 5)]
    public string dialogueMessage = "أهلاً بك في الجزيرة! هل تحتاج مساعدة؟";

    [Header("Notice Icon")]
    public GameObject noticeIcon; // صورة التنبيه فوق رأس الشخصية

    private void Start()
    {
        // إخفاء الأيقونة في بداية اللعبة
        if (noticeIcon != null)
        {
            noticeIcon.SetActive(false);
        }
    }

    // استدعاء هذه الدالة عند اقتراب اللاعب أو ابتعاده
    public void ShowNotice(bool show)
    {
        if (noticeIcon != null)
        {
            noticeIcon.SetActive(show);
        }

        // إخفاء صندوق الحوار إذا ابتعد اللاعب عن الـ NPC
        if (!show && DialogueManager.instance != null)
        {
            DialogueManager.instance.HideDialogue();
        }
    }

    // إرسال النص لصندوق الحوار بدلاً من الـ Console
    public void TriggerDialogue()
    {
        if (DialogueManager.instance != null)
        {
            DialogueManager.instance.ShowDialogue(dialogueMessage);
        }
    }
}