using UnityEngine;
using System.Collections;

/// <summary>
/// controls when all music within the game is played
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{

    public AudioClip[] startingMusic;
    public AudioClip[] gameMusic;
    public AudioClip[] deathNouses;

    AudioClip startingClip, gameClip, deathClip;    //randomized clips created at runtime
    JumpGameReferences jgr;

    //for use with DeathArea script
    public AudioClip DeathClip { get { return deathClip; } }

    void Awake()
    {
        jgr = GameObject.FindGameObjectWithTag(TagsAndLayers.gameController).GetComponent<JumpGameReferences>();
    }

    void Start()
    {
        startingClip = startingMusic[Random.Range(0, startingMusic.Length)];
        gameClip = gameMusic[Random.Range(0, gameMusic.Length)];
        deathClip = deathNouses[Random.Range(0, deathNouses.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        SwitchGameMusic();
    }

    //change the music that's playing based on the game state
    void SwitchGameMusic()
    {
        switch (jgr.jgs.gameState)
        {
            case JumpGameState.GameStateJump.IntroducingGame:
                if (!audio.isPlaying)
                {
                    audio.loop = true;
                    audio.clip = startingClip;
                    audio.Play();
                }
                break;
            case JumpGameState.GameStateJump.Starting:
                if (audio.isPlaying) {
                    audio.Stop(); ;
                }
                break;
            case JumpGameState.GameStateJump.Started:
                if (audio.clip != gameClip)
                {
                    audio.clip = gameClip;
                }
                if (!audio.isPlaying)
                    audio.Play();
                break;
            case JumpGameState.GameStateJump.Ended:
                if (audio.clip != deathClip)
                {
                    audio.loop = false;
                    audio.clip = deathClip;
                }
                if (!audio.isPlaying)
                    audio.Play();
                break;
        }
    }
}