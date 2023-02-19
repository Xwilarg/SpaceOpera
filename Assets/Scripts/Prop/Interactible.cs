using UnityEngine;
using UnityEngine.Events;

namespace SpaceOpera.Prop
{
    public class Interactible : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onClick, _onDone;

        public void Invoke()
        {
            _onClick.Invoke();
        }

        public void End()
        {
            _onDone.Invoke();
        }
    }
}
