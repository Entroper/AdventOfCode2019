using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Problem2
    {
        public static int Part1()
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

        public static (int x, int y) Part2()
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
