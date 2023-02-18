using SpaceOpera.SO;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceOpera.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerInfo _info;

        private Vector2 _mov;
        private Animator _anim;
        private SpriteRenderer _sr;
        private Rigidbody2D _rb;
        private Camera _cam;

        private bool _canShoot = true;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _sr = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
            _cam = GetComponentInChildren<Camera>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _mov * Time.fixedDeltaTime * _info.Speed;
        }

        public void TakeDamage(int amount)
        { }

        public void Move(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>().normalized;

            bool isMoving = _mov.magnitude != 0f;

            _anim.SetBool("IsWalking", isMoving);

            if (isMoving)
            {
                if (Mathf.Abs(_mov.y) > Mathf.Abs(_mov.x))
                {
                    _sr.flipX = false;
                    if (_mov.y > 0)
                    {
                        _anim.SetInteger("Direction", 1);
                    }
                    else
                    {
                        _anim.SetInteger("Direction", 0);
                    }
                }
                else
                {
                    _anim.SetInteger("Direction", 2);
                    if (_mov.x > 0f)
                    {
                        _sr.flipX = true;
                    }
                    else
                    {
                        _sr.flipX = false;
                    }
                }
            }
        }

        public void Shoot(InputAction.CallbackContext value)
        {
            if (value.performed && _canShoot)
            {
                var screenPos = _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                Vector3 relPos = screenPos - transform.position;
                float angle = Mathf.Atan2(relPos.y, relPos.x) * Mathf.Rad2Deg;
                var bullet = Instantiate(_info.BulletPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * _info.BulletSpeed, ForceMode2D.Impulse);
                StartCoroutine(Reload());
            }
        }

        private IEnumerator Reload()
        {
            _canShoot = false;
            yield return new WaitForSeconds(_info.GunReloadTime);
            _canShoot = true;
        }
    }
}
