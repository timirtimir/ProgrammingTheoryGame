using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private InputSystem_Actions controls;
    private Camera eyes;
    private LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new InputSystem_Actions();
        eyes = gameObject.GetComponentInChildren<Camera>();
        layerMask = LayerMask.GetMask("Default");
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        LookAround();
        if (controls.Player.CallExplosion.WasPressedThisFrame())
        {
            CreateExplosion();
        }
    }
    private void CreateExplosion()
    {
        RaycastHit hit;
        Ray ray = new Ray(eyes.transform.position, eyes.transform.forward);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(eyes.transform.position, eyes.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        Vector3 explosionLocation = hit.point;
        Instantiate(explosionPrefab, explosionLocation, explosionPrefab.transform.rotation);
        
    }
    private void LookAround()
    {
        Vector2 look = controls.Player.LookAround.ReadValue<Vector2>() * 0.1f;
        float xRotation = look.y;
        float yRotation = look.x * -1;
        eyes.transform.localEulerAngles += new Vector3 (xRotation, yRotation, 0);
    }
}
