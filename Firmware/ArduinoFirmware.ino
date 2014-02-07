

// **************************************************************************************
//  Name		:	_39693_Ctrl_Pkg.ino					*
//  Author		:	Jason Traud						*
//  Notice		:	Copyright (c) 2013 SuperDroid Robots			*
//			:	All Rights Reserved					*
//  Date		:	December 28, 2013           				*
//											*
//  Arduino		:	Arduino Mega 2560 R3 Development Board			*
//	Shield(s)	:	Ethernet Shield R3, SDR Mega expansion shield		*
//	Sensors  	:	2x Max Sonar Rangefinders                               *
//  Motor Controller	:	4x SDR PWM Motor Controllers    			*
//											*
//  Notes		: To be used with the standard WiFi ATR program			*
//											*
//			Settings:							*
//				- Motor							*
//					Forward Slow:	128 		Fast: 254	*
//					Reverse Slow:	126		Fast: 0	        *
//					Motor Off:		127			*
//					Reverse bit:	False	Mixing: False		*
//					Hard Turns Permissive: False			*
// **************************************************************************************

#include "Arduino.h"                 // Arduino library
#include <avr/io.h>                  // General definations of registers
#include <util/delay.h>              // Delay functions
#include "math.h"
#include <SPI.h>                     // SPI Library
#include <Ethernet.h>                // Ethernet library
#include <SoftwareServo.h>           // Software Servos library (currently in use)
#include <Servo.h>                   // Hardware Servos

// *********************
// Define hardware pins
// *********************

//#define creates constants rather than varibles.
#define dirFR A5       // Front Right Motor
#define pwmFR 3        // Pulse Width Modulation(speed)
#define dirFL A4       // Front Left Motor
#define pwmFL 5         // Pulse Width Modulation(speed)
#define dirRR A3       // Rear Right Motor
#define pwmRR 6        // Pulse Width Modulation(speed)
#define dirRL A2       // Rear Left Motor
#define pwmRL 9        // Pulse Width Modulation(speed)
#define rightSonar A8  // Sonars Analog pin 8 This Sensor wire has a line on it
#define leftSonar A9   // Sonars Analog pin 9 
//#define servoRightPin 2  // Sonars Analog pin 2 Hardware
//#define servoLeftPin 4    // Sonars Analog pin 4 Hardware
#define softwareServoRightPin 29 //Software Servos Pin Declaration 29
#define softwareServoLeftPin  27  //Software Servos Pin Declaration 29 This Servo Wire has a black Line on it
// Initialize LEDs

// *********************
// Networking Declarations
// *********************
byte mac[] = {0x90, 0xA2, 0xDA, 0x0D, 0xC2, 0x0F};  // Fixed MAC of ethernet shield
IPAddress ip		(192,168,10,240);           // IP Address used in WiFi ATR Program
IPAddress gateway	(192,168,10,101);             // Must match bridge settings
IPAddress subnet	(255,255,255,255);
EthernetServer server(5050);                        // Port number used in WiFi ATR Program

// *********************
// Networking Buffer
// *********************
unsigned char inputBuffer[3];         // Buffer to hold the incoming data flag
unsigned char head;                   // oldest written byte
unsigned char mid;                    // mid written byte
unsigned char tail;                   // newest written byte

// *********************
// Motor Constants 
// *********************
int motorValueMax = 255;  
int motorValueMin = 0;
int motorZeroHigh = 137;  
int motorZeroLow = 117;
int motorZero = 127;
int maxMotorPower;

// *********************
// Servos 
// *********************
//Servo servoRight;
//Servo servoLeft;
SoftwareServo servoRight; //Declaring the software Servos to be references later
SoftwareServo servoLeft;

// *********************
// Define Internal RAM
// *********************
byte Bad_Tx;
word No_Tx;
word chksum1;
byte mask;
word servoRightPosition = 1500;
word servoLeftPosition = 1500;
int wait;

// *********************
// Recieved RAM
// *********************
byte Motor_Val_FaB;
byte Motor_Val_LaR;
byte Motor_Val_Sp;
byte Digital_1;
byte chksum;


int inputFB = 0;
int inputLR = 0;
int inputSpin = 0;

// *********************
// Transmitted RAM
// *********************
word ControlPower;                     // Battery source 1 - Usually 12V
word MainPower;		               // Battery source 2 - Usually 24V
word Analog3;                          // Analog2

// *********************
// Motors 
// *********************
typedef struct { //Creats a struct which hold certain values
	int pulse;
	bool direction;
	bool brake;
}	MotorValues;

MotorValues motorFL;	
MotorValues motorFR;
MotorValues motorRL;	
MotorValues motorRR;
int Speed=100;     //Speed of the wheels NOTE: Speed of freely spinning wheels is not the same speed 
                   // as under a load. May need to adjust this number depending on flooring 
