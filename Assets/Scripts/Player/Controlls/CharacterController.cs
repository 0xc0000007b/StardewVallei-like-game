using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class CharacterController : MonoBehaviour
{
  [SerializeField] private float _speed;
  [SerializeField] private bool _isWalk;
  private Vector2 _lastMoveVec;
  private Animator _anim; 
  private Vector2 _mv;
  private Rigidbody2D _rb2d;

  public bool IsWalk => _isWalk;
  public Vector2 LastMoveVec => _lastMoveVec;
  private void Awake()
  {
    _rb2d = GetComponent<Rigidbody2D>();
    _anim = GetComponent<Animator>();
  }

  private void Update()
  {
    Move();
  }

  private void Move()
  {
    CheckTheVector();
  }

  private void CheckTheVector()
  {
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");
    _anim.SetFloat("horizontal", horizontal);
    _anim.SetFloat("vertical", vertical);
    _mv = new Vector2(horizontal, vertical).normalized;
    _rb2d.velocity = _mv * _speed;
    _isWalk = horizontal != 0 || vertical != 0;
    _anim.SetBool("isWalk", _isWalk);
    if (horizontal != 0 || vertical != 0)
    {
      _lastMoveVec = new Vector2(horizontal, vertical).normalized;
    }
    _anim.SetFloat("lastHorizontal", horizontal);
    _anim.SetFloat("lastVertical", vertical);
  }
}
