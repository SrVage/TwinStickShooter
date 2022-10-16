using Code.Components;
using Code.Components.Input;
using Code.Components.Tags;
using Unity.Entities;
using UnityEngine;

namespace Code.Initialize
{
    public class PlayerInitialize:MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField] private float _moveSpeed;
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new PlayerTag());
            dstManager.AddComponentData(entity, new Movement {Speed = _moveSpeed});
            dstManager.AddComponentData(entity, new CharacterInputData());
        }
    }
}