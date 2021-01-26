using UnityEngine;
using UnityEngine.UI;

public class sceneLightController : MonoBehaviour
{
    [SerializeField]
    Slider skyboxExposureSlider, directionalLightIntensitySlider, atmosphericThickness;

    Light dirLight;

    //float randomIntensityValue;

    void Start()
    {
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();

        //randomIntensityValue = Random.Range(0.5f, 2f);

        //light.intensity = randomIntensityValue;

        //RenderSettings.skybox.SetFloat("_Exposure", randomIntensityValue);

        //RenderSettings.skybox.SetFloat("_AtmosphereThickness", randomIntensityValue);
    }

    public void ChangeAtmThickness()
    {
        RenderSettings.skybox.SetFloat("_AtmosphereThickness", atmosphericThickness.value);
    }

    public void ChangeSkyboxExposure()
    {
        RenderSettings.skybox.SetFloat("_Exposure", skyboxExposureSlider.value);
    }

    public void ChangeDirLightIntensity()
    {
        dirLight.intensity = directionalLightIntensitySlider.value;
    }
}
