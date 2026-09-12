using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float startSize = 0.1f;
    private float endSize = 3f;
    private float t = 0;
    private float expandSpeed = 8;
    // Creates the explosion as a small obejct
    void Start()
    {
        transform.localScale = new Vector3(startSize, startSize, startSize);
    }

    // Expands the explosion over time to achieve a basic animation
    void Update()
    {
        transform.localScale = Vector3.Lerp(new Vector3(startSize, startSize, startSize), new Vector3(endSize, endSize, endSize), t);
        t += Time.deltaTime * expandSpeed;
        if(t > 1)
        {
            Destroy(gameObject);
        }
    }
}
