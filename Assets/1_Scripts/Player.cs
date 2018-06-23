﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject yellowColorRayr;

    public float speed = 8;
    public float rayFiringRate = 0.2f;

    enum Facing { LEFT, RIGHT };
    private Facing facing = Facing.RIGHT;

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            facing = Facing.LEFT;
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            facing = Facing.RIGHT;
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("FirePowerRay", 0.000001f, rayFiringRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("FirePowerRay");
        }
    }

    private void FirePowerRay()
    {
        //Debug.Log("FireLaser");
        GameObject beam = Instantiate(yellowColorRayr, transform.position, Quaternion.identity) as GameObject;
        float speed = beam.gameObject.GetComponent<PowerRay>().GetSpeed();

        if (facing == Facing.RIGHT)
            beam.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        else
            beam.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

        //AudioSource.PlayClipAtPoint(fireSound, transform.position);

    }
}