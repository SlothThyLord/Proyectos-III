using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Tracking.Velocity;


/*Great script that solves the innertia issue when throwing stuff around, now I can transmit my uncontrolled hatred for the human kind into the VR world. Cheers. */
public class OVRAnchorVelocityEstimator : VelocityTracker
{
    public GameObject trackedGameObject;
    public GameObject relativeTo;
    public override bool IsActive()
    {
        return trackedGameObject != null && trackedGameObject.activeInHierarchy && isActiveAndEnabled;
    }

    protected override Vector3 DoGetAngularVelocity()
    {
        switch (trackedGameObject.name)
        {
            case "CenterEyeAnchor":
                return trackedGameObject.transform.rotation * (OVRManager.isHmdPresent ? OVRPlugin.GetNodeAngularVelocity(OVRPlugin.Node.EyeCenter,OVRPlugin.Step.Render).FromFlippedZVector3f(): Vector3.zero);
            case "LeftHandAnchor":
                return trackedGameObject.transform.rotation * (OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch));
            case "RightHandAnchor":
                return trackedGameObject.transform.rotation * (OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch));
        }
        return Vector3.zero;
    }

    protected override Vector3 DoGetVelocity()
    {
        switch (trackedGameObject.name)
        {
            case "CenterEyeAnchor":
                return relativeTo.transform.rotation * (OVRManager.isHmdPresent ? OVRPlugin.GetNodeVelocity(OVRPlugin.Node.EyeCenter, OVRPlugin.Step.Render).FromFlippedZVector3f() : Vector3.zero);
            case "LeftHandAnchor":
                return trackedGameObject.transform.rotation * (OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch));
            case "RightHandAnchor":
                return trackedGameObject.transform.rotation * (OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch));
        }
        return Vector3.zero;
    }
}
