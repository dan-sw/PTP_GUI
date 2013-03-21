using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    class Terminal
    {

        public SerialPort Serial = new SerialPort();

        //Terminal Parameters
        public int BaudRate { get; private set; }
        public int DataBits { get; private set; }
        public Parity Parity { get; private set; }
        public Handshake Handshake { get; private set; }
        public StopBits StopBits { get; private set; }
        public int ReadTimeout { get; private set; }
        public int WriteTimeout { get; private set; }

        public string SerialReceived = "";
        public string SerialTransmit = "";
        public string Connect_Disconnect = "";
        public string[] ports = SerialPort.GetPortNames();

        private void SerialParameters()
        {
            //Defuallt EVB connectivity parameters 
            BaudRate = 115200;
            DataBits = 8;
            ReadTimeout = 200;
            WriteTimeout = 200;
            Handshake = System.IO.Ports.Handshake.None;
            Parity = System.IO.Ports.Parity.None;
            StopBits = System.IO.Ports.StopBits.One;

        }

        private void ConfigureSerial()
        {
            SerialParameters();
            Serial.BaudRate = BaudRate;
            Serial.DataBits = DataBits;
            Serial.Handshake = Handshake;
            Serial.Parity = Parity;
            Serial.StopBits = StopBits;
            Serial.ReadTimeout = ReadTimeout;
            Serial.WriteTimeout = WriteTimeout;
            Serial.Handshake = System.IO.Ports.Handshake.None;


        }

        public void Serial_Connect_Disconnect()
        {


            //uses the same button to connect and disconnect 
            try
            {
                if (Serial.IsOpen)
                {
                    Serial.Close();
                    Connect_Disconnect = "DisConnected";
                }
                else
                {
                    ConfigureSerial();
                    Serial.Open();
                    Connect_Disconnect = "Connected";
                }
            }
            catch (Exception errormessage)
            {
                MessageBox.Show("Connect/Disconnect serial Error: \n\n" + errormessage);
                Connect_Disconnect = "Connect/Disconnect";
            }
        }

        public void Write(string Transmit)
        {
            //write to serial the "Transmit" data
            if (Serial.IsOpen)
            {
                try
                {
                    Serial.WriteLine(Transmit + "\r");
                }
                catch (Exception errormessage)
                {
                    MessageBox.Show("Writing to serial Port Error: \n\n" + errormessage);
                }
            }
        }

        public string Read()
        {
            SerialReceived = "";
            try
            {
                //read line by line the data from serial
                while ((Serial.ReadLine().ToString()) != (""))
                {
                    this.SerialReceived += Serial.ReadLine().ToString();
                }
                return (this.SerialReceived);
            }
            catch
            {
                return (this.SerialReceived);
            }
        }

        public string CheckForData()
        {
            SerialReceived = "";
            //read serial buffer for new data receive.
            try
            {
                SerialReceived = Serial.ReadExisting();
                return (this.SerialReceived);
            }
            catch
            {
                return (this.SerialReceived);
            }
        }
    }
}

    
