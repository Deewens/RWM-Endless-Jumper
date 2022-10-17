using UnityEngine;

namespace PowerUp
{
    public interface IPowerUp
    {
        PowerUpType powerUpType { get; }

        /**
         * Instantiate a new PowerUp in the level
         */
        void Spawn();
    }
}