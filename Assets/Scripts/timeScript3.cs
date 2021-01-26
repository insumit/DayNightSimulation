using UnityEngine;

public class timeScript3 : MonoBehaviour
{
    [SerializeField] private Light sunLight;
    [SerializeField] private float secondsInFullDay = 120f;

    [Range(0, 1)] [SerializeField] private float currentTimeOfDay = 0;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;

    private void Start()
    {
        sunInitialIntensity = sunLight.intensity;
    }

    private void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if(currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    private void UpdateSun()
    {
        sunLight.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;

        if(currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
        }
        else if(currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if(currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay) * (1 / 0.02f)));
        }

        sunLight.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
