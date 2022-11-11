using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    [SerializeField] private float _interactAreaSize;
    [SerializeField] private float _diastancOffset;
    
    private CharacterController _character;
    private Rigidbody2D _rb2d;

    private void Awake()
    {
        _character = GetComponent<CharacterController>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UseTool();
    }

    private void UseTool()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = _rb2d.position + _character.LastMoveVec * _diastancOffset;

            Collider2D[] colls = Physics2D.OverlapCircleAll(pos, _interactAreaSize);
            foreach (Collider2D c in colls )
            {
                
                ToolHit hit = c.GetComponent<ToolHit>();
                if (hit != null)
                {
                    hit.Hit();
                    break;
                }
            }
        }
    }
}
