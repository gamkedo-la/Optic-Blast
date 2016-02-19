using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	public string loadScene;

	public float hp = 0.3f;
	public GameObject explosionEffectPrefab;

	public bool mustDestroy = false;
	public bool shouldDestroy = false;

	public static int mustDestroyCount = 0;

	public void Start() {
		if(mustDestroy) {
			mustDestroyCount++;
			shouldDestroy = true;
		}
	}

	public void Damage () {
		if(Random.Range(0, 100) < 17 && hp < 0.5f) {
			transform.Rotate(200.0f * Time.deltaTime, 250.0f * Time.deltaTime, 100.0f * Time.deltaTime);
		}
		hp -= Time.deltaTime;
		if(hp < 0.0f) {
			Explode();
		}
	}
	void Update() {
		if(mustDestroy && Input.GetKeyDown(KeyCode.K)) {
			Explode();
		}
	}

	public void Explode(bool killCounts = true) {
		if(killCounts) { // false for self destruct attack
			if(shouldDestroy) {
				TapToTeleport.enemiesDefeated++;
				if(mustDestroy) {
					mustDestroyCount--;
					Debug.Log(mustDestroyCount);
					if(mustDestroyCount <= 0) { // cycle levels
						if(TypeText.wonAlready[TypeText.instance.whichLev] == false) {
							TypeText.wonAlready[TypeText.instance.whichLev] = true;
						}

						//Application.LoadLevel( (Application.loadedLevel+1) % Application.levelCount );
						Application.LoadLevel("MenuScene");
					}
				}
			} else {
				TapToTeleport.suppliesLost++;
			}
		}
		if(loadScene.Length > 0) {
			mustDestroyCount = 0;
			Application.LoadLevel(loadScene);
		}
		if(explosionEffectPrefab) {
			GameObject.Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
		}
		Destroy(gameObject);
	}
}
