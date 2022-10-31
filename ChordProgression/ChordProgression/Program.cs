using System;
using System.Linq;
using System.Collections.Generic;

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

        public Chords nextChord(){
            if (chordsCanGoTo == null)
            {
                Console.WriteLine("No Chords to go to. Please use setChordsCanGoTo method to set the chords");
                return null;
            }
            var rand = new Random();
            int next = rand.Next(chordsCanGoTo.Length);
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
            allMajorChordsStr[6] = "viid";
            Chords viiMaj = new Chords("vii°");

            Dictionary<string, Chords> chordMapMaj = new Dictionary<string, Chords>();



            IMaj.setChordsCanGoTo(new Chords[] { IMaj, iiMaj, iiiMaj, IVMaj, VMaj, viMaj, viiMaj });
            iiMaj.setChordsCanGoTo(new Chords[] { viiMaj, VMaj });
            iiiMaj.setChordsCanGoTo(new Chords[] { iiMaj, IVMaj, viMaj });
            IVMaj.setChordsCanGoTo(new Chords[] { IMaj, iiMaj, VMaj, viiMaj });
            VMaj.setChordsCanGoTo(new Chords[] { IMaj, viMaj });
            viMaj.setChordsCanGoTo(new Chords[] { IMaj, iiMaj, IVMaj, VMaj, viiMaj });
            viiMaj.setChordsCanGoTo(new Chords[] { IMaj, VMaj, viMaj });

            chordMapMaj.Add("I", IMaj);
            chordMapMaj.Add("ii", iiMaj);
            chordMapMaj.Add("iii", iiiMaj);
            chordMapMaj.Add("IV", IVMaj);
            chordMapMaj.Add("V", VMaj);
            chordMapMaj.Add("vi", viMaj);
            chordMapMaj.Add("vii", viiMaj);



            allMinorChordsStr[0] = "i";
            Chords iMin = new Chords("i");
            allMinorChordsStr[1] = "iid";
            Chords iiMin = new Chords("ii°");
            allMinorChordsStr[2] = "III";
            Chords IIIMin = new Chords("III");
            allMinorChordsStr[3] = "iv";
            Chords ivMin = new Chords("iv");
            allMinorChordsStr[4] = "V";
            Chords VMin = new Chords("V");
            allMinorChordsStr[5] = "VI";
            Chords VIMin = new Chords("VI");
            allMinorChordsStr[6] = "viid";
            Chords viiMin = new Chords("vii°");
            Dictionary<string, Chords> chordMapMin = new Dictionary<string, Chords>();

            iMin.setChordsCanGoTo(new Chords[] { iMin, iiMin, IIIMin, ivMin, VMin, VIMin, viiMin });
            iiMin.setChordsCanGoTo(new Chords[] { viiMin, VMin });
            IIIMin.setChordsCanGoTo(new Chords[] { iiMin, ivMin, VIMin });
            ivMin.setChordsCanGoTo(new Chords[] { iMin, iiMin, VMin, viiMin });
            VMin.setChordsCanGoTo(new Chords[] { iMin, VIMin });
            VIMin.setChordsCanGoTo(new Chords[] { iMin, iiMin, ivMin, VMin, viiMin });
            viiMin.setChordsCanGoTo(new Chords[] { iMin, VMin, VIMin });

            chordMapMin.Add("i", iMin);
            chordMapMin.Add("iid", iiMin);
            chordMapMin.Add("III", IIIMin);
            chordMapMin.Add("iv", ivMin);
            chordMapMin.Add("V", VMin);
            chordMapMin.Add("VI", VIMin);
            chordMapMin.Add("viid", viiMin);

            Boolean keepRunning = true;
            Console.WriteLine("Welcome to the random (but correct) Triad Chord Progression in Roman Numerals!");
            while (keepRunning)
            {
                int numOfChords = 0;
                Boolean isMajor = true;
                String startingChord = "";
                while (numOfChords == 0)
                {
                    Console.WriteLine("How many Chords do you want? Must have at least 3.");
                    numOfChords = Convert.ToInt32(Console.ReadLine());
                    if (numOfChords < 3)
                    {
                        Console.WriteLine("Please select a number greater then 3.");
                        numOfChords = 0;
                    }
                }
                Chords[] chordProg = new Chords[numOfChords];
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
                    Chords firstChord = chordMapMaj[startingChord];
                    chordProg[0] = firstChord;
                    Console.Write(chordProg[0].toString() + ", ");
                    for (int i = 1; i < numOfChords - 1; i++)
                    {
                        chordProg[i] = chordProg[i - 1].nextChord();
                        Console.Write(chordProg[i].toString() + ", ");
                    }
                    chordProg[numOfChords - 1] = chordProg[numOfChords - 2].nextChord();
                    Console.WriteLine(chordProg[numOfChords - 1].toString());

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
                    Chords firstChord = chordMapMin[startingChord];
                    chordProg[0] = firstChord;
                    Console.Write(chordProg[0].toString() + ", ");
                    for (int i = 1; i < numOfChords - 1; i++)
                    {
                        chordProg[i] = chordProg[i - 1].nextChord();
                        Console.Write(chordProg[i].toString() + ", ");
                    }
                    chordProg[numOfChords - 1] = chordProg[numOfChords - 2].nextChord();
                    Console.WriteLine(chordProg[numOfChords - 1].toString());
                }
                Console.WriteLine("Do you want to create another chord progression? Type 'Yes' for yes, or anything else for no.");
                String ans = Console.ReadLine();
                if (ans == "Yes" || ans == "yes" || ans == "Y" || ans == "y")
                {
                    continue;
                }
                else
                {
                    keepRunning = false;
                    Console.Write("Thank you!");
                }
            }
        }
    }
}
