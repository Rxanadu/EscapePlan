using UnityEngine;
using System.Collections;

public class StopOnTimeout : MonoBehaviour
{

    public float lifeTime;
    public bool isProjectile;

    // Use this for initialization
    void Start()
    {
        if (isProjectile)
            Invoke("DisableProjectile", lifeTime);
        else if (!isProjectile)
        {
            AudioSource audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
                Destroy(gameObject, lifeTime);
            else
                Destroy(gameObject, audioSource.audio.clip.length);
        }
    }

    void DisableProjectile()
    {
        gameObject.SetActive(false);
    }
}