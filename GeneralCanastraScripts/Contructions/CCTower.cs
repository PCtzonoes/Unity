using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTower : Tower {

    public AudioClip[] Spawn;
    public AudioClip[] atk;
    public AudioClip[] hit;
    // Use this for initialization
    void Start () {
        StartCoroutine(AppyDamange());
        
        AudioSource.PlayClipAtPoint(Spawn[UnityEngine.Random.Range(0, (Spawn.Length - 1))], Camera.main.transform.position);
    }

    protected virtual IEnumerator AppyDamange()
    {
        while (ManagerGame.Singleton.OnGame)
        {
            for (int ii = 0; ii < ManagerGame.Singleton.Enemies.Count; ii++)
            {
                Character enemie = ManagerGame.Singleton.Enemies[ii];
                if (enemie.Alive && Vector3.Distance(enemie.transform.position, gameObject.transform.position) < Range)
                {
                    AtackEnemieCC(enemie);
                }
            }
            yield return new WaitForSeconds(.25f);
        }
    }
    private void AtackEnemieCC(Character x)
    {
        x.AplyDamange(Damange,Character.CC.Slow);
    }

}
