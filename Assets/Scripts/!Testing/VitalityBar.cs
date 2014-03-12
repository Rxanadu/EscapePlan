using UnityEngine;
using System.Collections;

/// <summary>
/// <remarks>This was NOT made by me; it was made by the person from this area:
/// https://www.youtube.com/watch?v=rNeIj1Ll4_k </remarks>
/// </summary>
public class VitalityBar : MonoBehaviour
{
    static float curHp = 300.0f;
    static float maxHp = 300.0f;

    static float curMana = 50.0f;
    static float maxMana = 50.0f;

    public Texture2D HpBarTexture;
    public Texture2D ManaBarTexture;

    float hpBarLength;
    float hpPercentage;

    float manaBarLength;
    float manaPercentage;


    void OnGUI()
    {
        GUI.DrawTexture(new Rect((Screen.width / 2) - 100, 20, hpBarLength, 10), HpBarTexture);
        GUI.DrawTexture(new Rect((Screen.width / 2) - 100, 30, manaBarLength, 10), ManaBarTexture);
    }

    void Update()
    {
        //clamp values
        curHp = Mathf.Clamp(curHp, 0, maxHp);
        curMana = Mathf.Clamp(curMana, 0, maxMana);

        hpPercentage = curHp / maxHp;
        hpBarLength = hpPercentage * 100;

        manaPercentage = curMana / maxMana;
        manaBarLength = manaPercentage * 100;

        ReduceVitality();
    }

    void ReduceVitality() {
        if (Input.GetKeyDown("h"))
        {
            curHp -= 10.0f;
        }

        if (Input.GetKeyDown("m"))
        {
            curMana -= 10.0f;
        }
    }
}