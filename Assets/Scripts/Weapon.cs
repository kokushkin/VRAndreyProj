using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    public Transform barrel = null;
    public GameObject projectilePrefab = null;

    private XRGrabInteractable interactable = null;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();

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

    }
}
