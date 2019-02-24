using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astro : MonoBehaviour
{

    public static List<Astro> astroList = new List<Astro>();

    [SerializeField]
    private float mass = 1.0f;
    public float Mass
    {
        get
        {
            return mass;
        }
        private set
        {
            if (value > 0)
            {
                mass = value;
            }
        }
    }
    [HideInInspector]
    public Vector3 dir = Vector3.zero;
    private SphereCollider cl;
    // Use this for initialization
    void Start()
    {
        astroList.Add(this);       
        cl = GetComponent<SphereCollider>();
    }


    void Update()
    {
        foreach (Astro astro in astroList)
        {
            
            if (astro != this)
            {
                if (collisionAstros(astro))
                {
                    dir += CalcAtraction(this, astro) * (astro.transform.position - gameObject.transform.position);
                }
            }
        }
        transform.position += dir * Time.deltaTime;
    }

    private float CalcAtraction(Astro A, Astro B)
    {
        return 0.006f * B.Mass / Mathf.Pow(Vector3.Distance(A.transform.position, B.transform.position), 2);
    }
    private bool collisionAstros(Astro other)
    {
        if (Vector3.Distance(gameObject.transform.position,other.transform.position) <= cl.radius+other.cl.radius)
        {
            if (mass > other.mass)
            {
                dir += other.dir*other.Mass / mass;
                mass += other.mass;
                transform.localScale += Vector3.one * 0.05f * other.mass;
                Destroy(other.gameObject);
            }
            else
            {
                other.dir += dir*mass / other.mass;
                other.mass += mass;
                other.transform.localScale += Vector3.one * 0.05f * mass;
                Destroy(gameObject);
            }
            return false;
        }
        return true;
    }
    private void OnDestroy()
    {
        astroList.Remove(this);
    }
}
