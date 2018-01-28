using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Banana.Controllers {
    public class SpeedyCar : MonoBehaviour {

        public float torque = 60f;
        public int currentGear = -1;
        private Vector3 destination;

        public delegate void CollisionAction();
        public event CollisionAction OnCollided;

        private Vector3 edge;

        // Use this for initialization
        void Start() {
            edge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, Camera.main.nearClipPlane));
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

            if (transform.position.x < edge.x && OnCollided != null) OnCollided();
        }

        private float GetGearModifier() {
            switch (currentGear) {
                case 0:
                    return 0.9f;
                case 1:
                    return 0.6f;
                case 2:
                    return 1.2f;
                case 3:
                    return 1.6f;
                default:
                    return 1f;
            }
        }
    }
}
