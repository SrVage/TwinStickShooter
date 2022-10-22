using Code.Components;
using Code.Components.Input;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using static UnityEngine.Screen;

namespace Code.Gameplay.MoveSystems
{
    internal sealed partial class PlayerMoveSystem:SystemBase
    {

        protected override void OnUpdate()
        {

            Entities.ForEach((TransformAspect transform, ref PhysicsVelocity physics,  in Movement speed, in CharacterInputData inputData) =>
            {
                float rotation = Mathf.Atan2(inputData.MousePosition.y-height/2, inputData.MousePosition.x-width/2);
                transform.LocalRotation = quaternion.Euler(0, -rotation, 0);
                //transform.RotateWorld(quaternion.RotateY(UnityEngine.Time.deltaTime*(inputData.MousePosition.x-Screen.width/2)/100));
                physics.Angular = new float3(inputData.MoveDirection.x, 0 , inputData.MoveDirection.y)*speed.Speed; //(speed.Speed)*(inputData.MoveDirection.x * transform.Back+inputData.MoveDirection.y*transform.Right);
                //transform.LocalPosition += (speed.Speed*UnityEngine.Time.deltaTime)*(inputData.MoveDirection.x * transform.Back+inputData.MoveDirection.y*transform.Right);
            }).WithoutBurst().Run();
        }
    }
}