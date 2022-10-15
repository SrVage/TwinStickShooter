using Code.Components.Input;
using Unity.Entities;
using UnityEngine;

namespace Code.Gameplay.Initialize
{
    public class CreateInputData:MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new CharacterInputData());
        }
    }
}