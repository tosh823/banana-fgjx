using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Banana.Controllers {
    public class Car : MonoBehaviour {

        public float threshold = 5f;

        // Use this for initialization
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {

        }

        public void ChangeSpeed() {
            Vector3 shift = new Vector3(threshold, 0f, 0f);
            Vector3 destination = transform.position + shift;
            transform.position = Vector3.Lerp(transform.position, destination, 0.5f);
        }
    }
}
