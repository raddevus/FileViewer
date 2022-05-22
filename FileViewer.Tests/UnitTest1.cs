using Xunit;
using System.Collections.Generic;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void GetFileSystemItems(){
            FileSystem fs = new FileSystem(@"c:\users\");
            List<FileSystemItem> allItems = fs.GetAllFileSystemItems();
        }
    }

    
}