using System;
using System.Collections.Generic;
using System.Linq;

namespace OrganizingLottery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var segmentInput = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();
            var allPoints = new List<Point>();
            var output = new List<long>();
            for (int i = 0; i < segmentInput[0]; i++)
            {
                var segment = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();

                allPoints.Add(new Point() { Type = Point.Types.SegmentStart, Value = segment[0], Precedence = 0 });
                allPoints.Add(new Point() { Type = Point.Types.SegmentEnd, Value = segment[1], Precedence = 2 });
            }

            var points = Console.ReadLine().Split(' ').Select(x => long.Parse(x)).ToList();

            for (int i = 0; i < points.Count; i++)
            {
                long point = points[i];
                allPoints.Add(new Point() { Type = Point.Types.Point, Value = point, Index = i, Precedence = 1 });
            }

            allPoints = allPoints.OrderBy(x => x.Value).ThenBy(x => x.Precedence).ToList();

            int counter = 0;
            for (int i=0; i< allPoints.Count; i++)
            {
                var point = allPoints[i];
                if (point.Type == Point.Types.SegmentStart)
                {
                    counter++;
                }
                else if (point.Type == Point.Types.SegmentEnd)
                {
                    counter--;
                }
                else
                {
                    points[point.Index] = counter;
                }
            }

            Console.WriteLine(String.Join(" ", points));
        }

        static List<List<long>> FindSegments(long point, List<List<long>> input)
        {
            var output = new List<List<long>>();

            for (int i = 0; i < input.Count; i++)
            {
                List<long> segment = input[i];
                if (point >= segment[0] && point <= segment[1])
                {
                    output.Add(segment);
                }
            }

            return output;
        }

        public class Point
        {
            public static class Types {
                public const string Point = "Point";
                public const string SegmentStart = "SegmentStart";
                public const string SegmentEnd = "SegmentEnd";
            }
            public string Type { get; set; }
            public long Value { get; set; }
            public int Index { get; set; }
            public int Precedence { get; set; }
        }
    }
}
