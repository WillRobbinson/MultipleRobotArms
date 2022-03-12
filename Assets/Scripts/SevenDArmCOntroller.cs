using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SevenDArmCOntroller : MonoBehaviour
{

    public Slider baseSlider; // MultiArm_06
    public Transform robotBase;
    public float baseTurnRate = 0.10f;
    public float baseZRotMin = -90.0f;
    public float baseZRotMax = 90.0f;
    public float baseSliderValue = 0.0f;
    private float baseZRotate = 0.0f;

    public Slider shoulderSlider; // BaseShoulder
    public Transform shoulder;
    public float shoulderTurnRate = 1.0f;
    public float shoulderXRotMin = -90.0f;
    public float shoulderXRotMax = 90.0f;
    public float shoulderSliderValue = 0.0f;
    private float shoulderXRotate = 0.0f;


    public Slider upperArmSlider;
    public Transform upperArm;
    public float upperArmTurnRate = 1.0f;
    public float upperArmZRotMin = -90.0f;
    public float upperArmZRotMax = 90.0f;
    public float upperArmSliderValue = 0.0f;
    private float upperArmZRotate = 0.0f;

    public Slider elbowSlider;
    public Transform elbow;
    public float elbowTurnRate = 1.0f;
    public float elbowXRotMin = -90.0f;
    public float elbowXRotMax = 90.0f;
    public float elbowSliderValue = 0.0f;
    private float elbowXRotate = 0.0f;

    public Slider wristSlider;
    public Transform wrist;
    public float wristTurnRate = 1.0f;
    public float wristZRotMin = -90.0f;
    public float wristZRotMax = 90.0f;
    public float wristSliderValue = 0.0f;
    private float wristZRotate = 0.0f;

    public Slider handSlider;
    public Transform hand;
    public float handTurnRate = 1.0f;
    public float handXRotMin = -90.0f;
    public float handXRotMax = 90.0f;
    public float handSliderValue = 0.0f;
    private float handXRotate = 0.0f;

    public Slider pincherBaseSlider;
    public Transform pincherBase;
    public float pincherBaseTurnRate = 1.0f;
    public float pincherBaseZRotMin = -179.0f;
    public float pincherBaseZRotMax = 180.0f;
    public float pincherBaseSliderValue = 0.0f;
    private float pincherBaseZRotate = 0.0f;

    public Slider leftPincherSlider;
    public Transform leftPincher;
    public float leftPincherTurnRate = 1.0f;
    public float leftPincherXRotMin = -90.0f;
    public float leftPincherXRotMax = 90.0f;
    public float leftPincherSliderValue = 0.0f;
    private float leftPincherXRotate = 0.0f;

    public Slider rightPincherSlider;
    public Transform rightPincher;
    public float rightPincherTurnRate = 1.0f;
    public float rightPincherXRotMin = -90.0f;
    public float rightPincherXRotMax = 90.0f;
    public float rightPincherSliderValue = 0.0f;
    private float rightPincherXRotate = 0.0f;


    void Start()
    {
        baseSlider.minValue = -1;
        baseSlider.maxValue = 1;

        shoulderSlider.minValue = -1;
        shoulderSlider.maxValue = 1;

        upperArmSlider.minValue = -1;
        upperArmSlider.maxValue = 1;

        elbowSlider.minValue = -1;
        elbowSlider.maxValue = 1;

        wristSlider.minValue = -1;
        wristSlider.maxValue = 1;

        handSlider.minValue = -1;
        handSlider.maxValue = 1;

        pincherBaseSlider.minValue = -1;
        pincherBaseSlider.maxValue = 1;

        leftPincherSlider.minValue = -1;
        leftPincherSlider.maxValue = 1;

        rightPincherSlider.minValue = -1;
        rightPincherSlider.maxValue = 1;

    }

    void CheckInput()
    {
        baseSliderValue = baseSlider.value;
        shoulderSliderValue = shoulderSlider.value;
        upperArmSliderValue = upperArmSlider.value;
        elbowSliderValue = elbowSlider.value;
        wristSliderValue = wristSlider.value;
        handSliderValue = handSlider.value;
        pincherBaseSliderValue = pincherBaseSlider.value;
        leftPincherSliderValue = leftPincherSlider.value;
        rightPincherSliderValue = rightPincherSlider.value;
    }

    void ProcessMovement()
    {
        baseZRotate += baseSliderValue * baseTurnRate;
        baseZRotate = Mathf.Clamp(baseZRotate, baseZRotMin, baseZRotMax);
        robotBase.localEulerAngles = new Vector3(robotBase.localEulerAngles.x,
                                                 robotBase.localEulerAngles.y,
                                                 baseZRotate);

        shoulderXRotate += shoulderSliderValue * shoulderTurnRate;
        shoulderXRotate = Mathf.Clamp(shoulderXRotate, shoulderXRotMin, shoulderXRotMax);
        shoulder.localEulerAngles = new Vector3(shoulderXRotate,
                                                shoulder.localEulerAngles.y,
                                                shoulder.localEulerAngles.z);

        upperArmZRotate += upperArmSliderValue * upperArmTurnRate;
        upperArmZRotate = Mathf.Clamp(upperArmZRotate, upperArmZRotMin, upperArmZRotMax);
        upperArm.localEulerAngles = new Vector3(upperArm.localEulerAngles.x,
                                                upperArm.localEulerAngles.y,
                                                upperArmZRotate);

        elbowXRotate += elbowSliderValue * elbowTurnRate;
        elbowXRotate = Mathf.Clamp(elbowXRotate, elbowXRotMin, elbowXRotMax);
        elbow.localEulerAngles = new Vector3(elbowXRotate,
                                                elbow.localEulerAngles.y,
                                                elbow.localEulerAngles.z);

        wristZRotate += wristSliderValue * wristTurnRate;
        wristZRotate = Mathf.Clamp(wristZRotate, wristZRotMin, wristZRotMax);
        wrist.localEulerAngles = new Vector3(wrist.localEulerAngles.x,
                                            wrist.localEulerAngles.y,
                                            wristZRotate);

        handXRotate += handSliderValue * handTurnRate;
        handXRotate = Mathf.Clamp(handXRotate, handXRotMin, handXRotMax);
        hand.localEulerAngles = new Vector3(handXRotate,
                                            hand.localEulerAngles.y,
                                            hand.localEulerAngles.z);

        pincherBaseZRotate += pincherBaseSliderValue * pincherBaseTurnRate;
        pincherBaseZRotate = Mathf.Clamp(pincherBaseZRotate, pincherBaseZRotMin, pincherBaseZRotMax);
        pincherBase.localEulerAngles = new Vector3(pincherBase.localEulerAngles.x,
                                                    pincherBase.localEulerAngles.y,
                                                    pincherBaseZRotate);

        leftPincherXRotate += leftPincherSliderValue * leftPincherTurnRate;
        leftPincherXRotate = Mathf.Clamp(leftPincherXRotate, leftPincherXRotMin, leftPincherXRotMax);
        leftPincher.localEulerAngles = new Vector3(leftPincherXRotate,
                                                    leftPincher.localEulerAngles.y,
                                                    leftPincher.localEulerAngles.z);

        rightPincherXRotate += rightPincherSliderValue * rightPincherTurnRate;
        rightPincherXRotate = Mathf.Clamp(rightPincherXRotate, rightPincherXRotMin, rightPincherXRotMax);
        rightPincher.localEulerAngles = new Vector3(rightPincherXRotate,
                                                    rightPincher.localEulerAngles.y,
                                                    rightPincher.localEulerAngles.z);
    }

    public void ResetSliders()
    {
        baseSliderValue = 0.0f;
        baseSlider.value = 0.0f;

        shoulderSliderValue = 0.0f;
        shoulderSlider.value = 0.0f;

        upperArmSliderValue = 0.0f;
        upperArmSlider.value = 0.0f;

        elbowSliderValue = 0.0f;
        elbowSlider.value = 0.0f;

        wristSliderValue = 0.0f;
        wristSlider.value = 0.0f;

        handSliderValue = 0.0f;
        handSlider.value = 0.0f;

        pincherBaseSliderValue = 0.0f;
        pincherBaseSlider.value = 0.0f;

        leftPincherSliderValue = 0.0f;
        leftPincherSlider.value = 0.0f;

        rightPincherSliderValue = 0.0f;
        rightPincherSlider.value = 0.0f;
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
