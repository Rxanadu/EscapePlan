using UnityEngine;
using System.Collections;

public class InfoDisplay : MonoBehaviour {
	public enum InfoType {
		TimeRemaining,
		TimeLimit,
		PrisonerAmount,
		PrisonersRemaining
	}

	public InfoType infoType;

	TextMesh infoText;
	string infoTextString;

	public Texture2D timeRemaining, timeLimit, prisonerAmount, prisonersRemaining;

	void Start() {
		infoTextString = "";
	}

	// Use this for initialization
	void Update () {
		infoText = transform.FindChild("info_display_number-display").gameObject.GetComponent<TextMesh>();

		SetInfoType ();
	}

	/// <summary>
	/// Sets info type for display.
	/// <remarks>can't find a way to reference main textures using a simple variable,
	/// 	had to resort to finding the main texture in runtime via "Find()" :(</remarks>
	/// </summary>
	void SetInfoType() {
		switch(infoType) {
			case InfoType.TimeRemaining:
				transform.Find("info-display_message").gameObject.renderer.material.mainTexture = timeRemaining;
				float stageTime = QuickStart.quickStart.RemainingTime;
				infoTextString = string.Format("{0}:{1:00}", (int)stageTime / 60, (int)stageTime % 60);
				infoText.text = infoTextString;
				break;
			case InfoType.TimeLimit:
				transform.Find("info-display_message").gameObject.renderer.material.mainTexture = timeLimit;
				float stageTimeLimit = StageController.stageController.levelTimeLimit;
				infoTextString = string.Format("{0}:{1:00}", (int)stageTimeLimit / 60, (int)stageTimeLimit % 60);
				infoText.text = "00:00";
				break;
			case InfoType.PrisonerAmount:
				transform.Find("info-display_message").gameObject.renderer.material.mainTexture = prisonerAmount;
				infoText.text = "00";
				break;
			case InfoType.PrisonersRemaining:
				transform.Find("info-display_message").gameObject.renderer.material.mainTexture = prisonersRemaining;
				if(EndRoom.endRoom.PrisonersLeft>0)
					infoTextString = EndRoom.endRoom.PrisonersLeft.ToString();
				else
					infoTextString = "0";
				infoText.text = infoTextString;
				break;
		}
	}
}
