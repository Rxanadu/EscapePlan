using UnityEngine;
using System.Collections;

public class MapScreen : MonoBehaviour {

	public static MapScreen mapScreen;

	int selectedFloor;

	public Texture2D[] mapFloors;

	public int SelectedFloor{
		get{return selectedFloor;}
		set{selectedFloor=value;}
	}

	void Awake(){
		mapScreen = this;
	}

	// Use this for initialization
	void Start () {
		selectedFloor= 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(selectedFloor>mapFloors.Length-1)
			selectedFloor=0;
		if(selectedFloor<0)
			selectedFloor=mapFloors.Length-1;

		renderer.material.mainTexture= mapFloors[selectedFloor];
	}
}
