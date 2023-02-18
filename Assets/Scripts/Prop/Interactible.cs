using UnityEngine;
using UnityEngine.Events;

namespace SpaceOpera.Prop
{
    public class Interactible : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onClick;

        public void Invoke()
        {
            _onClick.Invoke();
        }
    }
}
