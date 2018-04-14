using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {

    public int health = 100;
    public bool dead = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((gameObject.transform.position.y < -5) && (gameObject.transform.position.y > -6))
        {
            dead = true;
        }
        if ((gameObject.transform.position.y < -72) && (gameObject.transform.position.y > -73))
        {
            dead = true;
        }
        if (dead == true)
        {
            StartCoroutine("Die");
        }
	}

    IEnumerator Die()
    {
        SceneManager.LoadScene("Prototipo1");
        yield return null;
    }
}
