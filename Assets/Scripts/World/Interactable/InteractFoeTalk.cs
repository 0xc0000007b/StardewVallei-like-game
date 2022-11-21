using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using World.Interactable;

public class InteractFoeTalk : Interactable
{
    public override void Interact(Character character)
    {
        if(Input.GetMouseButtonDown(1))
            Debug.Log("hi");
    }
}
