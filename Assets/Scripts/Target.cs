using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [Serializable]
    public class HitEvent: UnityEvent<int> { }
    public HitEvent OnHit = new HitEvent();


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
            FigureOutScore(collision.transform.position);
    }


    private void FigureOutScore(Vector3 hitPosition)
    {
        var distanceFromCentre = Vector3.Distance(transform.position, hitPosition);
        int score = 0;
        
        if (distanceFromCentre < 0.25f)
        {
            EditorApplication.isPlaying = false;
            score = 15;
        }
        

        else if (distanceFromCentre < 0.5f)
            score = 5;

        OnHit.Invoke(score);

    }
}
