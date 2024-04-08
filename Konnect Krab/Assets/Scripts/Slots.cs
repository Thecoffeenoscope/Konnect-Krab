using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Slots : MonoBehaviour
{
    public int slot;
    public GameManager gm;

    void OnMouseDown()
    {

        
     gm.Turns(slot);
       
    }

    

}
