using System;

namespace DataStructures_Course_Oded_High_School
{
	class Program
	{
		public static void Main(string[] args)
		{
			

			// Declare List:
			Node<int> p1 = new Node<int>(5), p2 = new Node<int>(5), p3 = new Node<int>(8), p4 = new Node<int>(10), p5 = new Node<int>(13);
			p1.SetNext(p2); p2.SetNext(p3); p3.SetNext(p4); p4.SetNext(p5);

			Node<int> po1 = new Node<int>(5), po2 = new Node<int>(7), po3 = new Node<int>(8), po4 = new Node<int>(40), po5 = new Node<int>(45);
			po1.SetNext(po2); po2.SetNext(po3); po3.SetNext(po4); po4.SetNext(po5);
			int[] arr = new int[5] { 300, 5, 100, 3, 9 };

			
			BinNode<int> left = new BinNode<int> (11);							//10
			BinNode<int> right = new BinNode<int> (12);						//11	//12
			BinNode<int> root = new BinNode<int>(left, 10, right);		  //1  //2 //3 //4
			left.SetLeft(new BinNode<int>(1));											// 42
																						 // -3
			left.SetRight(new BinNode<int>(2));
			right.SetLeft(new BinNode<int>(3));
			right.SetRight(new BinNode<int>(4));
			right.GetRight().SetRight(new BinNode<int>(42));
			right.GetRight().GetRight().SetRight(new BinNode<int>(-3));


			Stack<int> Integers1 = new Stack<int>();
			Integers1.Push(2);
			Integers1.Push(4);
			Integers1.Push(223);
			Integers1.Push(8);
			Integers1.Push(5);
			Integers1.Push(4);
			
			Stack<int> Integers2 = new Stack<int>();
			Integers2.Push(4);
			Integers2.Push(6);
			Integers2.Push(223);
			Integers2.Push(78);
			Integers2.Push(3);
			Integers2.Push(1);

           TarV()	; 

        }
		public static void TarV()
        {
			int[] arr = new int[10];
			for(int i =0; i < arr.Length; i++)
			{ 
				if (i % 2 == 0)
                    arr[i] = i*-2;
				if (i%2!=0)
                   arr[i] = i*2;
				i++;
            }
            Console.WriteLine(arr);
        }
		public static int FindMaxInArr(int[] arr)
        {
			int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
				max = Math.Max(max, arr[i]);
            }
			return max;
        }
		public static bool P177T22(BinNode<int> bt, int num)
		{
			/*הפעולה בודקת האם עץ מכיל את כל המספרים מאחד ועד "נום" (שהתקבל בקלט) פעם אחת בלבד*/
			for (int i = 1; i < num+1; i++)
			{
				if (!IsExistInTree(bt, i))
				{
					return false;
				}


			}
			return true;
		}
		public static bool P177T21(BinNode<int> bt)
        {
			if (bt == null)
				return false;
			bool simetri = (Math.Abs(TreeHeight(bt.GetLeft()) - TreeHeight(bt.GetRight()))) == 1;
			return simetri;

        }
		public static bool IsLeaf(BinNode<int> bt)
        {
			return bt.HasLeft() && bt.HasRight();
        }
		public static bool P177T22(BinNode<int> bt)
        {
			if (bt == null)
				return true;
			if (IsLeaf(bt))
				return true;
			if (bt.HasLeft() && bt.HasRight())
				return true && P177T22(bt.GetLeft()) && P177T22(bt.GetRight());
			if (!bt.HasRight() && bt.HasLeft())
				return false;
			if (bt.HasRight() && !bt.HasLeft())
				return false;
			else
				return true;
        }
		public static int TreeHeight(BinNode<int> bintree)
        {
			if (bintree == null)
				return -1;
			return 1 + Math.Max(TreeHeight(bintree.GetLeft()), TreeHeight(bintree.GetRight()));
        }
		public static bool IsExistInTree(BinNode<int> bintree, int number)
        {
			/*פעולה שמחזירה אמת אם ערך נמצא בעץ, אחרת מחזירה שקר*/
			if (bintree == null)
				return false;
			return (bintree.GetValue() == number || IsExistInTree(bintree.GetLeft(), number) || IsExistInTree(bintree.GetRight(), number));

        }
		
		
        /*public static void P176T10(BinNode<int> t)
        {	
			if (t.GetLeft() = null)

			if (t.HasLeft() == false && t.HasRight() == false)
                Console.WriteLine(t);
			P176T10(t.GetLeft());
			P176T10(t.GetRight());
        }*/

        public static Stack<int> CloneStack(Stack<int> s)
        {
			/*פעולה שמקבלת מחסנית ומחזירה שכפול
			 * מדויק של המחסנית מבלי להרוס אותה*/
			Stack<int> newStk = new Stack<int>();
			Stack<int> temp = new Stack<int>();
			while (!s.IsEmpty())
            {
				temp.Push(s.Pop());
            }
            while (!temp.IsEmpty())
            {
				newStk.Push(temp.Top());
				s.Push(temp.Pop());
            }
			return newStk;
        }

