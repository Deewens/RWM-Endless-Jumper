using System;
using UnityEngine;

public class ChasingEnemy : MonoBehaviour
{
    [field: SerializeField]
    public float OffsetFromPlayer { get; } = 10f;

    [SerializeField] private PlayerController _player;
    
    private void Start()
    {
        float playerXPosition = _player.transform.position.x;
        transform.position = new Vector2(playerXPosition - OffsetFromPlayer, transform.position.y);
    }
}
