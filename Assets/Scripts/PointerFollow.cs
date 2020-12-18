using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerFollow : MonoBehaviour
{
    public Camera mainCamera;
    void Update()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y);
        transform.position = mousePos;
    }
}