int i;            //Used in a loop to ramp up a speed instead of a sudden jump in speed
// *********************
// Sonar
// *********************
bool sonarSweepR;                  //Used to keep direction of sweep on sonarR 
bool sonarSweepL;                  //Used to keep direction of sweep on sonarL
word sonarR;                       //Reading from sonarR
word sonarL;                       //Reading from sonarL
int SweepTimer;// Counts up to allow time for the sonar to move

// These determine degrees that the servo is facing
int sideL=90;  // Side for both is 90
int sideR=90;  // The range of sweeping when sweeping in the backward direction

//This is used to sweep the servo while facing backwards
int backDiff=10;
int reverseL=0; //180 degrees on the servo because they are facing opposite directions L=180 is R=0
int reverseR=180;

//This is used both for positioning and sweeping the servos in the forward/backward direction
int frontL=180; //180 degrees on the servo because they are facing opposite directions L=180 is R=0 
int frontR=10; // This is set to 10 to allow sonars to sweep in the same direction without interference. Sweeps 10-0 rather than 0->10
int frontDiff=10;// The range of sweeping when sweeping in the front direction

// Left Sweep = 120->40   Right Sweep = 140->60   Right=140 is Left=40
int sweepForward=30; //Change this number to adjust how forward both sweep
int sweepBackward=50;//Change this number to adjust how backward both sweep
int sideHighLeft=sideL+sweepForward; //calculates the highest value Left sweeps to  
int sideHighRight=sideR+sweepBackward;//calculates the highest values Right sweeps to  
int sideDiff=sweepForward+sweepBackward;//This calcuates the max range of the sweeping


int distance=100; // This is used to determine how close the robot gets before changing directiio
                  // Must consider changing this if the sweeping distance is change
                  // Consider how this will be used when the robot is spining to avoid collisions
int changeMovementDistance=50;//This is used to determine when the change direction. 
                              //If one direction is more "open" then the traveling position by x, it will change
                              //see Slide_L,Slide_R and Reverse
// *********************
// States
// *********************

// This is the declaration of the state machine I used while proggraming this robot
bool autoflag; // This is used as a flag to tell the robot when to go into automation mode
int S_Forward=1;
int S_Backward=2;
int S_Looking=3;
int S_SlideL=4;
int S_SlideR=5;
int S_SpinR=6;
int S_SpinL=7;
int State; //This is what the current state is, and where you store the next state

int ini;//This varible is used to tell the robot it "just" entered a new state, allowing it for initilization
int Looked;// This varible is used in the Looking State. This insures it looks the full range before picking a direction
int lowestL;//This varible stores the "closest" object while sweeping left. If less than distance it will not go left
int lowestR;// This does the same thing as lowestL. If both are greater than distance, the larger number will be picked


// *********************
// Return Packet
// *********************
typedef struct
{
  unsigned char Pre1;
  unsigned char Pre2;
  unsigned char Pre3;
  unsigned char Pre4;
  unsigned char Digital;
  unsigned char Analog1;
  unsigned char Analog2;
  unsigned char Analog3;
} returnData;
returnData sendData;

//**********************************************************************************
// Sets up our serial com, hardware pins, SPI bus for ethernet shield
// Sets servos position and sweep direction and Sets up first state
// and initialize misc flags
// setup is always entered at start with arduino code. No need to call this function
// RETURNS: Nothing
//***********************************************************************************
void setup()
{	
  Serial.begin(9600);    // Initialize Serial
  Serial.flush();        // Clear
  while (!Serial) {}       // Flash L4 if we are waiting for a serial connection

  // Setup our output hardware pins for the motor controllers  
  pinMode(dirFL, OUTPUT);
  pinMode(dirFR, OUTPUT);
  pinMode(dirRL, OUTPUT);
  pinMode(dirRR, OUTPUT);
  pinMode(pwmFL, OUTPUT);
  pinMode(pwmFR, OUTPUT);
  pinMode(pwmRL, OUTPUT);
  pinMode(pwmRR, OUTPUT);
  pinMode(softwareServoRightPin, OUTPUT);
  pinMode(softwareServoLeftPin, OUTPUT);
 
  
  // Send a stop command to the motors for safety
  allStop();
  
  // Initialize our COM buffer
  head = 0;
  mid = 1; 
  tail = 2;
  inputBuffer[0] = 0; 
  inputBuffer[1] = 0; 
  inputBuffer[2] = 0;
	
  // Initialize server
  SPI.begin();
  Ethernet.begin(mac, ip);
  server.begin();

  // Initializes our Packet Flags
  sendData.Pre1 = 'S';  sendData.Pre2 = 'D';  sendData.Pre3 = 'R';  sendData.Pre4 = '1';
  
  
  // Initialize our servos
  //These varibles are used for sweeping later, must be updated here first.
  servoRightPosition = frontR;  //Sets Varible to front
  servoLeftPosition = frontL;  //Sets Varible to front
  //This uses the softwareServos
  servoLeft.attach(softwareServoLeftPin); //tells servoLeft what pin to watch
  servoRight.attach(softwareServoRightPin);//tells servoRight what pin to watch
  servoLeft.write(servoLeftPosition);      //Tells the servo to move to servoLeftPosition
  servoRight.write(servoRightPosition);    //Tells the servo to move to servoRightPosition
  WaitForSonars();                         //Waits for sonars to move to correct position before moving on
 
  
  // This was removed for software Servo changes
  //servoLeft.attach(2); 
  //servoLeft.write(frontL);//Sets sonar to forward
  //servoRight.attach(4);
  //servoRight.write(frontR);//Sets sonar to forward

  sonarSweepR=1; //Initializes direction of each servos
  sonarSweepL=1;
  SweepTimer=0;  // Sets to 0 to begin timer in first state
  State=S_Forward;//Sets first start to moving forward, can be changed to any state
  ini=1;          //Tells the next state will be the first time it enters that state. 
  //ini=1 should be set to 1 everytime a new state is declared.
  allStop();//Double checks that the motors are off to prevent robot from running off before main loop starts 
  autoflag=0;
}


