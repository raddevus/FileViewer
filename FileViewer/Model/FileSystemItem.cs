using System;

public class FileSystemItem {

    public FileSystemItem(String name, char type, String fullName)
    {
        this.Name = name;
        this.Type = type;
        this.FullName = fullName;
    }

    public String Name {get;set;} // current diretory name or file name - no path info

    public char Type {get;set;} // D=directory, F=file

    public String FullName {get;set;} // full path to file or directory, including name

}