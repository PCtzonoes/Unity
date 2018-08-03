using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {


    public static Manager Singleton;//GameManager Singleton
  

    private void Awake()
    {
        Singleton = this;
        DontDestroyOnLoad(gameObject);
    }

    //prefab Lists
    public Enemie[] PEnemieList;
    public Tower[] PTowerList;

}
