using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ComponentClass
{
    public static void AddRigidBody(GameObject gameObject){
        // If not, add a Rigidbody component
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();

        // Set the Rigidbody properties
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.mass = 2.0f; // Set the mass to 2.0
        //rb.drag = 0.5f; // Set the drag to 0.5
        //rb.angularDrag = 0.05f; // Set the angular drag to 0.05
    }

    public static void AddMeshCollider(GameObject gameObject){
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();
        mc.convex = true; // Assign the mesh from the MeshFilter
    }

    public static void AddXRGrabInteractable(GameObject gameObject){
        // Check if the GameObject already has an XRGrabInteractable component
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable  = gameObject.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grabInteractable.movementType = UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable.MovementType.VelocityTracking;
        grabInteractable.useDynamicAttach = true; 
        grabInteractable.attachEaseInTime = 0.0f;
        grabInteractable.selectMode = UnityEngine.XR.Interaction.Toolkit.Interactables.InteractableSelectMode.Multiple;
    }

    public static void AddMeshRenderer(GameObject gameObject){
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        Material material1 = (Material) Resources.Load("UniversalMaterialGrey.mat");
        renderer.material = material1;
    }
}