using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;
using Valve.VR;
using UnityEngine.InputSystem;

public class ControllerOutput : MonoBehaviour
{
    static public Vector2 leftaxisDirection;
    static public Vector2 rightaxisDirection;

    static public bool pressPrimaryButton = false;
    static public bool pressMenuButton = false;

    void Start()
    {
        SteamVR.Initialize();
    }

    void Update()
    {
        leftaxisDirection = Vector2.zero;
        rightaxisDirection = Vector2.zero;

#if UNITY_EDITOR
        if (Keyboard.current.wKey.isPressed) leftaxisDirection.y += 1;
        if (Keyboard.current.sKey.isPressed) leftaxisDirection.y -= 1;
        if (Keyboard.current.aKey.isPressed) leftaxisDirection.x -= 1;
        if (Keyboard.current.dKey.isPressed) leftaxisDirection.x += 1;

        if (Keyboard.current.iKey.isPressed) rightaxisDirection.y += 1;
        if (Keyboard.current.kKey.isPressed) rightaxisDirection.y -= 1;
        if (Keyboard.current.jKey.isPressed) rightaxisDirection.x -= 1;
        if (Keyboard.current.lKey.isPressed) rightaxisDirection.x += 1;

        pressMenuButton = Keyboard.current.enterKey.wasPressedThisFrame;
        pressPrimaryButton = Keyboard.current.spaceKey.wasPressedThisFrame;

#else
        if (SteamVR_Actions.mixedreality_LeftPadTrackerPressed.state)
            leftaxisDirection = SteamVR_Actions.mixedreality_LeftPadTracker.GetAxis(SteamVR_Input_Sources.LeftHand);

        if (SteamVR_Actions.mixedreality_RightPadTrackerPressed.stateUp)
            rightaxisDirection = SteamVR_Actions.mixedreality_RightPadTracker.GetAxis(SteamVR_Input_Sources.RightHand);

        pressMenuButton = SteamVR_Actions.mixedreality_PressMenu.stateUp;
        pressPrimaryButton = SteamVR_Actions.mixedreality_PressTrigger.stateUp;
#endif
    }
}
