using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{
    public int newYValue;
    public int speed;
    private GameObject blockGO;


    int newZValue;
    // Start is called before the first frame update
    void Start()
    {
//        blockGO = GameObject.Find("CubeTop");
        print("Initial Y value: "+transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 newPosition = new Vector3(transform.position.x, newYValue, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
    }
}
