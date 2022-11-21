
using UnityEngine;
using World.Interactable;

public class ChestOpener : Interactable
{
    [SerializeField] private GameObject _openedChest;
    [SerializeField] private bool _isOpened;

    [SerializeField] private GameObject _closedChest;

    public override void Interact(Character character)
    {
        OpenOrCloseChest();
    }
    private void OpenOrCloseChest()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!_isOpened)
            {
                _isOpened = true;
                _closedChest.SetActive(false);
                _openedChest.SetActive(true);
                
            }
            else
            {
                _isOpened = false;
                _openedChest.SetActive(false);
                _closedChest.SetActive(true);
            }
                
            
        }
        
    }
}
