using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    //[HideInInspector]
    public int damange;
    [HideInInspector]
    public Character target;
    public float Speed = 5.0f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (target == null||!target.Alive) Destroy(gameObject); //remove em caso de premorte
        transform.LookAt(target.transform);
        transform.position += transform.forward * Speed*Time.fixedDeltaTime;
       
	}

    
    private void OnTriggerEnter(Collider other)//no choque
    {
        
        if (other.gameObject == target.gameObject)
        {
            other.GetComponent<Character>().AplyDamange(damange);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }
}
