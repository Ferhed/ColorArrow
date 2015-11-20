using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {


    public float speed = 5f;
    public bool launched = false;
	public GameObject trail;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(launched)
            transform.position = transform.position + transform.up * Time.deltaTime * speed;
	}

    void OnCollisionEnter(Collision collision) {

        Debug.Log("collision");
        if(collision.gameObject.tag == "EnemyCAC")
        {
            collision.gameObject.GetComponent<enemyCAC>().hitByArrow(tag);
        }
        else if (collision.gameObject.tag == "EnemyDist")
        {
            collision.gameObject.GetComponent<enemyDistance>().hitByArrow(tag);
        }
        else if (collision.gameObject.tag == "EnemyTank")
        {
            collision.gameObject.GetComponent<enemyTank>().hitByArrow(tag);
        }


        launched = false;



    }
}
