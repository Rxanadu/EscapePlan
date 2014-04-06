using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{

    public AudioClip[] startingMusic;
    public AudioClip[] gameMusic;
    public AudioClip[] deathNouses;

    JumpGameReferences jgr;

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchGameMusic();
    }

    void SwitchGameMusic()
    {
        switch (jgr.jgs.gameState)
        {
            case JumpGameState.GameStateJump.Starting:
                if (!audio.isPlaying)
                {
                    audio.loop = true;
                    audio.clip = startingMusic[Random.Range(0, startingMusic.Length)];
                    audio.Play();
                }
                break;
            case JumpGameState.GameStateJump.Started:
                audio.clip = gameMusic[Random.Range(0, gameMusic.Length)];
                audio.Play();
                break;
            case JumpGameState.GameStateJump.Ended:
                audio.loop = false;
                audio.PlayOneShot(deathNouses[Random.Range(0, deathNouses.Length)]);
                break;
        }
    }
}