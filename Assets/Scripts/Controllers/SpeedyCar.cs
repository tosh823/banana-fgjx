using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Banana.Controllers {
    public class SpeedyCar : MonoBehaviour {

        public float torque = 60f;
        public int currentGear = 0;
        private Vector3 destination;

        public delegate void CollisionAction();
        public event CollisionAction OnCollided;

        // Use this for initialization
        void Start() {
            
        }

        void OnCollisionEnter2D(Collision2D coll) {
            if (coll.gameObject.GetComponent<Car>() != null) {
                // Collision with a car
                if (OnCollided != null) OnCollided();
            }
        }

        // Update is called once per frame
        void Update() {
            float acceleration = torque * GetGearModifier();
            float relativeAcceleration = acceleration - torque;
            Vector3 shift = new Vector3(relativeAcceleration * 0.05f, 0f, 0f);
            destination = transform.position + shift;
            transform.position = Vector3.Lerp(transform.position, destination, 0.05f);
        }

        private float GetGearModifier() {
            switch (currentGear) {
                case 0:
                    return 1f;
                case 1:
                    return 0.25f;
                case 2:
                    return 0.75f;
                case 3:
                    return 1.25f;
                default:
                    return 1f;
            }
        }
    }
}
