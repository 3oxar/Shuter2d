using UnityEngine;

public class FlyBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private int damage = 1;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * _speed;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        Destroy(gameObject);
    }
}
