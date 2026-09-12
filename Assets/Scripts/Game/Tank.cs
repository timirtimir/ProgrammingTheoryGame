using UnityEngine;

// Inheritance
public class Tank : Enemy
{
    private float zBound = 3f;
    private float xDirection = 0;
    private float zDirection = 1;
    private float rotationSpeed = 720;
    // Initalises the enemy using the enemy class constructor
    void Start()
    {
        base.Start();
        moveSpeed = 2;
    }
    // Polymorphism
    // Moves the tank in a triangle
    public override void Move()
    {
        HandleMovement();
        Vector3 xTranslation = (Vector3.right * xDirection * 2);
        Vector3 zTranslation = (Vector3.forward * zDirection);
        Vector3 movement = xTranslation + zTranslation;
        transform.Translate(movement * Time.deltaTime * moveSpeed, Space.World);
        HandleLookDirection(movement);
            
    }
    // Handles the movement by changing the tanks direction
    public void HandleMovement()
    {

        if (transform.position.z <= -zBound)
        {
            zDirection = 1;
        }
        else if (transform.position.z >= zBound)
        {
            zDirection = -1;
        }
        if (zDirection == 1)
        {
            xDirection = 0;
        }
        else if (zDirection == -1)
        {
            if (transform.position.z <= 0)
            {
                xDirection = 1;
            }
            else
            {
                xDirection = -1;
            }
        }
    }
    // Handles the direction looked at by the tank using the movement of the tank
    public void HandleLookDirection(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            Quaternion lookDirection = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, rotationSpeed * Time.deltaTime);
        }
    }
}
