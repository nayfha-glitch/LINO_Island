using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed = 5f;
    private Animator anim;
    private Rigidbody2D rb; // 1. أضفنا مكون الفيزياء

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // 2. ربطنا مكون الفيزياء
    }

    public void HandleUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized;
        
        // 3. تحريك الشخصية باستخدام الفيزياء بدلاً من التحريك العادي لكي تحترم الجدران
        rb.linearVelocity = movement * speed;

        if (movement != Vector2.zero)
        {
            anim.SetFloat("moveX", moveX);
            anim.SetFloat("moveY", moveY);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}