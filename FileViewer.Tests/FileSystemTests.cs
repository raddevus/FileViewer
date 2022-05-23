using System;
using Xunit;
using System.Collections.Generic;

namespace FileViewer.Tests
{
    public class FileSystemTests
    {
        [Fact]
        public void GetFileSystemItems(){
            FileSystem fs = new FileSystem(Environment.GetFolderPath (Environment.SpecialFolder.UserProfile));
            List<FileSystemItem> allItems = fs.GetAllFileSystemItems();
            Assert.True(allItems.Count > 0);

        }

        [Fact]
        public void GetFileSystemErrors(){
            FileSystem fs = new FileSystem(@"c:\invalidpath");
            Assert.Throws<System.IO.DirectoryNotFoundException>(() => fs.GetAllFileSystemItems());
        }
    }

    
}