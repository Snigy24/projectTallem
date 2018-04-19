using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grappling_hook : MonoBehaviour {

    DistanceJoint2D joint;
    Vector3 grapTarget;
    RaycastHit2D hit;
    public float distance = 20f;
    public LayerMask mask;
    public LineRenderer line;
    GameObject fishingrod;
    private bool facingRight = true;

    // Use this for initialization
    void Start () {
		joint = GetComponent<DistanceJoint2D> ();
        joint.enabled = false;
        line.enabled = false;
        fishingrod = GameObject.FindWithTag("fishrod");
    }

    GameObject FindClosestTarget(string graple)
    {
        Vector3 position = transform.position;
        return GameObject.FindGameObjectsWithTag(graple)
            .OrderBy(o => (o.transform.position - position).sqrMagnitude)
            .FirstOrDefault();
    }

    // Update is called once per frame
    void Update () {

        // print("Closest Object is " + FindClosestTarget("graple").name);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            // Find grap
            grapTarget = FindClosestTarget("graple").transform.position;

            hit = Physics2D.Raycast(transform.position, grapTarget - transform.position, distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D> () != null)
            {
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;
                line.SetPosition(0, new Vector2(fishingrod.transform.position.x , fishingrod.transform.position.y));
                line.SetPosition(1, hit.point);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            line.SetPosition(0, new Vector2(fishingrod.transform.position.x, fishingrod.transform.position.y));

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                // Force
                if (facingRight == true)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.right * 300);
                    GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100);
                }

                if (facingRight == false)
                {
                    GetComponent<Rigidbody2D>().AddForce(Vector2.left * 300);
                    GetComponent<Rigidbody2D>().AddForce(Vector2.down * 100);
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            joint.enabled = false;
            line.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            facingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            facingRight = true;
        }
    }
}