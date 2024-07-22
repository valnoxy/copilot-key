# Copilot Key
This repository contains code for pressing the Copilot key (Left-Shift + Windows + F23).

## esp32-copilot-key
ESP32 firmware - Bluetooth LE Copilot Key

## software-copilot-key
C# project - Simulates pressing the Copilot Key

## Parsed Argument
When pressing the Copilot key, the following application is executed:

```C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe --single-argument microsoft-edge:///?ux=copilot&tcp=1&source=hotkey```