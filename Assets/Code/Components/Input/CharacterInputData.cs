using Unity.Entities;
using Unity.Mathematics;

namespace Code.Components.Input
{
    public struct CharacterInputData:IComponentData
    {
        public float2 MoveDirection;
        public float2 MousePosition;
        public float Shoot;
        public float Recharge;
    }
}