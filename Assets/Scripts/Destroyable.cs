using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	float hp = 0.3f;
	public GameObject explosionEffectPrefab;
	public void Damage () {
		transform.Rotate(290.0f*Time.deltaTime, 245.0f*Time.deltaTime, 210.0f*Time.deltaTime);
		hp -= Time.deltaTime;
		if(hp < 0.0f) {
			Explode();
		}
	}
	void Explode() {
		GameObject.Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
