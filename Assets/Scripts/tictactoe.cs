using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tictactoe : MonoBehaviour
{
    public GameObject cross, circle;
    public enum Seed
    {
        EMPTY,
        CROSS,
        CIRCLE
    };
    public Seed turn;
    public Text TextTurn;
    public GameObject[] spawns = new GameObject[9];
    public Seed[] player = new Seed[9];

    private void Awake()
    {
        TextTurn.text = "Turn: " + turn.ToString();

        for (int i = 0; i < 9; i++)
        {
            player[i] = Seed.EMPTY;
        }
    }

    public void SpawnNew(GameObject obj, int id)
    {
        if(turn == Seed.CROSS)
        {
            spawns[id] = Instantiate(cross, obj.transform.position, Quaternion.identity);
            player[id] = turn;

            if (Win(turn))
            {
                turn = Seed.EMPTY;
                TextTurn.text = "Cross has Won !!! ";
            }
            else
            {
                turn = Seed.CIRCLE;
                TextTurn.text = "Turn: " + turn.ToString();
            }

          
        }
        else if (turn == Seed.CIRCLE)
        {
            spawns[id] = Instantiate(circle, obj.transform.position, Quaternion.identity);
            player[id] = turn;
            if (Win(turn))
            {
                turn = Seed.EMPTY;
                TextTurn.text = "Circle has Won !!! ";
            }
            else
            {
                turn = Seed.CROSS;
                TextTurn.text = "Turn: " + turn.ToString();
            }

        }

        if (Draw())
        {
            turn = Seed.EMPTY;
            TextTurn.text = "DRAW !!";
        }

        Destroy(obj.gameObject);
        

    }

    bool IsEmpty()
    {
        bool empty = false;
        for (int i = 0; i < 9; i++)
        {
            if (player[i] == Seed.EMPTY)
            {
                empty = true;
                break;

            }
        }

        return empty;
    }

    bool Win(Seed CurrentPlayer)
    {

        bool hasWin = false;
        int[,] allConditions = new int[8, 3]
            {{0, 1, 2}, {3, 4, 5}, {6, 7, 8}, {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, {0, 4, 8}, {2, 4, 6}};

        for (int i = 0; i < 8; i++)
        {
            if (player[allConditions[i, 0]] == CurrentPlayer
                & player[allConditions[i, 1]] == CurrentPlayer
                & player[allConditions[i, 2]] == CurrentPlayer)
            {
                hasWin = true;
                break;
            }
        }

        return hasWin;
    }

    bool Draw()
    {
        bool crossWin, circleWin, anyEmpty;

        crossWin = Win(Seed.CROSS);
        circleWin = Win(Seed.CIRCLE);
        anyEmpty = IsEmpty();

        bool isDraw = false;

        if (crossWin == false & circleWin == false & anyEmpty == false)
            isDraw = true;

        return isDraw;
    }


}

