using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;


public class Point {

	public bool isBoundable { get; set; } = false; 
	public bool isAvailible { get; set; }

	public int X {get; set;} 
	public int Y {get; set;} 
	
	public void GeneratePoint(int x, int y){
		Point point = new Point()
		{ //Unity Clone in x and y
			X = x, // nécessaire in Unity 
			Y = y
		};
	}
}

public class Node : Point {
	public Point FirstPoint  {get; private set;}
	public Point SecondPoint{get; private set;}

	public void CreateNode(Point firstPoint, Point secondPoint) {
		Node node = new Node()
		{
			FirstPoint = firstPoint,
			SecondPoint = secondPoint
		};
	}

	public static IList<Node> nodes = new IList<Node>();

	public static bool CheckNode(Point firstPoint, Point secondPoint)
    {
		Node tempNode = new Node() {
			FirstPoint = firstPoint, 
			SecondPoint = secondPoint
		};

		Node tempNodeReversed = new Node()
		{
			FirstPoint = secondPoint,
			SecondPoint = firstPoint 
		};

		foreach(var item in nodes)

        {
			if ((tempNode == item) || (tempNodeReversed == item))
			{
				~tempNode();
				~tempNodeReversed();
				return true;
			}	
        }
		~tempNode();
		~tempNodeReversed();
		return false; 
    }
}

public static Point[][] MapPoints { get; set; }

public class Map : Point {


	// x = cols, y = rows 
	//Map Generator
	public static Point[][] MapGenerator(int x, int y, Point[][] points)
    {
		for(int i = 0; i < x; i++)
        {
			for(int j = 0; j < y; j++)
			{
				points[x][y] = GeneratePoint(x, y); 
			}
        }
		return points; 
    }

	public void MoveUp_Preview(GameObject ball, Point[][] MapPoints)
	{
		// We will use the override and abstract class for GameObject methods

		currentPosition_X = ball.GetPositionIndex_X();
		
		currentPosition_Y = ball.GetPositionIndex_Y();
		if (MapPoints[currentPosition_X + 1][currentPosition_Y].isAvailible == true && (currentPosition_X + 1 < MapPoints.GetLength(0)))
		{
			ball.SetMove(1, 0); 
			//Move x + 1 
		}
	}
}