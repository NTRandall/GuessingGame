using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessingGame.Service
{
    public class BasicRandomNumberGenerator
        : IRandomNumberGenerator
    {
        public int GetNext(int min, int max)
        {
           return new Random().Next(min, max);
        }
    }
}