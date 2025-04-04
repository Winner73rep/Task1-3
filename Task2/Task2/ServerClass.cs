using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task2
{
    public static class ServerClass
    {
        private static int count = 0;
        private static readonly ReaderWriterLockSlim locker = new ReaderWriterLockSlim();     
        public static int GetCount()
        {
            locker.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                locker.ExitReadLock();
            }
        }
        public static void AddToCount(int value)
        {
            locker.EnterWriteLock();
            try
            {
                count += value;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
