using Code.Components;
using Code.Components.Input;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Code.Gameplay.MoveSystems
{
    internal sealed partial class PlayerMoveSystem:SystemBase
    {

        protected override void OnUpdate()
        {

            Entities.ForEach((TransformAspect transform, in Movement speed, in CharacterInputData inputData) =>
            {
                transform.LocalPosition += (speed.Speed*UnityEngine.Time.deltaTime)*(inputData.MoveDirection.x * transform.Forward+inputData.MoveDirection.y*transform.Right);

            }).WithoutBurst().Run();
        }
    }
}