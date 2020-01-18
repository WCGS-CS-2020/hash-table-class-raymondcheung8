using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors_Surgery_With_Priority
{
    class Node
    {
        public string item;         // The item in the node
        public Node next;           // The next node in the list
        public Node(string input)
        {
            item = input;
            next = null;
        }           // Constructor
    }

    class LinkedList
    {
        private Node head;          // Attribute
        private int length;         // Attribute
        private int maxLength;          // Attribute
        public LinkedList()
        {
            head = null;
            length = 0;
            maxLength = 0;
        }           // Constructor for head as it will contain null at the start of the program, there will be nothing in the list and there will be no maximum length set by the user

        public bool isFull()
        {
            if (length == maxLength) return true;           // The queue is full when the length of the queue is the same as the maximum there can be
            else return false;          // If the length of the queue is not the same as the maximum there can be, the queue isn't full
        }

        public bool isEmpty()
        {
            if (head == null) return true;         // If there is nothing after the first node, the list is empty
            else return false;          // If there is more than one node, the list isn't empty
        }

        public void setMaxLength(int newMaxLength)
        {
            maxLength = newMaxLength;
        }           // Changes the maximum length of the queue

        public void emptyListMessage()
        {
            Console.WriteLine("List is empty!");
        }           // Displays a message to tell the user the list is empty

        public void fullListMessage()
        {
            Console.WriteLine("List is full!");
        }           // Displays a message to tell the user the list is full

        public void append(string newItem)
        {
            if (!isFull())
            {
                if (isEmpty()) head = new Node(newItem);            //If the list is empty, no new nodes need to be added since the head can just be changed
                else
                {
                    Node current = head;            // The scanning pointer will start at the head
                    Node toAdd = new Node(newItem);           // A new node will be created to store the item that is to be added to the list
                    while (current.next != null) current = current.next;            // This will repeat until the end of the list is found
                    current.next = toAdd;           // The last node will now point to the new pointer
                }
                length++;           // This will increment the list by one
            }
            else fullListMessage();         // A message will be outputted to tell the user that the list is full
        }

        public void pop()
        {
            if (!isEmpty())         // If the list is empty, no further items can be outputted
            {
                Console.WriteLine(head.item);           // The item in the head will be outputted
                head = head.next;           // The node next to the head will become the new head
                length--;           // This will decrement the length of the list by one
            }
            else emptyListMessage();           // A message will be outputted to tell the user that the list is empty
        }

        public void push(string newItem)
        {
            if (!isFull())          // If the list is empty, no further items can be outputted
            {
                if (isEmpty()) head = new Node(newItem);            //If the list is empty, no new nodes need to be added since the head can just be changed
                else
                {
                    Node temp = head;           // I have stored the head in a temporary node
                    Node toAdd = new Node(newItem);         // A new node will be created to store the item that is to be added to the list
                    head = toAdd;           // I have stored the new node as the new head
                    head.next = temp;           // I have made the new head point at the previous head
                }
                length++;           // This will increment the list by one
            }
            else fullListMessage();         // A message will be outputted to tell the user that the list is full
        }

        public int count(string item)
        {
            int itemCount = 0;          // Initialises the count to zero
            if (!isEmpty())         // This makes sure that this algorithm will only run if the list isn't empty
            {
                Node current = head;            // The scanning pointer will start at the head
                while (current != null)         // This will repeat until the end of the list
                {
                    if (current.item == item) itemCount++;          // This will count the number of times the item appears in the list
                    current = current.next;         // This cycles through the nodes
                }
            }
            else emptyListMessage();            // This displays a message telling the user the list is empty
            return itemCount;           // This will return the number of times the item appears in the list
        }

        public int getLength()
        {
            return length;          // Returns the amount of nodes there are in the list
        }

        public void display()
        {
            if (!isEmpty())         // If the list is empty, no further items can be outputted
            {
                Node current = head;            // The scanning pointer will start at the head
                while (current != null)         // This will repeat until the end of the list is found
                {
                    Console.WriteLine(current.item);            // This will output the item in the current node
                    current = current.next;         // This will move the scanning pointer to the next node
                }
            }
            else emptyListMessage();            // A message will be outputted to tell the user that the list is full
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();         // Initialising a new list
            bool exit = false;          // Creating a boolean so that the program will run until the user selects the exit option
            while (!exit)           // Will repeat the program until the user selects the exit option
            {
                setSize(ref list);
                menu();         // Calls upon a subroutine that outputs the options that the user may choose
                string input = Console.ReadLine().ToUpper();            // Stores the user's input to a variable and converts the input to upper case so that there needs to be less conditions for the selection statement
                switch (input)          // This will run certain code depending on the user's input
                {
                    case "1":
                        append(ref list);           // Calls upon a subroutine that will add an item to the end of the list
                        break;
                    case "2":
                        pop(ref list);          // Calls upon a subroutine that will remove the head and output the item stored in it while making the next node the new head
                        break;
                    case "3":
                        push(ref list);         // Calls upon a subroutine that will add an item to the front of the list
                        break;
                    case "4":
                        count(ref list);            // Calls upon a subroutine that will count the number of times an item appears in the list
                        break;
                    case "5":
                        getLength(ref list);            // Calls upon a subroutine that will find the number of nodes in the list
                        break;
                    case "6":
                        displayList(ref list);          // Calls upon a subroutine that will display the items in the list
                        break;
                    case "E":
                        exit = true;            // Allows the user to end the program by exiting the while statement
                        break;
                    default:
                        errorMessage();         // Calls upon a subroutine that will tell the user that their input was not valid
                        break;
                }
            }
        }

        static void menu()
        {
            Console.WriteLine(@"Choose one of the following options:
(1) Add a patient to the list
(2) Add a priority patient to the list
(3) Remove a patient from the list
(4) Count
(5) Length
(6) Display
(E) Exit");
        }           // Displays the option menu

        static void errorMessage()
        {
            Console.WriteLine("***INVALID INPUT***");
        }           // Displays an error message that tells the user their input is invalid

        static void setSize(ref LinkedList list)
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Please enter the maximum capacity of the queue:");
                try
                {
                    int maxLength = Convert.ToInt16(Console.ReadLine());
                    list.setMaxLength(maxLength);
                    validInput = true;
                }
                catch
                {
                    errorMessage();
                }
            }
        }

        static void append(ref LinkedList list)
        {
            Console.WriteLine("Enter next item for the list:");
            list.append(Console.ReadLine());
        }           // Adds an item to the end of the list

        static void pop(ref LinkedList list)
        {
            list.pop();
        }           // Removes the head and output the item stored in it while making the next node the new head

        static void push(ref LinkedList list)
        {
            Console.WriteLine("Enter item to be pushed into the list:");
            list.push(Console.ReadLine());
        }           // Adds an item to the beginning of the list

        static void count(ref LinkedList list)
        {
            Console.WriteLine("Enter the item to be counted:");
            int itemCount = list.count(Console.ReadLine());
            Console.WriteLine("The item appears {0} times", itemCount);
        }           // Outputs the number of times the item appears in a list

        static void getLength(ref LinkedList list)
        {
            Console.WriteLine("This list consists of {0} items!", list.getLength());
        }           // Outputs the number of items in the list

        static void displayList(ref LinkedList list)
        {
            list.display();
        }           // Outputs the items in the list
    }
}
