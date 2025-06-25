using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    public float pickUpDistance = 5f;
    public float moveSpeed = 10f;

    [SerializeField]
    Camera cam;
    private GameObject heldObject;
    private Rigidbody heldRb;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
                TryPickUpObject();
            else
                DropObject();
        }

        if (heldObject != null)
            MoveObject();
    }

    void TryPickUpObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, pickUpDistance))
        {
            if (hit.rigidbody != null)
            {
                heldObject = hit.collider.gameObject;
                heldRb = heldObject.GetComponent<Rigidbody>();

                heldRb.useGravity = false;
                heldRb.freezeRotation = true;
            }
        }
    }

    void MoveObject()
    {
        Vector3 targetPosition = cam.transform.position + cam.transform.forward * pickUpDistance;
        Vector3 direction = (targetPosition - heldObject.transform.position);
        heldRb.velocity = direction * moveSpeed;
    }

    void DropObject()
    {
        heldRb.useGravity = true;
        heldRb.freezeRotation = false;
        heldObject = null;
        heldRb = null;
    }
}
