using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {
	public static DontDestroy instance = null;
	// Use this for initialization
	void Start () {
		if(instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}