		public static Stack<int> ReverseStack(Stack<int> s)
        {
			/*פעולה שמקבלת מחסנית ומחזירה העתק
			 * שלה כשאביריה מסודרים בסדר הפוך*/
			Stack<int> newStk = new Stack<int>();
			Stack<int> temp = CloneStack(s);
            while (!temp.IsEmpty())
            {
				newStk.Push(temp.Pop());
            }
			return newStk;
        }
		public static bool IsExistInStack(Stack<int> s, int num)
        {
			/*פעולה שמחזירה אמת אם ערך נמצא במחסנית*/
			Stack<int> sCopy = CloneStack(s);
            while (!sCopy.IsEmpty())
            {
				if (sCopy.Pop() == num)
                {
					return true;
                }
            }
			return false;
        }
		public static int SumStack(Stack<int> s)
        {
			/*פעולה שמחזירה את סכום הערכים במחסנית*/
			int sum = 0;
			Stack<int> sCopy = CloneStack(s);
			while (!sCopy.IsEmpty())
            {
				sum += sCopy.Pop();
            }
			return sum;
        }

		public static int StackLenght(Stack<int> s)
        {
			/*מחזירה את אורך המחסנית(מס' האיברים)י*/
			int lenght = 0;
			Stack<int> sCopy = CloneStack(s);
            while (!sCopy.IsEmpty())
            {
				lenght++;
				sCopy.Pop();
            }
			return lenght;
        }

		public static int HowManyInStack(Stack<int> s, int num)
        {
			/*מחזירה את כמות המופעים של מספר במחסנית*/
			int count = 0;
			Stack<int> sCopy = CloneStack(s);
            while (!sCopy.IsEmpty())
            {
				if (sCopy.Pop() == num)
					count++;
            }
			return count;
        }
		public static void DeleteFromStack(Stack<int> s, int num)
        {
			/*פעולה שמוחקת את כל הערכים ששוים לערך שהתקבל*/
			Stack<int> sReversed = ReverseStack(s);
            while (!s.IsEmpty())
            {
				s.Pop();
            }
            while (!sReversed.IsEmpty())
            {
				int x = sReversed.Pop();
				if (x != num)
					s.Push(x);
            }
        }

		public static int MinInStack(Stack<int> s)
        {
			/*מחזירה את המספר הכי קטן במחסנית*/
			if (s == null)
				return 0;
			Stack<int> sCopy = CloneStack(s);
			int minVal = sCopy.Pop();
			while (!sCopy.IsEmpty())
            {
				minVal = Math.Min(minVal, sCopy.Pop());
            }
			return minVal;
        }
		public static bool LenghtIsEven(string word)
        {
			if (word.Length % 2 == 0)
				return true;
			return false;
        }
		public static string SwitchTheCneterChar(string word)
        {
			char[] charArr = word.ToCharArray();
			if(charArr.Length <= 2)
            {
				return "" + 'a' + 'b';
            }
            if (LenghtIsEven(word))
            {
				charArr[charArr.Length / 2] = 'a';
				charArr[(charArr.Length / 2) - 1] = 'b';
			}
			else
				charArr[(word.Length / 2)] = 'a';

			string fixedString = new string(charArr);
			return fixedString;

		}

		public static string FbiTargilMain(string sentence)
        {
			string[] words = sentence.Split(' ');
			string fixedCentence = "";
            for (int i = 0; i < words.Length; i++)
            {
				fixedCentence += SwitchTheCneterChar(words[i]) + ' ';
            }
			return fixedCentence;
        }

		public static bool AhadotCheck(Stack<int> stk, int num)
        {
			Stack<int> backup = new Stack<int>();
			int x;
			bool flag;

			flag = false;
			while (!stk.IsEmpty())
            {
				x = stk.Pop();
				backup.Push(x);
				if (x % 10 == num)
					flag = true;

				
			}
			
			while (!backup.IsEmpty())
				stk.Push(backup.Pop());
			return flag;
				

        }

		public static int LastAndRemove(Stack<int> stk)
        {
			Stack<int> temp = new Stack<int>();

			int lenght = GetLenght(stk);
            for (int i = 0; i < lenght-1; i++)
            {

				temp.Push(stk.Pop());
            }
			int thelast = stk.Pop();
            while (!temp.IsEmpty())
            {
				stk.Push(temp.Pop());
			}
			return thelast;



        }

