using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void rotateLeft()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0)) * transform.rotation;
    }

    public void rotateRight()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0)) * transform.rotation;
    }

    public void exit()
    {
        Application.Quit();
    }
}
