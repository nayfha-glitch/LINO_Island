using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed = 5f;

    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // إعدادات الفيزياء
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    public void HandleUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // تحريك اللاعب
        
        rb.linearVelocity = movement * speed;

        // الأنيميشن
        if (movement != Vector2.zero)
        {
            anim.SetFloat("moveX", movement.x);
            anim.SetFloat("moveY", movement.y);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
    // 4. إضافة دالة OnTriggerEnter2D للكشف عن الاصطدام مع الأعداء
    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("enemy"))
    {
        Debug.Log("Player Entered A Battle Zone! Battle Begins!");

        // البحث عن سكربت SimpleBattle وتفعيل شاشة القتال تلقائياً
        SimpleBattle battleSystem = FindAnyObjectByType<SimpleBattle>();
        if (battleSystem != null && battleSystem.battlePanel != null)
        {
            battleSystem.battlePanel.SetActive(true);
        }
    }
}
}
