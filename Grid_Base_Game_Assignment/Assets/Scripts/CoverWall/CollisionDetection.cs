using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    GridController grid;
    int rows;
    int cols;
    int size;

    void Awake()
    {
        grid = GameObject.FindGameObjectWithTag("GridLayer").GetComponent<GridController>();

        rows = grid.Rows;
        cols = grid.Cols;
        size = grid.Size;

        rows = rows * size;
        cols = cols * size;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 currentPosition = other.gameObject.transform.position;
            
            if (currentPosition.x >= (float)rows)
            {
                other.gameObject.transform.position = new Vector3(0, currentPosition.y, currentPosition.z);
            } 
            else if (currentPosition.x < 0)
            {
                other.gameObject.transform.position = new Vector3(rows - size, currentPosition.y, currentPosition.z);
            }
            else if (currentPosition.z >= (float)cols)
            {
                other.gameObject.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0);
            }
            else if (currentPosition.z < 0)
            {
                other.gameObject.transform.position = new Vector3(currentPosition.x, currentPosition.y, cols - size);
            }
        }
    }
}
