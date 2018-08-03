using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : Tower//torre padrao
{               
    public GameObject rotatable;//parte rodavel da torre
    public GameObject SpawnPointBullet;//ponto de spawn do projetil
    public Bullet bullet;//projetil instanciado

    public AudioClip[] Spawn;
    public AudioClip[] atk;
    public AudioClip[] hit;

    private float delay = 0;
    private void Start()
    {
        if (rotatable == null)//erro no prefab
        {
            Debug.Log("Torre Sem rotacionador: " + gameObject);
            Destroy(gameObject);
        }
        AudioSource.PlayClipAtPoint(Spawn[UnityEngine.Random.Range(0, (Spawn.Length - 1))], Camera.main.transform.position);
        StartCoroutine("LookForEnemies");
    }
    
    private void FixedUpdate()
    {
        if (target != null&&target.Alive)
        {
            
            //roda para o alvo
           rotatable.transform.rotation = Quaternion.LookRotation(target.transform.position - gameObject.transform.position, Vector3.up);

            
            if (Time.time > delay + FireRate)//atira
            {
                FireBullet();
                delay = Time.time;
                transform.GetComponent<Animator>().SetBool("AnimTorre-stingAtirar", true);
            }
            if(Time.time > delay + FireRate/2)
            {
                transform.GetComponent<Animator>().SetBool("AnimTorre-stingAtirar",false);
            }
            if (Vector3.Distance(gameObject.transform.position, target.transform.position) > Range)//para de atirar
            {
                target = null;
                LookEnemies();
            }
        }
        else
        {
            target = null;
            LookEnemies();
        }

    }
    /// <summary>
    /// Tiro padrao Sem fisica.
    /// </summary>
    private void FireBullet()
    {
        Bullet temp = Instantiate(bullet, SpawnPointBullet.transform.position, Quaternion.identity);
        temp.target = target;
        temp.damange = Damange;
        AudioSource.PlayClipAtPoint(atk[UnityEngine.Random.Range(0, (atk.Length - 1))], Camera.main.transform.position,0.5F);
    }

    private void OnMouseDown()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            hudManager.Singleton.TowerUp(gameObject);
        }
    }


}
