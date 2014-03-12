using UnityEngine;
using System.Collections;

public class AlarmBox : MonoBehaviour {

	bool isDead;	//determines whether alarm box could be destroyed
	public float deathTime;
	public GameObject alarmBoxExplosion;

	public bool IsDead{
		set{isDead=value;}
	}

	// Use this for initialization
	void Start () {	
		isDead=false;
	}
	
	// Update is called once per frame
	void Update () {

		if(isDead)
			Invoke ("DestroyAlarmBox", deathTime);
	}

	void DestroyAlarmBox(){
		Destroy (this.gameObject);
		Instantiate (alarmBoxExplosion, transform.position, transform.rotation);
	}
}
