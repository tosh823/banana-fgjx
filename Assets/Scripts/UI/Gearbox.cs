using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Banana.UI {
    public class Gearbox : MonoBehaviour {

        public delegate void GearAction(int gear);
        public event GearAction OnShifted;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void OnGearPressed(int gear) {
            if (OnShifted != null) OnShifted(gear);
        }
    }
}
