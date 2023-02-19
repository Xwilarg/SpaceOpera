using SpaceOpera.Computer;
using SpaceOpera.SO;
using UnityEngine;

namespace SpaceOpera
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        protected PlayerInfo _info;

        protected Vector2 _mov;
        private Rigidbody2D _rb;
        private Animator _anim;
        private SpriteRenderer _sr;

        protected void Init()
        {
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            _sr = GetComponent<SpriteRenderer>();
        }

        protected void _FixedUpdate()
        {
            _rb.velocity = _mov * Time.fixedDeltaTime * _info.Speed;
            
            bool isMoving = _mov.magnitude != 0f;

            _anim.SetBool("IsWalking", isMoving);
            _sr.sortingOrder = -(int)(transform.position.y * 100f);

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
    }
}
