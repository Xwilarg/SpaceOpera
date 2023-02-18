using UnityEngine;

namespace SpaceOpera.Computer
{
    public class ComputerManager : MonoBehaviour
    {
        public static ComputerManager Instance { private set; get; }

        [SerializeField]
        private GameObject _computer;

        [SerializeField]
        private Transform _screenContainer;

        public bool IsEnabled => _computer.activeInHierarchy;

        private void Awake()
        {
            Instance = this;
        }

        public void Show(ScreenType type)
        {

        }
    }
}
