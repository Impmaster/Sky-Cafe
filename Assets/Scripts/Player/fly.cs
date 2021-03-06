﻿using UnityEngine;
using UnityEngine.Audio;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;


public class fly : MonoBehaviour {
	
	private float distanceToGround;
	
	public float speed = 0;
	
	public float accel = 5;
	
	public float maxSpeed = 30;
	
	private FirstPersonController movementScript;
	
	[SerializeField]
	private bool isFlying = false;
	
	private Camera cam;
	
	public float camShakeSpeed = 0.1f;
	
	private float timeFlying;

	public AudioClip flySound;
	ParticleSystem.EmissionModule em;

	public ParticleSystem particles;

	AudioSource audioSrc;
	public float SoundFadeSpeed = 0.0001f;
	

	

	// Use this for initialization
	void Start () {
		distanceToGround = GetComponent<Collider>().bounds.extents.y;
		movementScript = GetComponent<FirstPersonController>();
		cam = GetComponentInChildren<Camera>();
		audioSrc = GetComponent<AudioSource>();
		em = particles.emission;
		em.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		em.enabled = false;
		

		//Only fly if already in the air
		if (!isGrounded()) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				isFlying = true;
				movementScript.setFlying(true);
			}
			
			
			if (isFlying) {

				if (Input.GetKey(KeyCode.Space)) {
					em.enabled = true;

					//Do sound effect
					if (!audioSrc.isPlaying) {
						audioSrc.clip = flySound;
						audioSrc.Play();
					}

					//Measures the angle the camera should shake at
					timeFlying += camShakeSpeed;
					shake(cam, timeFlying);

					//Increases speed
					movementScript.setUpSpeed(speed);
					if (speed < maxSpeed) {
						speed += accel;
					} else {
						speed = maxSpeed;
					}


				//Fall through the air	
				} else {
					//Turn off sound
					if (audioSrc.isPlaying) {
						StartCoroutine(jetpackSound());
					}


					timeFlying = 0;
					speed = 0;
					isFlying = false;
					movementScript.setFlying(false);
					
					//Resets the camera to the default position
					cam.transform.Rotate(new Vector3(0,0,0));
				}
			}
			
		} else {
			isFlying = false;
		}
		

	}

		IEnumerator jetpackSound() {
            float originalVolume = audioSrc.volume;
            for (float x = audioSrc.volume; x > 0; x -= SoundFadeSpeed) {
                audioSrc.volume -= SoundFadeSpeed;

				if (isGrounded()) {
					audioSrc.volume = originalVolume;
					break;
				}
                yield return null;
            }
            audioSrc.volume = originalVolume;
            audioSrc.Stop();
        }
	
	
	//Sends a raycast straight down to check if the player is on the ground.
	private bool isGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
	}
	
	private void shake(Camera cam, float time) {
		 cam.transform.Rotate(new Vector3(0, 0, Mathf.Sin(time)/2));
	}
}
