using Cinemachine;
using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin noise;

    public static ScreenShake Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        noise = vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Noise(float amplitudeGain, float frequencyGain)
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
    }

    public IEnumerator Noise(float amplitude, float frequency, float time)
    {
        Noise(amplitude, frequency);
        yield return new WaitForSeconds(time);
        Noise(0, 0);
    }

}