using UnityEngine;
using System.Collections;

public class StopOnTimeout : MonoBehaviour {

    public float lifeTime;
    public bool isProjectile;

	// Use this for initialization
	void Start () {
        if (isProjectile)
            Invoke("DisableProjectile", lifeTime);
        else if (!isProjectile)
            Destroy(gameObject, lifeTime);
	}

    void DisableProjectile() {
        gameObject.SetActive(false);
    }
}
