using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAiming : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera mainCamera;
    private Rigidbody rb;
    private Vector2 travelDirection;

    [Header(("Weapon"))] 
    [SerializeField] private ParticleSystem bulletShellsParticle;
    private float weaponAngle;
    [SerializeField] public Transform weaponEndPoint;
    private Vector3 weaponToMouse;
    private Vector3 changingWeaponToMouse;
    public Vector3 mousePos;
    private bool hasWeapon;
    [SerializeField] private Animator weaponAnim;
    private float weaponScreenShake;

    [Header("GameObjects")]
    [SerializeField] private GameObject muzzleFlashVisual;
    [SerializeField] private LineRenderer shotgunLaser;
    private RaycastHit shotgunLaserRayHit;
    private GameObject seaGull;

    private void Update()
    {
        HandleAimingUpdate();
        
        Shoot();
        
        shotgunLaser.SetPosition(0, weaponEndPoint.position);
    }

    private void HandleAimingUpdate()
    {
        Debug.Log(mousePos);
        mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        if (Vector3.Distance(transform.position, mousePos) >= 1.35f)
        {
            if (Vector3.Distance(weaponEndPoint.position, mousePos) <= 2f)
            {
                changingWeaponToMouse = mousePos - weaponEndPoint.transform.position;

                Vector3 negativeMousePositionXY = changingWeaponToMouse * -2;
                Vector3 positiveMousePositionXY = changingWeaponToMouse * 2;
            
                if (weaponToMouse.x < 0)
                {
                    weaponToMouse = negativeMousePositionXY.normalized;
                }

                if (weaponToMouse.x > 0)
                {
                    weaponToMouse = positiveMousePositionXY.normalized;
                }
            }
            else
            {
                weaponToMouse = mousePos - weaponEndPoint.transform.position;
            }
        }
        
        shotgunLaser.SetPosition(1, mousePos);
        
        weaponAngle = Vector3.SignedAngle(Vector3.up, weaponToMouse, Vector3.forward);
        
        transform.eulerAngles = new Vector3(0, 0, weaponAngle);
    }
    
    private void Shoot()
    {
        if (Ammunition.Instance.ammo >= 1)
        {
            if (!Input.GetMouseButtonDown(0)) 
                return;

            StartCoroutine(ScreenShake.Instance.Noise(20, 10, 0.1f));

            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            ray.origin = transform.position;

            if (seaGull != null)
            {
                StartCoroutine(seaGull.GetComponent<Seagull>().Stop());
            }
        
            Ammunition.Instance.SubtractAmmo();
        
            //StartCoroutine(WeaponVisualCoroutine());
        }
    }
    
    private IEnumerator WeaponVisualCoroutine()
    {
        muzzleFlashVisual.SetActive(true);

        bulletShellsParticle.Play();

        weaponAnim.SetTrigger("ShootGun");
        
        //AudioManager.Instance.Play("Shooting");
        
        yield return new WaitForSeconds(.1f);
        
        weaponAnim.SetTrigger("GunStartPos");

        bulletShellsParticle.Stop();

        muzzleFlashVisual.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.GetComponent<Seagull>())
        {
            seaGull = col.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        seaGull = null;
    }
}
