using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    private InputSystem_Actions controls;
    private Camera eyes;
    private LayerMask layerMask;
    private bool isZoomed = true;
    private float baseFOV;
    private float zoomFOV = 15;
    private float t = 1;
    private float zoomSpeed = 3f;
    private int ammo = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = new InputSystem_Actions();
        eyes = gameObject.GetComponentInChildren<Camera>();
        layerMask = LayerMask.GetMask("Default");
        baseFOV = eyes.fieldOfView;
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
        if (controls.Player.Zoom.WasPressedThisFrame())
        {
            t = 0;
            isZoomed = !isZoomed;
        }
        ZoomInOut();
    }
    private async void CreateExplosion()
    {
        if (ammo > 0)
        {
            RaycastHit hit;
            Ray ray = new Ray(eyes.transform.position, eyes.transform.forward);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 explosionLocation = hit.point;
                await Awaitable.WaitForSecondsAsync(2.0f);
                Instantiate(explosionPrefab, explosionLocation, explosionPrefab.transform.rotation);
                ammo--;
            }
        }

        
    }
    private void LookAround()
    {
        Vector2 look = controls.Player.LookAround.ReadValue<Vector2>() * 0.1f;
        float xRotation = look.y;
        float yRotation = look.x * -1;
        eyes.transform.localEulerAngles += new Vector3 (xRotation, yRotation, 0);
    }
    private void ZoomInOut()
    {
        if (isZoomed)
        {
            eyes.fieldOfView = Mathf.Lerp(zoomFOV, baseFOV, t);
        }
        else {
            eyes.fieldOfView = Mathf.Lerp(baseFOV, zoomFOV, t);
        }
        t += Time.deltaTime * zoomSpeed;

    }
}
