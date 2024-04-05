using UnityEngine;
using TMPro;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    private int ammo;

    public static Ammunition Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        ammoText.text = ammo.ToString();
    }

    private void AddAmmo()
    {
        ammo++;
    }

    private void SubtractAmmo()
    {
        ammo--;
    }
}
