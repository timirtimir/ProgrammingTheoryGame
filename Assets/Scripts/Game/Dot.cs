using UnityEngine;

public class Dot : MonoBehaviour
{
    private Enemy enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = transform.parent.GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            enemy.DotHit();
            Destroy(gameObject);
        }
    }
}
