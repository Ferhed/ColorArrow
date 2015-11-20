using UnityEngine;
using System.Collections;

public abstract class Character:MonoBehaviour {

    public void death()
    {
        Destroy(gameObject);
    }
}
