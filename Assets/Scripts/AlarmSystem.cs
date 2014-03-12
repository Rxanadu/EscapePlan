using UnityEngine;
using System.Collections;

/// <summary>
/// Alarm system for the game
/// <remarks>will only be one instance of this object</remarks>
/// </summary>
[RequireComponent(typeof(Light))]
public class AlarmSystem : MonoBehaviour {

	public static AlarmSystem alarmSystem;

	bool alarmActive;
	float initialLightIntensity;
	Light alarmLight;
	Color initalLightColor;
	float targetIntensity;
	GameObject[] tripwires;
	float deathTimer;
	float startTime;
	float remainingTime;

	public Color alarmLightColor;
	public float alarmRate;
	public float highIntensity,lowIntensity;
	public float changeMargin;
	public float deatTimeLimit;

	public bool AlarmActive{
		get{return alarmActive;}
		set{alarmActive=value;}
	}

	public float RemainingTime{
		get{return remainingTime;}
	}

	void Awake(){
		if(alarmSystem==null){
			DontDestroyOnLoad (this.gameObject);
			alarmSystem=this;
		}
		else if(alarmSystem!=this)
			Destroy (gameObject);

		ResetDeathTimer ();
	}

	// Use this for initialization
	void Start () {
		alarmActive=false;
		alarmLight = GetComponent<Light>();
		initalLightColor =alarmLight.color;
		initialLightIntensity = alarmLight.intensity;
		targetIntensity=highIntensity;

		tripwires = GameObject.FindGameObjectsWithTag ("Tripwire");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//clamp time for game
		remainingTime = Mathf.Clamp (remainingTime, 0, deatTimeLimit);

		if(alarmActive)
		{
			TurnAlarmOn ();
			CountdownDeathTimer ();
			PlayAlarmSound ();
		}
		else{
			TurnAlarmOff ();
			ResetDeathTimer ();
			StopAlarmSound ();
		}
	}
	
	void TurnAlarmOn(){
		float alarmStep = alarmRate*Time.deltaTime;
		alarmLight.color = alarmLightColor;
		alarmLight.intensity = Mathf.Lerp(alarmLight.intensity, targetIntensity, alarmStep);
		
		CheckTargetIntensity();

		//disable all tripwires
		foreach(GameObject tripwire in tripwires){
			tripwire.GetComponent<Tripwire>().enabled=false;
			tripwire.GetComponent<LineRenderer>().enabled=false;
		}
	}

	void TurnAlarmOff(){
		alarmLight.color = initalLightColor;
		alarmLight.intensity = initialLightIntensity;

		//enable all tripwires
		foreach(GameObject tripwire in tripwires){
			tripwire.GetComponent<Tripwire>().enabled=true;
			tripwire.GetComponent<LineRenderer>().enabled=true;
		}
	}

	void CountdownDeathTimer(){

		deathTimer = Time.time-startTime;
		remainingTime = deatTimeLimit-deathTimer;
	}

	void ResetDeathTimer(){
		startTime = Time.time;
		remainingTime=deatTimeLimit;
	}

	void PlayAlarmSound(){
		if(!audio.isPlaying){
			audio.Play ();
		}
	}

	void StopAlarmSound(){
		if(audio.isPlaying){
			audio.Stop ();
		}
	}

	void CheckTargetIntensity ()
	{
		// If the difference between the target and current intensities is less than the change margin...
		if(Mathf.Abs(targetIntensity - alarmLight.intensity) < changeMargin)
		{
			// ... if the target intensity is high...
			if(targetIntensity == highIntensity)
				// ... then set the target to low.
				targetIntensity = lowIntensity;
			else
				// Otherwise set the targer to high.
				targetIntensity = highIntensity;
		}
	}
}
