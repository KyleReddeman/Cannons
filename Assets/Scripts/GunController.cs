using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {


    public float speed = 50f;
	public Transform rotatePoint;
    
    private float turnAxisInput;

    void Awake() {
    }

    void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
		turnAxisInput = -1 * Input.GetAxis("TurretAxis");

	}
	void LateUpdate() {
		if(turnAxisInput != 0) {

			rotatePoint.Rotate(turnAxisInput * speed * Time.deltaTime, 0f, 0f);
			float x = rotatePoint.rotation.eulerAngles.x;
			x += 180;
			if(x >= 360) {
				x -= 360;
			}
			rotatePoint.rotation = Quaternion.Euler(Mathf.Clamp(x, 165f, 186f) - 180f, 0f, 0f);//Mathf.Clamp(x, 165f, 186f) + 180, 0f, 0f);
		}

	}

    
}
