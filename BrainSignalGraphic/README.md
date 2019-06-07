
## Brain Wave Graphics and Dynamical Changes
![alt text](https://i.ibb.co/80mJyGB/Screenshot-83.png)

### 01 / Bluetooth Connection
In this application data being received via Bluetooth from COM port being read as RAW data. Users can either choose AUTO or specific Bluetooth connection.

### 02 / 1D Kalman Filtering
As it's similiar for all sensor processing applications , data recevied may have some hitches and broken data during transmission.To handle this situtation I have used a simple 1 Dimensional Kalman filtering

### 03 / Live and Responsive UI
With UI I had to make sure it was responsive and fast enough to show dynamic changes made available from connection port. I have used C# dynamic graphical libraries to make it happen fast and fluid.
