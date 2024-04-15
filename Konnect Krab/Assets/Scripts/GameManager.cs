using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Game Objects
    public GameObject Player1;
    public GameObject Player2;

    public GameObject Player1Ghost;
    public GameObject Player2Ghost; 

    public GameObject[] SpawnLocation;

    GameObject FallingPiece;
    #endregion

    #region attributes 
    private bool Player1Turn = true;

    int[,] BoardDimensions;

    public int BoardHeight = 7;
    public int BoardWidth = 7;

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
       BoardDimensions = new int[BoardHeight, BoardWidth];
        Player1Ghost.SetActive(false);
        Player2Ghost.SetActive(false);
    }

    public void Hoveroverslot(int slot)
    {
        if (BoardDimensions[BoardHeight - 1, BoardWidth - 1] == 0 && (FallingPiece == null || FallingPiece.GetComponent<Rigidbody>().velocity == Vector3.zero))
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
      
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    public void SelectSlot (int slot)
    {
        if(FallingPiece == null || FallingPiece.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            Turns(slot);

        }
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
                FallingPiece = Instantiate(Player1, SpawnLocation[slot].transform.position, Quaternion.identity);
                FallingPiece.GetComponent<Rigidbody>().velocity = new Vector3(0, 0.1f, 0);
                Player1Turn = false;
                
                if(HasWon(1))
                {
                    Debug.LogWarning("Player 1 wins");

                }
            }
            else
            {
                FallingPiece = Instantiate(Player2, SpawnLocation[slot].transform.position, Quaternion.identity);
                FallingPiece.GetComponent<Rigidbody>().velocity = new Vector3(0, 0.1f, 0);
                Player1Turn = true;

                if (HasWon(2))
                {
                    Debug.LogWarning("Player 2 wins");

                }
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

    bool HasWon(int playerNum)
    {
        //horizontal win
        for (int x = 0; x < BoardWidth - 3; x++)
        {
            for (int y = 0; y < BoardHeight; y++)
            {
                if(BoardDimensions[x, y] == playerNum && BoardDimensions[x+1, y] == playerNum && BoardDimensions[x+2, y] == playerNum && BoardDimensions[x + 3, y] == playerNum && BoardDimensions[x + 3, y] == playerNum)
                {
                    return true;
                }
            }
        }

        //verticle win 
        for (int x = 0; x < BoardWidth; x++)
        {
            for (int y = 0; y < BoardHeight - 3; y++)
            {
                if (BoardDimensions[x, y] == playerNum && BoardDimensions[x, y + 1] == playerNum && BoardDimensions[x, y + 2] == playerNum && BoardDimensions[x, y + 3] == playerNum)
                {
                    return true;
                }
            }
        }

        //diagonal win 

        for(int x = 0; x < BoardWidth - 3; x++)
        {
            for (int y = 0;y < BoardHeight - 3; y++)
            {
                if (BoardDimensions[x, y] == playerNum && BoardDimensions[x + 1, y + 1] == playerNum && BoardDimensions[x + 2, y + 2] == playerNum && BoardDimensions[x + 3, y + 3] == playerNum)
                {
                    return true;
                }
            }
        }






        for(int x = 0; x < BoardWidth - 3; x++)
        {
            for (int y = 0; y < BoardHeight - 3; y++)
            {
                if (BoardDimensions[x, y + 3] == playerNum && BoardDimensions[x + 1, y + 2] == playerNum && BoardDimensions[x + 2, y + 1] == playerNum && BoardDimensions[x + 3, y] == playerNum)
                {
                    return true;
                }
            }
        }

        return false;


        //verticle win 

    }

    #endregion





}

