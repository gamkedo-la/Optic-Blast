using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeText : MonoBehaviour {
	public GameObject[] AwakeWhenDone;
	public SpawnEnemies ActivatePlayerSpawner;
	Text myText;
	string fullText;
	public int whichLev;
	public static bool[] wonAlready = new bool[3]; // tracks which stages have been won
	public static bool[] doneAlready = new bool[3]; // prevents text from showing up on retries
	public static bool initTextYet = false;
	public static TypeText instance;
	public AudioClip voiceOver;

	void PlayClipOn(AudioClip clip, Vector3 pos, float atVol = 1.0f, Transform attachToParent = null) {
		GameObject tempGO = new GameObject("TempAudio"); // create the temp object
		tempGO.transform.position = pos; // set its position
		if(attachToParent != null) {
			tempGO.transform.parent = attachToParent.transform;
		}
		AudioSource aSource = tempGO.AddComponent<AudioSource>() as AudioSource; // add an audio source
		aSource.clip = clip; // define the clip
		aSource.volume = atVol;
		aSource.pitch = 1.0f;// Random.Range(0.7f,1.4f);
		// set other aSource properties here, if desired
		aSource.Play(); // start the sound
		Destroy(tempGO, clip.length/aSource.pitch); // destroy object after clip duration
	}

	// Use this for initialization
	void Start () {
		instance = this; // lazily reassigning singleton between stages
		// only doing it here to check whichLev when saving which level got won

		if(initTextYet == false) {
			initTextYet = true;
			for(int i = 0; i < 3; i++) {
				doneAlready[i] = false;
				wonAlready[i] = false;
			}
		}

		if(doneAlready[whichLev] == false) {
			if(voiceOver) {
				PlayClipOn(voiceOver, transform.position, 1.0f, transform);
			}
			for(int i = 0; i < AwakeWhenDone.Length; i++) {
				AwakeWhenDone[i].SetActive(false);
			}
			if(ActivatePlayerSpawner) {
				ActivatePlayerSpawner.enabled = false;
			}

			myText = GetComponent<Text>();
			fullText = myText.text;
			myText.text = " ■";
			StartCoroutine(TypeOutText());
			doneAlready[whichLev] = true;
		} else {
			WhenDone();
		}
	}
	
	IEnumerator TypeOutText() {
		while(fullText.Length > myText.text.Length) {
			yield return new WaitForSeconds(Random.Range(0.1f,0.3f) * 0.43f);
			if(fullText.Substring(myText.text.Length, 1).ToCharArray()[0] == '\n') {
				myText.text = fullText.Substring(0, myText.text.Length)+" ■";
				yield return new WaitForSeconds(1.0f);
			} else {
				myText.text = fullText.Substring(0, myText.text.Length-1)+" ■";
			}
		}
		yield return new WaitForSeconds(0.75f);
		Canvas parentCanv = transform.parent.GetComponent<Canvas>();
		for(int i = 0; i < 20; i++) {
			parentCanv.enabled = (parentCanv.enabled == false );
			yield return new WaitForSeconds(0.7f * Random.Range(0.01f,0.03f) * (20-i));
		}
		WhenDone();
	}

	void WhenDone() {
		for(int i = 0; i < AwakeWhenDone.Length; i++) {
			AwakeWhenDone[i].SetActive(true);
		}
		if(ActivatePlayerSpawner) {
			ActivatePlayerSpawner.enabled = true;
		}
		Destroy(transform.parent.gameObject);
	}
}