//******************************************************************************
// Main program loop where we check for incomming packets and read them. 
// Also handles timeouts
// RETURNS: Nothing
//******************************************************************************
void loop()
{
sonarR = analogRead(A8); //Reads in the value from each Sonar each time this loop is ran
sonarL = analogRead(A9); //Reads in the value from each Sonar each time this loop is ran
//Serial.print("Left is");
//Serial.print((int)sonarL);
//Serial.print(" Right is");
//Serial.println((int)sonarR);
if(autoflag==1)
  {

    
    if(State==S_Forward)//Each state starts by making sure you are in this state
    {
      if(ini==1) // This is the initilization for this state
      {
      servoRightPosition = frontR;  //Sets Right Servo Varible to front
      servoLeftPosition = frontL;  //Sets Left Servo Varible to front
      servoLeft.write(frontL);//Sets servo to forward
      servoRight.write(frontR);//Sets servo to forward
      WaitForSonars();// waits for the position of the servos to finish
      ini=0; //Prevents entering ini every single loop
      SweepTimer=0;// initilizes the timer   
      DriveForward();//Tells the robot to move in the forward position till informed differently
      }
      else
      {
        if(SweepTimer==50)//Gives time for the sonar motor to move the sensor before updating position. Change the number to effect the frequency.
        {
          SweepTimer=0;//after entering this state sets it back to 0 to reach 50 again(without overflow)
          if(sonarR>distance && sonarL>distance)//If both Left and Right are "open" keep moving forward
          {
           SweepSonarFrontL();//Sweeps the Left  Sonar in the forward direction
           SweepSonarFrontR();//Sweeps the Right Sonar in the forward direction
          //Motor keeps moving forward because no other direction has been given
          }
          else//if either Sonar Left or Right saw something in front of the robot
          {
            State=S_Looking; // look which direction is open
            ini=1;           //Lets looking know its the first loop 
            allStop();       //Stops the motots to prevent crashing into anything
          }
        }
        SweepTimer=SweepTimer+1;//Increases SweepTimer by 1 to eventually get to 50
      }
    } 
      
    if(State==S_Looking)//Checks to see if we are in Looking State
      {
      if(ini==1)//initilization of this state
        {
        //Motor Stop 
        sonarSweepL=0;//sets the direction of the senors to sweep in the same way
        sonarSweepR=0;  
        servoRightPosition = sideR;  //Sets Varible to side
        servoLeftPosition = sideL;  //Sets Varible to side
        servoRight.write(servoRightPosition);//Sets servo to side
        servoLeft.write(servoLeftPosition);//Sets servo to side
        WaitForSonars();//waits for the sonar to reach the position
        SweepTimer=0;//starts the timer
        lowestR=1000;//Starts the varible extremely high to allow any sonar reading to replace it
        lowestL=1000;//This also resets the last reading from the last time we were in Looking
        ini=0;// prevents re-enter into this code 
        Looked=0;// Set to zero to tell this state that we have not fully looked at the side
        } 
      else
      {
          if(SweepTimer==50)//Gives time for the sonar motor to move the sensor before updating position. Change the number to effect the frequency.
          {   
           SweepTimer=0;    //sets the timer back to 0 to allow it to reach 50 again without overflowing    
           SweepSonarSideR(); //Sweeps the sonars on the side to check for which direction is safe
           SweepSonarSideL();
           if(servoLeftPosition==90)//When the Left servo reaches 90 increament this varible to check later
           {
             Looked=Looked+1;
           }
           if(Looked==2)// After the Left servo reaches 90 twice, you know it has looked both above 90 and below 90
           {
             if(lowestR<distance && lowestL<distance)//if both the closest left and closest right is less than distance then we cannot slide left or right
             {
               State=S_Backward;//Next state is going in reverse because you cannot go left or right
               ini=1;//sets to initilization for next state
               allStop();//I stop the motors on every state change(even tho this states motors are already off)
             }
             else if(lowestR>lowestL)// If the right is more open then the left it goes right
                { 
                 State=S_SlideR; //Next state=Slide Right
                 ini=1;//sets to initilzation for next state
                 allStop();//I stop the motors on every state change(even tho this states motors are already off)
                }
              else
              {
               State=S_SlideL;//If one(or more) is greater than the distance and Right is not larger, then left is the direction to go 
               ini=1;// Same thing as always
               allStop();
              }
           }
          }
          if(sonarL<lowestL)//checks to see if current position is "closer" then the last
            lowestL=sonarL;//if so store it
          if(sonarR<lowestR)
            lowestR=sonarR;
            
        SweepTimer=SweepTimer+1;//increases to get back to 50 sooner
          }
      }
      
      if(State==S_SlideL)//Checks to see if the state we are in is Sliding L
      {
        if(ini)//init varibles and position for this state
        {
        servoRightPosition = frontR;  //Sets Varible to front
        servoRight.write(servoRightPosition);//Sets servo to front
        servoLeftPosition = sideL;  //Sets Varible to side
        servoLeft.write(servoLeftPosition);//Sets servo to side
        WaitForSonars(); // waits for the sonar to position correctly
        SweepTimer=0;
        ini=0;
        SlideLeft(); // Sets the motors to slide left
        }
        else
        {

          if(SweepTimer==50)//Gives time for the sonar motor to move the sensor before updating position. Change the number to effect the frequency.
          {   
           SweepTimer=0;  //sets back to 0 to allow reaching of 50 again without overflow       
             if(sonarR>distance&&sonarL+changeMovementDistance<sonarR) // If while sliding forward there is room to move forward and there is more room to move forward than keep going sideways, go forward
               {
                 State=S_Forward;// change the direction to forward
                 ini=1;
                 allStop();
               }
               
            else if(sonarL<distance && sonarR<distance)// if neither moving left or moving forward are an option Spin
            {
               State=S_SpinL; //This spins the robot to allow more options of travel
               ini=1;
               allStop();
            }   
           else//If neither of the states above are true, it still has room to travel Left
            {   
             SweepSonarSideL(); //Keep sweeping and sliding
             SweepSonarFrontR(); //Checks direction and Sweeps motor
            //The motors have not been told to stop sliding left, it keeps sliding
            }

           }
           
        SweepTimer=SweepTimer+1;//gotta get back to 50 somehow
        }
      }
      
    if(State==S_SlideR)// checks to see if the state is sliding right This is very similar to Sliding lefty
      {
        if(ini)
        {
        servoRightPosition = sideR;  //Sets Varible to side
        servoRight.write(servoRightPosition);//Sets servo to side
        servoLeftPosition = frontL;  //Sets Varible to front
        servoLeft.write(servoLeftPosition);//Sets sonar to front
        WaitForSonars(); // wait for sonars to reach starting position
        SweepTimer=0; // starts to 0 to increment up to timer
        ini=0;// allows access to the rest of the state
        SlideRight();//Motors set to slidingRight
        }
        else
        {
          if(SweepTimer==50)//Gives time for the sonar motor to move the sensor before updating position. Change the number to effect the frequency.
          {   
           SweepTimer=0;//ensures proper timing rather than overflow
            if(sonarR<sonarL && sonarL+changeMovementDistance>distance) //If there is more room to move forward(by a margin) than moving Right more Move forward instead 
               {
                 State=S_Forward;//Next start is moving forward
                 ini=1;//sets up initilization for next time
                 allStop();//stop sliding right
               }
            else if(sonarR<distance && sonarL<distance) // if both forward and right are blocked spin around)
            {
               State=S_SpinR; //Next state is spin
               ini=1;
               allStop();
            }
           else//If everything else is not correct, you have room to keep sliding Right
            {   
           SweepSonarSideR();
           SweepSonarFrontL();
            }
   
           }
           
        SweepTimer=SweepTimer+1;//chug-a-chug-a chooo-choo
        }
      }
      
     if(State==S_SpinL)// checks to see if the state is spining left
      {
        if(ini)
        {
        servoRightPosition = frontR;  //Sets Varible to front
        servoRight.write(servoRightPosition);//Sets sonar to fron
        servoLeftPosition = sideL;  //Sets Varible to side
        servoLeft.write(servoLeftPosition);//Sets sonar to side
        WaitForSonars();// wait for sonars to reach proper position
        SweepTimer=0;
        ini=0;
        SpinClockwise();// starts morots to moving clockwise
        //spin

        }
        else
        {

          if(SweepTimer==50)//Gives time for the sonar motor to move the sensor before updating position. Change the number to effect the frequency.
          {   
           SweepTimer=0; //overflow is bad for timing mmmmmkay?
           if(sonarL<distance && sonarR<distance)// if you still cant move in either direction, just keep spinning just keep spinning
            {   
           SweepSonarFrontR();// Keep sweeping too!
           SweepSonarSideL();
             //Keep Spinning
            }
            else if(sonarR>sonarL)// if forward is open
            {
               State=S_Forward; // move forward
               ini=1;
               allStop();
            }
           else
               {
                 State=S_SlideL; // if sliding left is availbe
                 ini=1; // slide left!
                 allStop();
               }
           }
           
        SweepTimer=SweepTimer+1;//I think I can I think I can
        }
      }
 
      if(State==S_SpinR)
      {
        if(ini)
        {
        servoLeftPosition = frontL;  //Sets Varible to front
        servoLeft.write(servoLeftPosition);//Sets servo to front
        servoRightPosition = sideR;  //Sets Varible to side
        servoRight.write(servoRightPosition);//Sets servo to side
        WaitForSonars(); // wait for servos to get to the correct position
        SweepTimer=0;
        ini=0;
        //spin
        SpinCounterClockwise();//Motors spinning robot in counterclockwise position

        }
        else
        {

          if(SweepTimer==50)//Gives time for the sonar motor to move the sensor before updating position. Change the number to effect the frequency.
          {   
           SweepTimer=0; 
           if(sonarR<distance&&sonarL<distance)// if neither direction is open keep spinning
            {   
             SweepSonarFrontL();
             SweepSonarSideR(); //sweeps each servo in the correct range
             //Keep Spinning
            }
            else if(sonarR<sonarL)//if forward is availbe change state to forward
            {
               State=S_Forward;
               ini=1;
               allStop();
            }
           else//if sliding left is open change state to sliding forward
               {
                 State=S_SlideL;
                 ini=1;
                 allStop();
               }
           }
           
        SweepTimer=SweepTimer+1;
        }
      }
      
    if(State==S_Backward)//checks for moving backward, This is our last case situation
    {
      if(ini==1)
      {
        ini=0;
        servoLeftPosition = reverseL;  //Sets Varible to reverse
        servoLeft.write(servoLeftPosition);//Sets servo to reverse
        servoRightPosition = sideR;  //Sets Varible to side
        servoRight.write(servoRightPosition);//Sets servo to side
        WaitForSonars(); // waits for position to reach. Backward is potentiall the longest wait as it may need to spin from forward to back
        SweepTimer=0;
        DriveBackward();// put the motors in reverse
       }
       else
       {
         if(SweepTimer==50)//Gives time for the sonar motor to move the sensor before updating position. Change the number to effect the frequency.
          {  
           SweepTimer=0; 

          if(sonarL<distance+25)// Checks to see if there is anything behind the robot, the extra 25 is the account for the length of the robot
          {
            State=S_Looking;// If there is something behind it go to looking left and right for next direction
            ini=1;
            allStop();
          }
          
          else if(sonarR>changeMovementDistance+sonarL &&sonarR>distance)// if there is nothing behind it but Moving Right has more open space
          {
            State=S_SlideR;//move right
            ini=1;
            allStop();
          } 
          else// if not keep going backward
            {   
           SweepSonarSideR();
           SweepSonarBackL();
            }
       
       }
        SweepTimer=SweepTimer+1;
      }
    }
 SoftwareServo::refresh(); // This is used to tell the software servos to move every single cycle. It will timeout if it does not get frequent updates.  
}

    
 

  // Looks for input data from a client
  EthernetClient client = server.available();
  
  if (client == true)  // Client returns true when a client is connected
  {
    // Updates buffer
    processBuffer(client);
    
    // Test for our start SDR Flag:	S = 0x53, D = 0x44, R = 0x52
    if ((inputBuffer[head] == 0x53) && (inputBuffer[mid] == 0x44) && (inputBuffer[tail] == 0x52))
    {	
      // When we are here, we've seen our start flag so the next 6 bytes will be out packet. 
      // So we read them in.						
      Motor_Val_FaB      = client.read();
     // Serial.print(Motor_Val_FaB);
      Motor_Val_LaR      = client.read();
    //  Serial.print(Motor_Val_LaR);
      Motor_Val_Sp       = client.read();
     // Serial.print(Motor_Val_Sp);
      Digital_1          = client.read();
      //Serial.print(Digital_1);
      chksum             = client.read();
      //Serial.print(chksum);
 
     if(Digital_1>0x00)
       {
         autoflag=1;
       }
     else
       {
         autoflag=0;
         ini=1;
         State=S_Forward;
        servoRightPosition = frontR;  //Sets Right Servo Varible to front
        servoLeftPosition = frontL;  //Sets Left Servo Varible to front
       
      
        // Since we've read in our packet, we need to reintialize the buffer so we do not immediately 
        // return here. 
        inputBuffer[0] = 0; inputBuffer[1] = 0; inputBuffer[2] = 0;
        
        }
        // Once we've recieved our packet and verified our checksum, we can process the information
        if(processCheckSum())
        {
          processMotors(); // Sends motor commands
          processIO();  
          returnPacket();  // Replies back to the program
        }
        else
        {
          allStop();
        }
            
    }
     
  }
  else
  {
    //Serial.println("Client=False");
  }

  

}

