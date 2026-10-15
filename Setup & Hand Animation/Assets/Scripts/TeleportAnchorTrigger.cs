using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

[RequireComponent(typeof(TeleportationAnchor))]
public class TeleportAnchorTrigger : MonoBehaviour
{
    public Material redPoint;
    public Material greenPoint;
    public Renderer rend;
    public GameObject wallToRemove;      // still only needed on one anchor

    static int activatedCount;
    static int totalAnchors;
    static GameObject wall;

    bool isActivated;

    void Awake()
    {
        activatedCount = 0;
        if (wallToRemove != null) wall = wallToRemove;
        if (rend != null && redPoint != null) rend.material = redPoint;

        GetComponent<TeleportationAnchor>().teleporting.AddListener(_ => OnTeleportHere());
    }

    void Start()
    {
        totalAnchors = FindObjectsByType<TeleportAnchorTrigger>(FindObjectsSortMode.None).Length;
    }

    void OnTeleportHere()
    {
        if (isActivated) return;
        isActivated = true;

        rend.material = greenPoint;
        activatedCount++;
        Debug.Log($"Anchors activated: {activatedCount}/{totalAnchors}");

        if (activatedCount >= totalAnchors && wall != null)
            wall.SetActive(false);
    }
}