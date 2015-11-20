using UnityEngine;
using System.Collections;

public class playerMovement :Character {

	public float speed = 15f;

	private CharacterController character;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3 (Input.GetAxis ("L_XAxis_1"), -Input.GetAxis ("L_YAxis_1"), 0f);
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= speed;


		character.Move (moveDirection * Time.deltaTime);

	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            death();
        }
    }


}
