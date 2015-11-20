using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class targetAndShoot : MonoBehaviour {

	public GameObject target;
    public Vector3 tarPosition = Vector3.right;
    public GameObject[] pickPosition;
	// Use this for initialization

    private SpriteRenderer playerRenderer;
    public List<GameObject> arrowList;
    enum COLOR {
        BLUE = 1,
        RED =2,
        GREEN =3
    }

    private COLOR currentState = COLOR.BLUE;
    private int currentArrow = 0;
    private Vector3 launchDirect = -Vector3.right;


    
	void Start () {
        playerRenderer = GetComponent<SpriteRenderer>();
        changeColor(arrowList);
	}
	
	// Update is called once per frame
	void Update () {

        placeArrow();

        tarPosition = new Vector3(Input.GetAxis("R_XAxis_1"), -Input.GetAxis("R_YAxis_1"), 0);
        float distance = Vector3.Distance(Vector3.zero, tarPosition);
        if (distance != 0)
        {
            tarPosition = tarPosition / (distance * 4f);
            target.transform.localPosition = tarPosition;
            launchDirect = tarPosition;
        }

       if(Input.GetButtonDown("LB_1") && arrowList.Count >0)
       {
           if (currentArrow + 1 >= arrowList.Count)
               currentArrow = 0;
           else
               currentArrow++;
           changeColor(arrowList);
       }
       if (Input.GetButtonDown("RB_1") && arrowList.Count > 0)
       {
           launchArrow();
       }
	}

    void launchArrow()
    {
        Transform fleche;
        if (currentArrow <= arrowList.Count-1)
        {
            fleche = arrowList[currentArrow].transform;
            fleche.position = transform.position + launchDirect ;

            float angle;
            angle = (Mathf.Atan2((transform.position.y + launchDirect.y - transform.position.y), (transform.position.x + launchDirect.x - transform.position.x)) + Mathf.PI) * 180 / Mathf.PI;
            fleche.eulerAngles = new Vector3(0, 0, angle + 90);
            fleche.parent = null;
            arrow scriptArrow = fleche.GetComponent<arrow>();
            scriptArrow.launched = true;
            scriptArrow.trail.SetActive(true);
            arrowList.Remove(fleche.gameObject);
            changeColor(arrowList);
        }
    }

    void placeArrow()
    {
        if (arrowList.Count>=1)
            arrowList[0].transform.position = pickPosition[0].transform.position;
        if (arrowList.Count >= 2)
            arrowList[1].transform.position = pickPosition[1].transform.position;
        if (arrowList.Count == 3)
            arrowList[2].transform.position = pickPosition[2].transform.position;
    }

     void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Blue" || other.gameObject.tag == "Red" || other.gameObject.tag == "Green")
        {
            if (!other.GetComponent<arrow>().launched)
            {
                other.transform.position = Vector3.zero;
                other.transform.eulerAngles = new Vector3(0, 0, -30);
                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                arrowList.Add(other.gameObject);
                changeColor(arrowList);
                arrow scriptArrow = other.GetComponent<arrow>();
                scriptArrow.trail.SetActive(false);
            }

        }
    }

    public void changeColor(List<GameObject> arrowList)
    {
        int color = 1;
        GameObject fleche = null;
        if (currentArrow <= arrowList.Count - 1)
        {
            fleche = arrowList[currentArrow];
        }

		if(fleche == null)
		{
			color = 0;
		}
        else if (fleche.tag == "Blue")
        {
            color = 1;
        }
        else if (fleche.tag == "Red")
        {
            color = 2;
        }
        else if (fleche.tag == "Green")
        {
            color = 3;
        }

        

        switch (color)
        {
			case 0:
			playerRenderer.color = Color.cyan;
				break;
            case 1:
                playerRenderer.color = Color.blue;
                break;
            case 2:
                playerRenderer.color = Color.red;
                break;
            case 3:
                playerRenderer.color = Color.green;
                break;
        }
    }

}
