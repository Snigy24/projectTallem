using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour {

    private GameObject cam;

    // Use this for initialization
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update () {
            transform.position = new Vector2(cam.transform.position.x + 6, cam.transform.position.y + 4);
    }
}
