using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Based_Calculator
{
    class Node
    {
        public string item;
        public Node next;
        public Node(string input)
        {
            item = input;
            next = null;
        }
    }

    class Stack
    {
        private int maxSize;
        private Node head;
        private int size;
        public Stack()
        {
            maxSize = 100;
            head = null;
            size = 0;
        }

        public bool isFull()
        {
            if (size == maxSize) return true;
            else return false;
        }

        public bool isEmpty()
        {
            if (size == 0) return true;
            else return false;
        }

        private void MessageFull()
        {
            Console.WriteLine("The stack is full!");
        }

        private void MessageEmpty()
        {
            Console.WriteLine("The stack is empty!");
        }

        public void push(string item)
        {
            if (!isFull())
            {
                Node temp = head;
                head = new Node(item);
                head.next = temp;
                size++;
            }
            else MessageFull();
        }

        public string pop()
        {
            if (!isEmpty())
            {
                string item = head.item;
                head = head.next;
                size--;
                return item;
            }
            else
            {
                MessageEmpty();
                return "";
            }
        }

        public string peek()
        {
            return head.item;
        }

        public void print()
        {
            Node current = head;
            string output = "";
            while (current != null)
            {
                if (current == head) output += current.item;
                else output += "\n" + current.item;
                current = current.next;
            }
            string[] outputArray = output.Split('\n');
            for (int i = outputArray.Length - 1; i >= 0; i--) Console.WriteLine(outputArray[i]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            Stack stack = new Stack();
            while (!exit)
            {
                Console.WriteLine("Please enter an expression in reverse Polish notation");
                string input = Console.ReadLine();
                string[] items = input.Split(' ');
                bool outputAnswer = true;
                foreach (string item in items)
                {
                    outputAnswer = true;
                    int inputType = getInputType(item);
                    // 0 = NUMBER
                    // 1 = OPERATION
                    // 2 = EXIT
                    // 3 = PRINT
                    // 4 = INVALID
                    switch (inputType)
                    {
                        case 0:
                            stack.push(item);
                            break;
                        case 1:
                            doOperation(ref stack, item[0], ref outputAnswer);
                            break;
                        case 2:
                            exit = true;
                            outputAnswer = false;
                            break;
                        case 3:
                            stack.print();
                            outputAnswer = false;
                            break;
                        case 4:
                            Console.WriteLine("***INVALID INPUT***");
                            outputAnswer = false;
                            break;
                        default:
                            Console.WriteLine("***ERROR***");
                            outputAnswer = false;
                            break;
                    }
                    if (outputAnswer == false) break;
                }
                if (outputAnswer == true) Console.WriteLine(stack.peek());
            }
        }

        static int getInputType(string input)
        {
            int inputType = -1;
            foreach (char c in input)
            {
                if (c >= 48 && c <= 57) inputType = 0;
                // '0' is 48 in ASCII
                // '9' is 57 in ASCII
                else
                {
                    inputType = -1;
                    break;
                }
            }
            if (inputType == -1)
            {
                if (input.Length == 1
                    && (input[0] == '+' || input[0] == '-' || input[0] == '*' || input[0] == '/'))
                    inputType = 1;
                else if (input == "exit") inputType = 2;
                else if (input == "print") inputType = 3;
                else inputType = 4;
            }
            return inputType;
        }

        static void doOperation(ref Stack stack, char item, ref bool outputAnswer)
        {
            try
            {
                int num2 = Convert.ToInt32(stack.pop());
                int num1 = Convert.ToInt32(stack.pop());
                int result = 0;
                string stringResult = "";

                switch (item)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        result = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("***ERROR***");
                        break;
                }
                stringResult = Convert.ToString(result);
                stack.push(stringResult);
            }
            catch
            {
                Console.WriteLine("***INVALID INPUT***");
                outputAnswer = false;
            }
        }
    }
}