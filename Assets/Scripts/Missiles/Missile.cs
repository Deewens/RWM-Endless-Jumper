using System.Collections;
using UnityEngine;

namespace Missiles
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private ParticleSystem blood;

        private Rigidbody2D _rb;
        
        private Collider2D _collider;

        private AudioSource _hurt;
        private ParticleSystem _currentParticle;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
            
            _hurt = GetComponent<AudioSource>();
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = -transform.right * speed;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            _currentParticle = Instantiate(blood, col.gameObject.transform.position,Quaternion.identity,col.gameObject.transform);
            _hurt.Play();
            PlayerDamageSystem damageSystem = col.GetComponent<PlayerDamageSystem>();
            if (damageSystem != null)
            {
                if (damageSystem._playerDamage == 0)
                {
                    damageSystem.SetDamage(1);
                    StartCoroutine(CountDownTimer());
                }
                
                else if (damageSystem._playerDamage == 1)
                {
                    damageSystem.SetDamage(2); // TODO: Increment the damage value rather than hardsetting it Also _playerdamage shouln't be public
                }
            }
        }
        
        IEnumerator CountDownTimer()
        {
            _collider.enabled = false;
            yield return new WaitForSeconds(5f);
            _collider.enabled = true;
        }
    }
}