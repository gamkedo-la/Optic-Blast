using UnityEngine;
using System.Collections;

public class LaserBlast : MonoBehaviour {
	public Light[] attackToggleLights;
	public ParticleSystem[] laserEffect;
    public GameObject laserBeam;
    public float scrollSpeed;

    Renderer laserRender;
	AudioSource beamSound;

	void OnTriggerStay (Collider other) {
		if(Input.GetButton("Fire1") && TapToTeleport.jumpProcess == 0.0f) {
			Destroyable destScript = other.GetComponent<Destroyable>();
			if(destScript) {
				destScript.Damage();
			}
		}
	}

	void ToggleLights(bool setTo) {
		for(int i = 0; i < attackToggleLights.Length; i++) {
			attackToggleLights[i].enabled = setTo;
            laserEffect[i].enableEmission = setTo;
        }
		beamSound.enabled = setTo;
        laserRender.enabled = setTo;
	}

	void Start() {
		beamSound = GetComponent<AudioSource>(); // (on/from self)
        laserRender = laserBeam.GetComponent<Renderer>();
		ToggleLights(false);
	}

	void Update() {
		if(Input.GetButtonDown("Fire1") && TapToTeleport.jumpProcess == 0.0f) {
			ToggleLights(true);
		}
		if(Input.GetButtonUp("Fire1") || (TapToTeleport.jumpProcess != 0.0f && beamSound.enabled)) {
			ToggleLights(false);
		}
        float offset = Time.time * scrollSpeed;
        laserRender.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
