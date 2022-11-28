using System;
using System.Collections;
using UnityEngine;

public class ChasingEnemy : MonoBehaviour
{
    [field: SerializeField]
    public float OffsetFromPlayerStable { get; private set; } = 6f;
    
    public float OffsetFromPlayerUnstable { get; private set; } = 2f;

    private PlayerDamageSystem _pds;

    [SerializeField] private PlayerController _player;

    private Vector2 _stablePosition;
    private Vector2 _unstablePosition;


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
            transform.position = _unstablePosition;
            StartCoroutine(LerpPosition(_stablePosition, 5));
        }
    }

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
