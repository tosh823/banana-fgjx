using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Banana.Controllers {
    public class Scenery : MonoBehaviour {

        public float speed = 1f;

        private CompositeCollider2D cc;
        private float width;

        // Use this for initialization
        void Start() {
            cc = GetComponent<CompositeCollider2D>();
            width = cc.bounds.size.x;
        }

        // Update is called once per frame
        void Update() {
            if (transform.position.x < -width) {
                Reposition();
            }
            else {
                Vector3 step = transform.right * speed * Time.deltaTime;
                transform.position -= step;
            }
        }

        public void Reposition() {
            Vector3 shifted = transform.position;
            shifted.x = width - 0.2f;
            transform.position = shifted;
        }
    }
}
