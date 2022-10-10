using UnityEngine;

namespace PowerUp
{
    public interface IPowerUp
    {
        PowerUpType Type { get; }

        /**
         * Instantiate a new PowerUp in the level
         */
        void Spawn();
    }
}