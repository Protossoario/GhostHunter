using UnityEngine;

[RequireComponent(typeof(Light))]
public class TorchlightScript : MonoBehaviour
{
	public float minIntensity = 4.0f;
	public float maxIntensity = 8.0f;
	public float minRange = 1.4f;
	public float maxRange = 1.6f;
	
	float random;
	
	void Start()
	{
		random = Random.Range(0.0f, 65535.0f);
	}
	
	void Update()
	{
		float noise = Mathf.PerlinNoise(random, Time.time);
		light.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
		light.range = Mathf.Lerp(minRange, maxRange, noise);
	}
}