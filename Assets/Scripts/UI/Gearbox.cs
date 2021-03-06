﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Banana.UI {
    public class Gearbox : MonoBehaviour {

        private int currentGear = 0;

        public delegate void GearAction(int gear);
        public event GearAction OnShifted;

        public delegate void StartAction();
        public event StartAction OnStart;

        public Image cgImage;
        public Text scoreText;
        public GameObject startPanel;
        public GameObject gameOverPanel;

        public List<Slot> slots;
        public int activeSlot = 0;

        // Use this for initialization
        void Start() {
            SetScore(0);
            slots[activeSlot].IsActive = true;
        }

        // Update is called once per frame
        void Update() {

        }

        public void OnGearPressed(int gear) {
            if (gear == currentGear) {
                OnSlotPressed(1);
            }
            else {
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
                slots[activeSlot].hasGear = true;
            }
        }

        public void OnSlotPressed(int slot) {
            if (OnShifted != null) OnShifted(0);
            currentGear = 0;
            cgImage.enabled = false;
            slots[activeSlot].hasGear = false;
        }

        public void SetScore(float score) {
            scoreText.text = Mathf.RoundToInt(score).ToString();
        }

        public void OnStartPressed() {
            if (OnShifted != null) OnStart();
            startPanel.SetActive(false);
            gameOverPanel.SetActive(false);
        }

        public void ShowGameOverPanel() {
            gameOverPanel.SetActive(true);
            currentGear = 0;
            cgImage.enabled = false;
            slots[activeSlot].hasGear = false;
        }
    }
}
