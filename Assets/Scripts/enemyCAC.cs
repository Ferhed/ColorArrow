using UnityEngine;
using System.Collections;

public class enemyCAC : enemy {


	void Update () {
        calculDirection();
        if (!die)
        {
            deplacement();
        }

        if (die)
        {
            currentDie();
        }
	}









}
