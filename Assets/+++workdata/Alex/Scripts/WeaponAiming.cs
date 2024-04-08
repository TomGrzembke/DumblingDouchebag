using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAiming : MonoBehaviour
{
    [Header("Camera")]
    Camera mainCamera;

    [Header(("Weapon"))]
    [SerializeField] private ParticleSystem bulletShellsParticle;
    private float weaponAngle;
    [SerializeField] public Transform weaponEndPoint;
    private Vector3 weaponToMouse;
    private Vector3 changingWeaponToMouse;
    public Vector3 mousePos;
    [SerializeField] private Animator weaponAnim;

    [Header("GameObjects")]
    [SerializeField] private GameObject muzzleFlashVisual;
    [SerializeField] private LineRenderer shotgunLaser;
    private GameObject seaGull;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        shotgunLaser.SetPosition(0, weaponEndPoint.position);

        HandleAimingUpdate();

        Shoot();
    }

    private void HandleAimingUpdate()
    {
        Debug.Log(mousePos);
        mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        weaponToMouse = mousePos - transform.position;
        shotgunLaser.SetPosition(1, mousePos);

        weaponAngle = Vector3.SignedAngle(Vector3.up, weaponToMouse, Vector3.forward);

        print(weaponAngle);

        transform.eulerAngles = new(0, 0, weaponAngle);
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
        if (col.gameObject.GetComponent<Seagull>())
        {
            seaGull = col.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        seaGull = null;
    }
}
