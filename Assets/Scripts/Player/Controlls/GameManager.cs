
using UnityEngine;

namespace Player.Controlls
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;
        [SerializeField] private CharacterController _character;
        public CharacterController Character => _character;
        private void Awake()
        {
            _instance = this;
        }
    }
}