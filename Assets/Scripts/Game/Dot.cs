using UnityEngine;

public class Dot : MonoBehaviour
{
    private Enemy enemy;
    // Sets the enemy as the parent object of the dot
    void Start()
    {
        enemy = transform.parent.GetComponent<Enemy>();
    }
    // Destroys a dot if it contacts an explosion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            enemy.DotHit();
            Destroy(gameObject);
        }
    }
}
