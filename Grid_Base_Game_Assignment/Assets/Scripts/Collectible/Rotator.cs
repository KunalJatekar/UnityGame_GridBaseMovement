using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    CollectibleSpawner collectibleSpawner;

    void Awake()
    {
        collectibleSpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<CollectibleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0, 1f, 0), Time.deltaTime * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collectibleSpawner.HighScore++;
            gameObject.SetActive(false);
            collectibleSpawner.CanSpawn = true;
            collectibleSpawner.OnCollectingScore += CollectibleSpawner_OnCollectingScore;
        }
    }

    private void CollectibleSpawner_OnCollectingScore(Text text)
    {
        text.text = "" + collectibleSpawner.HighScore;
    }
}
