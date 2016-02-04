using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	public float hp = 0.3f;
	public GameObject explosionEffectPrefab;
	public void Damage () {
		if(Random.Range(0, 100) < 17 && hp < 0.5f) {
			transform.Rotate(200.0f * Time.deltaTime, 250.0f * Time.deltaTime, 100.0f * Time.deltaTime);
		}
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
