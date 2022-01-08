using System;
using System.IO;
using System.Collections.Generic;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Composite Example.");
            // Create the root for the base folder
            Composite root = new Composite(@"C:\TEMP");

            // Populate all children for the root
            PopulateFilesAndFolders(root);

            // Call display to show all folders, files and sizes
            root.Display("");
        }

        // This method gets all files and folders from the Composite parameter path
        // and creates children recursively 
        static void PopulateFilesAndFolders(Composite c)
        {

            // Get the folder data of the given composite
            DirectoryInfo directoryInfo = new DirectoryInfo(c.Name);

            // Get all the files from the folder and add them as leafs
            FileInfo[] listOfFiles = directoryInfo.GetFiles();
            foreach (FileInfo file in listOfFiles)
            {
                Leaf oneFile = new Leaf(file.FullName);
                c.Add(oneFile);
            }

            // Add all sub directories and add them as composite 
            // Add all the sub directories files 
            DirectoryInfo[] ListOfFolders = directoryInfo.GetDirectories();
            foreach (DirectoryInfo folder in ListOfFolders)
            {
                // add composite child
                Composite folderComposite = new Composite(folder.FullName);
                c.Add(folderComposite);

                PopulateFilesAndFolders(folderComposite); // go into the subfolder recursively
            }
        }
    }

    public abstract class Component
    {
        public string Name { get; protected set; }

        public Component(string name)
        {
            Name = name;
        }

        public abstract void Add(Component c);

        public abstract void Remove(Component c);

        public abstract void Display(string space);

        public abstract long GetSize();
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void Add(Component c)
        {
            throw new NotSupportedException("Leaf element cannot add child!");
        }

        public override void Remove(Component c)
        {
            throw new NotSupportedException("Leaf element cannot remove child!");
        }

        public override void Display(string space)
        {
            Console.WriteLine($"{space} {this.Name} size: {GetSize().ToString("#,##0")}");
        }

        public override long GetSize()
        {
            FileInfo fileInfo = new FileInfo(this.Name);
            return fileInfo.Length; // this returns the size of the file
        }
    }
    public class Composite : Component
    {

        private List<Component> children = new List<Component>();

        public Composite(string name) : base(name)
        {
        }

        public override void Add(Component c)
        {
            children.Add(c);
        }

        public override void Remove(Component c)
        {
            children.Remove(c);
        }

        public override void Display(string space)
        {
            Console.WriteLine($"{space} {this.Name} [Folder size: {GetSize().ToString("#,##0")}]");

            foreach (Component c in children)
            {
                c.Display(space + "    ");
            }
        }

        public override long GetSize()
        {
            long sum = 0;

            foreach (Component c in children)
            {
                // adding the size of each child to the sum
                sum = sum + c.GetSize();
            }

            return sum;
        }
    }
}
