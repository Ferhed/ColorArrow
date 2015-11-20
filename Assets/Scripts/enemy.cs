using UnityEngine;
using System.Collections;

public class enemy : Character {

    public Transform player;
    public CharacterController controller;
    public GameObject[] explosion; // Red / Blue / Green
    public bool die = false;
    public Vector3 direction;
    public float speed = 10f;

	void Start () {

        init();
	}
	
    public virtual void init()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void destruction()
    {
        Collider[] currentCollider = GetComponentsInChildren<Collider>();
        foreach (Collider collider in currentCollider)
        {
            collider.enabled = false;
        }
        die = true;
    }

    public void hitByArrow(string color)
    {
        switch (color)
        {
            case "Red":
                explosion[0].GetComponent<ParticleSystem>().Play();
                break;
            case "Blue":
                explosion[1].GetComponent<ParticleSystem>().Play();
                break;
            case "Green":
                explosion[2].GetComponent<ParticleSystem>().Play();
                break;
        }
        destruction();
    }

    public void calculDirection()
    {
        if (player)
        {
            direction = new Vector3(player.position.x - transform.position.x, player.position.y - transform.position.y, 0);
            float distance = Vector3.Distance(player.position, transform.position);
            direction /= distance;
        }
    }

    public void currentDie()
    {
        transform.localScale *= 0.98f;
        if (transform.localScale.x < 0.2)
        {
            Destroy(gameObject);
        }
    }

    public void deplacement()
    {
        controller.Move(direction * Time.deltaTime * speed);
    }
}
