using UnityEngine;
using System.Collections;

public class PillarShrinker : MonoBehaviour {

    public GameObject shrinkEmitter;
    public Transform shrinkPump;
    public float scaleRate = 3.0f;

    LineRenderer shrinkLine;
    Vector3 initPumpScale, lowPumpScale;
    Vector3 targetScale;
    void Awake() {
        shrinkLine = shrinkEmitter.GetComponent<LineRenderer>();
        initPumpScale = shrinkPump.localScale;
        lowPumpScale = new Vector3(.1f,  initPumpScale.y, .1f);
    }

	// Use this for initialization
	void Start () {
        if (shrinkLine == null)
            return;

        //shrinkLine.enabled = false;

        targetScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        //shrink the pillars when the raycast hits them!!!
        Ray shrinkRay = new Ray(shrinkEmitter.transform.position, -shrinkEmitter.transform.up);
        RaycastHit hit;

        if (Physics.Raycast(shrinkRay, out hit))
        {            
            if (shrinkLine == null)
                return;

            shrinkLine.SetPosition(0, shrinkEmitter.transform.position);
            shrinkLine.SetPosition(1, hit.point);

            if (hit.transform.CompareTag(TagsAndLayers.jumppadPillar)) {
                hit.transform.localScale -= new Vector3(.1f * Time.deltaTime, hit.transform.localScale.y, .1f * Time.deltaTime);
            }
        }

        //loop shrinking pump 'animation'(for now)
        if (shrinkPump == null)
            return;

        float scaleStep = scaleRate * Time.deltaTime;
        if (shrinkPump.localScale.x <= .1f)
            targetScale = initPumpScale;
        if (shrinkPump.localScale.x >= 1.0f)
            targetScale = lowPumpScale;

        shrinkPump.localScale = Vector3.Lerp(shrinkPump.localScale, targetScale, scaleStep);
    }
}
