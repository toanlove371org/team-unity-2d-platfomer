using UnityEngine;
using System.Collections;

public class GameTrigger : MonoBehaviour {

	public GameObject hero;
	private Vector2 heroSpawnPos;

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region Respawn
	public void SetHeroSpawnPos(Vector2 pos) {
		this.heroSpawnPos = pos;
	}

	public void RespawnHero() {
		hero.SetActive(false);
		StartCoroutine("WaitToRespawn");
	}

	IEnumerator WaitToRespawn() {
		hero.transform.position = heroSpawnPos;
		hero.GetComponent<PlayerHealth>().SetHealth(10);
		yield return new WaitForSeconds(2);
		hero.SetActive(true);
	}
	#endregion

	#region Hide Object
	public void ShowObjects(GameObject go) {
		go.GetComponent<TrigHideObject>().SetActiveAll(true);
	}
	#endregion

	#region Spawn Item
	public void SpawnItem(Vector2 pos) {
		PickupSpawner.Instance.SpawnItem(2, pos);
	}
	#endregion
}
