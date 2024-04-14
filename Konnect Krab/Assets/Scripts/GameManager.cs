using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public GameObject Player1Ghost;
    public GameObject Player2Ghost; 

    public GameObject[] SpawnLocation;

    private bool Player1Turn = true;

    int[,] BoardDimensions;

    public int BoardHeight = 7;
    public int BoardWidth = 7;


    // Start is called before the first frame update
    void Start()
    {
       BoardDimensions = new int[BoardHeight, BoardWidth];
        Player1Ghost.SetActive(false);
        Player2Ghost.SetActive(false);
    }

    public void Hoveroverslot(int slot)
    {
        if (Player1Turn)
        {
            Player1Ghost.SetActive(true);
            Player1Ghost.transform.position = SpawnLocation[slot].transform.position;
        }
        else
        {
            Player2Ghost.SetActive(true);
            Player2Ghost.transform.position = SpawnLocation[slot].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }



    public void Turns(int slot)
    {
        if (UpdateBoard(slot))
        {
            Player1Ghost.SetActive(false);
            Player2Ghost.SetActive(false);

            Debug.Log("GameManager Slot" + slot);
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
       

    }

    bool UpdateBoard(int slot)
    {
        for (int row = 0; row <= BoardHeight; row++)
        {
            if (BoardDimensions[slot, row] == 0)
            {
                if (Player1Turn)
                {
                    BoardDimensions[slot, row] = 1;
                }

                else
                {
                    BoardDimensions[slot, row] = 2;
                }
                Debug.Log("piece spawned at (" + slot + "," + row + ")");
                return true;
            }
        }
        
        return false;
    }

  

    
    

   
}