//******************************************************************************
// Reads in serial data to our buffer and updates our pointers
// RETURNS: Nothing
//******************************************************************************
// Retrieves byte and saves it into the buffer
void processBuffer (EthernetClient client)
{
  // Increment flag pointers
  tail = tail + 1; mid = mid + 1; head = head + 1;
  
  // Loop pointers if they exceed the buffer length
  if (tail > 2) tail = 0;
  if (mid > 2) mid = 0;
  if (head > 2) head = 0;
  
  // write the read information to the new tail
//  Serial.println("Head= ");
//  Serial.print(head);
//   Serial.print(" mid ");
//  Serial.print(mid);
//   Serial.print(" tail= ");
//  Serial.print(tail);
  inputBuffer[tail] = client.read();
}

//******************************************************************************
// Sums our incoming packet and compares it with the expected value
// RETURNS: whether our checksum passed or not
//******************************************************************************
bool processCheckSum()
{
  chksum1 = byte(Motor_Val_FaB    + Motor_Val_LaR   +  Motor_Val_Sp  + Digital_1);
  
  // Checksum fail condition
  if (chksum1 != chksum)
  {
    Bad_Tx = Bad_Tx + 1;
    if(Bad_Tx > 3)
    { Bad_Tx = Bad_Tx -1; }
    return false;
  }
  
  // Checksum pass condition
  else
  { 
     No_Tx = 0;	
     Bad_Tx = 0; 
     return true; 
  }
}

