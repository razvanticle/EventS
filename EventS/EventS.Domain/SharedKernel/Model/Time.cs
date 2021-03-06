﻿namespace EventS.Domain.SharedKernel.Model
{
    public class Time : ValueObjectBase<Time>
    {
        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public int Hour { get; }

        public int Minute { get; }
    }
}