
using Player.Controlls;
using UnityEngine;

public class PickUpLog : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _pickingUpDistance;
    [SerializeField] private float _ttl;
     private Transform _player;

     private void Awake()
     {
         _player = GameManager.Instance.Character.transform;
     }

     private void Update()
     {
         PickingUp();
     }

     private void PickingUp()
     {
         float distance = Vector3.Distance(transform.position, _player.position);
         if (distance > _pickingUpDistance)
         {
             return;
         }
        _ttl -= Time.deltaTime;
         transform.position = Vector3.MoveTowards(transform.position,
             _player.position,
             _speed * Time.deltaTime);
         
         if (distance < 0.5f) Destroy(gameObject);
     }
}
