# Brain Computer Interface
![alt text](https://i.ibb.co/DwqrHQx/brain-computer-interface.png)

Brain Computer Interface and 5 applications to demonstrate how useful EEG devices will be in future. 

## Brain Wave Graphics and Dynamical Changes
![alt text](https://i.ibb.co/80mJyGB/Screenshot-83.png)

### 01 / Bluetooth Connection
In this application data being received via Bluetooth from COM port being read as RAW data. Users can either choose AUTO or specific Bluetooth connection.

### 02 / 1D Kalman Filtering
As it's similiar for all sensor processing applications , data recevied may have some hitches and broken data during transmission.To handle this situtation I have used a simple 1 Dimensional Kalman filtering

### 03 / Live and Responsive UI
With UI I had to make sure it was responsive and fast enough to show dynamic changes made available from connection port. I have used C# dynamic graphical libraries to make it happen fast and fluid.

## Brain Keyboard
![alt text](https://i.ibb.co/rFhcy7d/slaytagidecek1-1203.png)

### 01 / Purpose

This application developed ALS patients in mind.Inspired by Stephen Hawking's writing machine . I have developed a similar but very cheap alternative with Python and headset.This way users can write the letter on screen by focusing on the letter.

### 02 / How does it works ?

In the screen letters are sliding to next each other with 250ms second delay. If user focuses on letter it want to write it can simply cross threshold value.
User either can choose attention,meditation or eye blinking strength to choose which is most preferable to use. 
By my tests I have found 65 appropriate value for threshold.

### 03 / Output

Using Python's library user can see focused letters on screen real time.
This way people can forward this writing to emails,websites and limitless other options.


## Mind Driver 3D
![alt text](https://i.ibb.co/HHvw02x/Screenshot-88.png)

### 01 / What is it ?

To witness future potential of EEG devices i have developed a car simulation/game that shows 
EEG devices can be used in health and entertainment together.
I have created 3D virtual space using UNITY 3D game / physics engine.
And i have created a car that would control with brain signals
Car's suspension and control code developed with C# , model itself is free to get from asset store

### 02 / Input System
Input system of this vehicle is very simple. Car is moving on 20 m/s automatically in beginning to NORTH (0,0,0) direction.
if user pass attention threshold it will become faster periodically.
If user want to slower the car it needs to pass meditation threshold periodically

### 03 / Move Around

To move user need to pass eye blinking strength threshold so car can move fixed direction.
Starting from NORTH EAST SOUTH WEST and NORTH again.
This way I have emulated very complex situation with a lot of inputs being  used and with only 3 inputs available.



## Smart Bird and Brain Tennis
![alt text](https://i.ibb.co/NZBw5yQ/test-0.png)
![alt text](https://i.ibb.co/y4B4cxS/kusresmi.png)


### 01 / Smart Bird
In Smart Bird application inspired by Flappy bird on mobile devices
user simply chooses which mode and trying to pass threshold of that mode. This way bird can jump around pipes.
Even though this is indeed hard application with traditional input systems it is very flexible to do it in EEG.

### 02 / Brain Tennis
In Brain Tennis  the player  compete against CPU component i wrote . CPU simply focuses on length between ball and itself to figure out input.Player is moving automatically and withing threshold passed it moves to opposite direction.
 With intense testing user can have enjoyable game using EEG.
### 03 / Conclusion
 I have tried to show how EEG devices can be useful collaborating with other tech. It is very hopeful future for EEG devices and tech
