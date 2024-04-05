using UnityEngine;
using TMPro;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    public int ammo;

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

    public void AddAmmo()
    {
        ammo++;
    }

    public void SubtractAmmo()
    {
        ammo--;
    }
}
