using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public static class ComponentClass
{
    public static void AddRigidBody(GameObject gameObject)
    {
        // If not, add a Rigidbody component
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();

        // Set the Rigidbody properties
        rb.useGravity = true;
        rb.mass = 2.0f; // Set the mass to 2.0
        //rb.drag = 0.5f; // Set the drag to 0.5
        //rb.angularDrag = 0.05f; // Set the angular drag to 0.05
    }

    public static void AddMeshCollider(GameObject gameObject)
    {
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();

        // Set the MeshCollider properties
        mc.convex = false; // Set to true if you need the collider to be convex
        mc.sharedMesh = gameObject.AddComponent<MeshFilter>().sharedMesh; // Assign the mesh from the MeshFilter

        mc.inflateMesh = true; // Example property, set to true to inflate the mesh

    }


    public static void AddGrabInteractable(GameObject gameObject)
    {
        // Check if the GameObject already has an XRGrabInteractable component
        XRGrabInteractable grabInteractable = gameObject.AddComponent<XRGrabInteractable>();

        // Set XRGrabInteractable properties for XRGrabInteractableMode.XRGrabMode
        //grabInteractable.interactionManager = FindObjectOfType<XRInteractionManager>(); // Assign interaction manager if needed
        //grabInteractable.attachTransform = transform; // Set the attach transform
        //grabInteractable.interactableObject = gameObject; // Set the interactable object
        //grabInteractable.throwOnDetach = true; // Example property
        //grabInteractable.attachEaseInTime = 0.15f; // Example property

        // Set the mode to XRGrabInteractableMode.XRGrabMode
        //grabInteractable.interactionMode = XRGrabInteractable.InteractionMode.XRGrabMode;
    }
}