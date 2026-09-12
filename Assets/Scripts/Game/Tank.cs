using UnityEngine;

public class Tank : Enemy
{
    private float zBound = 3f;
    private float xBound = 3f;
    private float xDirection = 0;
    private float zDirection = 1;
    private float rotationSpeed = 720;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        moveSpeed = 2;
    }
    // Polymorphism
    public override void Move()
    {
        HandleMovement();
        Vector3 xTranslation = (Vector3.right * xDirection * 2);
        Vector3 zTranslation = (Vector3.forward * zDirection);
        Vector3 movement = xTranslation + zTranslation;
        transform.Translate(movement * Time.deltaTime * moveSpeed, Space.World);
        HandleLookDirection(movement);
            
    }
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
    public void HandleLookDirection(Vector3 movement)
    {
        if (movement != Vector3.zero)
        {
            Quaternion lookDirection = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, rotationSpeed * Time.deltaTime);
        }
    }
}
