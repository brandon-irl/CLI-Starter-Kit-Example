using System;
using System.Linq;
using System.Collections.Generic;

namespace InterviewQuestions
{
	public static class InterviewCake
	{

		#region Question1
		public static IEnumerable<string> GetMaxProfits()
		{
			int[] stockPricesYesterday = new int[] { 10, 7, 5, 8, 11, 9 };

			int low = stockPricesYesterday[0];
			int difference = 0;

			foreach (var price in stockPricesYesterday)
			{
				low = Math.Min(price, low);
				difference = Math.Max(price - low, difference);
			}
			yield return difference.ToString();
		}

		#endregion

		#region Question2
		public static IEnumerable<int> GetProductsOfAllIntsExceptAtIndex()
		{
			var arr = new int[] { 1, 7, 3, 4 };
			var result = new int[arr.Length];
			for (int x = 0; x < result.Length; x++)
				result[x] = 1;

			var product = 1;
			for (int i = 1; i < arr.Length; i++)
			{
				product = product * arr[i - 1];
				result[i] = result[i] * product;
			}
			product = 1;

			for (int i = arr.Length - 2; i >= 0; i--)
			{
				product = product * arr[i + 1];
				result[i] = result[i] * product;
			}

			return result;
		}
		#endregion

		#region Question3
		public static void HighestProduct()
		{

		}
		#endregion

		#region Question4
		public static void MergingMeetingTimes()
		{
			var meetings = new List<int[]>
			{
				new int[]{0, 1},
				new int[]{3, 5},
				new int[]{4, 8},
				new int[]{10, 12},
				new int[]{9, 10}
			};
			condenseMeetingTimes(meetings);
		}
		private static void condenseMeetingTimes(List<int[]> meetings)
		{

		}
		#endregion

		#region Question5
		public static void MakingChange()
		{
			var amount = 4;
			var denominations = new int[] { 1, 2, 3 };
		}

		#endregion

		#region Question6
		public static void GetRectangleIntersection()
		{
			var rect1 = new Rectangle(5, 0, 3, 20);
			var rect2 = new Rectangle(7, 5, 2, 20);
			var result = new Rectangle();
			var xoverlap = FindXOverlap(rect1, rect2);
			result.leftX = xoverlap.Item1;
			result.width = xoverlap.Item2;
		}
		protected class Rectangle
		{

			// coordinates of bottom left corner
			public int leftX;
			public int bottomY;

			// dimensions
			public int width;
			public int height;

			public Rectangle(int leftX, int bottomY, int width, int height)
			{
				this.leftX = leftX;
				this.bottomY = bottomY;
				this.width = width;
				this.height = height;
			}

			public Rectangle() { }

			public String toString()
			{
				return String.Format("({0}, {1}, {2}, {3})", leftX, bottomY, width, height);
			}
		}
		private static Tuple<int, int> FindXOverlap(Rectangle rect1, Rectangle rect2)
		{
			Rectangle leftmostRect;
			Rectangle otherRect;
			if (rect1.leftX < rect2.leftX)
			{
				leftmostRect = rect1;
				otherRect = rect2;
			}
			else
			{
				leftmostRect = rect2;
				otherRect = rect1;
			}
			var xr = otherRect.leftX;
			var wr = (leftmostRect.width + otherRect.width) - ((otherRect.leftX + otherRect.width) - leftmostRect.leftX);
			return Tuple.Create(xr, wr);
		}
		private static Tuple<int, int> FindYOverlap(Rectangle rect1, Rectangle rect2)
		{
			Rectangle botmostRect;
			Rectangle otherRect;
			if (rect1.bottomY < rect2.bottomY)
			{
				botmostRect = rect1;
				otherRect = rect2;
			}
			else
			{
				botmostRect = rect2;
				otherRect = rect1;
			}
			var xr = otherRect.bottomY;
			var wr = (botmostRect.height + otherRect.height) - ((otherRect.bottomY + otherRect.height) - botmostRect.bottomY);
			return Tuple.Create(xr, wr);
		}
		#endregion

		#region Question24
		public static string KthToLastNode(int k, Node headNode)
		{
			var soFar = 0;
			var leftNode = headNode;
			var nextNode = headNode;
			while (nextNode != null)
			{
				nextNode = nextNode.Next;
				if (soFar >= k)
					leftNode = leftNode.Next;
				soFar++;
			}
			if (leftNode == null)
				throw new ArgumentException("list length must be greater than k");

			return $"Last K node is {leftNode.Value}";
		}
		#endregion

		#region Question25
		public static Node ReverseALinkedList(Node headNode)
		{

			/* Test Data
			var a = new Node(1);
			var b = new Node(2);
			var c = new Node(3);
			var d = new Node(4);
			var e = new Node(5);

			a.Next = b;
			b.Next = c;
			c.Next = d;
			d.Next = e;
			 */
			if (headNode == null)
				return null;

			Node lastNode = null;
			var currentNode = headNode;
			while (currentNode.Next != null)
			{
				var nextNode = currentNode.Next;
				currentNode.Next = lastNode;
				lastNode = currentNode;
				currentNode = nextNode;
			}

			return currentNode;
		}
		#endregion

		#region Question43
		public static int[] MergeSortedArrays(int[] first, int[] second)
		{
			var maxLength = first.Length + second.Length;
			var result = new int[maxLength];

			var firstPointer = 0;
			var secondPointer = 0;

			for (var i = 0; i < maxLength; i++)
			{
				if(first[firstPointer] < second[secondPointer])
				{
					result[i] = first[firstPointer];
					firstPointer++;
				}else if (first[firstPointer] > second[secondPointer])
				{
					result[i] = second[secondPointer];
					secondPointer++;
				}
				else
				{
					throw new Exception();
				}
			}

			return result;
		}
		#endregion
	}

	public class Node
	{
		public int Value { get; set; }
		public Node Next { get; set; }

		public Node(int value)
		{
			this.Value = value;
		}
	}

}
