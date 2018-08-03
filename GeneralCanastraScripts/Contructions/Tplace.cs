using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Tplace : Tower
{

    

    private void OnMouseDown()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            hudManager.Singleton.TowerBase(gameObject);
        }
    }

    protected override void AtackEnemie()
    {

    }
    public void Upgrade(int  x)
    {
        switch (x)
        {
            case 0:
                Instantiate(Manager.Singleton.PTowerList[1], transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
            case 1:
                Instantiate(Manager.Singleton.PTowerList[2], transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
            case 2:
                Instantiate(Manager.Singleton.PTowerList[3], transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
        }
    }

}