		public static int GetLenght(Stack<int> s)
        {
			Stack<int> s2 = new Stack<int>();
			int counter = 0;
            while (!s.IsEmpty())
            {
				s2.Push(s.Pop());
				counter++;

            }
			while (s2.IsEmpty())
            {
				s.Push(s2.Pop());
				
            }
			return counter;
        }
		public static bool IfExistInStack(Stack<int> s, int num)
        {
			if (s.IsEmpty())
				return false;
			if (s.Pop() == num)
				return true;
			else
				return false | IfExistInStack(s, num);
        }

		public static bool IfEquals(Stack<int> s1, Stack<int> s2)
		{
			if (s1.IsEmpty() && !s2.IsEmpty())		//if s1 is empty and s2 is not
				return false;
			if (!s1.IsEmpty() && s2.IsEmpty())      //if s2 is empty and s1 is not
				return false;
			if (s1.IsEmpty() && s2.IsEmpty())
				return true;
			if (s1.Pop() == s2.Pop())				//if the top values are equals
				return true && IfEquals(s1, s2);		//return true for these values											// and check for the next values
			else
				return false;

		}
		public static void SwitchVals(Node<int> one, Node<int> two)
        {
			
			int temp = one.GetValue();
			one.SetValue(two.GetValue());
			two.SetValue(temp);
        }

		public static void Change(Node<int> first)
        {
			Node<int> last = first;
			Node<int> pos = first;
			
			while (pos.GetNext() != null)
            {
				pos = pos.GetNext();		// הגעה לתא האחרון ברשימה
            }
			last = pos;
			SwitchVals(first, last);		// מחליף את ערכי הראשון והאחרון
			pos = first;
			first = first.GetNext();
			
			while(first != last)
            {
				while (pos.GetNext() != last)
                {
					pos = pos.GetNext();	// מקרב את ההתחלה והסוף לאמצע

                }
				last = pos;
				SwitchVals(first, last);
				first = first.GetNext();
				pos = first;
            }
			

			

        }
		
		public static int GetEvenCountAfter(Node<int> first, Node<int> after)
		{
			while (first != after && first != null)
			{
				first = first.GetNext();
			}

			if (first == null)
			{
				return 0;
			}
			if (after.GetValue() % 2 == 0)
			{
				return 1 + GetEvenCountAfter(first, first.GetNext());
			}
			else
			{
				return 0 + GetEvenCountAfter(first, first.GetNext());
			}


			static void PrintTheEvenIndexesValues(Node<int> first)
			{
				Console.WriteLine(first.GetValue());
				if (first.HasNext() && first.GetNext().HasNext())
				{
					PrintTheEvenIndexesValues(first.GetNext().GetNext());
				}
			}


			static int SumFromPToQ(Node<int> lst, Node<int> p, Node<int> q)
			{
				if (p.GetNext() == q)
				{
					return p.GetValue();
				}

				return p.GetValue() + SumFromPToQ(lst, p.GetNext(), q);
			}



			static int DifferenceInLength(Node<int> lst1, Node<int> lst2)
			{
				if (lst1.HasNext() && !lst2.HasNext())
				{
					int count = 0;
					for (; lst1.HasNext(); count++)
					{
						lst1 = lst1.GetNext();
					}

					return count;
				}
				else if (lst2.HasNext() && !lst1.HasNext())
				{
					int count = 0;
					for (; lst2.HasNext(); count++)
					{
						lst2 = lst2.GetNext();
					}

					return count;
				}
				else if (!lst1.HasNext() && !lst2.HasNext())
				{
					return 0;
				}

				return DifferenceInLength(lst1.GetNext(), lst2.GetNext());
			}
			static Node<string> RemoveLongWords(Node<string> first, int len)
			{
				if (first == null)
					return first;
				Node<string> head = first;
				do
				{
					if (first.GetNext().GetValue().Length < len)
						first.SetNext(first.GetNext().GetNext());
					else
						first = first.GetNext();




				} while (first.HasNext() && first.GetNext().HasNext());
				return head;
			}

			static Node<T> AddLast<T>(Node<T> p, T value) // Function in kind of listservices
			{
				Node<T> newNode = new Node<T>(value);
				p.SetNext(newNode);
				return newNode;
			}

			static int NumOfWordsStartingWithCapitalLetters(Node<string> first)
			{
				if (first == null)
					return 0;

				int counter = 0;
				do
				{

					if (char.IsUpper(first.GetValue()[0]))
						counter++;
					first = first.GetNext();
				} while (first.HasNext());

				return counter;

			}
		}
            public static int Power(int n1, int n2) { 
			
				if (n2 == 0)
					return 1;
				else
					return Power(n1, n2-1) * n1;
			}
		public static void PrintTheZugiIndexes(Node<int> first)
		{
			if (first == null)
				Console.WriteLine("No values in list");
			if (!first.HasNext())
				Console.WriteLine("End of List");

			first = first.GetNext();
			Console.WriteLine(first.GetValue());
			while (first.GetNext().HasNext()) { 

				PrintTheZugiIndexes(first.GetNext()); 
			}
        }

		
	}
}