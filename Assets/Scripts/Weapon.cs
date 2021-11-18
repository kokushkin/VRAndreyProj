using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    public float recoil = 1.0f;
    public Transform barrel = null;
    public GameObject projectilePrefab = null;

    private XRGrabInteractable interactable = null;
    private Rigidbody rbody = null;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        rbody = GetComponent<Rigidbody>();

    }

    private void OnEnable()
    {
        interactable.onActivate.AddListener(Fire);
    }


    private void OnDisable()
    {
        interactable.onActivate.RemoveListener(Fire);

    }

    private void Fire(XRBaseInteractor interactable)
    {
        var projectileObject = Instantiate(projectilePrefab, barrel.position, barrel.rotation);
        var projective = projectileObject.GetComponent<Projectile>();
        projective.Launch();


        rbody.AddRelativeForce(Vector3.right * recoil, ForceMode.Impulse);

        EditorApplication.isPlaying = false;

    }
}
