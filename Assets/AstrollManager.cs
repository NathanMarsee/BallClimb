using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstrollManager : MonoBehaviour
{
    public BallClimbControls controls;
    private bool pressedPause = false;
    public GameObject menu;
    public bool won;
    // Start is called before the first frame update
    void Start()
    {
        Renderer[] tests = FindObjectsOfType(typeof(Renderer)) as Renderer[];
        foreach (var t in tests)
        {
            if (t.gameObject.tag != "playerModel")
            {
                t.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }
        }


        var foundGuide = FindObjectOfType<RotateToInputPlusCamera>();
        if (foundGuide != null)
            controls = foundGuide.GetComponent<RotateToInputPlusCamera>().controls;

        controls.UI.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!won)
        {
            if ((controls.Gameplay.Pause.ReadValue<float>() < 0.5f || controls.UI.Pause.ReadValue<float>() < 0.5f) && pressedPause)
            {
                pressedPause = false;
            }
            if ((controls.Gameplay.Pause.ReadValue<float>() > 0.5f || controls.UI.Pause.ReadValue<float>() > 0.5f) && !pressedPause)
            {
                pressedPause = true;
                TogglePause();
            }
        }
    }

    public void TogglePause()
    {
        if(menu.activeInHierarchy)
        {
            menu.SetActive(false);
            controls.Gameplay.Enable();
            controls.UI.Disable();
        } else
        {
            menu.SetActive(true);
            controls.Gameplay.Disable();
            controls.UI.Enable();
        }
    }
}
