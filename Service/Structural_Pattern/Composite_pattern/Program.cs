using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Composite_pattern
{
    public interface FileCompoment
    {
        void showProperty();
        long totalSize();
    }
    public class FileLeaf : FileCompoment
    {
        private string name;
        private long size;
        public FileLeaf(string name, long size)
        {
            this.name = name;
            this.size = size;

        }
        public long totalSize()
        {
            return size;
        }
        public void showProperty()
        {
            Console.WriteLine($"{name} ({size})");
        }
    public class FolderComposite : FileCompoment
        {
            private List<FileCompoment> files = new ArrayList<>();
            public FolderComposite(List<FileCompoment> files)
            {
                this.files = files;
            }
            public void showProperty()
            {
                foreach (FileCompoment file in files)
                {
                    file.showProperty();
                }
            }
            public long totalSize()
            {
                long total = 0;
                foreach(FileCompoment file in files)
                {
                    total += file.totalSize();
                }
                return total;
            }
        }

    }
public class client
    {
        public static void main(String[] args)
        {
            FileCompoment file1 = new FileLeaf("file 1", 10);
            FileCompoment file2 = new FileLeaf("file 2", 5);
            FileCompoment file3 = new FileLeaf("file 3", 12);
        }
        List<FileCompoment> files = Arrays.asList(file1, file2, file3);
}       FileCompoment folder = new FolderComposite()
