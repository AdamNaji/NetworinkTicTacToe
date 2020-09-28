using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    public GameObject Camera;
    public tictactoe Script;
    public int x; 
    private void Awake()
    {
        Script = Camera.GetComponent<tictactoe>();
    }

    void OnMouseDown()
    {
        Script.SpawnNew(this.gameObject,x );
    }
}
