using Code.Components.Tags;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Code.Gameplay
{
    internal sealed partial class FollowCameraSystem:SystemBase
    {
        private Transform _transform;

        protected override void OnStartRunning()
        {
            _transform = Object.FindObjectOfType<FollowCamera>().transform;
        }

        protected override void OnUpdate()
        {
            Entities.WithAll<PlayerTag>().ForEach((in Translation transform) =>
            {
                _transform.position = transform.Value;
            }).WithoutBurst().Run();
        }
    }
}