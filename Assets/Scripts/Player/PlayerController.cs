using SpaceOpera.Audio;
using SpaceOpera.Computer;
using SpaceOpera.Dialogue;
using SpaceOpera.Prop;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceOpera.Player
{
    public class PlayerController : Character
    {
        private Camera _cam;

        private bool _canShoot = true;
        private bool _isShooting;

        private Interactible _interacting;

        private void Awake()
        {
            _cam = GetComponentInChildren<Camera>();
            Init();
        }

        private void FixedUpdate()
        {
            if (DialogueManager.Instance.IsEnabled)
            {
                _mov = Vector2.zero;
            }

            _FixedUpdate();

            if (_mov.magnitude != 0f)
            {
                ComputerManager.Instance.Close();
                if (_interacting != null)
                {
                    _interacting.End();
                    _interacting = null;
                }
            }
        }

        private void Update()
        {
            if (_isShooting && _canShoot && !ComputerManager.Instance.IsEnabled && !DialogueManager.Instance.IsEnabled)
            {
                var screenPos = _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                Vector3 relPos = screenPos - transform.position;
                float angle = Mathf.Atan2(relPos.y, relPos.x) * Mathf.Rad2Deg + Random.Range(-_info.BulletOffset, _info.BulletOffset);
                var bullet = Instantiate(_info.BulletPrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * _info.BulletSpeed, ForceMode2D.Impulse);
                AudioManager.Instance.PlayOneShot(FMODEvents.Instance.LaserShot, transform.position);
                StartCoroutine(Reload());
            }
        }

        public void TakeDamage(int amount)
        { }

        public void Move(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>().normalized;
        }

        public void Shoot(InputAction.CallbackContext value)
        {
            if (DialogueManager.Instance.IsEnabled && value.performed)
            {
                DialogueManager.Instance.Hide();
                if (_interacting != null)
                {
                    _interacting.End();
                    _interacting = null;
                }
            }
            else if (_interacting == null)
            {
                if (value.phase == InputActionPhase.Started)
                {
                    _isShooting = true;
                }
                else if (value.phase == InputActionPhase.Canceled)
                {
                    _isShooting = false;
                }
            }
        }

        public void Use(InputAction.CallbackContext value)
        {
            if (value.performed)
            {
                var hit = Physics2D.Raycast(transform.position, _mov, 0.5f, ~(1 << 6));
                if (hit.collider != null)
                {
                    if (hit.collider.TryGetComponent<Interactible>(out var component))
                    {
                _mov = Vector2.zero;
                        component.Invoke();
                        _interacting = component;
                    }
                }
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
