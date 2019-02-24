using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public static Controller singleton;
    private int dir = 1;
    [SerializeField]
    private GameObject center;
    [SerializeField]
    private GameObject astroRef;
    public Controller()
    {
        singleton = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Astro temp = Instantiate(astroRef, 18 * Random.insideUnitSphere + center.transform.position, Quaternion.identity).GetComponent<Astro>();
            temp.dir = Random.Range(2,10) * Vector3.Cross(center.transform.position, temp.transform.position).normalized * dir;
            if (dir == 1) dir = -1;
            else dir = 1;
        }
    }

    public void ExitButton()
    {      
        Application.Quit();
    }
}
