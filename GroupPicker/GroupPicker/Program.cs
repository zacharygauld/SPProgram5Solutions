using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            PickGroups(5, 20);
            Console.ReadKey();
        }

        /// <summary>
        /// Create random groups of students based on the wanted size of a group and the size of the class
        /// </summary>
        /// <param name="groupSize">How many students to assign to a group</param>
        /// <param name="classSize">How many students in the class</param>
        static void PickGroups(int groupSize, int classSize)
        {
            // generate an RNG and lists to hold a list of students in the class as well as a group list
            Random rng = new Random();
            List<int> classList = new List<int>();
            List<int> groupList = new List<int>();

            // add data into the classList
            for (int i = 1; i <= classSize; i++ )
            {
                classList.Add(i);
            }

            // loop until all students have been assigned to a group
            while (classList.Count() > 0)
            {
                // generate a random number to associate a student to take from classList
                int randomStudent = rng.Next(0, classList.Count());
                // assign a variable to classList's index to store the data in that element
                int selectedStudent = classList[randomStudent];
                // remove the element chosen from classList
                classList.RemoveAt(randomStudent);
                // add the element to the groupList
                groupList.Add(selectedStudent);

                // once the size of the groupList equals the size of groupSize
                if (groupList.Count() == groupSize)
                {
                    // output the students in a group
                    Console.WriteLine("GROUP:");
                    foreach (int student in groupList)
                    {
                        Console.WriteLine(student);
                    }
                    Console.WriteLine();
                    // clear the groupList for use again for the next go around
                    groupList.Clear();
                }
            }

        }
    }
}
