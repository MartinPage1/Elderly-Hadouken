// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""GameplayP2"",
            ""id"": ""e86446f0-13a0-45d1-a829-c60983b5c4c7"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""32e68a5f-f02e-47f9-a72d-c624732a5cce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""65bc8780-25d8-4362-bec9-d82390be226c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c74b10e5-104a-4eb2-b3b3-b3c05abe52d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireLeft"",
                    ""type"": ""Button"",
                    ""id"": ""3247c5db-eb01-4553-88d5-212e0aca40dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireRight"",
                    ""type"": ""Button"",
                    ""id"": ""6ec77615-50d1-4695-a634-500f17ad7c76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SuperLeft"",
                    ""type"": ""Button"",
                    ""id"": ""a9c0288f-0be1-4c4e-a8b6-e675d95f0dda"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SuperRight"",
                    ""type"": ""Button"",
                    ""id"": ""8feb9404-f540-4578-bf3b-4cc1b94689c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""b7a30b8d-373b-4824-a5a0-4ef0b41a4e7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""6f7babf9-55d8-4e3f-a924-44c67acbe90e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""32654eef-1d62-4c30-b554-75d522eb7c2a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bed1008d-9915-4b89-86a9-848e32d32ab4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d6c08da-13b2-4df1-bc3b-28832fbe86fd"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""872e66ff-9886-42de-a60f-3ee289a0caee"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""462b34a1-80d6-4924-84e4-571371339926"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3648dfef-0d6e-4acd-9eac-212d949ed5c0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SuperLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89f6fc02-0ffe-4a24-9c89-3fcfeb0820f3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SuperRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be0ebd74-d22d-431f-b001-070ce7765441"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""431dc472-b662-4408-a76f-e2aae0284283"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""right"",
                    ""id"": ""856a6dd5-9658-47bc-b68f-cc8f5b24e92e"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GameplayP1"",
            ""id"": ""1a354e58-de1c-4f67-9923-b6c3546a09b9"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""fefa92e1-618f-4dbc-82b3-4a02be7a3641"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bd5f2907-6e5a-4a7e-ad96-296b64a7a37e"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameplayP2
        m_GameplayP2 = asset.FindActionMap("GameplayP2", throwIfNotFound: true);
        m_GameplayP2_MoveLeft = m_GameplayP2.FindAction("MoveLeft", throwIfNotFound: true);
        m_GameplayP2_MoveRight = m_GameplayP2.FindAction("MoveRight", throwIfNotFound: true);
        m_GameplayP2_Jump = m_GameplayP2.FindAction("Jump", throwIfNotFound: true);
        m_GameplayP2_FireLeft = m_GameplayP2.FindAction("FireLeft", throwIfNotFound: true);
        m_GameplayP2_FireRight = m_GameplayP2.FindAction("FireRight", throwIfNotFound: true);
        m_GameplayP2_SuperLeft = m_GameplayP2.FindAction("SuperLeft", throwIfNotFound: true);
        m_GameplayP2_SuperRight = m_GameplayP2.FindAction("SuperRight", throwIfNotFound: true);
        m_GameplayP2_Select = m_GameplayP2.FindAction("Select", throwIfNotFound: true);
        // GameplayP1
        m_GameplayP1 = asset.FindActionMap("GameplayP1", throwIfNotFound: true);
        m_GameplayP1_Newaction = m_GameplayP1.FindAction("New action", throwIfNotFound: true);
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

    // GameplayP2
    private readonly InputActionMap m_GameplayP2;
    private IGameplayP2Actions m_GameplayP2ActionsCallbackInterface;
    private readonly InputAction m_GameplayP2_MoveLeft;
    private readonly InputAction m_GameplayP2_MoveRight;
    private readonly InputAction m_GameplayP2_Jump;
    private readonly InputAction m_GameplayP2_FireLeft;
    private readonly InputAction m_GameplayP2_FireRight;
    private readonly InputAction m_GameplayP2_SuperLeft;
    private readonly InputAction m_GameplayP2_SuperRight;
    private readonly InputAction m_GameplayP2_Select;
    public struct GameplayP2Actions
    {
        private @PlayerControls m_Wrapper;
        public GameplayP2Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveLeft => m_Wrapper.m_GameplayP2_MoveLeft;
        public InputAction @MoveRight => m_Wrapper.m_GameplayP2_MoveRight;
        public InputAction @Jump => m_Wrapper.m_GameplayP2_Jump;
        public InputAction @FireLeft => m_Wrapper.m_GameplayP2_FireLeft;
        public InputAction @FireRight => m_Wrapper.m_GameplayP2_FireRight;
        public InputAction @SuperLeft => m_Wrapper.m_GameplayP2_SuperLeft;
        public InputAction @SuperRight => m_Wrapper.m_GameplayP2_SuperRight;
        public InputAction @Select => m_Wrapper.m_GameplayP2_Select;
        public InputActionMap Get() { return m_Wrapper.m_GameplayP2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayP2Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplayP2Actions instance)
        {
            if (m_Wrapper.m_GameplayP2ActionsCallbackInterface != null)
            {
                @MoveLeft.started -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.performed -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnMoveLeft;
                @MoveLeft.canceled -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnMoveLeft;
                @MoveRight.started -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnMoveRight;
                @MoveRight.performed -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnMoveRight;
                @MoveRight.canceled -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnMoveRight;
                @Jump.started -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnJump;
                @FireLeft.started -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnFireLeft;
                @FireLeft.performed -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnFireLeft;
                @FireLeft.canceled -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnFireLeft;
                @FireRight.started -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnFireRight;
                @FireRight.performed -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnFireRight;
                @FireRight.canceled -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnFireRight;
                @SuperLeft.started -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSuperLeft;
                @SuperLeft.performed -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSuperLeft;
                @SuperLeft.canceled -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSuperLeft;
                @SuperRight.started -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSuperRight;
                @SuperRight.performed -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSuperRight;
                @SuperRight.canceled -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSuperRight;
                @Select.started -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_GameplayP2ActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_GameplayP2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveLeft.started += instance.OnMoveLeft;
                @MoveLeft.performed += instance.OnMoveLeft;
                @MoveLeft.canceled += instance.OnMoveLeft;
                @MoveRight.started += instance.OnMoveRight;
                @MoveRight.performed += instance.OnMoveRight;
                @MoveRight.canceled += instance.OnMoveRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @FireLeft.started += instance.OnFireLeft;
                @FireLeft.performed += instance.OnFireLeft;
                @FireLeft.canceled += instance.OnFireLeft;
                @FireRight.started += instance.OnFireRight;
                @FireRight.performed += instance.OnFireRight;
                @FireRight.canceled += instance.OnFireRight;
                @SuperLeft.started += instance.OnSuperLeft;
                @SuperLeft.performed += instance.OnSuperLeft;
                @SuperLeft.canceled += instance.OnSuperLeft;
                @SuperRight.started += instance.OnSuperRight;
                @SuperRight.performed += instance.OnSuperRight;
                @SuperRight.canceled += instance.OnSuperRight;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public GameplayP2Actions @GameplayP2 => new GameplayP2Actions(this);

    // GameplayP1
    private readonly InputActionMap m_GameplayP1;
    private IGameplayP1Actions m_GameplayP1ActionsCallbackInterface;
    private readonly InputAction m_GameplayP1_Newaction;
    public struct GameplayP1Actions
    {
        private @PlayerControls m_Wrapper;
        public GameplayP1Actions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_GameplayP1_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_GameplayP1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayP1Actions set) { return set.Get(); }
        public void SetCallbacks(IGameplayP1Actions instance)
        {
            if (m_Wrapper.m_GameplayP1ActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_GameplayP1ActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_GameplayP1ActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_GameplayP1ActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_GameplayP1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public GameplayP1Actions @GameplayP1 => new GameplayP1Actions(this);
    public interface IGameplayP2Actions
    {
        void OnMoveLeft(InputAction.CallbackContext context);
        void OnMoveRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFireLeft(InputAction.CallbackContext context);
        void OnFireRight(InputAction.CallbackContext context);
        void OnSuperLeft(InputAction.CallbackContext context);
        void OnSuperRight(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
    public interface IGameplayP1Actions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
