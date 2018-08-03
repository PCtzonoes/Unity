using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ManagerGame : MonoBehaviour
{
    [System.Serializable]
    public struct Wave
    {
        public int Fast;
        public int Normal;
        public int Strong;
    }


    public static ManagerGame Singleton;

    private List<Character> enemies;
    private List<Tower> towers;
    private List<SpawnPoint> spawnPoints;
    private int cotage;
    private int lifes;
    public WayPoint[] wayPoints;
    private bool onGame;
    private int qualho;
    [SerializeField]
    private List<Wave> waves;
    private int WaveCount = -1;
    private GameObject lTower;

    public Text TCotage;
    public Text TLifes;

    public AudioSource Fala;
    public AudioClip musica;


    private bool inWave = false;

    public int Cotage
    {
        get
        {
            return cotage;
        }

        set
        {
            cotage = value;
            TCotage.text = cotage + "¢";
        }
    }

    public List<Character> Enemies
    {
        get
        {
            return enemies;
        }

        set
        {
            enemies = value;
        }
    }

    public List<Tower> Towers
    {
        get
        {
            return towers;
        }

        set
        {
            towers = value;
        }
    }

    public List<SpawnPoint> SpawnPoints
    {
        get
        {
            return spawnPoints;
        }
        set
        {
            spawnPoints = value;
        }
    }

    public bool OnGame
    {
        get
        {
            return onGame;
        }
    }

    public int Qualho
    {
        get
        {
            return qualho;
        }

        set
        {
            qualho = value;
        }
    }

    public GameObject LTower
    {
        get
        {
            return lTower;
        }

        set
        {
            lTower = value;
        }
    }

    public int Lifes
    {
        get
        {
            return lifes;
        }

        set
        {
            lifes = value;
            TLifes.text = "Vidas: "+lifes;
        }
    }




    private void Awake()
    {
        Singleton = this;
        onGame = true;
        Cotage = 0;
        Enemies = new List<Character>();
        Towers = new List<Tower>();
        spawnPoints = new List<SpawnPoint>();
    }

    private void Start()
    {
        Lifes = 5;
        SpawnEnemies();
        StartCoroutine(FalaGeneral());
        AudioSource.PlayClipAtPoint(musica, Camera.main.transform.position,2.0f);
    }

    public void SpawnEnemies()
    {
        if (Enemies.Count == 0)
        {
            WaveCount++;
            if (WaveCount >= waves.Count)
            {
                EndLevel();
            }
            else if (!inWave)
            {

                SpawnEnemies(waves[WaveCount]);
            }
        }
    }

    private void SpawnEnemies(Wave wave)
    {
        inWave = true;
        StartCoroutine(SpawningWave(wave));
    }

    private void EndLevel()
    {
        throw new NotImplementedException();
    }
    protected IEnumerator SpawningWave(Wave wave)
    {

        int total = (wave.Fast) / 3 + (wave.Normal) / 2 + wave.Strong;
        //Debug.Log("Wave de " + total);
        for (int ii = 0; ii < total; ii++)
        {
            //Debug.Log("Wave: " + (ii + 1) + " de " + total);
            if (wave.Fast > 0)
            {
                for (int jj = 0; jj < 3; jj++)
                {
                    Instantiate(Manager.Singleton.PEnemieList[0], spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count - 1)].transform.position, Quaternion.identity);
                    wave.Fast--;
                    yield return new WaitForSeconds(1.0f);
                }
            }
            else if (wave.Normal > 0)
            {
                for (int jj = 0; jj < 2; jj++)
                {
                    Instantiate(Manager.Singleton.PEnemieList[1], spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count - 1)].transform.position, Quaternion.identity);
                    wave.Normal--;
                    yield return new WaitForSeconds(0.75f);
                }
            }
            else if (wave.Strong > 0)
            {
                Instantiate(Manager.Singleton.PEnemieList[2], spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count - 1)].transform.position, Quaternion.identity);
                wave.Strong--;
            }
            else Debug.LogError("Erro wave: " + wave);
            yield return new WaitForSeconds(4.5f);
        }
        inWave = false;

    }

    private IEnumerator FalaGeneral()
    {
        yield return new WaitForSeconds(6.0f);
        Fala.Play();
    }
}
