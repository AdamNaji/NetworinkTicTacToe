using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Click : NetworkBehaviour
{
    public GameObject Camera;
    public tictactoe Script;
    public int x; 
    private void Awake()
    {
        Script = Camera.GetComponent<tictactoe>();
    }

    [Command]
    void OnMouseDown()
    {
        Debug.Log("ERROR");
        Script.SpawnNew(this.gameObject,x );
    }
}
