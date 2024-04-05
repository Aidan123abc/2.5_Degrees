using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraFollow2DLERP : MonoBehaviour {

      public GameObject target;
      public float camSpeed = 4.0f;

      void Start(){
            target = GameObject.FindWithTag("Player");
      }

      // void FixedUpdate () {
      //       Vector2 pos = Vector2.Lerp ((Vector2)transform.position, (Vector2)target.transform.position, camSpeed * Time.fixedDeltaTime);
      //       transform.position = new Vector3 (pos.x, pos.y, transform.position.z);
      // }

      void FixedUpdate () {
      if (target != null) {
        Vector2 targetPosition = target.transform.position;
        Vector2 cameraPosition = transform.position;
        // Assuming you want some offset; adjust x and y values as needed
        Vector2 offset = new Vector2(1.0f, 1.0f); 
        Vector2 newPos = Vector2.Lerp(cameraPosition, targetPosition + offset, camSpeed * Time.fixedDeltaTime);
        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }
}
}
