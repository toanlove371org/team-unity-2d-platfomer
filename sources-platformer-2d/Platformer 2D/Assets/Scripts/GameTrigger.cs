using UnityEngine;
using System.Collections;

public class GameTrigger : MonoBehaviour {

	private GameObject hero;
	public Font font;
	private string noticeText;
	private Vector2 heroSpawnPos;

	GUIStyle myStyle;

	#region Singleton
	private static GameTrigger instance;
	private GameTrigger() {}
	public static GameTrigger Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType(typeof(GameTrigger)) as  GameTrigger;
			}
			return instance;
		}
	}
	#endregion

	// Use this for initialization
	void Start () {
		hero = GameObject.FindGameObjectWithTag("Player");
		heroSpawnPos = hero.transform.position;
		myStyle = new GUIStyle();
		myStyle.font = font;
		myStyle.fontSize = 40;
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.normal.textColor = Color.blue;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region Respawn
	public void SetHeroSpawnPos(Vector2 pos) {
		this.heroSpawnPos = pos;
	}

	public void RespawnHero() {
		Collider2D[] cols = hero.GetComponents<Collider2D>();
		foreach(Collider2D c in cols)
		{
			c.isTrigger = false;
		}
		// ... disable user Player Control script
		hero.GetComponent<PlayerControl>().enabled = true;
		// ... disable the Gun script to stop a dead guy shooting a nonexistant bazooka
		hero.GetComponentInChildren<GunPlayer>().enabled = true;

		hero.GetComponentInChildren<GunPlayer>().ResetBullet();
		hero.SetActive(false);
		StartCoroutine(WaitToRespawn(heroSpawnPos));

	}

	IEnumerator WaitToRespawn(Vector2 pos) {
//		hero.transform.position = heroSpawnPos;
		hero.transform.position = pos;
		hero.GetComponent<PlayerHealth>().SetHealth(10);
		yield return new WaitForSeconds(2);
		hero.SetActive(true);
//		hero.GetComponentInChildren<GunPlayer>().ResetBullet();
	}
	#endregion

	#region End level
	public void EndLevel() {
		FadeScene.LoadLevel(Application.loadedLevel + 1, 1.5f, 2.0f, Color.black);
	}
	#endregion

	#region Text
	public void ShowNotice(string text, float time) {

		StartCoroutine(WaitShowNotice(text, time));
	}

	IEnumerator WaitShowNotice(string text, float time) {
		noticeText = text;
		yield return new WaitForSeconds(time);
		noticeText = "";
	}

	void OnGUI() {


		GUI.Label (new Rect (Screen.width/2 - 50, Screen.height - 50, 100, 20),
		           noticeText, myStyle);
	}
	#endregion
}
