﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour {

    public Transform playerRootObject;

    public KeyCode grabKey;
    public float throwForse;

    public GameObject grabbedObject;



    public Transform grabObjectPos;

    public GameObject heands;

    public GameObject collidedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(grabKey))
        {
            if (collidedObject != null && grabbedObject == null && collidedObject.transform.parent == null)
            {
                grabbedObject = collidedObject;
                grabbedObject.transform.position = grabObjectPos.position;
                grabbedObject.transform.parent = gameObject.transform;
                grabbedObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;

                //heands.SetActive(true);
            }
            else
            {
                if (grabbedObject != null)
                {
                    grabbedObject.transform.parent = null;
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabbedObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(throwForse * playerRootObject.lossyScale.x, -throwForse/10), ForceMode2D.Impulse);
                    grabbedObject = null;

                    //heands.SetActive(false);
                }
            }
               
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "GrabObject")
            collidedObject = coll.gameObject;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "GrabObject")
            collidedObject = null;
    }
}
