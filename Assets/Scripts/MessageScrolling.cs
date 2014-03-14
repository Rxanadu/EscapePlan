using UnityEngine;
using System.Collections;

public class MessageScrolling : MonoBehaviour {

	public Vector2 scrollSpeed = Vector2.one;
	Material messageMaterial;
	
	// Use this for initialization
	void Start()
	{
		messageMaterial = renderer.material;
	}
	
	// Update is called once per frame
	void Update()
	{
		//messageMaterial.mainTextureOffset += scrollSpeed * Time.deltaTime;
		messageMaterial.mainTextureOffset = scrollSpeed * Time.time;
	}
}
