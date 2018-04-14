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
        if (player.transform.position.y >= -30)
        {
            transform.position = new Vector3(player.transform.position.x, yMapaFuturo, transform.position.z);
        }
        if (player.transform.position.y < -30)
        {
            transform.position = new Vector3(player.transform.position.x, yMapaPassado, transform.position.z);
        }
    }
}
