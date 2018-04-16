using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_System : MonoBehaviour {

    private GameObject player;
    public float yMapaFuturo = 1;
    public float yMapaPassado = 66;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
