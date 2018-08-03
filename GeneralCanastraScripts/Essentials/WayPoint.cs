using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

    public int index = -1;
	
	void Start () {
        if(index!=-1)
        ManagerGame.Singleton.wayPoints[index]=this;
	}

}
