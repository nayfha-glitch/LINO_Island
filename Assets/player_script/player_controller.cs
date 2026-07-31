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
}