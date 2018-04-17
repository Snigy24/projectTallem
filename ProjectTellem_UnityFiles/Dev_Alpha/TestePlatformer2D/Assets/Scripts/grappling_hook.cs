using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappling_hook : MonoBehaviour {

    DistanceJoint2D joint;
    Vector3 grapTarget;
    RaycastHit2D hit;
    public float distance = 20f;
    public LayerMask mask;
    public LineRenderer line;
    GameObject fishingrod;

	// Use this for initialization
	void Start () {
		joint = GetComponent<DistanceJoint2D> ();
        joint.enabled = false;
        line.enabled = false;
        fishingrod = GameObject.FindWithTag("fishrod");

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
        {
            grapTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grapTarget.z = 0;

            hit = Physics2D.Raycast(transform.position, grapTarget - transform.position, distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D> () != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, new Vector2(fishingrod.transform.position.x, fishingrod.transform.position.y));
                line.SetPosition(1, hit.point);
            }
        }

        if (Input.GetMouseButton(1))
        {
            line.SetPosition(0, new Vector2(fishingrod.transform.position.x, fishingrod.transform.position.y));
        }

        if (Input.GetMouseButtonUp(1))
        {
            joint.enabled = false;
            line.enabled = false;
        }
    }
}
