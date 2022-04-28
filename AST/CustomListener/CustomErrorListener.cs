using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Sharpen;
public class CustomErrorListener : BaseErrorListener
{
        
        public CustomErrorListener(string _filename)
        {
                this.filename=_filename;
        }
        string filename;
        public override void ReportAmbiguity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, bool exact, BitSet ambigAlts, ATNConfigSet configs)
        {
                //Console.Write("4");
                // do nothing;
        }
        public override void ReportAttemptingFullContext(Parser recognizer, DFA dfa, int startIndex, int stopIndex, BitSet conflictingAlts, SimulatorState conflictState)
        {
              //  Console.Write("3");
                // do nothing;
        }
        public override void ReportContextSensitivity(Parser recognizer, DFA dfa, int startIndex, int stopIndex, int prediction, SimulatorState acceptState)
        {
            //    Console.Write("2");
                // do nothing;
        }
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
             //  Console.Write("1");
                
                // do nothing;

                Console.WriteLine(filename);
                Console.WriteLine($"Symbol {offendingSymbol} at ({line},{charPositionInLine} : {msg})");
        }
}