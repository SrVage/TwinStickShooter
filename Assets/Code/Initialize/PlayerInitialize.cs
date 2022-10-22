using Code.Components;
using Code.Components.Input;
using Code.Components.Tags;
using Unity.Entities;
using UnityEngine;

namespace Code.Initialize
{
    public class PlayerInitialize:MonoBehaviour
    {
        [SerializeField] public float _moveSpeed;
    }

    public class PlayerBaker : Baker<PlayerInitialize>
    {
        public override void Bake(PlayerInitialize authoring)
        {
            AddComponent(new PlayerTag());
            AddComponent(new Movement {Speed = authoring._moveSpeed});
            AddComponent(new CharacterInputData());
        }
    }
}