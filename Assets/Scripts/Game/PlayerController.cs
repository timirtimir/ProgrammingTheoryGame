using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private TextMeshProUGUI ammoText;
    private InputSystem_Actions controls;
    private Camera eyes;
    private LayerMask layerMask;
    private bool isZoomed = true;
    private bool isShotCalled = false;
    private float baseFOV;
    private float zoomFOV = 15;
    private float t = 1;
    private float zoomSpeed = 3f;
    private float explosionSpeed = 1f;
    private int ammo = 10;
    private GameManager gameManager;
    
    // Initialises the variables
    void Awake()
    {
        controls = new InputSystem_Actions();
        eyes = gameObject.GetComponentInChildren<Camera>();
        gameManager = FindFirstObjectByType<GameManager>();
        layerMask = LayerMask.GetMask("Default");
        baseFOV = eyes.fieldOfView;
        ammoText.text = "Ammo: " + ammo;
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    // Allows the player control as long as the game is active
    void Update()
    {
        if (gameManager.GetGameState())
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
}
    // Creates an explosion on the ground where the player is looking
    private async void CreateExplosion()
    {
        if (ammo > 0 && !isShotCalled)
        {
            RaycastHit hit;
            Ray ray = new Ray(eyes.transform.position, eyes.transform.forward);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                isShotCalled = true;
                Vector3 explosionLocation = hit.point;
                await Awaitable.WaitForSecondsAsync(explosionSpeed);
                ammo--;
                ammoText.text = "Ammo: " + ammo;
                Instantiate(explosionPrefab, explosionLocation, explosionPrefab.transform.rotation);
                if (ammo <= 0)
                {
                    gameManager.GameOver();
                }
                isShotCalled = false;
            }
        }

        
    }
    // Abstraction
    // Allows the player to look around
    private void LookAround()
    {
        Vector2 look = controls.Player.LookAround.ReadValue<Vector2>() * 0.1f;
        float xRotation = look.y * -1;
        float yRotation = look.x;
        eyes.transform.localEulerAngles += new Vector3 (xRotation, yRotation, 0);
    }
    // Zooms in if zoomed out and vice versa
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
