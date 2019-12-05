using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = Problem2Part2();
            
            Console.WriteLine("Answer: {0}", answer);
        }

        static int Problem1Part1()
        {
            var lines = File.ReadAllLines("inputs/Problem1.txt");
            var masses = lines.Select(line => int.Parse(line));

            return masses.Sum(mass => mass / 3 - 2);
        }

        static int Problem1Part2()
        {
            var lines = File.ReadAllLines("inputs/Problem1.txt");
            var masses = lines.Select(line => int.Parse(line));

            return masses.Sum(mass => GetTotalFuel(mass));
        }

        static int Problem2Part1()
        {
            // Read program.
            var input = File.ReadAllText("inputs/Problem2.txt");
            var inputs = input.Split(',');
            var program = inputs.Select(i => int.Parse(i)).ToArray();

            // Set 1202 alarm.
            program[1] = 12;
            program[2] = 2;

            RunProgram(program);

            return program[0];
        }

        static (int x, int y) Problem2Part2()
        {
            // Read program.
            var input = File.ReadAllText("inputs/Problem2.txt");
            var inputs = input.Split(',');
            var sourceProgram = inputs.Select(i => int.Parse(i)).ToArray();

            int x = 0, y = 0;
            int[] program;
            do
            {
                program = sourceProgram.ToArray(); // make a copy
                program[1] = x;
                program[2] = y;

                RunProgram(program);
                if (program[0] == 19690720)
                    break;

                x++;
                if (x > 99)
                {
                    x = 0;
                    y++;
                }

            } while (y <= 99);

            return (x, y);
        }

        static int GetTotalFuel(int mass)
        {
            int total = 0;
            while (mass > 0)
            {
                mass /= 3;
                mass -= 2;
                if (mass > 0)
                    total += mass;
            }

            return total;
        }

        private static void RunProgram(int[] program)
        {
            int pc = 0; // program counter
            OpCode operation;
            do
            {
                operation = (OpCode)program[pc++];
                int read1 = program[pc++];
                int read2 = program[pc++];
                int write = program[pc++];

                switch (operation)
                {
                    case OpCode.Add:
                        program[write] = program[read1] + program[read2];
                        break;

                    case OpCode.Multiply:
                        program[write] = program[read1] * program[read2];
                        break;

                    case OpCode.Halt:
                        break;

                    default:
                        throw new InvalidOperationException("Unrecognized opcode " + ((int)operation).ToString());
                }
            } while (operation != OpCode.Halt);
        }
    }
}
