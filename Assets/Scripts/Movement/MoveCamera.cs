using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public float movSpeed = 5;
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * movSpeed,
            0,
            Input.GetAxis("Vertical") * Time.deltaTime * movSpeed);

        transform.position += newPos;

    }
}
