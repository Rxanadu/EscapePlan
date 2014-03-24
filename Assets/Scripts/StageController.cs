using UnityEngine;
using System.Collections;

/// <summary>
/// controls major aspects of each stage
/// </summary>
public class StageController : MonoBehaviour
{

    public static StageController stageController;

    bool gameActive;
    float startTime, timer, remainingTime;
    GameObject player;

    public ScreenFader screenFader;
    public float levelTimeLimit;
    public Color fullFade, noFade;
    public float fadeDuration;

    public bool GameActive
    {
        get { return gameActive; }
    }

    public float RemainingTime
    {
        get { return remainingTime; }
    }

    void Awake()
    {
        stageController = this;
        startTime = Time.time;
        player = GameObject.FindGameObjectWithTag(TagsAndLayers.player);       
    }

    void Start() {
        print("Starting 'Start' function...");
        gameActive = true;

        //StopCoroutine("StopGame");
        //screenFader.SetScreenOverlayColor(fullFade);
        //screenFader.StartFade(noFade, fadeDuration);

        //StartCoroutine(StopGame());
    }

    // Update is called once per frame
    void Update()
    {
        LevelCountdown();

        //if (remainingTime <= 0)
        //    StopGame();

        print("Game Active: " + gameActive);

        //if (AlarmSystem.alarmSystem.RemainingTime <= 0)       
        //    StopGame();        
    }

    void LevelCountdown()
    {
        timer = Time.time - startTime;
        remainingTime = levelTimeLimit - timer;
    }

    ///<remarks>acts as 'Game Over' function
    ///	only run when either level timer or alarm timer ends</remarks>

    IEnumerator StopGame()
    {
        //activate game for duration of level time limit
        gameActive = true;

        yield return new WaitForSeconds(levelTimeLimit);

        //disable exit room
        gameActive = false;

        //disable player's movement, look movement
        player.GetComponent<CharacterMotor>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        Camera.main.GetComponent<MouseLook>().enabled = false;

        //fade out screen
        screenFader.SetScreenOverlayColor(noFade);
        screenFader.StartFade(fullFade, fadeDuration);

        yield return new WaitForSeconds(fadeDuration);

        //reload scene after fade
        Application.LoadLevel(Application.loadedLevel);
        yield break;
    }
}