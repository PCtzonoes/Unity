using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : Character
{
    [SerializeField]
    private int cotage=1;
    private int wpAtual = 0;
    private void Start()
    {
        ManagerGame.Singleton.Enemies.Add(gameObject.GetComponent<Enemie>());
        
    }

    private void FixedUpdate()
    {

        Vector3 way = (ManagerGame.Singleton.wayPoints[wpAtual].transform.position - transform.position);
        transform.rotation = Quaternion.LookRotation(way, Vector3.up);
        // Debug.Log(way.magnitude);
        if (way.magnitude < 1 && wpAtual < ManagerGame.Singleton.wayPoints.Length-1) wpAtual++;
        if (way.magnitude < 1 && wpAtual == ManagerGame.Singleton.wayPoints.Length-1) TouchObjective();
        if(Alive) sc.Move(way.normalized *0.02f *Speed);
        
        // Debug.Log(wpAtual);
    }

    private void TouchObjective()
    {
        ManagerGame.Singleton.Lifes--;
        AudioSource.PlayClipAtPoint(objetivo[UnityEngine.Random.Range(0, (objetivo.Length - 1))], Camera.main.transform.position);
        OnDeath(0);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        transform.Rotate(90, 0, 90);
        ManagerGame.Singleton.Cotage += cotage;

    }
    protected void OnDeath(int x)
    {
        
        transform.Rotate(90, 0, 90);
        ManagerGame.Singleton.Cotage += cotage;
        ManagerGame.Singleton.Enemies.Remove(this);
        foreach (Tower t in ManagerGame.Singleton.Towers)
        {
            t.TargetDead(gameObject);
        }
        alive = false;
        Destroy(sc);
        Destroy(gameObject, 3.0f);
    }

}
