using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    public GameObject[] SpawnLocation;

    bool Player1Turn = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(int slot)
    {
        Instantiate(Player1, SpawnLocation[slot].transform.position, Quaternion.identity);
    }

    public void SelectSlot(int slot)
    {
        Debug.Log("GameManager Slot" +  slot);
    }

    public void TakeTurn(int slot)
    {
        if (Player1Turn)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Instantiate(Player1, transform.position, Quaternion.identity);
            }
        }
        
    }
    

   
}

