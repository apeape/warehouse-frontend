using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WarehouseFrontend
{
    public static class Util
    {
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

        /// <summary>
        ///  RetryAction( () => SomeFunctionThatCanFail(), numRetries, timeOut );
        /// </summary>
        public static TResult RetryAction<TResult>(Func<TResult> action, int numRetries, int retryTimeout)
        {
            if (action == null)
                throw new ArgumentNullException("action"); // slightly safer...

            do
            {
                try { return action(); }
                catch
                {
                    if (numRetries <= 0) throw;  // improved to avoid silent failure
                    else
                    {
                        Thread.Sleep(retryTimeout);
                        Console.WriteLine("retrying " + action.Method.Name.ToString());
                    }
                }
            } while (numRetries-- > 0);

            return default(TResult);
        }
    }
}
