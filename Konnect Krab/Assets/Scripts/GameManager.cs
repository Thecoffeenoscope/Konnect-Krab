using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public GameObject[] SpawnLocation;

    private bool Player1Turn = true;

    private int[,] BoardDimensions;

    public int BoardHeight = 6;
    public int BoardWidth = 7;


    // Start is called before the first frame update
    void Start()
    {
        BoardDimensions = new int[BoardHeight, BoardWidth];
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    public void Turns(int slot)
    {
        UpdateBoard(slot);

        Debug.Log("GameManager Slot" +  slot);
        if (Player1Turn)
        {
            Instantiate(Player1, SpawnLocation[slot].transform.position, Quaternion.identity);
            Player1Turn = false;
        }
        else
        {
            Instantiate(Player2, SpawnLocation[slot].transform.position, Quaternion.identity);
            Player1Turn = true;
        }

    }

    public void UpdateBoard(int slot)
    {
        for (int i = 0; i < BoardHeight; i++)
        {
            if (BoardDimensions[slot, i] == 0)
            {
                if (Player1Turn)
                {
                    BoardDimensions[slot, i] = 1;
                }

                else
                {
                    BoardDimensions[slot, i] = 2;
                }
                Debug.Log("piece spawned at (" + slot + "," + i + ")");
                
            }
        }
        
    }

  

    
    

   
}

