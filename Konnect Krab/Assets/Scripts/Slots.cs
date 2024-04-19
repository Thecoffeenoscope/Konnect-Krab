using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Slots : MonoBehaviour
{
    public int slot;
    public GameManager gm;
    
    /// <summary>
    /// spawns the piece on click
    /// </summary>
    void OnMouseDown()
    {


        gm.SelectSlot(slot);
        
     
       
    }

    /// <summary>
    /// makes the piece hover over the slot
    /// </summary>
    void OnMouseOver()
    {
        gm.Hoveroverslot(slot);
    }

}
