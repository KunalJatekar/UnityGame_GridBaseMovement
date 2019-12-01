using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnee;
    [SerializeField] ObjectPooler pooler;
    [SerializeField] Text highScoreText;

    public event System.Action<Text> OnCollectingScore;

    List<GameObject> spawnPoints;
    bool canSpawn;
    int highScore;

    public bool CanSpawn
    {
        get
        {
            return canSpawn;
        }
        set
        {
            canSpawn = value;
        }
    }

    public int HighScore
    {
        get
        {
            return highScore;
        }
        set
        {
            highScore = value;
        }
    }

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectWithTag("GridLayer").GetComponent<GridController>().Dots;
        CanSpawn = true;
        HighScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            int randomShape = Random.Range(0, spawnee.Length);
            int randomPoint = Random.Range(0, spawnPoints.Count);

            GameObject gObj = pooler.GetObject(spawnee[randomShape].name);
            Vector3 objectPosition = spawnPoints[randomPoint].transform.position;
            objectPosition.y = 1f;
            gObj.transform.position = objectPosition;
            //gObj.transform.rotation = spawnPoints[randomPoint].transform.rotation;
            gObj.SetActive(true);
            CanSpawn = false;

            if (OnCollectingScore != null)
            {
                OnCollectingScore(highScoreText);
            }
        }
    }

}
