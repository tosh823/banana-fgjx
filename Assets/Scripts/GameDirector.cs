using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Banana.Controllers;
using Banana.UI;

namespace Banana {
    public class GameDirector : MonoBehaviour {

        public SceneryMaster scenery;
        public Car garbageCar;
        public Gearbox gearboxUI;

        public float maxSpeed = 100f;
        public float minSpeed = 60f;

        public int time;

        private float currentSpeed;

        // Use this for initialization
        void Start() {
            gearboxUI.OnShifted += ChangeGear;
            time = Random.Range(3, 10);
            StartCoroutine("ChangeSpeed");
        }

        // Update is called once per frame
        void Update() {

        }

        private IEnumerator ChangeSpeed() {
            while (time > 0) {
                time--;
                yield return new WaitForSeconds(1);
            }
            currentSpeed = Random.Range(minSpeed, maxSpeed);
            scenery.ChangeSpeed(currentSpeed);
            garbageCar.ChangeSpeed(currentSpeed);
            time = Random.Range(3, 10);
            StartCoroutine("ChangeSpeed");
        }

        public void ChangeGear(int gear) {
            Debug.Log("Change gear to " + gear);
        }
    }
}
