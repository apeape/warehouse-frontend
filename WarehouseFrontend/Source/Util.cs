using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

namespace WarehouseFrontend
{
    public static class Util
    {
        public const int bytesToKibibytes = 1024;
        public const double kibibytesToMegabits = 128;

        public static string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "TB", "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        public static TResult RetryAction<TResult>(Func<TResult> action, int numRetries, int retryTimeout)
        {
            return RetryAction<TResult>(action, null, numRetries, retryTimeout);
        }
        /// <summary>
        ///  RetryAction( () => SomeFunctionThatCanFail(), ... );
        /// </summary>
        public static TResult RetryAction<TResult>(Func<TResult> action, string actionName, int numRetries, int retryTimeout)
        {
            if (action == null)
                throw new ArgumentNullException("action"); // slightly safer...

            do
            {
                try { return action(); }
                catch (JsonRpcException jre)
                {
                    if (actionName != null)
                        Console.WriteLine(actionName + " failed: " + jre.Message);
                    else
                        Console.WriteLine("json-rpc call failed: " + jre.Message);
                    throw;
                }
                catch (Exception e)
                {
                    if (numRetries <= 0) throw;  // improved to avoid silent failure
                    else
                    {
                        if (actionName != null)
                            Console.WriteLine(actionName + " failed: " + e.Message + ", retrying...");
                        else
                            Console.WriteLine("failed: " + e.Message + ", retrying...");

                        Thread.Sleep(retryTimeout);
                    }
                }
            } while (numRetries-- > 0);

            return default(TResult);
        }

        public static string ArrayToStringGeneric<T>(IList<T> array, string delimeter)
        {
            string outputString = "";

            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] is IList)
                {
                    //Recursively convert nested arrays to string
                    outputString += ArrayToStringGeneric<T>((IList<T>)array[i], delimeter);
                }
                else
                {
                    outputString += array[i];
                }

                if (i != array.Count - 1)
                    outputString += delimeter;
            }

            return outputString;
        }
    }
}
