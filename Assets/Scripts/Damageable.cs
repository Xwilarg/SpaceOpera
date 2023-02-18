using UnityEngine;
using UnityEngine.Events;

namespace SpaceOpera
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent<int> _onDamage;
    }
}
