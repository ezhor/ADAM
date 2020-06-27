import serial, time

class SerialManager():
    def __init__(self):        
        self.arduino = serial.Serial("COM7", 9600)
        time.sleep(1)

    def sendLine(self, line):
        self.arduino.write((line + "\n").encode())

    def sendData(self, data):
        self.arduino.write((data).encode())

    def sendAnimation(self, animation, delay):
        for data in animation:
            self.sendData(data)
            time.sleep(delay)