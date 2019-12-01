using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] int size = 1;
    [SerializeField] GameObject dot;
    [SerializeField] int rows;
    [SerializeField] int cols;

    Vector3 midVector;
    List<GameObject> dots;

    public Vector3 MidVector
    {
        get
        {
            return midVector;
        }
    }

    public int Size
    {
        get
        {
            return size;
        }
    }

    public int Rows
    {
        get
        {
            return rows;
        }
    }

    public int Cols
    {
        get
        {
            return cols;
        }
    }

    public List<GameObject> Dots
    {
        get
        {
            return dots;
        }
    }

    public Vector3 getNearestPointOnGrid(Vector3 position)
    {
        Vector3 result = transform.position + position * size;
        
        return result;
    }

    private void Awake()
    {
        dots = new List<GameObject>();

        for (float x = transform.position.x; x < rows; x++)
        {
            for (float z = transform.position.z; z < cols; z++)
            {
                Vector3 point = getNearestPointOnGrid(new Vector3(x, 0f, z));
                GameObject gameObject = Instantiate(dot, point, Quaternion.identity, this.transform);
                dots.Add(gameObject);
                if (x == rows / 2 && z == cols / 2)
                    midVector = point;
            }
        }
    }

}
