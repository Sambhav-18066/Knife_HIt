using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGROTATION : MonoBehaviour
{
    [System.Serializable]
   private class RotationElement
    {
        public float speed;
        public float Duration;

    }
    [SerializeField]
    RotationElement[] rotationPattern;

    private WheelJoint2D wheeljoint;
    private JointMotor2D motor;


    private void Awake()
    {
        
        wheeljoint = GetComponent<WheelJoint2D>();
        motor = new JointMotor2D();
        StartCoroutine("playRotationPattern");
    }

    //co-routine

    private IEnumerator playRotationPattern()
    {
        int rotationIndex=0;
        while (true)
        {
            yield return new WaitForFixedUpdate();

            motor.motorSpeed = rotationPattern[rotationIndex].speed;
            motor.maxMotorTorque = 1000;
            wheeljoint.motor = motor;

            yield return new WaitForSecondsRealtime(rotationPattern[rotationIndex].Duration);
            rotationIndex++;
            rotationIndex = rotationIndex < rotationPattern.Length ? rotationIndex : 0; 

        }
    }

}
