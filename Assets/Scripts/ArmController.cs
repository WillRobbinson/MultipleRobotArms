using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmController : MonoBehaviour
{
    public Slider baseSlider;
    public Transform robotBase;
    public float baseTurnRate = 1.0f;
    public float baseZRotMin = -90.0f;
    public float baseZRotMax = 90.0f;
    public float baseSliderValue = 0.0f;
    private float baseZRotate = 0.0f;
    
    public Slider upperArmSlider;
    public Transform upperArm;
    public float upperArmTurnRate = 1.0f;
    public float upperArmXRotMin = -90.0f;
    public float upperArmXRotMax = 90.0f;
    public float upperArmSliderValue = 0.0f;
    private float upperArmXRotate = 0.0f;

    public Slider forearmSlider;
    public Transform forearm;
    public float forearmTurnRate = 1.0f;
    public float forearmXRotMin = -90.0f;
    public float forearmXRotMax = 90.0f;
    public float forearmSliderValue = 0.0f;
    private float forearmXRotate = 0.0f;

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

    public Slider pinchersSlider;
    public Transform pinchers;
    public float pinchersTurnRate = 1.0f;
    public float pinchersZRotMin = -179.0f;
    public float pinchersZRotMax = 180.0f;
    public float pinchersSliderValue = 0.0f;
    private float pinchersZRotate = 0.0f;
        

    void Start()
    {
        baseSlider.minValue = -1;
        baseSlider.maxValue = 1;

        upperArmSlider.minValue = -1;
        upperArmSlider.maxValue = 1;

        forearmSlider.minValue = -1;
        forearmSlider.maxValue = 1;

        handSlider.minValue = -1;
        handSlider.maxValue = 1;

        pincherBaseSlider.minValue = -1;
        pincherBaseSlider.maxValue = 1;

        pinchersSlider.minValue = -1;
        pinchersSlider.maxValue = 1;

    }

    void CheckInput()
    {
        baseSliderValue = baseSlider.value;
        upperArmSliderValue = upperArmSlider.value;
        forearmSliderValue = forearmSlider.value;
        handSliderValue = handSlider.value;
        pincherBaseSliderValue = pincherBaseSlider.value;
        pinchersSliderValue = pinchersSlider.value;
    }

    void ProcessMovement()
    {
        baseZRotate += baseSliderValue * baseTurnRate;
        baseZRotate = Mathf.Clamp(baseZRotate, baseZRotMin, baseZRotMax);
        robotBase.localEulerAngles = new Vector3(   robotBase.localEulerAngles.x, 
                                                    robotBase.localEulerAngles.y, 
                                                    baseZRotate);

        upperArmXRotate += upperArmSliderValue * upperArmTurnRate;
        upperArmXRotate = Mathf.Clamp(upperArmXRotate, upperArmXRotMin, upperArmXRotMax);
        upperArm.localEulerAngles = new Vector3(upperArmXRotate,
                                                upperArm.localEulerAngles.y,
                                                upperArm.localEulerAngles.z);
        
        forearmXRotate += forearmSliderValue * forearmTurnRate;
        forearmXRotate = Mathf.Clamp(forearmXRotate, forearmXRotMin, forearmXRotMax);
        forearm.localEulerAngles = new Vector3( forearmXRotate,
                                                forearm.localEulerAngles.y,
                                                forearm.localEulerAngles.z);

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

        pinchersZRotate += pinchersSliderValue * pinchersTurnRate;
        pinchersZRotate = Mathf.Clamp(pinchersZRotate, pinchersZRotMin, pinchersZRotMax);
        pinchers.localEulerAngles = new Vector3(pinchers.localEulerAngles.x,
                                                    pinchers.localEulerAngles.y,
                                                    pinchersZRotate);
    }

    public void ResetSliders()
    {
        baseSliderValue = 0.0f;
        baseSlider.value = 0.0f;

        upperArmSliderValue = 0.0f;
        upperArmSlider.value = 0.0f;

        forearmSliderValue = 0.0f;
        forearmSlider.value = 0.0f;

        handSliderValue = 0.0f;
        handSlider.value = 0.0f;

        pincherBaseSliderValue = 0.0f;
        pincherBaseSlider.value = 0.0f;

        pinchersSliderValue = 0.0f;
        pinchersSlider.value = 0.0f;
    }

    void Update()
    {
        CheckInput();
        ProcessMovement();
    }
}
