using UnityEngine;
using TMPro;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    public int ammo;
    [SerializeField] private GameObject canvas;
    private float fadeTime;

    public static Ammunition Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        ammoText.text = ammo.ToString();

        if (ammo >= 3)
        {
            fadeTime += Time.deltaTime;
            canvas.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0, .7f, fadeTime);
        }
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
