using System.IO;
using System.IO.Ports;

public class CA2000
{
    public SerialPort OpenPort1(string portName)
    {
        SerialPort port = new SerialPort(portName);
        port.Open();  //CA2000 fires because this might throw //David: Except it doesn't
        SomeMethod(); //Other method operations can fail
        return port;
    }

    public void OpenPort1A(string portName)
    {
        SerialPort port = new SerialPort(portName); //David: CA2000 fires here
        port.Open();  //CA2000 fires because this might throw 
        SomeMethod(); //Other method operations can fail
    }

    public SerialPort OpenPort2(string portName)
    {
        SerialPort tempPort = null;
        SerialPort port = null;
        try
        {
            tempPort = new SerialPort(portName);
            tempPort.Open();
            SomeMethod();
            //Add any other methods above this line
            port = tempPort;
            tempPort = null;

        }
        finally
        {
            if (tempPort != null)
            {
                tempPort.Close();
            }
        }
        return port;
    }

    private void SomeMethod()
    {
    }

    public StreamReader CreateReader1(int x)
    {
        var local = new StreamReader("C:\\Temp.txt");
        checked { x += 1; }
        return local;
    }

    public void CreateReader1A(int x)
    {
        var local = new StreamReader("C:\\Temp.txt");
        checked { x += 1; }
    }
}
