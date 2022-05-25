using System;

public class WindowMessage {
    // Used to pass messages between windows, 
    // which will contain the command & data

    public WindowMessage(String command, String data)
    {
        this.Command = command;
        this.Data = data;
    }

    public String Command{get;set;}
    public String Data{get;set;}
}