//******************************************************************************
// Sums our incoming packet and compares it with the expected value
// RETURNS: whether our checksum passed or not
//******************************************************************************
void processMotors()
{
  bool halfSpeed;
  int motorPower;
  double tempScale;

  // Initialize our motor power values
  motorFL.pulse = 0;
  motorFR.pulse = 0;
  motorRL.pulse = 0;
  motorRR.pulse = 0;


  // *************************
  // Front and Back Motion
  // *************************
  
  // Extracts motor power 
  motorPower = shiftAndBoundInput((int)Motor_Val_FaB);
  
  // Applys to pulse values
  motorFL.pulse = motorFL.pulse - motorPower;
  motorRL.pulse = motorRL.pulse - motorPower;
  motorFR.pulse = motorFR.pulse + motorPower;
  motorRR.pulse = motorRR.pulse + motorPower;
  
  // *************************
  // Left and Right Motion
  // *************************
  
  // Extracts motor power 
  motorPower = shiftAndBoundInput ((int)Motor_Val_LaR);
  
  // Applys to pulse values
  motorFL.pulse = motorFL.pulse - motorPower;
  motorRL.pulse = motorRL.pulse + motorPower;
  motorFR.pulse = motorFR.pulse - motorPower;
  motorRR.pulse = motorRR.pulse + motorPower;
  
  // *************************
  // Spin
  // *************************
  
  // Extracts motor power 
  motorPower = shiftAndBoundInput ((int)Motor_Val_Sp);
  
  // Applys to pulse values
  motorFL.pulse = motorFL.pulse + motorPower;
  motorRL.pulse = motorRL.pulse + motorPower;
  motorFR.pulse = motorFR.pulse + motorPower;
  motorRR.pulse = motorRR.pulse + motorPower;
  
  
  // Determine and apply direction bits and then convert to positive
  if ( motorFR.pulse < 0)  { digitalWrite(dirFR,LOW);  }
  else                     { digitalWrite(dirFR,HIGH); }
  if ( motorFL.pulse < 0)  { digitalWrite(dirFL,LOW);  }
  else                     { digitalWrite(dirFL,HIGH); }
  if ( motorRR.pulse < 0)  { digitalWrite(dirRR,LOW);  }
  else                     { digitalWrite(dirRR,HIGH); }
  if ( motorRL.pulse < 0)  { digitalWrite(dirRL,LOW);  }
  else                     { digitalWrite(dirRL,HIGH); }
      
  motorFR.pulse = abs(motorFR.pulse);
  motorFL.pulse = abs(motorFL.pulse);
  motorRR.pulse = abs(motorRR.pulse);
  motorRL.pulse = abs(motorRL.pulse);
  
  maxMotorPower = max(motorFR.pulse, motorFL.pulse);
  maxMotorPower = max(maxMotorPower, motorRL.pulse);
  maxMotorPower = max(maxMotorPower, motorRR.pulse);
  
  if (maxMotorPower > 253)
  {
    tempScale = (double)253 / (double)maxMotorPower;
    motorFL.pulse = tempScale * (double)motorFL.pulse;
    motorFR.pulse = tempScale * (double)motorFR.pulse;
    motorRL.pulse = tempScale * (double)motorRL.pulse;
    motorRR.pulse = tempScale * (double)motorRR.pulse;
  }

  //Sends data to motors
  analogWrite(pwmFR, motorFR.pulse);
  analogWrite(pwmRR, motorRR.pulse);
  analogWrite(pwmFL, motorFL.pulse);
  analogWrite(pwmRL, motorRL.pulse);  
}


