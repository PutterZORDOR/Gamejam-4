using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3F;
        private Vector3 velocity = Vector3.zero;
    
        void Update()
        {
            // Define a target position above and behind the target transform
            Vector3 targetPosition = player.TransformPoint(new Vector3(0, 1, -10));
    
            // Smoothly move the camera towards that target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
}
