using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	public float hp = 0.3f;
	public GameObject explosionEffectPrefab;

	public bool mustDestroy = false;
	public bool shouldDestroy = false;

	static int mustDestroyCount = 0;

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
	public void Explode(bool killCounts = true) {
		if(killCounts) { // false for self destruct attack
			if(shouldDestroy) {
				TapToTeleport.enemiesDefeated++;
				mustDestroyCount--;
				Debug.Log(mustDestroyCount);
				if(mustDestroyCount <= 0) { // cycle levels
					Application.LoadLevel( (Application.loadedLevel+1) % Application.levelCount );
				}
			} else {
				TapToTeleport.suppliesLost++;
			}
		}
		GameObject.Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
