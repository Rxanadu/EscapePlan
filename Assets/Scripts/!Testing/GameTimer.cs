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

        if (timerText == null)
            return;

        string timerString = string.Format("{0:00}", timer);
        timerText.text = timerString;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
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
            GUI.Box(new Rect(1, 1, 1, 1), timer.ToString("0"));

            if (showGUI)
            {
                GUI.Box(new Rect(2, 2, 2, 2), "+" + addTime.ToString("0"));
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