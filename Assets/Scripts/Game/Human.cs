using UnityEngine;

// Inheritance
public class Human : Enemy
{   
    private float zBound = 5f;
    private float direction = 1;
    // Initalises the enemy using the enemy class constructor
    void Start()
    {
        base.Start();
        moveSpeed = 3;
    }
    // Moves the humans from left to right
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