//******************************************************************************
// Processes the inputs, outputs and servo commands
// RETURNS: None
//******************************************************************************
void processIO()
{
//  // Outputs 
//  mask = B00000001;			// Digital_1.0
//  if(Digital_1 & mask)
//    digitalWrite(output1, HIGH);
//  else
//    digitalWrite(output1, LOW);
//  
//  mask = B00000010;			// Digital_1.1
//  if(Digital_1 & mask)
//    digitalWrite(output2, HIGH);
//  else
//    digitalWrite(output2, LOW);
//  
//  mask = B00000100;			// Digital_1.2
//  if(Digital_1 & mask)
//    digitalWrite(output3, HIGH);
//  else
//    digitalWrite(output3, LOW);
//  
//  mask = B00001000;			// Digital_1.3
//  if(Digital_1 & mask)
//    digitalWrite(output4, HIGH);
//  else
//    digitalWrite(output4, LOW);
//  
//  // Set up Tx Package
//  Digital_3 = 0x0;
//  if(digitalRead(Input1))	{	Digital_3 = Digital_3 + 1;	}
//  if(digitalRead(Input2))	{	Digital_3 = Digital_3 + 2;	}
//  if(digitalRead(Input3))	{	Digital_3 = Digital_3 + 4;	}
//  if(digitalRead(Input4))	{	Digital_3 = Digital_3 + 8;	}
//
//  Analog3 = analogRead(A2);


}
//******************************************************************************
// Assembles and transmitts the return packet
// RETURNS: None
//******************************************************************************
void returnPacket()
{
  unsigned char * message;
  
//  sendData.Digital = (unsigned char)motorFL.direction;
//  sendData.Analog1 = (unsigned char)motorFR.direction;
//  sendData.Analog2 = (unsigned char)motorRL.direction;
//  sendData.Analog3 = (unsigned char)motorRR.direction;

  sendData.Digital = 0x00;
  sendData.Analog1 = (unsigned char)sonarR;
  sendData.Analog2 = (unsigned char)sonarL;
  sendData.Analog3 = (unsigned char)Analog3;
  Serial.println("------------");
  Serial.println(sendData.Pre1);
  Serial.println(sendData.Pre2);
  Serial.println(sendData.Pre3);
  Serial.println(sendData.Pre4);
  Serial.println(0x00);
  Serial.println(sendData.Analog1);
  Serial.println(sendData.Analog2);
  Serial.println(sendData.Analog3);
  message = (unsigned char *) &sendData;
  server.write(message, sizeof(returnData));
}


