using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointRotator : MonoBehaviour
{

    public float baseTurnRate = 1.0f;
    public string getRotationAxis(string jointName)
    {
        // NOTE: may have to support +/- values
        if ("Shoulder Joint".Equals(jointName)) return "Z";
        if ("BaseShoulder".Equals(jointName)) return "X";
        if ("UpperArm".Equals(jointName)) return "Z";
        if ("Elbow".Equals(jointName)) return "X";
        if ("Wrist".Equals(jointName)) return "Z";
        if ("Hand".Equals(jointName)) return "X";
        if ("PincherBase".Equals(jointName)) return "Z";
        if ("LeftPincher".Equals(jointName)) return "X";
        if ("RightPincher".Equals(jointName)) return "X";
        return "Unknown";
    }

    public int getMaxAngle(string jointName)
    {
        if ("BaseShoulder".Equals(jointName)) return 60;
        if ("Elbow".Equals(jointName)) return 90;
        if ("Hand".Equals(jointName)) return 90;
        if ("PincherBase".Equals(jointName)) return -85;
        if ("LeftPincher".Equals(jointName)) return 85;
        if ("RightPincher".Equals(jointName)) return 359;
        return 0;
    }

    public int getMinAngle(string jointName)
    {
        if ("BaseShoulder".Equals(jointName)) return -20;
        if ("Elbow".Equals(jointName)) return -90;
        if ("Hand".Equals(jointName)) return -90;
        if ("PincherBase".Equals(jointName)) return 85;
        if ("LeftPincher".Equals(jointName)) return -85;
        if ("RightPincher".Equals(jointName)) return 0;
        return 0;
    }

    public void RotateJoint(GameObject gameObject,int angleIncrement)
    {
        string axis = getRotationAxis(gameObject.name);
        
        if ("unknown".Equals(axis)) print("unknown axis for gameObject "+gameObject.name);

        if ("X".Equals(axis))
        {
            float baseRotate = gameObject.transform.localEulerAngles.x + angleIncrement * baseTurnRate;
            print("X:rot:" + gameObject.name + " was " + gameObject.transform.localEulerAngles.x + " a*b=" + angleIncrement * baseTurnRate + " bR="+ baseRotate);
            // Need a range here: 0-80 or 360-280 or 0-(-20)
            if ((baseRotate >= 0 && baseRotate <= 80) || (baseRotate >= 280 && baseRotate < 380) || (baseRotate < 0 && baseRotate >= -19.99997))
            {
                //            baseRotate = Mathf.Clamp(baseRotate, getMinAngle(gameObject.name), getMaxAngle(gameObject.name));
                LeanTween.rotateLocal(gameObject, new Vector3(baseRotate,
                                                        gameObject.transform.localEulerAngles.y,
                                                        gameObject.transform.localEulerAngles.z), 0.2f);
            }
        } 
        else if ("Y".Equals(axis))
        {
            float baseRotate = gameObject.transform.localEulerAngles.y + angleIncrement * baseTurnRate;
            print("Y:rot:" + gameObject.name + " was " + gameObject.transform.localEulerAngles.y + " a*b=" + angleIncrement * baseTurnRate +" br="+ baseRotate);
//            baseRotate = Mathf.Clamp(baseRotate, -90, 90);
            LeanTween.rotateLocal(gameObject, new Vector3(gameObject.transform.localEulerAngles.x,
                                                        baseRotate,
                                                        gameObject.transform.localEulerAngles.y), 0.2f);
        }
        else if ("Z".Equals(axis))
        {
            float baseRotate = gameObject.transform.localEulerAngles.z + angleIncrement * baseTurnRate;
            print("Z:rot(ua):" + gameObject.name + " was " + gameObject.transform.localEulerAngles.z + " a*b=" + angleIncrement * baseTurnRate+ " bR="+ baseRotate);
            // baseRotate = Mathf.Clamp(baseRotate, 0, 359);
            // print("Z:rot(ua):" + gameObject.name + " was " + gameObject.transform.rotation.z + " a*b=" + angleIncrement * baseTurnRate + " bR=" + baseRotate);
            LeanTween.rotateLocal(gameObject, new Vector3(gameObject.transform.localEulerAngles.x,
                                                        gameObject.transform.localEulerAngles.y,
                                                        baseRotate), 0.2f);
        }
        else
        {
            print("Should never get here");
        }

    }

}
