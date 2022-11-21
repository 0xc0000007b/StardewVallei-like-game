using UnityEngine;

namespace Player.Utils
{
    public class HighlightController : MonoBehaviour
    {
        [SerializeField] private GameObject _marker;

        private GameObject _target;

        public void Mark(GameObject target)
        {
            if (_target == target) return;
            _target = target;
            Vector3 pos = target.transform.position + Vector3.up * 0.5f;
            Mark(pos);
        }

        public void Mark(Vector3 pos)
        {
            _marker.SetActive(true);
            _marker.transform.position = pos;
        }

        public void Hide()
        {
            if (_target == null) _marker.SetActive(false);
        }
    }
}