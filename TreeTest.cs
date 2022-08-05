using System;
using System.Collections;
namespace Solution
{
   

    public class Node
    {

        public char Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }


    }


    public class Solution
    {
        public static void Main(string[] args)
        {
            // previously define the Trees values 
            IsTargetLevelHanagram(new Node(), new Node(), 3);
        }

        private static void GetTreesStringFromSpecificLevel(Queue<Node> soure, Queue<Node> targetToCheck,
            int levelToCheck, int currentLevel,ref string t1Values, ref string t2Values)
        {
            //We are in the level of childs
            if (currentLevel == levelToCheck)
            {
                while (soure.Any())
                {
                    //Getting all the chars from nodes on the Level to check on Tree 1
                    t1Values += t1Values + soure.Dequeue().Value;
                }
                while (targetToCheck.Any())
                {
                    //Getting all the chars from nodes on the Level to check on Tree 2 (Target)
                    t2Values += t1Values + soure.Dequeue().Value;
                }

                //Here I have the strings from both Trees
                return;
            }

            Queue<Node> soureLevelChilds = new Queue<Node>();
            Queue<Node> targetLevelChildToCheck = new Queue<Node>();
            //To get the level before of level to check (Parent of Level to check)
            while (currentLevel != levelToCheck )
            {
                while (soure.Any())
                {
                    //Inserting all childs of current level from Source Tree
                    Node tmpNode = soure.Dequeue();
                    if (tmpNode.Right != null)
                        soureLevelChilds.Enqueue(tmpNode.Right);
                    if (tmpNode.Left != null)
                        soureLevelChilds.Enqueue(tmpNode.Left);
                }
                while (targetToCheck.Any())
                {
                    //Inserting all childs of current level from Target Tree
                    Node tmpNode = targetToCheck.Dequeue();
                    if (tmpNode.Right != null)
                        targetLevelChildToCheck.Enqueue(tmpNode.Right);
                    if (tmpNode.Left != null)
                        targetLevelChildToCheck.Enqueue(tmpNode.Left);
                }

                GetTreesStringFromSpecificLevel(soureLevelChilds, targetLevelChildToCheck,
                    levelToCheck, currentLevel++, ref t1Values, ref t2Values);

            }
        }

        public static bool IsTargetLevelHanagram(Node soure, Node targetToCheck, int levelToCheck)
        {  

            if (levelToCheck == 1)
                return soure.Value.Equals(targetToCheck.Value);

            Queue<Node> tree1 = new Queue<Node>();
            Queue<Node> tree2 = new Queue<Node>();

            //Defining initial queues 
            tree1.Enqueue(soure);
            tree2.Enqueue(targetToCheck);
            string stringFromTree1 = "";
            string stringFromTree2 = "";
            //Setting  the current level as 0 (Root)
            GetTreesStringFromSpecificLevel(tree1, tree2, levelToCheck, 0, ref stringFromTree1, ref stringFromTree2);

            //This method sort both strings and if they are equals , then both trees are anagrams.
            return IsHanagram(stringFromTree1, stringFromTree2);
        }

        //I didnt implement the sort of the 2 strings and compare to focus on the traverse of the Trees.
        public static bool IsHanagram(string tre1String, string tree2String)
        {
            return true;
        }
    }


}
