using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Banana.Controllers {
    public class Car : MonoBehaviour {

        public float currentSpeed = 60f;
        private Vector3 destination;

        // Use this for initialization
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
            transform.position = Vector3.Lerp(transform.position, destination, 0.05f);
        }

        public void ChangeSpeed(float speed) {
            float relativeAcceleration = speed - currentSpeed;
            Vector3 shift = new Vector3(relativeAcceleration * 0.05f, 0f, 0f);
            destination = transform.position + shift;
        }
    }
}
