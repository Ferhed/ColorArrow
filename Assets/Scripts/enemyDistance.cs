using UnityEngine;
using System.Collections;

public class enemyDistance : enemy {
    public float distanceToShoot = 5f;
    public float minimumToShoot = 3f;
    public float maximumToShoot = 7f;
    public GameObject fireBall;

    
    private Vector3 launchDirect;
    public float distance;
    private float timeToShoot = 2f;

    void Update()
    {
        calculDirection();
        if (!die)
        {
            distance = Vector3.Distance(transform.position, player.position);
            if (timeToShoot != 0)
            {
                timeToShoot = Mathf.Max(0f, timeToShoot - Time.deltaTime);
            }

            if (distance > distanceToShoot)
            {
                deplacement();

            }
            else
            {
                controller.Move(Vector3.zero);
                if (timeToShoot == 0)
                {
                    launchFireBall();
                }
            }
        }
        
        if (die)
        {
            currentDie();
        }
        direction /= distance;
    }


    void launchFireBall()
    {
        launchDirect = new Vector3(player.position.x - transform.position.x, player.position.y - transform.position.y, 0);
        if (distance != 0)
        {
            launchDirect = launchDirect / (distance);
        }
        float angle;
        angle = (Mathf.Atan2((transform.position.y + launchDirect.y - transform.position.y), (transform.position.x + launchDirect.x - transform.position.x)) + Mathf.PI) * 180 / Mathf.PI;
        GameObject ball = (GameObject)Instantiate(fireBall,transform.position+launchDirect,Quaternion.identity) as GameObject;
        ball.transform.eulerAngles = new Vector3(0, 0, angle+90);
        timeToShoot = Random.Range(minimumToShoot, maximumToShoot);
    }


}