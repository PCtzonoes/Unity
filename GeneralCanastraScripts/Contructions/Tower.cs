using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour//classe basica nao utilizavel
{
    [Range(0, 15)]
    public int Damange = 1;
    [Range(3, 10)]
    public int Range = 5;
    [Range(1, 5)]
    public float FireRate = 5;

    protected Character target;//alvo nao accessivel por nao parentes
    [SerializeField]
    private GameObject upgrade;



    /// <summary>
    /// Inicia corrotina de ataque.
    /// </summary>
    protected virtual void AtackEnemie()
    {
        StopAllCoroutines();
    }
    /// <summary>
    /// inicia corrotina de Idle torre
    /// </summary>
    protected virtual void LookEnemies()
    {
        StartCoroutine("LookForEnemies");
    }
    /// <summary>
    /// Verificacao na morte de cada inimigo.
    /// </summary>
    /// <param name="Dead">Objeto inimigo morto.</param>
    public void TargetDead(GameObject Dead)
    {
        if (Dead == target)
        {
            target = null;
            LookEnemies();
        }
    }
    /// <summary>
    /// Procura por inimigos no raido de alcance.
    /// </summary>
    /// <returns>Tempo entre buscas.</returns>
    protected virtual IEnumerator LookForEnemies()
    {
        while (ManagerGame.Singleton.OnGame)
        {
            foreach (Character enemie in ManagerGame.Singleton.Enemies)
            {
                if (Vector3.Distance(enemie.transform.position, gameObject.transform.position) < Range)
                {
                    target = enemie;
                    AtackEnemie();
                }
            }
            yield return new WaitForSeconds(.25f);
        }
    }

    private void OnMouseEnter()
    {
        transform.localScale *= 1.2f;
    }
    private void OnMouseExit()
    {
        transform.localScale /= 1.2f;
    }
    private void OnMouseDown()
    {

    }
    public virtual void Upgrade()
    {
        if (upgrade != null)
        {
            Instantiate(upgrade, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public virtual void Downgrade()
    {

        Instantiate(Manager.Singleton.PTowerList[0], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
