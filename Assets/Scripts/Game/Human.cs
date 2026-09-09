using UnityEngine;

public class Human : Enemy
{   
    private float zBound = 5f;
    private float direction = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        moveSpeed = 3;
    }

    public override void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * direction);

        if (transform.position.z <= -zBound )
        {
            direction = 1;
        }
        else if (transform.position.z >= zBound)
        {
            direction = -1;
        }
    }
}
