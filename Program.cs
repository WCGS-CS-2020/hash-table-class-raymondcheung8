using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    class Node
    {
        public string item;
        public Node next;

        public Node(string input)
        {
            item = input;
            next = null;
        }           // Constructor
    }           // A node will be used for each index in the table

    class HashTable
    {
        private const int sizeOfTable = 8191;
        private Node[] table;
        private int size;

        public HashTable()
        {
            table = new Node[sizeOfTable];
            for (int i = 0; i < sizeOfTable; i++) table[i] = null;
            size = 0;
        }           // Constructor

        private int getKey(string item)
        {
            int key = 0;
            if (item.Length < 3) foreach (char c in item) key += c;         // If the string isn't at least three characters long, it finds the sum of the ASCII values of the characters in the string
            else for (int i = 0; i < 3; i++) key += item[i];            // Finds the sum of the ASCII values of the first three characters of the string
            key = key % sizeOfTable;            // Divides the sum found by the size of the table
            return key;
        }           // Uses a simple hashing algorithm to generate and return a key

        public void add(string item)
        {
            int key = getKey(item);         // Gets a key using a hashing algorithm
            if (table[key] == null) table[key] = new Node(item);            // This adds the item to the table if there isn't an item already there
            else
            {
                Node current = table[key];          // This is a searching pointer
                while (current.next != null) current = current.next;          // This searches for the previous item to index to the same value
                current.next = new Node(item);         // This adds on the new item behind the previous last item
            }
            size++;         // There is one more item in the table so this variable increases by one
        }           // Adds the item into the table

        public bool search(string item)
        {
            bool found = false;
            int key = getKey(item);

            if (table[key] == null) ;           // If there is nothing already stored in the table at that index, the item isn't there
            else if (table[key].item == item) found = true;
            else
            {
                Node current = table[key];          // This is a searching pointer
                while (found == false && current.next != null)
                {
                    current = current.next;         // This moves on to the next item
                    if (current.item == item) found = true;
                }
            }
            return found;
        }           // Searches for an item in the table

        public void delete(string item)
        {
            int key = getKey(item);
            if (table[key] == null) Console.WriteLine("\nItem not found!");           // If there is nothing already stored in the table at that index, the item isn't there
            else if (table[key].item == item)
            {
                table[key] = table[key].next;
                size--;         // There is one less item in the table so this variable decreases by one
                Console.WriteLine("\nItem deleted");
            }
            else
            {
                bool found = false;
                Node current = table[key];          // This is a searching pointer
                while (found == false && current.next != null)
                {
                    current = current.next;         // This moves on to the next item
                    if (current.item == item)
                    {
                        current = current.next;
                        size--;         // There is one less item in the table so this variable decreases by one
                        found = true;
                    }
                }
                if (found == false) Console.WriteLine("\nItem not found!");
                else Console.WriteLine("\nItem deleted");
            }
        }           // Searches and deletes an item in the table

        public void displayAll()
        {
            if (size == 0) Console.WriteLine("There is nothing in the table");
            else
            {
                foreach (Node n in table)
                {
                    if (n == null) ;            // If nothing is stored at that index in the table, nothing needs to be outputted
                    else
                    {
                        Node current = n;          // This is a searching pointer

                        Console.WriteLine(current.item);
                        while (current.next != null)
                        {
                            current = current.next;         // This moves on to the next node
                            Console.WriteLine(current.item);
                        }
                    }
                }
            }
        }           // Displays all the items in the table

        public double getLoadFactor()
        {
            double loadFactor = Convert.ToDouble(size) / Convert.ToDouble(sizeOfTable);
            return loadFactor;
        }           // Returns the current load factor
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashTable table = new HashTable();
            bool exit = false;
            while (!exit)
            {
                menu();
                string input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "1":
                        newLine();
                        add(ref table);
                        newLine();
                        break;
                    case "2":
                        newLine();
                        search(table);
                        newLine();
                        break;
                    case "3":
                        newLine();
                        delete(ref table);
                        newLine();
                        break;
                    case "4":
                        newLine();
                        displayAll(table);
                        newLine();
                        break;
                    case "5":
                        newLine();
                        getLoadFactor(table);
                        newLine();
                        break;
                    case "E":
                        exit = true;
                        break;
                    default:
                        newLine();
                        Console.WriteLine("***INVALID INPUT***");
                        newLine();
                        break;
                }
            }
        }

        static void menu()
        {
            Console.WriteLine(@"Please select one of the following options:
(1) Add item
(2) Search for item
(3) Delete item
(4) Display all items
(5) Get load factor
(E) Exit program");
        }           // Displays all the options the user can choose

        static void newLine()
        {
            Console.Write("\n");
        }           // Adds a new line

        static void add(ref HashTable table)
        {
            Console.WriteLine("Enter item to be added:");
            string input = Console.ReadLine();
            if (input != "") table.add(input);
            else Console.WriteLine("***INVALID INPUT***");
        }

        static void search(HashTable table)
        {
            Console.WriteLine("Enter item to be searched:");
            string input = Console.ReadLine();
            bool found = table.search(input);
            string not = (found) ? " " : " not ";           // Adds a "not" in the sentence if the item isn't found
            Console.WriteLine("Item{0}found", not);
        }

        static void delete(ref HashTable table)
        {
            Console.WriteLine("Enter item to be deleted:");
            string input = Console.ReadLine();
            if (input != "") table.delete(input);
            else Console.WriteLine("***INVALID INPUT***");
        }

        static void displayAll(HashTable table)
        {
            table.displayAll();
        }

        static void getLoadFactor(HashTable table)
        {
            Console.WriteLine(table.getLoadFactor());
        }
    }
}