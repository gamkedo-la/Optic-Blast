using UnityEngine;
using System.Collections;

public class LaserBlast : MonoBehaviour {
	public Light[] attackToggleLights;
	public ParticleSystem laserEffect;
	AudioSource beamSound;

	void OnTriggerStay (Collider other) {
		if(Input.GetButton("Fire1")) {
			Destroyable destScript = other.GetComponent<Destroyable>();
			if(destScript) {
				destScript.Damage();
			}
		}
	}

	void ToggleLights(bool setTo) {
		for(int i = 0; i < attackToggleLights.Length; i++) {
			attackToggleLights[i].enabled = setTo;
		}
		beamSound.enabled = setTo;
		laserEffect.enableEmission = setTo;
	}

	void Start() {
		beamSound = GetComponent<AudioSource>(); // (on/from self)
		ToggleLights(false);
	}

	void Update() {
		if(Input.GetButtonDown("Fire1")) {
			ToggleLights(true);
		}
		if(Input.GetButtonUp("Fire1")) {
			ToggleLights(false);
		}
	}
}
