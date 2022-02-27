// A program to test output values of sensors

const int redButtonPin = 5; 
const int grnButtonPin = 6;
const int yelButtonPin = 7;
const int bluButtonPin = 8;
const int motionPin = 9;

int redPushed = 0;
int grnPushed = 0;
int yelPushed = 0;
int bluPushed = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600); //9600 bits per second

  pinMode(redButtonPin, INPUT);
  pinMode(grnButtonPin, INPUT);
  pinMode(yelButtonPin, INPUT);
  pinMode(bluButtonPin, INPUT); 
  pinMode(motionPin, INPUT);


}

void loop() {
  // put your main code here, to run repeatedly:
  int sensorValues = 0;
  if(digitalRead(5) == HIGH){
    sensorValues += 1;
  }
  
  sensorValues = sensorValues << 1;
  if(digitalRead(6) == HIGH){
    sensorValues += 1;
  }

  sensorValues = sensorValues << 1;
  if(digitalRead(7) == HIGH){
    sensorValues += 1;
  }

  sensorValues = sensorValues << 1;
  if(digitalRead(8) == HIGH){
    sensorValues += 1;
  }

  sensorValues = sensorValues << 1;
  if(digitalRead(9) == HIGH){
    sensorValues += 1;
  }
  Serial.flush();
  Serial.write(sensorValues);
//  Serial.print(sensorValues);
  delay(20);
}
