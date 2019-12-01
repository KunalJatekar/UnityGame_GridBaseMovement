using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTactics : MonoBehaviour
{
    [SerializeField] float speed;

    internal GridController grid;
    Vector3 playerStartPosition;

    internal void initialization()
    {
        grid = GameObject.FindGameObjectWithTag("GridLayer").GetComponent<GridController>();
        playerStartPosition = grid.MidVector;
        transform.position = playerStartPosition + new Vector3(0, 1f, 0);
    }

    Vector3 getNextPointToMove(Vector3 value)
    {
        return transform.position += value;
    }

    internal void movePlayerWithKey()
    {
        int size = grid.Size;
        Vector3 tempPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.W))
        {
            tempPosition = getNextPointToMove(new Vector3(0, 0, size));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            tempPosition = getNextPointToMove(new Vector3(0, 0, -size));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            tempPosition = getNextPointToMove(new Vector3(size, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            tempPosition = getNextPointToMove(new Vector3(-size, 0, 0));
        }

        transform.position = Vector3.MoveTowards(transform.position, tempPosition, Time.deltaTime * speed);
    }


    internal void movePlayerWithSwipe(string status)
    {
        int size = grid.Size;
        Vector3 tempPosition = transform.position;

        if (status == "Up")
        {
            tempPosition = getNextPointToMove(new Vector3(0, 0, size));
        }
        else if (status == "Down")
        {
            tempPosition = getNextPointToMove(new Vector3(0, 0, -size));
        }
        else if (status == "Right")
        {
            tempPosition = getNextPointToMove(new Vector3(size, 0, 0));
        }
        else if (status == "Left")
        {
            tempPosition = getNextPointToMove(new Vector3(-size, 0, 0));
        }

        transform.position = Vector3.MoveTowards(transform.position, tempPosition, Time.deltaTime * speed);
    }
}
