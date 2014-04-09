using UnityEngine;
using System.Collections;

/// <summary>
/// timer used to show how long game lasts
/// </summary>
public class GameTimer : MonoBehaviour
{

    public float timer = 10.0f;             //game's timer
    public float addTime = 10.0f;           //time added to the timer when collectable is touched
    public float timeDisplayFrame = 2.0f;   //time for which added time will appear
    public bool testingGUI = false;         //are we just testing the mechanics of the timer?
    public GUIText addTimeText;             //offical format for dislaying added time

    bool showGUI = false;                   //are we showing the add time text?
    GUIText timerText;                      //official format for displaying current time on timer
    JumpGameReferences jgr;

    public bool ShowGUI { set { showGUI = value; } }

    void Awake()
    {
        timerText = GetComponent<GUIText>();
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    // Use this for initialization
    void Start()
    {
        addTimeText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //do nothing if timer text cannot be found
        if (timerText == null)
            return;

        //display default text if game has not started or if it has finished
        if (jgr.jgs.gameState != JumpGameState.GameStateJump.Started)
        {
            timerText.text = "";
        }

        //count time down when game starts
        if (jgr.jgs.gameState == JumpGameState.GameStateJump.Started)
        {
            string timerString = string.Format("{0:00}", timer);
            timerText.text = timerString;
            timer -= Time.deltaTime;
        }

        if (timer <= 0 || jgr.jgs.gameState == JumpGameState.GameStateJump.Ended)
        {
            timer = 0;

            //only call if time <= 0
            if (jgr.jgs.gameState != JumpGameState.GameStateJump.Ended)
                jgr.jgs.gameState = JumpGameState.GameStateJump.Ended;
        }

        if (showGUI)
        {
            addTimeText.enabled = true;
            addTimeText.text = "+" + addTime.ToString("0");
            Invoke("ShowTimerGUI", timeDisplayFrame);
        }
    }

    void OnGUI()
    {
        if (testingGUI)
        {
            GUI.Box(new Rect(10, 10, 30, 30), timer.ToString("0"));

            if (showGUI)
            {
                GUI.Box(new Rect(15, 30, 30, 30), "+" + addTime.ToString("0"));
                Invoke("ShowTimerGUI", timeDisplayFrame);
            }
        }
    }

    void ShowTimerGUI()
    {
        showGUI = false;
        addTimeText.enabled = false;
    }
}