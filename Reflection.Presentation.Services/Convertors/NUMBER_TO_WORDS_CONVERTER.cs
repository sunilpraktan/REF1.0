using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Presentation.Services
{
    public class NUMBER_TO_WORDS_CONVERTER
    {
        #region . Amount In Word with currency # Format F01, Default.
        public static String AmountInWordsF01(String numb, string currency, string monitory_unit, string monitory_unit_prefix, string tail_word, string word_format, string word_prefix, string word_suffix)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (tail_word ?? "");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = monitory_unit_prefix;// just to separate whole numbers from points/cents  
                        endStr = monitory_unit + " " + endStr;//Cents  
                        //pointStr = ConvertDecimals(points); //use this if need to red 99 as Nine Nine 
                        pointStr = " " + ConvertWholeNumber(points); //use this if need to red 99 as Ninety Nine 
                    }
                }
                val = (word_prefix ?? "") + " " + String.Format("{0} {1} {2} {3} {4}", ConvertWholeNumber(wholeNo).Trim(), (word_suffix ?? ""), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }
        private static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        if (Number.Substring(0, pos) != "000" && Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros
                        //if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }
        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }
        #endregion

        #region . Amount In Word with currency # Format F02.
        public string AmountInWords(decimal Num, string currency, string monitory_unit, string monitory_unit_prefix, string tail_word,string word_format) // Default is null, F01: indian, use lakh, crore , F02: billion, million,hundred thousand...not use of lakh or crore,
        {
            string returnValue;
            //I have created this function for converting amount in indian rupees (INR).
            //You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.


            string strNum;
            string strNumDec;
            string StrWord;
            strNum = Num.ToString();


            if (strNum.IndexOf(".") + 1 != 0)
            {
                strNumDec = strNum.Substring(strNum.IndexOf(".") + 2 - 1);


                if (strNumDec.Length == 1)
                {
                    strNumDec = strNumDec + "0";
                }
                if (strNumDec.Length > 2)
                {
                    strNumDec = strNumDec.Substring(0, 2);
                }

                strNum = strNum.Substring(0, strNum.IndexOf(".") + 0);
                StrWord = ((double.Parse(strNum) == 1) ? " " + currency + " " : " " + currency + " ") + NumToWord((decimal)(double.Parse(strNum))) + ((double.Parse(strNumDec) > 0) ? ((string.IsNullOrEmpty(monitory_unit_prefix) ? "" : " " + monitory_unit_prefix) + (string.IsNullOrEmpty(monitory_unit) ? "" : " " + monitory_unit) + cWord3((decimal)(double.Parse(strNumDec)))) : "");
                //StrWord =  NumToWord((decimal)(double.Parse(strNum))) ;
            }
            else
            {
                StrWord = ((double.Parse(strNum) == 1) ? " " + currency + " " : " " + currency + " ") + NumToWord((decimal)(double.Parse(strNum)));
                //StrWord =NumToWord((decimal)(double.Parse(strNum)));
            }
            returnValue = StrWord + " " + (tail_word ?? "");
            return returnValue;
        }
        static public string NumToWord(decimal Num)
        {
            string returnValue;


            //I divided this function in two part.
            //1. Three or less digit number.
            //2. more than three digit number.
            string strNum;
            string StrWord;
            strNum = Num.ToString();


            if (strNum.Length <= 3)
            {
                StrWord = cWord3((decimal)(double.Parse(strNum)));
            }
            else
            {
                StrWord = cWordG3((decimal)(double.Parse(strNum.Substring(0, strNum.Length - 3)))) + " " + cWord3((decimal)(double.Parse(strNum.Substring(strNum.Length - 2 - 1))));
            }
            returnValue = StrWord;
            return returnValue;
        }
        static public string cWord3(decimal Num)
        {
            string returnValue;
            //1. Three or less digit number.
            string strNum = "";
            string StrWord = "";
            string readNum = "";
            if (Num < 0)
            {
                Num = Num * -1;
            }
            strNum = Num.ToString();


            if (strNum.Length == 3)
            {
                readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 1)));
                StrWord = retWord(decimal.Parse(readNum)) + " Hundred";
                strNum = strNum.Substring(1, strNum.Length - 1);
            }


            if (strNum.Length <= 2)
            {
                if (double.Parse(strNum) >= 0 && double.Parse(strNum) <= 20)
                {
                    StrWord = StrWord + " " + retWord((decimal)(double.Parse(strNum)));
                }
                else
                {
                    StrWord = StrWord + " " + retWord((decimal)(System.Convert.ToDouble(strNum.Substring(0, 1) + "0"))) + " " + retWord((decimal)(double.Parse(strNum.Substring(1, 1))));
                }
            }


            strNum = Num.ToString();
            returnValue = StrWord;
            return returnValue;
        }
        static public string cWordG3(decimal Num)
        {
            string returnValue;
            //2. more than three digit number.
            string strNum = "";
            string StrWord = "";
            string readNum = "";
            strNum = Num.ToString();
            if (strNum.Length % 2 != 0)
            {
                readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 1)));
                if (readNum != "0")
                {
                    StrWord = retWord(decimal.Parse(readNum));
                    readNum = System.Convert.ToString(double.Parse("1" + strReplicate("0", strNum.Length - 1) + "000"));
                    StrWord = StrWord + " " + retWord(decimal.Parse(readNum));
                }
                strNum = strNum.Substring(1);
            }
            while (!System.Convert.ToBoolean(strNum.Length == 0))
            {
                readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 2)));
                if (readNum != "0")
                {
                    StrWord = StrWord + " " + cWord3(decimal.Parse(readNum));
                    readNum = System.Convert.ToString(double.Parse("1" + strReplicate("0", strNum.Length - 2) + "000"));
                    StrWord = StrWord + " " + retWord(decimal.Parse(readNum));
                }
                strNum = strNum.Substring(2);
            }
            returnValue = StrWord;
            return returnValue;
        }
        static public string strReplicate(string str, int intD)
        {
            string returnValue;
            //This fucntion padded "0" after the number to evaluate hundred, thousand and on....
            //using this function you can replicate any Charactor with given string.
            int i;
            returnValue = "";
            for (i = 1; i <= intD; i++)
            {
                returnValue = returnValue + str;
            }
            return returnValue;
        }
        static public string retWord(decimal Num)
        {
            string returnValue;
            //This two dimensional array store the primary word convertion of number.
            returnValue = "";
            object[,] ArrWordList = new object[,] { { 0, "" }, { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" }, { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" }, { 20, "Twenty" }, { 30, "Thirty" }, { 40, "Forty" }, { 50, "Fifty" }, { 60, "Sixty" }, { 70, "Seventy" }, { 80, "Eighty" }, { 90, "Ninety" }, { 100, "Hundred" }, { 1000, "Thousand" }, { 100000, "Lakh" }, { 10000000, "Crore" }, { 1000000000, "Billion" } };

            int i;
            for (i = 0; i <= (ArrWordList.Length - 1); i++)
            {
                if (Num == System.Convert.ToDecimal(ArrWordList[i, 0]))
                {
                    returnValue = (string)(ArrWordList[i, 1]);
                    break;
                }
            }
            return returnValue;
        }
        #endregion
    }
}
