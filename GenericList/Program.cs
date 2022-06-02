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
			BinNode<int> root = new BinNode<int>(left, 10, right);		  //1  //21//3 //14
			left.SetLeft(new BinNode<int>(1));											// 42
																						 // -3
			left.SetRight(new BinNode<int>(21));
			right.SetLeft(new BinNode<int>(3));
			right.SetRight(new BinNode<int>(14));
			right.GetRight().SetRight(new BinNode<int>(42));
			right.GetRight().GetRight().SetRight(new BinNode<int>(-3));



			BinNode<int> left2 = new BinNode<int>(-2);                           //-10
			BinNode<int> right2 = new BinNode<int>(-10);                      //-2	//-10
			BinNode<int> root2 = new BinNode<int>(left, -10, right);        //-1  //-2 //-3 //-14
			left2.SetLeft(new BinNode<int>(-1));                                          // -42
																						// -6
			left2.SetRight(new BinNode<int>(-2));
			right2.SetLeft(new BinNode<int>(-3));
			right2.SetRight(new BinNode<int>(-14));
			right2.GetRight().SetRight(new BinNode<int>(-42));
			right2.GetRight().GetRight().SetRight(new BinNode<int>(-6));


			Stack<int> Integers1 = new Stack<int>();
			Integers1.Push(4);
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

			Stack<int> Integers3 = new Stack<int>();
			Integers3.Push(1);
			Integers3.Push(2);
			Integers3.Push(1);

			Stack<int> Integers4 = new Stack<int>();
			Integers4.Push(8);
			Integers4.Push(2);

			BinNode<Stack<int>> tr_stk = new BinNode<Stack<int>>(Integers1);

			tr_stk.SetLeft(new BinNode<Stack<int>>(Integers2));
			tr_stk.SetRight(new BinNode<Stack<int>>(Integers3));
			tr_stk.GetRight().SetRight(new BinNode<Stack<int>>(Integers4));

            
			int[] array = new int[6] { 3,2,4,6,6,8 };

			string[] arrstr = new string[4] { "hi", "ipspp", "posh", "shachaf" };
            Console.WriteLine(DominoArr(arrstr));
			Random rd = new Random();

            Console.WriteLine(p1);
			

            Console.WriteLine(Move(p1, 2));
			
		}
		public static Node<int> MoveLastToStart(Node<int> first)
        {
			Node<int> pos = first;
            while (pos.GetNext().HasNext())
            {
				pos = pos.GetNext();
            }
			Node<int> lastPos = pos.GetNext();
			pos.SetNext(null);
			lastPos.SetNext(first);
			return lastPos;
        }
		public static Node<int> Move(Node<int> first, int num)
        {
			Node<int> pos = first;
            for (int i = 0; i < num; i++)
            {
				first = MoveLastToStart(pos);
            }
			return first;
        }
		public static void CalcFinalGrade()
        {
			int magen = 100;
			int kitaYudProject = 100;
			for (int i = 5; i < 100; i++)
            {
                Console.WriteLine("Final Grade: " + (int)((0.2*magen)+(0.3*kitaYudProject)+(0.5*i)) + " Bargut Grade: " + i);
				
            }
        }
		
		
		public static bool Tar(Node<int> first1, Node<int> first2 )
        {
			bool flag = false;
			Node<int> pos1 = first1; //הרשימה הקצרה l1
			Node<int> pos2 = first2;//הרשימה הארוכה l2
            while (pos1.HasNext())
            {
				if (pos1.GetValue() == pos2.GetValue())
				{
					pos1 = pos1.GetNext();
					pos2 = pos2.GetNext();
					flag = true;
				}
				else
                {
					pos2 = pos2.GetNext();
					flag = false;
                }
            }
			return flag;
        }
		public static bool DominoArr(string[] arr)
        {
			bool flag = false ;
            for (int i = 0; i < arr.Length-1; i++)
            {
				if (arr[i][arr[i].Length-1] == arr[i + 1][0])
					flag = true;
				else
					flag = false;

            }
			return flag;
        }
		public static int RezefB(Stack<int> stk)
        {
			Stack<int> copy = CloneStack(stk);
			int max = Rezef(stk, copy.Top());

			while (!copy.IsEmpty())
            {
				max = Math.Max(Rezef(stk, copy.Pop()), max);
				
            }
			return max;
        }
		public static int Rezef(Stack<int> stk, int num)
        {
			int counter = 0;
			bool countFlag = false;
			Stack<int> copy = CloneStack(stk); 
            while (!copy.IsEmpty())
            {
				if (countFlag)
					counter++;
				if (copy.Top() == num)
				{
					countFlag = true;
					counter++;
				}
				else if(copy.Top() == -1*num)
                {
					countFlag = false;
					counter++;
                }
				
				copy.Pop();
            }
			return counter;
        }
		public static int GetLastEZugi(int[] arr)
        {int returnedVal = 99999;for (int i = arr.Length - 1; i > -1; i--)if (arr[i] % 2 != 0)returnedVal = arr[i]; return returnedVal; }
		
		public static Node<int> GetFirstKNodesAndRemoveThem(Node<int> first, int k)
        {
			int count = 0;
			Node<int> returnedList = new Node<int>(9999);
			while(first!=null && count != k)
            {
				returnedList.SetNext(new Node<int>(first.GetValue()));
				count++;
				first = first.GetNext();
            }
			return returnedList;
        }
		public static int ListLenght(Node<int> first)
        {
			int count = 0;
			Node<int> pos = first;
            while (pos != null)
            {
				count++;
				pos = pos.GetNext();

            }
			return count;
        }
		public static bool Kfula(string str)
        {
			int len = str.Length;
			string first = str.Substring(0, len / 2);
			string second = str.Substring(len / 2);
			return Equals(first, second);

        }
		public static bool ExistTwice(string str, char ch)
        { int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
				if (str[i] == ch)
					count++;

            }
			if (count == 2)
				return true;
			return false;
        }
		public static bool MahrozetKfula(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
				if (!ExistTwice(str, str[i]))
					return false;
            }
			return true;
        }
		public static bool Elazar(Node<int> first)
        {
			Node<int> pos = first;
			bool flag = false;
			while (pos!=null && pos.HasNext())
            {
				if (pos.GetValue() % 2 != pos.GetNext().GetValue() % 2)
					flag = true;
				pos = pos.GetNext();
            }
			return flag;
        }

		public static int Sum(BinNode<int> tr)
        {
			if (tr == null)
				return 0;
			return tr.GetValue() + Sum(tr.GetLeft()) + Sum(tr.GetRight());
        }
		public static bool Equals(int[][] arr1, int[][] arr2)
        {
			if (arr1.GetLength(1) != arr2.GetLength(1))
				return false;
			if (arr1.GetLength(0) != arr2.GetLength(0))
				return false;
            for (int i = 0; i < arr1.GetLength(0); i++)
            {	
				if (arr1[0][i] != arr2[0][i])
					return false;
            }
			for (int i = 0; i < arr1.GetLength(1); i++)
			{
				if (arr1[1][i] != arr2[1][i])
					return false;
			}
			return true;
		}
		public static bool Mahpela(int[] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1;j < arr.Length && j!=i; j++)
                {
                    for (int h = 2; h < arr.Length && j!=i&& h!=i && j!=h; h++)
                    {
						if (arr[i] * arr[j] * arr[h] == num)
							return true;
                    }
                }
            }
			return false;
        }
		public static Node<string> ConvertIntToStringList(Node<int> p)
        {
			Node<int> pos = p;
			Node<string> str = new Node<string>("aa");
            while (pos.HasNext())
            {
				str.SetNext(new Node<string>(pos.GetValue().ToString()));
            }
			return str.GetNext();
        }
		public static int above(int[] arr, int num)
        {
			int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
				sum += arr[i];
				if (num < sum)
					return arr[i];
            }
			return -1;
        }
		public static void BubbleSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr.Length - 1; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int temp = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = temp;
					}
				}
			}
		}
		public static void InsertSort(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < 0; j--)
				{
					if (arr[j] < arr[j - 1])
					{
						int temp = arr[j];
						arr[j] = arr[j - 1];
						arr[j - 1] = temp;
					}
				}
			}
		}

		public static bool IsExistInArr(int[] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
				if (arr[i] == num)
					return true;
            }
			return false;
        }
		public static void Tar2(BinNode<Stack<int>> t)
        {
			Stack<int> returned_stk = new Stack<int>();
			if (t != null)
			{
				Tar2(t.GetLeft());
				TarHelper(returned_stk, t.GetValue());	//סריקה InOrder של מחסניות העץ
				Tar2(t.GetRight());
			}
            Console.WriteLine(returned_stk);
		}
		public static void TarHelper(Stack<int> source, Stack<int> stk)
        {
			if (stk.IsEmpty()) {
				source.Push(0);					//אם המחסנית בצומת ריקה דחוף 0 למחסנית המוחזרת
				return;
			}
			while (!stk.IsEmpty()) {
				if (StackLenght(stk) == 1) 
				{ 
					source.Push(stk.Top());		//אם אורך המחסנית בצומת ==1 דחוף את הערך שבה למחסנית המוחזרת
					return;
				}

				else if (StackLenght(stk) == 2)
				{
					int x = stk.Pop();

					source.Push(x + stk.Top());	//אם אורך המחסנית בצומת == 2 דחוף את סכום הערכים שבה למחסנית המוחזרת
					stk.Push(x);
					return;
				}
				else
				{
					int y = stk.Pop();
					int z = stk.Pop();
					source.Push(stk.Top() + y + z);//אם במחסנית יש יותר מ2 איברים דחוף את סכום 3 האיברים העליונים במחסנית שבצומת
					stk.Push(z);
					stk.Push(y);
					return;
				}

					
			}
			source.Push(0);

		}
		public static void SwapNodes(Node<int> first, Node<int> p1, Node<int> p2)
        {
			if (first == null)
				return;
			Node<int> pos = first;
			while(pos.HasNext() && pos.GetValue() != p1.GetValue())
            {
				pos = pos.GetNext();		//מביא מצביע עד לחוליה הראשונה
            }
			Node<int> pos2 = pos;
			while (pos2.HasNext() && pos2.GetValue() != p2.GetValue())
			{
				pos2 = pos2.GetNext();		//מביא מצביע עד לחוליה השניה
			}
			int one_value = pos.GetValue();	// שמירת ערך החוליה הראשונה במשתנה
			int two_value = pos2.GetValue();//שמירת ערך החוליה השניה במשתנה
			pos.SetValue(two_value);		//ההחלפה
			pos2.SetValue(one_value);		//ההחלפה

		}
		public static bool BtrMemutza(BinNode<int> tr)
        {
			if (tr == null)
				return false;
			bool tnai = (tr.HasLeft() && tr.HasRight() && (tr.GetLeft().GetValue() + tr.GetRight().GetValue()) / 2 == tr.GetValue());
			return tnai && BtrMemutza(tr.GetLeft()) && BtrMemutza(tr.GetRight());
				
        }
		public static string HefreshOtiot(string str)
        {
			string abc = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < str.Length; i++)
            {
				string abcd = abc.Replace(str[i], '\0');
				abc = abcd;
            }
			return abc;
        }
		public static bool MaslulOle(BinNode<int> tr)
        {
			if (tr == null)
				return true;
			if (tr.HasLeft() && tr.GetLeft().GetValue() > tr.GetValue())
				return MaslulOle(tr.GetLeft());
			
			if (tr.HasRight() && tr.GetRight().GetValue() > tr.GetValue())
				return MaslulOle(tr.GetRight());
			return false;
        }
		
		
		public static int GetAhadot(int x)
        {
			if (x < 10)
				return -9;
			return x % 10;

        }
		/*public static Node<int> BuildDigit(Node<int> lst)
        {
			Node<int> pos = lst;
			Node<int> digits = new Node<int>(999999);
            while (pos != null)
            {
				digits.SetNext(new Node<int>(GetAhadot(pos.GetValue())));
				digits.SetNext(new Node<int>(GetAhadot(pos.GetValue()/10)));
				digits.SetNext(new Node<int>(GetAhadot(pos.GetValue()/100)));
			}

        }*/
		public static int CountAllReferences(char ch, string str)
        {
			int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
				if (str[i] == ch)
					counter++;
            }
			return counter;
        }
		public static int CountRowReferences(char ch, string str)
        {
			int counter = 0;
			for (int i = 0; i < str.Length-1; i++)
			{
				if (str[i] == ch)
					counter++;
				if (str[i+1] != str[i])
					return counter;
				
			}
			return counter+1;
		}

		public static bool IsUniqueStr(string str)
        {
			bool flag = true;
            for (int i = 0; i < str.Length; i++)
            {
				if (CountAllReferences(str[i], str) == CountRowReferences(str[i], str))
					flag = true;
				else
					return false;
            }
			return flag;
        }
		public static int CountNumInStack(Stack<int> s, int numToCount)
        {
			Stack<int> sCopy = CloneStack(s);
			
			int counter = 0;
            while (!sCopy.IsEmpty())
            {
				if (sCopy.Pop() == numToCount)
					counter++;
            }
			return counter;
        }

		
		public static bool IsSmallerThanAll(BinNode<int> tr, int val)
        {
			if (tr == null)
				return false;
			if (tr.GetValue() != val)
				return false;

			return IsSmallerThanAll(tr.GetLeft(), val) && IsSmallerThanAll(tr.GetRight(), val);


		}
		public static bool IsSmaller(BinNode<int> t1, BinNode<int> t2)
        {
			if (t1 == null)
				return true;
			if (!IsSmallerThanAll(t2, t1.GetValue()))
				return false;
			return IsSmaller(t1.GetLeft(), t2) && IsSmaller(t1.GetRight(), t2);
        }
		public static bool UpPath(BinNode<int> tr)
		{

			if (IsLeaf(tr))
				return true;
			bool left = tr.HasLeft() && tr.GetLeft().GetValue() > tr.GetValue();
			bool right = tr.HasRight() && tr.GetRight().GetValue() > tr.GetValue();
			if (left || right)
				return (left && UpPath(tr.GetLeft())) || (right && UpPath(tr.GetRight()));
			return false;
		}
		public static BinNode<int> CloneTree(BinNode<int> t)
        {
			if (t == null)
				return null;
			BinNode<int> left = CloneTree(t.GetLeft());
			BinNode<int> right = CloneTree(t.GetRight());
			return new BinNode<int>(left, t.GetValue(), right);
        }
		public static bool samesame(BinNode<int> a, BinNode<int> b)
		{
			/*בודק האם שני עצים זהים לחלוטין*/
			if (a == null && b == null)
				return true;
			if (a == null || b == null || a.GetValue() != b.GetValue())
				return false;
			return samesame(a.GetLeft(), b.GetLeft()) && samesame(a.GetRight(), b.GetRight());
		}
		/*public static bool SameStruct<T>(BinNode<T> t1, BinNode<T> t2)
        {
			if (t1 == t2)
				return true;
			if (t1.HasRight() && t2.HasRight() && !t1.HasLeft() && !t2.HasLeft())
				return true && SameStruct(t1.GetLeft());
			if (t1.HasLeft() && t2.HasLeft() && !t1.HasRight() && !t2.HasRight())
				return true;
			else
				return false;
		}

		
*/
		

		public static void Common(int[] arr)

        {
			int val_one;
			int one_counter=0;
			int val_two=0;
			int two_counter=0;

			val_one = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
				if (arr[i] == val_one)
					one_counter++;
				else
					val_two = arr[i];
					two_counter++;
            }
			if(one_counter > two_counter)
                for (int i = 0; i < arr.Length; i++)
                {
					if (arr[i] == val_one)
                        Console.WriteLine(i);
                }
			else
				for (int i = 0; i < arr.Length; i++)
				{
					if (arr[i] == val_two)
						Console.WriteLine(i);
				}
		}
		public static void SwipeTree<T>(BinNode<T> t)
        {
			//מחליף את ערכי העץ השמאליים לימין והימניים לשמאל
			BinNode<T> left;
			if (t == null)
				return;
			if (t.GetRight() == t.GetLeft())
				return;
			else
				left = t.GetLeft();
				t.SetLeft(t.GetRight());
				t.SetRight(left);
			SwipeTree(t.GetLeft());
			SwipeTree(t.GetRight());

        }
		public static int P176T14(BinNode<int> t)
        {
			if (t == null)
				return 0;
			 if (!t.HasLeft() && !t.HasRight())
				return 1 + P176T14(t.GetLeft()) + P176T14(t.GetRight());
			else
				return 0 + P176T14(t.GetLeft()) + P176T14(t.GetRight());

		}
		public static int P176T15(BinNode<int> t, int low, int high)
        {
			if (t == null)
				return 0;
			if (t.GetValue() < high && t.GetValue() > low)
				return 1 + P176T15(t.GetLeft(), low, high) + P176T15(t.GetRight(), low, high);
			else
				return 0 + P176T15(t.GetLeft(), low, high) + P176T15(t.GetRight(), low, high);
		}
		public static int P176T16(BinNode<int> t)
        {
			if (t.HasLeft() && t.HasRight())
				return t.GetValue() + P176T16(t.GetLeft()) + P176T16(t.GetRight());
			else
				return 0;

        }
		public static void TarV()
        {
            for (int i = 0; i < 10; i++)
            {
				Console.Write(i);
            }
            Console.WriteLine(" aa");
			for (int i = 0; i == 10; i++)
			{
				Console.Write(i);
			}
            Console.WriteLine(" dd");
			for (int i = 0; i == 10; i++)
			{
				Console.Write(i);
			}
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
			/*בדיקה האם עץ סימטרי*/
			if (bt == null)
				return false;
			bool simetri = (Math.Abs(TreeHeight(bt.GetLeft()) - TreeHeight(bt.GetRight()))) == 1;
			return simetri;

        }
		public static bool IsLeaf(BinNode<int> bt)
        {
			return !bt.HasLeft() && !bt.HasRight();
        }
		public static bool P177T22(BinNode<int> bt)
        {
			/*בודק אם לכל צומת יש 2 או 0 בנים*/
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
		public static void RemoveNode(Node<int> first, Node<int> p)
        {

        }
		public static void MoveNode(Node<int> first, Node<int> p)
        {
			//הנחה שהחוליה נמצאת ברשימה
			int x = p.GetValue();
			RemoveNode(first, p);
			Node<int> temp = new Node<int>(x);
			temp.SetNext(first);
			first = temp;
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
		public static Node<int> CloneList(Node<int> head)
        {
			Node<int> listCopy = null, pos = null;
			while (head != null)
            {
				while(pos != null && pos.HasNext())
                {
					pos = pos.GetNext();
                }
				if (pos == null)
				{
					pos = new Node<int>(head.GetValue());
					listCopy = pos;

				}
				else
					pos.SetNext(new Node<int>(head.GetValue()));
				head = head.GetNext();

            }
			return listCopy;
        }
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