using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    [SerializeField] private GameObject _openedChest;
    [SerializeField] private GameObject _closedChest;
    [SerializeField] private bool _isOpened;
   

    // Update is called once per frame
    void Update()
    {
        OpenOrCloseChest();
    }

    private void OpenOrCloseChest()
    {
        if (Input.GetMouseButtonDown(1) && !_isOpened)
        {
            
                _isOpened = true;
                _openedChest.SetActive(true);
            
        }
        else if(Input.GetMouseButtonDown(1) && _isOpened)
        {
                _isOpened = false;
                _openedChest.SetActive(false); 
        }
    }
}
