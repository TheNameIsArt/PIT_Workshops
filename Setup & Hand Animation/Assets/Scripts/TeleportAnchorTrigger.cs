using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportAnchorTrigger : MonoBehaviour
{
    public Material redPoint;
    public Material greenPoint;
    public Renderer rend;

    public static int activatedCount = 0;   // fælles counter for alle anchors
    public static int totalAnchors = 3;     // sæt dette til antal anchors

    public GameObject wallToRemove;         // kun udfyldt på én af anchors

    private bool isActivated = false;

    private void Awake()
    {
        // Sæt startfarve
        if (rend != null && redPoint != null)
            rend.material = redPoint;
    }

    // XR Interaction Toolkit event
    public void OnTeleportHere(LocomotionSystem locomotion)
    {
        if (isActivated) return;

        // Skift farve
        rend.material = greenPoint;
        isActivated = true;

        activatedCount++;

        // Hvis alle anchors er aktiveret → fjern væg
        if (activatedCount >= totalAnchors && wallToRemove != null)
        {
            wallToRemove.SetActive(false);
        }
    }
}
