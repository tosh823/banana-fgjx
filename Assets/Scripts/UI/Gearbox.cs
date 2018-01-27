using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Banana.UI {
    public class Gearbox : MonoBehaviour {

        private int currentGear = 0;

        public delegate void GearAction(int gear);
        public event GearAction OnShifted;

        public Image cgImage;

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void OnGearPressed(int gear) {
            currentGear = gear;
            if (OnShifted != null) OnShifted(gear);
            cgImage.enabled = true;
            switch (currentGear) {
                case 1:
                    cgImage.sprite = Resources.Load<Sprite>(@"Sprites/Gears/gear_8");
                    cgImage.SetNativeSize();
                    break;
                case 2:
                    cgImage.sprite = Resources.Load<Sprite>(@"Sprites/Gears/gear_12");
                    cgImage.SetNativeSize();
                    break;
                case 3:
                    cgImage.sprite = Resources.Load<Sprite>(@"Sprites/Gears/gear_16");
                    cgImage.SetNativeSize();
                    break;
            }

        }

        public void OnSlotPressed(int slot) {
            if (OnShifted != null) OnShifted(0);
            cgImage.enabled = false;
        }
    }
}
