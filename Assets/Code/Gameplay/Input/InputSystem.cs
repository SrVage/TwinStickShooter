using Code.Components.Input;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Gameplay.Input
{
    [RequireMatchingQueriesForUpdate]
    internal sealed partial class InputSystem:SystemBase
    {
        private InputAction _moveAction;
        private InputAction _fireAction;
        private InputAction _rechargeAction;
        private InputAction _mouseAction;
        private float2 _moveDirection;
        private float2 _mousePosition;
        private float _fireButton;
        private float _rechargeButton;

        protected override void OnStartRunning()
        {
            _moveAction = new InputAction("move");
            _moveAction.AddCompositeBinding("Dpad")
                .With("Up", binding: "<Keyboard>/w")
                .With("Down", binding: "<Keyboard>/s")
                .With("Left", binding: "<Keyboard>/a")
                .With("Right", binding: "<Keyboard>/d");
            _moveAction.performed += context => { _moveDirection = context.ReadValue<Vector2>(); };
            _moveAction.started += context => { _moveDirection = context.ReadValue<Vector2>(); };
            _moveAction.canceled += context => { _moveDirection = context.ReadValue<Vector2>(); };
            _moveAction.Enable();
            _fireAction = new InputAction("Fire", binding: "<Mouse>/leftButton");
            _fireAction.performed += context => { _fireButton = context.ReadValue<float>(); };
            _fireAction.started += context => { _fireButton = context.ReadValue<float>(); };
            _fireAction.canceled += context => { _fireButton = context.ReadValue<float>(); };
            _fireAction.Enable();
            _rechargeAction = new InputAction("Recharge", binding: "<Mouse>/rightButton");
            _rechargeAction.performed += context => { _rechargeButton = context.ReadValue<float>(); };
            _rechargeAction.started += context => { _rechargeButton = context.ReadValue<float>(); };
            _rechargeAction.canceled += context => { _rechargeButton = context.ReadValue<float>(); };
            _rechargeAction.Enable();
            _mouseAction = new InputAction("Look", binding: "<Mouse>/position");
            _mouseAction.performed += context => { _mousePosition = context.ReadValue<Vector2>(); };
            _mouseAction.started += context => { _mousePosition = context.ReadValue<Vector2>(); };
            _mouseAction.canceled += context => { _mousePosition = context.ReadValue<Vector2>(); };
            _mouseAction.Enable();
        }

        protected override void OnStopRunning()
        {
            _moveAction.Disable();
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((ref CharacterInputData characterInputData) =>
            {
                characterInputData.MoveDirection = _moveDirection;
                characterInputData.Shoot = _fireButton;
                characterInputData.Recharge = _rechargeButton;
                characterInputData.MousePosition = _mousePosition;
            }).WithoutBurst().Run();
        }
    }
}