using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// <remarks>place on any empty game object</remarks>
/// </summary>
public class ScreenshotTaker : MonoBehaviour {

	string imageDirectoryName;
	string imageDirectoryPath;

	string screenshotName;
	string screenshotExtension;
	string screenshotFileName;
	int screenshotCount;

	void Start () {
		SetupValues ();
		CheckForPicturesDirectory ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Q)){
			TakePictures ();
		}

		if(Input.GetKeyDown (KeyCode.E)){
			DeleteAllPictures ();
		}
	}	

	/// <summary>
	/// Checks for pictures directory.
	/// </summary>
	void CheckForPicturesDirectory(){
		if(Directory.Exists (imageDirectoryPath)){
			print ("Directory "+imageDirectoryPath+" exists");
		}
		else{
			Directory.CreateDirectory(imageDirectoryPath);
			print ("directory has been created: "+imageDirectoryPath);
		}
	}

	/// <summary>
	/// initialize values of all global variables in class
	/// </summary>
	void SetupValues(){
		imageDirectoryName= "/IngamePictures";
		imageDirectoryPath = Application.dataPath+imageDirectoryName;
		screenshotName = "/testing-screenshot-";
		screenshotCount=0;
		screenshotExtension=".png";
	}

	/// <summary>
	/// creates screenshot for placement in pictures dictionary
	/// </summary>
	void TakePictures(){
		if(screenshotName!=null){
			screenshotFileName =screenshotName+screenshotCount.ToString ()+screenshotExtension;
			Application.CaptureScreenshot (imageDirectoryPath+screenshotFileName);
			print (screenshotFileName+" saved");
			screenshotCount++;
		}
	}

	/// <summary>
	/// deletes all files in the pictures directory
	/// </summary>
	void DeleteAllPictures(){
		string[] pictureCount= Directory.GetFiles (imageDirectoryPath);

		if(pictureCount.Length>0){
			foreach(string picture in pictureCount){
				//print (picture);
				File.Delete (picture);
			}
			print ("All pictures deleted");
		}
		else{
			print ("No files found");
		}
	}
}
