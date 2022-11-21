
using Player.Utils;
using UnityEngine;
using World.Interactable;

namespace Player.Controlls
{
    public class CharacterInteractController : MonoBehaviour
    {
        [SerializeField] private float _diastancOffset;
        [SerializeField] private float _interactAreaSize;
        private CharacterController _controller;
        private Rigidbody2D _rb2d;
        private Character _character;
        [SerializeReference] private HighlightController _highlight;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
            _rb2d = GetComponent<Rigidbody2D>();
            _character = GetComponent<Character>();
        }

        private void Update()
        {
            Interact();
            CheckInteract();
        }
        
        private void CheckInteract()
        {
            Vector2 pos = _rb2d.position + _controller.LastMoveVec * _diastancOffset;

            Collider2D[] colls = Physics2D.OverlapCircleAll(pos, _interactAreaSize);
            
            foreach (Collider2D c in colls)
            {
                
                Interactable hit = c.GetComponent<Interactable>();
                if (hit != null)
                {
                    _highlight.Mark(hit.gameObject);
                    return;
                }
            }
            _highlight.Hide();
        }

        private void Interact()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Vector2 pos = _rb2d.position + _controller.LastMoveVec * _diastancOffset;

                Collider2D[] colls = Physics2D.OverlapCircleAll(pos, _interactAreaSize);
                foreach (Collider2D c in colls)
                {
                
                    Interactable hit = c.GetComponent<Interactable>();
                    if (hit != null)
                    {
                        hit.Interact(_character);
                        break;
                    }
                }
            }
        }
    }
}