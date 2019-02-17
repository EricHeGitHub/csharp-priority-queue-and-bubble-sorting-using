using System;
using System.Linq;
using System.Collections.Generic;
public class PriorityQueue
{
	public List<int> queue;
	public PriorityQueue(){
		queue =  new List<int>();
		queue.Add(0);
	}
	
	public void enqueue(int number){
		queue.Add(number);
		bubbleUp(queue);
	}
	
	public int dequeue(){
		int result = queue[1];
		queue[1] = queue[queue.Count() - 1];
		queue.RemoveAt(queue.Count() - 1);
		bubbleDown(queue);
		return result;
	}
	
	private void bubbleUp(List<int> queue){
		if(queue.Count() == 1){
			return;
		}
		
		_bubbleUp(queue,queue.Count() - 1);
	}
	private void _bubbleUp(List<int> queue, int index){
		if(index == 0){
			return;	
		}
		
		if(queue[index] < queue[index /2]){
			int temp = queue[index];
			queue[index] = queue[index/2];
			queue[index/2] = temp;
		}
		_bubbleUp(queue,index/2);	
	}
	
	private void bubbleDown(List<int> queue){
		if(queue.Count() == 1){
			return;
		}
		
		_bubbleDown(queue, queue.Count() - 1);
	}
	
	private void _bubbleDown(List<int> queue, int index){
		if(index == 0){
			return;	
		}
		if(index * 2 <= queue.Count() - 1)
		{
			if(queue[index] > queue[index * 2])
			{
				int temp = queue[index];
				queue[index] = queue[index * 2];
				queue[index * 2] = temp;
			}
			_bubbleDown(queue,index * 2);
		}
		else if(index * 2  + 1 <= queue.Count() - 1){
			if(queue[index] > queue[index * 2 + 1])
			{
				int temp = queue[index];
				queue[index] = queue[index * 2 +1];
				queue[index*2 + 1] = temp;
			}
			_bubbleDown(queue,index * 2 + 1);
		}
	}
	
	
}
public class Program
{
	public static void bubbleSort(int [] arr)
	{
		for(int i = 0; i < arr.Length - 1; i++){
			for(int j = 0; j < arr.Length - i -1; j++){
				if(arr[j] > arr[j + 1]){
					int temp = arr[j + 1];
					arr[j + 1] = arr[j];
					arr[j] = temp;
				}
			}
		}
	}	
	
    /* Prints the array */
    public static void printArray(int []arr) 
    { 
        int n = arr.Length; 
        for (int i = 0; i < n; ++i) 
            Console.Write(arr[i] + " "); 
        Console.WriteLine(); 
    } 
	// Driver method 
  	public static void Main() 
    { 
        int []arr1 = {64, 34, 25, 12, 22, 11, 90}; 
        bubbleSort(arr1); 
        Console.WriteLine("Sorted array"); 
        printArray(arr1); 
		
		PriorityQueue pq = new PriorityQueue();
		int []arr2 = {64, 34, 25, 12, 22, 11, 90}; 
		foreach(int i in arr2){
			pq.enqueue(i);
		}

		List<int> pqSorted = new List<int>();
		while(pq.queue.Count() > 1){
			pqSorted.Add(pq.dequeue());
		}
		
		int[] arr3 = pqSorted.ToArray();
		printArray(arr1); 
			
    } 
}
	
