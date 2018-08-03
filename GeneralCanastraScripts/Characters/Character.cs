using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public enum CC
    {
        Normal, Slow
    }
    public int Life;
    [Range(1, 5)]
    public float Speed=1;
    protected bool alive = true;
    private float lastSlow;
    private CC stateAtual = CC.Normal;

    protected CharacterController sc;
    public AudioClip[] hit;
    public AudioClip[] spawn;
    public AudioClip[] objetivo;

    public bool Alive
    {
        get
        {
           
            return alive;
        }
    }

    // Use this for initialization
    private void Awake()
    {
        sc = gameObject.GetComponent<CharacterController>();
        AudioSource.PlayClipAtPoint(spawn[UnityEngine.Random.Range(0, (spawn.Length - 1))], Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive&&stateAtual==CC.Slow && Time.time > lastSlow + 2)
        {
            stateAtual = CC.Normal;
            Speed *= 2;
        }
        if (!alive)transform.localScale*= (float)(0.95f);
    }
    /// <summary>
    /// Metodo chamado em qualqr caso de morte do personagem
    /// </summary>
    protected virtual void OnDeath()
    {
        ManagerGame.Singleton.Enemies.Remove(this);
        foreach (Tower t in ManagerGame.Singleton.Towers)
        {
            t.TargetDead(gameObject);
        }
        alive = false;
        AudioSource.PlayClipAtPoint(hit[UnityEngine.Random.Range(0, (hit.Length - 1))], Camera.main.transform.position);
       
        Destroy(sc);
        
    }

    public void AplyDamange(int dmg, CC ccState = CC.Normal)
    {
        Life -= dmg;
        if (Life <= 0)
        {
            OnDeath();
            Destroy(gameObject, 3.0f);
            if (ccState == CC.Slow)
            {
                if (stateAtual != CC.Slow)
                {
                    Speed = Speed * 0.5f;
                }
                stateAtual = CC.Slow;
                lastSlow = Time.time;
            }
        }
    }
}
