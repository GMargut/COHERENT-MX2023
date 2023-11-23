using System;
using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;

public class Program<T>
{
    private T[] elements;
    private int front;
    private int rear;
    private int capacity;

    public Program(int size)
    {
        capacity = size;
        elements = new T[capacity];
        front = 0;
        rear = -1;
    }

    public void Enqueue(T element)
    {
        if(rear == capacity - 1)
        {
            throw new InvalidOperationException("FIFO queue is Full");
        }
        elements[++rear] = element;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("FIFO queue is free");  
        }
        T element = elements[front++];
        return element;
    }

    public bool IsEmpty()
    {
        return front > rear;
    }
}
