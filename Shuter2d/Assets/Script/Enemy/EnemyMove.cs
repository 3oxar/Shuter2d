using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2; 

    private Transform currentTarget;
    private bool isRight = true;

    void Start()
    {
       
        currentTarget = point1;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (transform.position.x < currentTarget.position.x && !isRight)
        {
            Flip();
        }
        else if (transform.position.x > currentTarget.position.x && isRight)
        {
            Flip();
        }

        if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            if (currentTarget == point1)
            {
                currentTarget = point2;
            }
            else
            {
                currentTarget = point1;
            }
        }
    }

    private void Flip()
    {
        isRight = !isRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
