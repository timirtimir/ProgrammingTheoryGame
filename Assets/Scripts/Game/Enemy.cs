using UnityEngine;

// Inheritence
public class Enemy : MonoBehaviour
{
    protected int damageThershold;
    protected int hitCount;
    [SerializeField] private GameObject dotPrefab;
    private BoxCollider boxC;
    private Bounds bounds;
    private float xCount = 5f;
    private float yCount = 5f;
    private float zCount = 4f;
    private float xTotal;
    private float yTotal;
    private float zTotal;
    private GameManager gameManager;
    protected float moveSpeed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        damageThershold = 30;
        hitCount = 0;
        boxC = GetComponent<BoxCollider>();
        gameManager = FindFirstObjectByType<GameManager>();
        bounds = boxC.bounds;
        xTotal = bounds.max.x - bounds.min.x;
        yTotal = bounds.max.y - bounds.min.y;
        zTotal = bounds.max.z - bounds.min.z;
        for (int x=0; x<xCount; x++)
        {
            for(int y=0; y<yCount; y++)
            {
                for(int z=0; z<zCount; z++)
                {
                    float xPos = (x / (xCount - 1f)) * xTotal + bounds.min.x;
                    float yPos = (y / (yCount - 1f)) * yTotal + bounds.min.y;
                    float zPos = (z / (zCount - 1f)) * zTotal + bounds.min.z;

                    Vector3 dotPos = new Vector3(xPos, yPos, zPos);

                    Instantiate(dotPrefab, dotPos, dotPrefab.transform.rotation, gameObject.transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void DotHit()
    {
        hitCount++;
        Debug.Log(hitCount);
        if(hitCount > damageThershold)
        {
            gameManager.EnemyDied();
            Destroy(gameObject);
        }
    }
    public virtual void Move() { }
}
