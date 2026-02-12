using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private int _cout;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerHealth = collision.gameObject.GetComponent<IHealthPlayer>();
        if (playerHealth != null)
        {
            playerHealth.HealthUp(_cout);
            Destroy(gameObject);
        }

        

    }
}
