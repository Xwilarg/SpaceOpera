using UnityEngine;

namespace SpaceOpera.SO
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlayerInfo", fileName = "PlayerInfo")]
    public class PlayerInfo : ScriptableObject
    {
        [Tooltip("Speed of the player")]
        public float Speed;

        public float GunReloadTime;

        public GameObject BulletPrefab;
        public float BulletSpeed;
    }
}