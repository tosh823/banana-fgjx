using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Banana.Controllers {
    public class Movement : MonoBehaviour {

        public float Speed = 5f;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            float horInput = Input.GetAxis("Horizontal");
            if (horInput > 0f) {
                transform.Translate(transform.right * Speed * Time.deltaTime);
            }
            if (horInput < 0f) {
                transform.Translate(-transform.right * Speed * Time.deltaTime);
            }

            float verInput = Input.GetAxis("Vertical");
            if (verInput > 0f) {
                transform.Translate(transform.up * Speed * Time.deltaTime);
            }
            if (verInput < 0f) {
                transform.Translate(-transform.up * Speed * Time.deltaTime);

            }
        }
    }
}
