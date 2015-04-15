using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gold_Management : MonoBehaviour {
	public static Gold_Management Instance;
	public int curGold;
	public int maxGold;
	public Text gold;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		gold.text = "Gold:" +curGold+"/" +maxGold;

		if (curGold >= maxGold) {
			Debug.Log("qua man");
			Time.timeScale = 0.5f;
			if(Input.GetButtonDown("Fire1"))
			{
			Application.LoadLevel(Application.loadedLevel+1);
			//Debug.Log(Application.loadedLevel);
			}
		}
	}
}