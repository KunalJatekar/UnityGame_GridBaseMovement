using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerTactics
{

    // Start is called before the first frame update
    void Start()
    {
        initialization();
    }

    // Update is called once per frame
    void Update()
    {
#if  UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE
        
        movePlayerWithKey();

#endif
    }

    public void playerMove(string status)
    {
#if UNITY_ANDROID

        movePlayerWithSwipe(status);
        
#endif
    }
}
