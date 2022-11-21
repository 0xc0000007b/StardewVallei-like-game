
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class TreeCuttable : ToolHit
{
    [SerializeField] private float _treeHealth;
    [SerializeField] private GameObject _log;
    [SerializeField] private int _dropCount;
    [SerializeField] private float _spread;
    public override void Hit()
    {
        CutTheTree();
       
    }

    private void CollectTheDrop()
    {
        while (_dropCount > 0)
        {
            _dropCount--;
            Vector3 pos = transform.position;
            pos.x += _spread + UnityEngine.Random.value - _spread / 2;
            pos.y += _spread + UnityEngine.Random.value - _spread / 2;
            GameObject go = Instantiate(_log);
            go.transform.position = pos;
        }
    }

    private void CutTheTree()
    {
        if (Input.GetMouseButton(0))
        {
            _treeHealth--;

            if (_treeHealth == 0)
            {
                Destroy(gameObject);
                CollectTheDrop();
            }
        }
    }
}
