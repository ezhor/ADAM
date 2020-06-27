#include <Servo.h>

Servo onboardFL, shoulderFL, elbowFL;
Servo onboardFR, shoulderFR, elbowFR;

Servo onboardBL, shoulderBL, elbowBL;
Servo onboardBR, shoulderBR, elbowBR;

void setup(){
  Serial.begin(9600);
  attachServos();
}

void loop(){
  String data;
  if (Serial.available()) {
    data = Serial.readStringUntil('\n');
    
    onboardFL.write(data.substring(0,3).toInt());
    shoulderFL.write(data.substring(3,6).toInt());
    elbowFL.write(data.substring(6,9).toInt());

    onboardFR.write(data.substring(9,12).toInt());
    shoulderFR.write(data.substring(12,15).toInt());
    elbowFR.write(data.substring(15,18).toInt());
  
    onboardBL.write(data.substring(18,21).toInt());
    shoulderBL.write(data.substring(21,24).toInt());
    elbowBL.write(data.substring(24,27).toInt());
    
    onboardBR.write(data.substring(27,30).toInt());
    shoulderBR.write(data.substring(30,33).toInt());
    elbowBR.write(data.substring(33,36).toInt());
  }
}

void attachServos(){
  onboardFL.attach(2);
  shoulderFL.attach(3);
  elbowFL.attach(4);

  onboardFR.attach(5);
  shoulderFR.attach(6);
  elbowFR.attach(7);

  onboardBL.attach(8);
  shoulderBL.attach(9);
  elbowBL.attach(10);

  onboardBR.attach(11);
  shoulderBR.attach(12);
  elbowBR.attach(13);
}
