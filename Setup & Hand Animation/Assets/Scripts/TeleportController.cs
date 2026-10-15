using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class TeleportController : MonoBehaviour
{
    public InputActionProperty teleportationActivationAction;
    public XRRayInteractor teleportInteractor;

    void Start()
    {
        Debug.Log("TeleportController started, action: " + teleportationActivationAction.action?.name);
        teleportInteractor.gameObject.SetActive(false);

        teleportationActivationAction.action.Enable();
        teleportationActivationAction.action.performed += Action_performed;
        teleportationActivationAction.action.canceled += Action_canceled;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Teleport action performed");
        teleportInteractor.gameObject.SetActive(true);
    }

    private void Action_canceled(InputAction.CallbackContext obj)
    {
        StartCoroutine(StartTeleportation());
    }

    System.Collections.IEnumerator StartTeleportation()
    {
        yield return new WaitForSeconds(0.1f);
        teleportInteractor.gameObject.SetActive(false);
    }

}
