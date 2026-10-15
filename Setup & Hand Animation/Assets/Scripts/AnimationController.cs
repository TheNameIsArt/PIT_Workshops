using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    public InputActionProperty grabAction;
    public InputActionProperty triggerAction;

    public Animator handAnimator;

    void Update()
    {
        float grabValue = grabAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grab", grabValue);

        float triggerValue = triggerAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
    }
}