//******************************************************************************
// Processes the input command to a safe margin and shifts it to stradle 0
// RETURNS: None
//******************************************************************************
int shiftAndBoundInput (int inputPower)
{
  int shiftedAndBountInput = 0;
  
  shiftedAndBountInput = inputPower;
  if ((shiftedAndBountInput < 129) && (shiftedAndBountInput > 125)) { shiftedAndBountInput = 127; }
  if (shiftedAndBountInput > 254)                                   { shiftedAndBountInput = 254; }
  if (shiftedAndBountInput < 1)                                     { shiftedAndBountInput = 0; }
  shiftedAndBountInput = shiftedAndBountInput - 127;
  
  return shiftedAndBountInput;
}

//******************************************************************************
//Sets the servo to face the sonar sensor sweeping front rangeoh

// RETURNS: None
//******************************************************************************
void SweepSonarFrontL()
{
  
  SweepSonarLeft(frontL,frontL-frontDiff);
}
//******************************************************************************
//Sets the Right servo to face the sonar sensor sweeping the front range
// RETURNS: None
//******************************************************************************
void SweepSonarFrontR()
{
  SweepSonarRight(frontR,frontR-frontDiff); 
}
//******************************************************************************
//Sets the left servo to face the sonar sensor sweeping the side range
// RETURNS: None
//******************************************************************************
void SweepSonarSideL()
{
  SweepSonarLeft(sideHighLeft,sideHighLeft-sideDiff); 
}
//******************************************************************************
//Sets the Left servo to face the sonar sensor sweeping the back range
// RETURNS: None
//******************************************************************************
void SweepSonarBackL()
{
  SweepSonarLeft(backDiff,reverseL); 
}
//******************************************************************************
//Sets the Right servo to face the sonar sensor sweeping the side range
// RETURNS: None
//******************************************************************************
void SweepSonarSideR()
{
  SweepSonarRight(sideHighRight,sideHighRight-sideDiff);
}
//******************************************************************************
// This function waits for 3000 cycles while writting the position to the pin and refreshing
// RETURNS: None
//******************************************************************************
void WaitForSonars()
{
 wait=0;//Resets to 0 from the last time you waited
 while(wait<3000)
  {
   servoRight.write(servoRightPosition);//rewrites the previous servo comand
   servoLeft.write(servoLeftPosition);//rewrites the previous servo command
   SoftwareServo::refresh(); //refreshes the software servos so they do not time out
   wait=wait+1;// increse wait so you will break out of the loop eventually...
   } 
}
//******************************************************************************
//Sweeps the Right servo moving the sonar sensor 
// RETURNS: None
//******************************************************************************
void SweepSonarRight(int high,int low)//Main difference between SweepSonarRight and SweepSonarLeft is direction of sweepinmg

