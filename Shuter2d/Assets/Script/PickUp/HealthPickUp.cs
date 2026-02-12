using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private int _cout;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var playerHealth = collision.gameObject.GetComponent<IHealthPlayer>();
        if (playerHealth != null)
        {
            playerHealth.HealthUp(_cout);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _audioSource.Play();
            Destroy(gameObject, 0.5f);
        }

        

    }
}
