/**
 * This project turns the ESP32 into a Bluetooth LE keyboard that presses the Copilot key.
 */
#include <Arduino.h>
#include <BleKeyboard.h>

BleKeyboard bleKeyboard;
#define BUTTON_PIN 8

void setup() {
  Serial.begin(115200);
  Serial.println("Starting BLE work!");
  bleKeyboard.begin();
}

void loop() {
  if(digitalRead(BUTTON_PIN) == LOW) {
    bleKeyboard.press(KEY_LEFT_SHIFT);
    bleKeyboard.press(KEY_LEFT_GUI);
    bleKeyboard.press(KEY_F23);
    delay(100);
    bleKeyboard.releaseAll();
  }
  delay(100);
}