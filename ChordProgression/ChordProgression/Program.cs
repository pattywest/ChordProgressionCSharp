using System;
using System.Linq;

namespace ChordProgression
{

    public class Chords
    {
        private String nameOfChord;
        private Chords[] chordsCanGoTo;

        public Chords(String name)
        {
            nameOfChord = name;
        }

        public void setChordsCanGoTo(Chords[] canGoTo)
        {
            chordsCanGoTo = canGoTo;
        }

        public String nextChord(){
            if (chordsCanGoTo == null)
            {
                Console.WriteLine("No Chords to go to. Please use setChordsCanGoTo method to set the chords");
                return null;
            }
            var rand = new Random();
            int next = rand.Next(chordsCanGoTo.Length + 1);
            return chordsCanGoTo[next].toString();
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
            String[] allMajorChordsStr = new string[7];
            String[] allMinorChordsStr = new string[7];
            allMajorChordsStr[0] = "I";
            Chords IMaj = new Chords("I");
            allMajorChordsStr[1] = "ii";
            Chords iiMaj = new Chords("ii");
            allMajorChordsStr[2] = "iii";
            Chords iiiMaj = new Chords("iii");
            allMajorChordsStr[3] = "IV";
            Chords IVMaj = new Chords("IV");
            allMajorChordsStr[4] = "V";
            Chords VMaj = new Chords("V");
            allMajorChordsStr[5] = "vi";
            Chords viMaj = new Chords("vi");
            allMajorChordsStr[6] = "vii°";
            Chords viiMaj = new Chords("vii°");


            IMaj.setChordsCanGoTo(new Chords[] { IMaj, iiMaj, iiiMaj, IVMaj, VMaj, viMaj, viiMaj });
            iiMaj.setChordsCanGoTo(new Chords[] { IMaj, viiMaj, VMaj });


            allMinorChordsStr[0] = "i";
            Chords iMin = new Chords("i");
            allMinorChordsStr[1] = "ii°";
            Chords iiMin = new Chords("ii°");
            allMinorChordsStr[2] = "III";
            Chords IIIMin = new Chords("III");
            allMinorChordsStr[3] = "iv";
            Chords ivMin = new Chords("iv");
            allMinorChordsStr[4] = "V";
            Chords VMin = new Chords("V");
            allMinorChordsStr[5] = "VI";
            Chords VIMin = new Chords("VI");
            allMinorChordsStr[6] = "vii°";
            Chords viiMin = new Chords("vii°");

            iMin.setChordsCanGoTo(new Chords[] { iMin, iiMin, IIIMin, ivMin, VMin, VIMin, viiMin });


            int numOfChords = 0;
            Boolean isMajor = true;
            String startingChord = "";
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
                Boolean selectedStarting = false;
                while (!selectedStarting)
                {
                    Console.WriteLine("Select a starting chord from the following.");
                    for (int i = 0; i < allMajorChordsStr.Length; i++)
                    {
                        Console.WriteLine(allMajorChordsStr[i]);
                    }
                    startingChord = Console.ReadLine();
                    if (!allMajorChordsStr.Contains(startingChord))
                    {
                        Console.WriteLine("Invalid Chord.");

                    }
                    else
                    {
                        selectedStarting = true;
                    }
                }
                
            }
            else
            {
                Boolean selectedStarting = false;
                while (!selectedStarting)
                {
                    Console.WriteLine("Select a starting chord from the following.");
                    for (int i = 0; i < allMinorChordsStr.Length; i++)
                    {
                        Console.WriteLine(allMinorChordsStr[i]);
                    }
                    startingChord = Console.ReadLine();
                    if (!allMinorChordsStr.Contains(startingChord))
                    {
                        Console.WriteLine("Invalid Chord.");

                    }
                    else
                    {
                        selectedStarting = true;
                    }
                }
            }

            Console.WriteLine(isMajor);
            Console.WriteLine(numOfChords);
            Console.WriteLine(IMaj.nextChord());
            Console.WriteLine(iMin.nextChord());



        }
    }
}
