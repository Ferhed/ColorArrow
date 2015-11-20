using UnityEngine;
using System.Collections;

public class enemyTank : enemy {

    public float vitesseRotation = 1.5f;
    public GameObject bouclier;

    private Transform dad;
    private Transform trBouclier;
    private float angle;
    public override void init()
    {
        base.init();
        trBouclier = bouclier.transform;
        dad = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        calculDirection();
        if (!die)
        {
            deplacement();
        }
        rotateMePlz();
        if (die)
        {
            dad.localScale *= 0.98f;
            if (transform.localScale.x < 0.2)
            {
                Destroy(dad.gameObject);
            }
        }
        trBouclier.localPosition = transform.localPosition - transform.right/2;
        trBouclier.localRotation = transform.localRotation;

    }


    void rotateMePlz()
    {
        Vector3 wantToRotate = new Vector3(player.position.x - transform.position.x, player.position.y - transform.position.y, 0);
        angle = (Mathf.Atan2((transform.position.y + wantToRotate.y - transform.position.y), (transform.position.x + wantToRotate.x - transform.position.x)) + Mathf.PI) * 180 / Mathf.PI;
		if(angle>180)
		{
			angle -= 360;
		}
		float transformZ = transform.eulerAngles.z;
		if(transformZ>180)
		{
			transformZ -= 360;
		}
       // transform.eulerAngles = new Vector3(0, 0, angle );
        float test = angle - transformZ;
        if(test<0 && test>-180)
        {
            transform.Rotate(new Vector3(0, 0, -vitesseRotation));
        }
        else if (test>0 || test < -180)
        {
            transform.Rotate(new Vector3(0, 0, vitesseRotation));
        }
        
    }
}
