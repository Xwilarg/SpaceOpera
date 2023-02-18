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

        public void Close()
        {
            _computer.SetActive(false);
        }

        public void Show(GameObject screen)
        {
            _computer.SetActive(true);
            for (int i = 0; i < _screenContainer.childCount; i++)
                _screenContainer.GetChild(i).gameObject.SetActive(false);
            screen.SetActive(true);
        }
    }
}
