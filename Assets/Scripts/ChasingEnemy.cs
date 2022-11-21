using System;
using System.Collections;
using UnityEngine;

public class ChasingEnemy : MonoBehaviour
{
    [field: SerializeField]
    public float OffsetFromPlayerStable { get; private set; } = 6f;
    
    [field: SerializeField]
    public float OffsetFromPlayerUnstable { get; private set; } = 2f;

    [SerializeField]
    private PlayerDamageSystem _pds;

    [SerializeField] private PlayerController _player;

    [SerializeField] private bool m_angered = false;

    private Vector2 _stablePosition;
    private Vector2 _unstablePosition;

    [SerializeField] private int _duration = 5;


    private void Start()
    {
        float playerXPosition = _player.transform.position.x;
        _stablePosition = new Vector2(playerXPosition - OffsetFromPlayerStable, transform.position.y);
        transform.position = _stablePosition;
        
        _unstablePosition = new Vector2(playerXPosition - OffsetFromPlayerUnstable, transform.position.y);

        _pds = GameObject.FindWithTag("Player").GetComponent<PlayerDamageSystem>();
    }

    private void Update()
    {
        if (_pds._playerDamage == 1)
        {
            _pds.SetDamage(0);
            if(!m_angered)
                StartCoroutine(LerpPosition(_unstablePosition, _duration));
        }
    }

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            transform.position = Vector2.Lerp(_stablePosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        time = 0;
        while (time < duration)
        {
            transform.position = Vector2.Lerp(targetPosition, _stablePosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    public int GetDuration()
    {
        return _duration;
    }
}
