// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputsController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputsController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputsController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputsController"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""b68da1c8-d7f9-4343-9fd0-d62a88b0626a"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""963abc43-8e73-4623-b2e1-d70c95479a0e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""B"",
                    ""type"": ""Button"",
                    ""id"": ""5696ef70-7038-4304-baaf-423daa8b4c11"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""X"",
                    ""type"": ""Button"",
                    ""id"": ""fefb5f23-4c60-4776-979b-50463603e363"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""94ddd32a-e03c-4d36-8179-87ea41b8f93b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Joystick"",
                    ""type"": ""Value"",
                    ""id"": ""4aebf547-4928-4c94-9e1f-7142c92ea353"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""12cfda33-0687-4a08-b29f-0c75c3b8e666"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e24f85e8-878e-401c-8593-ba1f8c3bea14"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""B"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b5cf7c9-4d42-44e6-8f31-d140b65ce3c4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1e12c4b-151e-4e9e-83e1-732e98b6b762"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d7f7eff-f2d0-4ee9-a00c-7b2114d11c02"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Joystick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_A = m_Inputs.FindAction("A", throwIfNotFound: true);
        m_Inputs_B = m_Inputs.FindAction("B", throwIfNotFound: true);
        m_Inputs_X = m_Inputs.FindAction("X", throwIfNotFound: true);
        m_Inputs_Y = m_Inputs.FindAction("Y", throwIfNotFound: true);
        m_Inputs_Joystick = m_Inputs.FindAction("Joystick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Inputs
    private readonly InputActionMap m_Inputs;
    private IInputsActions m_InputsActionsCallbackInterface;
    private readonly InputAction m_Inputs_A;
    private readonly InputAction m_Inputs_B;
    private readonly InputAction m_Inputs_X;
    private readonly InputAction m_Inputs_Y;
    private readonly InputAction m_Inputs_Joystick;
    public struct InputsActions
    {
        private @InputsController m_Wrapper;
        public InputsActions(@InputsController wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_Inputs_A;
        public InputAction @B => m_Wrapper.m_Inputs_B;
        public InputAction @X => m_Wrapper.m_Inputs_X;
        public InputAction @Y => m_Wrapper.m_Inputs_Y;
        public InputAction @Joystick => m_Wrapper.m_Inputs_Joystick;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void SetCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnA;
                @B.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnB;
                @B.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnB;
                @B.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnB;
                @X.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnX;
                @X.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnX;
                @X.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnX;
                @Y.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnY;
                @Y.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnY;
                @Y.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnY;
                @Joystick.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnJoystick;
                @Joystick.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnJoystick;
                @Joystick.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnJoystick;
            }
            m_Wrapper.m_InputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @B.started += instance.OnB;
                @B.performed += instance.OnB;
                @B.canceled += instance.OnB;
                @X.started += instance.OnX;
                @X.performed += instance.OnX;
                @X.canceled += instance.OnX;
                @Y.started += instance.OnY;
                @Y.performed += instance.OnY;
                @Y.canceled += instance.OnY;
                @Joystick.started += instance.OnJoystick;
                @Joystick.performed += instance.OnJoystick;
                @Joystick.canceled += instance.OnJoystick;
            }
        }
    }
    public InputsActions @Inputs => new InputsActions(this);
    public interface IInputsActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnB(InputAction.CallbackContext context);
        void OnX(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnJoystick(InputAction.CallbackContext context);
    }
}
