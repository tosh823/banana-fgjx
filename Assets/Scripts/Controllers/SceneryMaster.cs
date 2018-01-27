using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Banana.Controllers {
    public class SceneryMaster : MonoBehaviour {

        public List<Scenery> groundSceneries;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void ChangeSpeed(float speed) {
            foreach (Scenery scenery in groundSceneries) {
                scenery.speed = speed * 0.1f;
            }
        }
    }
}
