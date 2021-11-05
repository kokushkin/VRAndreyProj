using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float launchForcce = 10.0f;
    private Rigidbody rigitBody = null;

    private void Awake()
    {
        rigitBody = GetComponent<Rigidbody>();
    }

    public void Launch()
    {
        rigitBody.AddRelativeForce(Vector3.forward * launchForcce, ForceMode.Impulse);
        Destroy(gameObject, 5.0f);
    }
}
