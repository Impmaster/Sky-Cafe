using UnityEngine;
using System.Collections;

public class timeOfDay : MonoBehaviour {


	public float time;

	private float startTime;


	private float originalExposure;
	public float exposureChangeSpeed = 0.1f;

	[SerializeField]
	private float exposure = 1;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		originalExposure = RenderSettings.skybox.GetFloat("_Exposure");
	}
	
	// Update is called once per frame
	void Update () {
		time = Time.time - startTime;
		RenderSettings.skybox.SetFloat("_Exposure", exposure);
		exposure -= exposureChangeSpeed;
	
	}

	void OnApplicationQuit() {

		//Resets the material
		RenderSettings.skybox.SetFloat("_Exposure", originalExposure);
	}
}
