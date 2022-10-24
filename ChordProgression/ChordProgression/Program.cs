using System;

namespace ChordProgression
{

    public class Chords
    {
        private String nameOfChord;
        private String[] chordsCanGoTo;

        public Chords(String name ,String[] canGoTo)
        {
            nameOfChord = name;
            chordsCanGoTo = canGoTo;
        }

        public String nextChord(){
            var rand = new Random();
            int next = rand.Next(chordsCanGoTo.Length+1);
            return chordsCanGoTo[next];
        }

        public String toString()
        {
            return nameOfChord;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            String[] allMajorChords = new string[7];
            String[] allMinorChords = new string[7];
            allMajorChords[0] = "I";
            allMajorChords[1] = "ii";
            allMajorChords[2] = "iii";
            allMajorChords[3] = "IV";
            allMajorChords[4] = "V";
            allMajorChords[5] = "vi";
            allMajorChords[6] = "vii°";

            allMinorChords[0] = "i";
            allMinorChords[1] = "ii°";
            allMinorChords[2] = "III";
            allMinorChords[3] = "iv";
            allMinorChords[4] = "V";
            allMinorChords[5] = "VI";
            allMinorChords[6] = "vii°";

            Chords IMaj = new Chords("I", allMajorChords);
            Chords imin = new Chords("i", allMinorChords);


            int numOfChords = 0;
            Boolean isMajor = true;
            String startingChord;
            Console.WriteLine("Welcome to the random (but correct) Triad Chord Progression in Roman Numerals!");
            Console.WriteLine("How many Chords do you want?");
            numOfChords = Convert.ToInt32(Console.ReadLine());
            Boolean continueWhile = true;
            while (continueWhile)
            {
                Console.WriteLine("Do you want Major triads, or Minor triads? Type 'Major' or 'Minor' depending on what you want");
                String majorOrMinor = Console.ReadLine();
                if (majorOrMinor.Equals("Major") || majorOrMinor.Equals("major"))
                {
                    isMajor = true;
                    continueWhile = false;
                }
                else if (majorOrMinor.Equals("Minor") || majorOrMinor.Equals("minor"))
                {
                    isMajor = false;
                    continueWhile = false;
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }
            }
            if (isMajor)
            {
                Console.WriteLine("Select a starting chord from the following.");
                for (int i = 0; i < allMajorChords.Length; i++)
                {
                    Console.WriteLine(allMajorChords[i]);
                }

            }
            else
            {
                Console.WriteLine("Select a starting chord from the following.");
                for (int i = 0; i < allMinorChords.Length; i++)
                {
                    Console.WriteLine(allMinorChords[i]);
                }
            }

            Console.WriteLine(isMajor);
            Console.WriteLine(numOfChords);
            Console.WriteLine(IMaj.nextChord());
            Console.WriteLine(imin.nextChord());

        }
    }
}
