using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Banana.Controllers;
using Banana.UI;

namespace Banana {
    public class GameDirector : MonoBehaviour {

        public SceneryMaster scenery;
        public Car garbageCar;
        public SpeedyCar ourCar;
        public Gearbox gearboxUI;

        public float maxSpeed = 100f;
        public float minSpeed = 60f;

        public float score = 0f;
        private bool isGameOver = true;

        private int time;

        private float currentSpeed;
        private float closestDistance;
        private float mostDistance;

        private Vector3 ourCarInitialPosition;
        private Vector3 garbageCarInitialPosition;

        // Use this for initialization
        void Start() {
            ourCarInitialPosition = ourCar.transform.position;
            garbageCarInitialPosition = garbageCar.transform.position;
            float gcWidth = garbageCar.GetComponent<SpriteRenderer>().bounds.size.x;
            float ocWidth = ourCar.GetComponent<SpriteRenderer>().bounds.size.x;
            closestDistance = (gcWidth + ocWidth) / 2f;
            mostDistance = closestDistance * 2f;
            gearboxUI.OnShifted += ChangeGear;
            gearboxUI.OnStart += StartGame;
            ourCar.OnCollided += GameOver;
        }

        // Update is called once per frame
        void Update() {
            if (!isGameOver) {

            }
        }

        public void StartGame() {
            score = 0f;
            ourCar.transform.position = ourCarInitialPosition;
            garbageCar.transform.position = garbageCarInitialPosition;
            currentSpeed = Random.Range(minSpeed, maxSpeed);
            scenery.ChangeSpeed(currentSpeed);
            garbageCar.ChangeSpeed(currentSpeed);
            time = Random.Range(3, 10);
            isGameOver = false;
            StartCoroutine("ChangeSpeed");
            StartCoroutine("CheckProgress");
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
            ourCar.currentGear = gear;
        }

        public void GameOver() {
            isGameOver = true;
            ourCar.currentGear = 0;
            StopCoroutine("ChangeSpeed");
            StopCoroutine("CheckProgress");
            gearboxUI.ShowGameOverPanel();
        }

        private IEnumerator CheckProgress() {
            while (!isGameOver) {
                float scoreModifier = 1f;
                float distance = Vector3.Distance(garbageCar.transform.position, ourCar.transform.position);
                scoreModifier = (distance < mostDistance ? 1f + closestDistance / distance : 0f);
                score += 1 * scoreModifier;
                gearboxUI.SetScore(score);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
