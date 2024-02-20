#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>

#define OLED_RESET 7
Adafruit_SSD1306 display(OLED_RESET);

void setup() {
  delay(180000); 
  Serial.begin(9600);
  display.begin(SSD1306_SWITCHCAPVCC, 0x3C);
  display.clearDisplay();
  display.setTextColor(WHITE);
  display.setCursor(0, 0);
  display.display();
}

void loop() {
  while (Serial.available() > 0) {
    display.clearDisplay();
    String input = Serial.readString();

    int openBraceIndex = input.indexOf('{');
    int closeBraceIndex = input.indexOf('}');

    if (openBraceIndex != -1 && closeBraceIndex != -1) {
      String message = input.substring(openBraceIndex + 1, closeBraceIndex);
      int lIndex = message.indexOf('L');
      int sIndex = message.indexOf('S');
      
      if (lIndex != -1) {
        display.setTextSize(2);
      } else if (sIndex != -1) {
        display.setTextSize(1);
      }
    
      display.setCursor(0, 0);
      display.println(message);
      display.display();
    }
  }
}