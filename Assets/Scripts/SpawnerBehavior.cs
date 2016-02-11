using UnityEngine;
using System.Collections;

public class SpawnerBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}


/*

    Spawners are the primary definitions of waves. In each wave, a collection of spawners appear, and begin spawning enemies until they are destroyed.

    Periodically, spawners will teleport to a new location. This is signaled by visibly shaking and creating a wubwubwub sound.

    Time permitting, King Spawners can be implemented that are larger, have more health, spawn more enemies - these will always try to teleport away when taking damage.




    */