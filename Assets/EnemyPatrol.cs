using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f; 
    public Collider2D battleZoneCollider; 
    private Vector2 targetPosition;

    void Start()
    {
        GetNewRandomPosition();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            GetNewRandomPosition();
        }
    }

    void GetNewRandomPosition()
    {
        if (battleZoneCollider != null)
        {
            float randomX = Random.Range(battleZoneCollider.bounds.min.x, battleZoneCollider.bounds.max.x);
            float randomY = Random.Range(battleZoneCollider.bounds.min.y, battleZoneCollider.bounds.max.y);
            targetPosition = new Vector2(randomX, randomY);
        }
    }
}
