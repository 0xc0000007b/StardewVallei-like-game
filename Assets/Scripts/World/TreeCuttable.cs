using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class TreeCuttable : ToolHit
{
    [SerializeField] private float _treeHealth;
    public override void Hit()
    {
        CutTheTree();
    }

    private void CutTheTree()
    {
        if (Input.GetMouseButton(0))
        {
            _treeHealth--;
            
        if (_treeHealth == 0)
        {
            Destroy(gameObject);   
        }
        }
    }
}
