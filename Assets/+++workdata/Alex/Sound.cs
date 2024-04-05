using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    #region serialized fields
    
    #endregion

    #region private fields
    
    #endregion

    private void Start() {
        
    }


    public string name;

    [Range(0, 1)]
    public float clipVolume;

    public AudioClip clip;

    public bool loop;

    [HideInInspector]
    public AudioSource audioSource;
}