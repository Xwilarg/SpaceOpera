using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceOpera
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _mov;
        private Animator _anim;
        private SpriteRenderer _sr;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _sr = GetComponent<SpriteRenderer>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _mov * Time.fixedDeltaTime * 500;
        }

        public void Move(InputAction.CallbackContext value)
        {
            _mov = value.ReadValue<Vector2>().normalized;

            bool isMoving = _mov.x != 0;

            _anim.SetBool("IsMoving", isMoving);

            // Flip sprite depending of where we are going
            if (_mov.x > 0f)
            {
                _sr.flipX = false;
            }
            else if (_mov.x < 0f)
            {
                _sr.flipX = true;
            }
        }
    }
}