{  

  if(servoRightPosition >= high) //Checks to make sure the Sonar has not reach a max range and if so change sweep direction
   sonarSweepR=0;
  if(servoRightPosition <= low)
    sonarSweepR=1;
  
  
  if(sonarSweepR==1)     //Sweeps in the direction by 1 degree.
    servoRightPosition = servoRightPosition + 1; // Change number to adjust speed at which sonars move
  else
    servoRightPosition = servoRightPosition - 1;
  servoRight.write(servoRightPosition);// Writes value to the pin
} 
//******************************************************************************
//Sweeps the left servo moving the sonar sensor 
// RETURNS: None
//******************************************************************************
void SweepSonarLeft(int high,int low)
{ 

  if(servoLeftPosition >= high)  //Checks to make sure the Sonar has not reach a max range and if so change sweep direction
    sonarSweepL=1;
  if(servoLeftPosition <= low)
    sonarSweepL=0;
    
  if(sonarSweepL==1)      //Sweeps in the direction by 1 degree.
    servoLeftPosition = servoLeftPosition - 1;
  else
    servoLeftPosition = servoLeftPosition + 1;
   
  servoLeft.write(servoLeftPosition); // Writes value to the pin
}

//******************************************************************************
//Drives forward
// RETURNS: None
//******************************************************************************

void DriveForward()//Drives forward
{
  digitalWrite(dirFR, HIGH); digitalWrite(dirFL, LOW); digitalWrite(dirRR, HIGH); digitalWrite(dirRL, LOW); //Sets the direction of the pins
                                                                                                            // The Left and Right Wheels are reversed 
                                                                                                            //as they are facing opposite direction
  drive();//Sends the command to spin the wheels a predetermined speed
}

//******************************************************************************
//One of the main moves in the cha cha slide, Robot slides left
// RETURNS: None
//******************************************************************************
void SlideLeft()//One of the main moves in the cha cha slide, Robot slides left
{
  digitalWrite(dirFR, HIGH); digitalWrite(dirFL, HIGH); digitalWrite(dirRR, LOW); digitalWrite(dirRL, LOW);//Left wheels spin toward eachother
                                                                                                           //Right wheels spin away from eachother
  drive();
}
//******************************************************************************
//Another extremely popular move in the cha cha slide, generally follows slide left
// RETURNS: None
//******************************************************************************
void SlideRight()
{
  digitalWrite(dirFR, LOW); digitalWrite(dirFL, LOW); digitalWrite(dirRR, HIGH); digitalWrite(dirRL, HIGH);//Right wheels spin away from eachother
  drive();                                                                                                 //Left wheels spin toward eachother
}

//void TwoHopsThisTime()
//{
//  To be implemented
//}
//******************************************************************************
//Drives backward
// RETURNS: None
//******************************************************************************
 void DriveBackward()//Drives backward
{
  digitalWrite(dirFR, LOW); digitalWrite(dirFL, HIGH); digitalWrite(dirRR, LOW); digitalWrite(dirRL, HIGH);//All pins set to reverse direction
  drive();
}
//******************************************************************************
//spins in the counterclockwise direction 
// RETURNS: None
//******************************************************************************
void SpinCounterClockwise()//spins in the counterclockwise direction 
{
  digitalWrite(dirFR, HIGH); digitalWrite(dirFL, HIGH); digitalWrite(dirRR, HIGH); digitalWrite(dirRL, HIGH);//sets Right to forward and left to backward
  drive();
}
//******************************************************************************
//Spins Clockwise
// RETURNS: None
//******************************************************************************
void SpinClockwise()//Spins Clockwise
{
  digitalWrite(dirFR, LOW); digitalWrite(dirFL, LOW); digitalWrite(dirRR, LOW); digitalWrite(dirRL, LOW);//Reverses the direction of counterclockwise
  drive();
}
//******************************************************************************
// Ramps Speed starting at 80% to 100% Cleaner start then just jumping to full speed
// RETURNS: None
//******************************************************************************
void drive()
{
   for (i = Speed*4/5; i < Speed; i++)
   
  { 
  motorFR.pulse = i; motorFL.pulse = i; motorRR.pulse = i; motorRL.pulse = i; commandMotors(); 
  delay(25); 
  } 
}
//******************************************************************************
// Sets motors to neutral when called
// RETURNS: None
//******************************************************************************
void allStop()// This sets all motors to 0 to stop their movement
{  
  motorFR.pulse = 0;
  motorFL.pulse = 0;
  motorRR.pulse = 0;
  motorRL.pulse = 0;
  
  analogWrite(pwmFR, motorFR.pulse);
  analogWrite(pwmFL, motorFL.pulse);
  analogWrite(pwmRR, motorRR.pulse);
  analogWrite(pwmRL, motorRL.pulse);
}


//******************************************************************************
// Sends commands to the motors
// RETURNS: None
//******************************************************************************
void commandMotors() { // This sends the speed and direction to the motors
  analogWrite(pwmFR, motorFR.pulse);
  analogWrite(pwmRR, motorRR.pulse);
  analogWrite(pwmFL, motorFL.pulse);
  analogWrite(pwmRL, motorRL.pulse);
}


