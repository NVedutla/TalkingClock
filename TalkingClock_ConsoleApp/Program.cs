using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace TalkingClock_ConsoleApp

{

    class Program

    {

        static void Main(string[] args)

        {

            //User enters time in HH:MM or HH.MM format

            Console.Write("Please enter time :-");



            //Read the time entered by user





            string displayTime = string.Empty;

            while (true)

            {

                try

                {

                    decimal number = Convert.ToDecimal(Console.ReadLine().Replace(":", "."));

                    displayTime = DisplayTime(number);

                    Console.WriteLine(displayTime);



                    break;

                }

                catch (Exception e)

                {

                    Console.Write("Invalid time,Please enter correct time :");

                }

            }



            Console.ReadLine();



        }



        //This method returns the output text and checks for time being on the hour, less than half past or more than half past

        public static string DisplayTime(decimal uTime)

        {

            string[] number = uTime.ToString().Split('.');

            int hour = Convert.ToInt16(number[0]);

            int min = Convert.ToInt16(number[1]);



            if (hour > 12)

            {

                hour -= 12;

            }







            string[] nums = { "zero", "one", "two", "three", "four",

                            "five", "six", "seven", "eight", "nine",

                            "ten", "eleven", "twelve", "thirteen",

                            "fourteen", "fifteen", "sixteen", "seventeen",

                            "eighteen", "nineteen", "twenty", "twenty one",

                            "twenty two", "twenty three", "twenty four",

                            "twenty five", "twenty six", "twenty seven",

                            "twenty eight", "twenty nine",

                        };



            //check for mins    

            if (min > 0)

            {

                string displayMins = returnHReadableMins(min, nums);

                //check if hour is after half past

                if (min > 30)

                {

                    //check for timings between 12:31 and 12:58

                    if (hour == 12)

                    {

                        return displayMins + nums[(hour % 2) + 1];

                    }

                    else

                    {

                        return displayMins + nums[hour + 1];

                    }

                }

                //check if hour is before half past

                else

                {

                    return displayMins + nums[hour];

                }

            }

            else

            {

                return nums[hour] + " O'clock";

            }

        }



        //This method returns a string with text - "five past", "ten past", "half past"

        public static string returnHReadableMins(int minutes, string[] nums)

        {

            string response = "";



            if (minutes == 1)

            {

                response = "One minute past ";

            }

            else if (minutes == 15)

            {

                response = "Quarter past ";

            }

            else if (minutes == 30)

            {

                response = "Half past ";

            }

            else if (minutes == 45)

            {

                response = "Quarter to ";

            }

            else if (minutes == 59)

            {

                response = "One minute to ";

            }

            else if (minutes <= 30)

            {

                response = nums[minutes] + " past ";

            }

            else if (minutes > 30)

            {

                response = nums[60 -

                    minutes] + " minutes to ";

            }



            return response;

        }

    }

}
