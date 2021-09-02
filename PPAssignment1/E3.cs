using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace PPAssignment1
{
    public class E3
    {
        public void RunE3()
        {
            Thread producer = new Thread(() => Produce());
            Thread consumer = new Thread(() => Consume());
        }

     
    }
}