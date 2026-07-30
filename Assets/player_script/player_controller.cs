using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float speed = 5f; // حددنا السرعة بـ 5 كقيمة افتراضية

    void Update()
    {
        // قراءة أوامر الحركة من الأسهم أو WASD
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // جمع الحركتين في متغير واحد وضبط السرعة عشان ما تكون أسرع بالزوايا المائلة
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // تحريك الشخصية بناءً على السرعة والوقت
        transform.Translate(movement * speed * Time.deltaTime);
    }
}