using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockBuilding : MonoBehaviour
{
    public GameObject block;
    GameObject cursorBlock;

    Vector3 mousePosition;
    Vector3 mousePositionGrid;
    // Start is called before the first frame update
    void Start()
    {
        cursorBlock = Instantiate(block, Input.mousePosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate Grid Position
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePositionGrid = new Vector3(Mathf.Round(mousePosition.x % 32), Mathf.Round(mousePosition.y % 32), 0);
        cursorBlock.transform.position = mousePositionGrid;
        Debug.Log(cursorBlock.transform.position);

        //Spawn Block
        if (Input.GetMouseButton(0))
        {
            Instantiate(block, mousePositionGrid, Quaternion.identity);
        }
    }
}
