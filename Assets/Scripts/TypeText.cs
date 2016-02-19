using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeText : MonoBehaviour {
	public GameObject[] AwakeWhenDone;
	Text myText;
	string fullText;
	public int whichLev;
	public static bool[] wonAlready = new bool[3]; // tracks which stages have been won
	public static bool[] doneAlready = new bool[3]; // prevents text from showing up on retries
	public static bool initTextYet = false;
	public static TypeText instance;

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
			for(int i = 0; i < AwakeWhenDone.Length; i++) {
				AwakeWhenDone[i].SetActive(false);
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
			yield return new WaitForSeconds(Random.Range(0.1f,0.3f) * 0.4f);
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
		Destroy(transform.parent.gameObject);
	}
}
