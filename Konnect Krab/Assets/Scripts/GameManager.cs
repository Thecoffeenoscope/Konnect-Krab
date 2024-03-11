using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public GameObject[] SpawnLocation;

    private bool Player1Turn = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        

    }

    public void SelectSlot(int slot)
    {
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

  

    void TakeTurn(int slot)
    {
        Instantiate(Player1, SpawnLocation[slot].transform.position, Quaternion.identity);
    }
    
    

   
}

