using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public enum TowerTypes
{
    normal, CC, AoE
}

public class hudManager : MonoBehaviour
{

    private GameObject T;
    public GameObject PTowerBuy;
    public GameObject PTowerUp;
    public GameObject POptions;

    public static hudManager Singleton;

    public hudManager()
    {
        Singleton = this;
    }
    public void TowerBase(GameObject t)
    {
        PTowerBuy.SetActive(true);
        T = t;
    }

    public void TowerUp(GameObject t)
    {
        PTowerUp.SetActive(true);
        T = t;
    }

    public void bChoice(int x)
    {
        if (T != null)
        {
            T.GetComponent<Tplace>().Upgrade(x);
        }
        bClosePanels();
    }
    public void bUpgrade()
    {
        if (T != null)
        {
            T.GetComponent<Tower>().Upgrade();
        }
        bClosePanels();
    }
    public void bDestroy()
    {
        if (T != null)
        {
            T.GetComponent<Tower>().Upgrade();
        }
        bClosePanels();
    }
    public void bClosePanels()
    {
        PTowerUp.SetActive(false);
        PTowerBuy.SetActive(false);
        POptions.SetActive(false);
        T = null;
    }




}
