using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	public float countdown = 2f;
	
	// Update is called once per frame
	void Update () {

	}

    public void DelayedCollisionEnabled()
    {
        Invoke("EnableCollider", 0.2f);
    }

    void EnableCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        FindObjectOfType<MapDestroyer>().Explode(transform.position);
        Destroy(gameObject);
    }
}
