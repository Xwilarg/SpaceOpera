using SpaceOpera.Computer;
using UnityEngine;

namespace SpaceOpera.Prop
{
    public class ComputerObj : MonoBehaviour
    {
        [SerializeField]
        private GameObject _targetScreen;

        public void SwitchOn()
        {
            ComputerManager.Instance.Show(_targetScreen);
        }
    }
}
