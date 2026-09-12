using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float startSize = 0.1f;
    private float endSize = 3f;
    private float t = 0;
    private float expandSpeed = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(startSize, startSize, startSize);
    }

    // Update is called once per frame
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
