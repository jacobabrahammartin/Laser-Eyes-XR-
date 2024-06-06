using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughManager : MonoBehaviour
{
    [SerializeField] private OVRPassthroughLayer passthroughLayer1; // Default layer OnGameStarted
    [SerializeField] private OVRPassthroughLayer passthroughLayer2; // Alternate layer OnGameOver

    private bool isLayer1Active = true;

    void Update()
    {
        // Use unity events to toggle layers on GameOver and GameStarted
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ToggleEnableDisableLayer();
        }
    }

    private void ToggleEnableDisableLayer()
    {
        // Disable the currently active layer and enable the other one
        if (isLayer1Active)
        {
            passthroughLayer1.enabled = false;
            passthroughLayer2.enabled = true;
        }
        else
        {
            passthroughLayer1.enabled = true;
            passthroughLayer2.enabled = false;
        }

        // Update the active layer flag
        isLayer1Active = !isLayer1Active;
    }
}
