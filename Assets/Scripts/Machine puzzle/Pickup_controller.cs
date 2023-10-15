using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_controller : MonoBehaviour
{
    [Header("Pickup settings")]
    // Area in front of the player we want to hold items at.
    [SerializeField] Transform holdArea;

    GameObject heldObject;
    Rigidbody heldObjRB;

    [Header("Physics settings")]
    [SerializeField] float pickupRange = 5.0f;
    [SerializeField] float pickupForce = 150.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {
                    // Pick up the object by looking at which collider the ray hit, then which object the collider belongs to?
                    PickUpObject(hit.transform.gameObject);
                }
            }
            else
            {
                // Drop the object
                DropObject();
            }
        }

        if (heldObject != null)
        {
            MoveObject();
        }
    }

    void PickUpObject(GameObject objToPickUp)
    {
        // Check if object has a rigid body.
        if (objToPickUp.GetComponent<Rigidbody>())
        {
            heldObjRB = objToPickUp.GetComponent<Rigidbody>();

            // Disable so it doesn't try to fall while being held.
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            // Make the held object a child of the hold area so the position values are automatically update when the camera moves.
            heldObjRB.transform.parent = holdArea;
            heldObject = objToPickUp;
        }
    }

    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        // Make the held object a child of the hold area so the position values are automatically update when the camera moves.
        heldObject.transform.parent = null;
        heldObject = null;
    }

    void MoveObject()
    {
        // If the hold area moved, update the held object as well.
        if (Vector3.Distance(heldObject.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = holdArea.position - heldObject.transform.position;
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }
}