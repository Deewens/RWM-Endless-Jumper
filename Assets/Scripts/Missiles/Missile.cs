using UnityEngine;

namespace Missiles
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = -transform.right * speed;
        }
    }
}