using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Banana.UI {
    public class Slot : MonoBehaviour {

        public float speed = 5f;
        public Image slotImage;
        public Image gearImage;

        public bool hasGear = false;

        private bool _isActive;
        public bool IsActive {
            set {
                if (value) {
                    slotImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(@"Sprites/UI/button_metalCircle"); 
                }
                else {
                    slotImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(@"Sprites/UI/button_metalBlank");
                }
                _isActive = value;
            }
            get {
                return _isActive;
            }
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if (hasGear) {
                RectTransform rectTransform = gearImage.GetComponent<RectTransform>();
                rectTransform.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
            }
        }
    }
}
