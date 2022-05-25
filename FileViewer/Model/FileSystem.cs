using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;


public class FileSystem{

    private String currentPath;
    public FileSystem(String currentPath)
    {
        this.currentPath = currentPath;
    }

    static public String GetUserHome(){
        return Environment.GetFolderPath (Environment.SpecialFolder.UserProfile);
    }

    public List<FileSystemItem> GetAllFileSystemItems(){
        List<FileSystemItem> allFileSysItems = new List<FileSystemItem>();
        try{
        DirectoryInfo di = new DirectoryInfo(currentPath);
        Console.WriteLine($"currentPath : {currentPath}");
        if (currentPath.Length == 1 && currentPath[0] == Path.DirectorySeparatorChar){
            //doesn't allow user to get to root - probably will change later.
            return allFileSysItems;
        }
        var allSystemInfo = di.EnumerateFileSystemInfos();
        allFileSysItems.Add(new FileSystemItem("..",'d',Path.Combine(Directory.GetParent(currentPath).FullName)));

        foreach (FileSystemInfo fi in allSystemInfo){
            char fsiType = 'f';
            if ((fi.Attributes & FileAttributes.Directory) == FileAttributes.Directory )
            {
                fsiType = 'd';
            }
            FileSystemItem fsi = new FileSystemItem(fi.Name,fsiType,fi.FullName);
            allFileSysItems.Add(fsi);
        }
        Console.WriteLine($"file count: {allFileSysItems.Count}");
        }
        catch (System.UnauthorizedAccessException ex){

        }
        return allFileSysItems;
    }
}
