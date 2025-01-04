//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from d:/Anul2/LFC/Compiler_LFC/Compiler_LFC/Grammar.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class GrammarLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		IF=1, ELSE=2, FOR=3, WHILE=4, RETURN=5, PLUS=6, MINUS=7, MUL=8, DIV=9, 
		MOD=10, LT=11, GT=12, LE=13, GE=14, EQ=15, NEQ=16, AND=17, OR=18, NOT=19, 
		INCREMENT=20, DECREMENT=21, ASSIGN=22, ADD_ASSIGN=23, SUB_ASSIGN=24, MUL_ASSIGN=25, 
		DIV_ASSIGN=26, MOD_ASSIGN=27, LPAREN=28, RPAREN=29, LBRACE=30, RBRACE=31, 
		COMMA=32, SEMICOLON=33, INT=34, FLOAT=35, DOUBLE=36, STRING=37, VOID=38, 
		IDENTIFIER=39, NUMBER=40, STRING_LITERAL=41, COMMENT=42, MULTILINE_COMMENT=43, 
		WS=44, LINE_COMMENT=45, BLOCK_COMMENT=46;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"IF", "ELSE", "FOR", "WHILE", "RETURN", "PLUS", "MINUS", "MUL", "DIV", 
		"MOD", "LT", "GT", "LE", "GE", "EQ", "NEQ", "AND", "OR", "NOT", "INCREMENT", 
		"DECREMENT", "ASSIGN", "ADD_ASSIGN", "SUB_ASSIGN", "MUL_ASSIGN", "DIV_ASSIGN", 
		"MOD_ASSIGN", "LPAREN", "RPAREN", "LBRACE", "RBRACE", "COMMA", "SEMICOLON", 
		"INT", "FLOAT", "DOUBLE", "STRING", "VOID", "IDENTIFIER", "NUMBER", "STRING_LITERAL", 
		"COMMENT", "MULTILINE_COMMENT", "WS", "LINE_COMMENT", "BLOCK_COMMENT"
	};


	public GrammarLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public GrammarLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'if'", "'else'", "'for'", "'while'", "'return'", "'+'", "'-'", 
		"'*'", "'/'", "'%'", "'<'", "'>'", "'<='", "'>='", "'=='", "'!='", "'&&'", 
		"'||'", "'!'", "'++'", "'--'", "'='", "'+='", "'-='", "'*='", "'/='", 
		"'%='", "'('", "')'", "'{'", "'}'", "','", "';'", "'int'", "'float'", 
		"'double'", "'string'", "'void'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "IF", "ELSE", "FOR", "WHILE", "RETURN", "PLUS", "MINUS", "MUL", 
		"DIV", "MOD", "LT", "GT", "LE", "GE", "EQ", "NEQ", "AND", "OR", "NOT", 
		"INCREMENT", "DECREMENT", "ASSIGN", "ADD_ASSIGN", "SUB_ASSIGN", "MUL_ASSIGN", 
		"DIV_ASSIGN", "MOD_ASSIGN", "LPAREN", "RPAREN", "LBRACE", "RBRACE", "COMMA", 
		"SEMICOLON", "INT", "FLOAT", "DOUBLE", "STRING", "VOID", "IDENTIFIER", 
		"NUMBER", "STRING_LITERAL", "COMMENT", "MULTILINE_COMMENT", "WS", "LINE_COMMENT", 
		"BLOCK_COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Grammar.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static GrammarLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,46,302,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,2,
		1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,1,4,1,4,1,5,1,
		5,1,6,1,6,1,7,1,7,1,8,1,8,1,9,1,9,1,10,1,10,1,11,1,11,1,12,1,12,1,12,1,
		13,1,13,1,13,1,14,1,14,1,14,1,15,1,15,1,15,1,16,1,16,1,16,1,17,1,17,1,
		17,1,18,1,18,1,19,1,19,1,19,1,20,1,20,1,20,1,21,1,21,1,22,1,22,1,22,1,
		23,1,23,1,23,1,24,1,24,1,24,1,25,1,25,1,25,1,26,1,26,1,26,1,27,1,27,1,
		28,1,28,1,29,1,29,1,30,1,30,1,31,1,31,1,32,1,32,1,33,1,33,1,33,1,33,1,
		34,1,34,1,34,1,34,1,34,1,34,1,35,1,35,1,35,1,35,1,35,1,35,1,35,1,36,1,
		36,1,36,1,36,1,36,1,36,1,36,1,37,1,37,1,37,1,37,1,37,1,38,1,38,5,38,219,
		8,38,10,38,12,38,222,9,38,1,39,4,39,225,8,39,11,39,12,39,226,1,39,1,39,
		4,39,231,8,39,11,39,12,39,232,3,39,235,8,39,1,40,1,40,5,40,239,8,40,10,
		40,12,40,242,9,40,1,40,1,40,1,41,1,41,1,41,1,41,5,41,250,8,41,10,41,12,
		41,253,9,41,1,41,1,41,1,42,1,42,1,42,1,42,5,42,261,8,42,10,42,12,42,264,
		9,42,1,42,1,42,1,42,1,42,1,42,1,43,4,43,272,8,43,11,43,12,43,273,1,43,
		1,43,1,44,1,44,1,44,1,44,5,44,282,8,44,10,44,12,44,285,9,44,1,44,1,44,
		1,45,1,45,1,45,1,45,5,45,293,8,45,10,45,12,45,296,9,45,1,45,1,45,1,45,
		1,45,1,45,3,240,262,294,0,46,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,
		10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,
		22,45,23,47,24,49,25,51,26,53,27,55,28,57,29,59,30,61,31,63,32,65,33,67,
		34,69,35,71,36,73,37,75,38,77,39,79,40,81,41,83,42,85,43,87,44,89,45,91,
		46,1,0,5,3,0,65,90,95,95,97,122,4,0,48,57,65,90,95,95,97,122,1,0,48,57,
		2,0,10,10,13,13,3,0,9,10,13,13,32,32,311,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,
		0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,
		17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,
		0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,
		0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,
		1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,
		0,0,61,1,0,0,0,0,63,1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,
		1,0,0,0,0,73,1,0,0,0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,
		0,0,83,1,0,0,0,0,85,1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,0,0,91,1,0,0,0,1,93,
		1,0,0,0,3,96,1,0,0,0,5,101,1,0,0,0,7,105,1,0,0,0,9,111,1,0,0,0,11,118,
		1,0,0,0,13,120,1,0,0,0,15,122,1,0,0,0,17,124,1,0,0,0,19,126,1,0,0,0,21,
		128,1,0,0,0,23,130,1,0,0,0,25,132,1,0,0,0,27,135,1,0,0,0,29,138,1,0,0,
		0,31,141,1,0,0,0,33,144,1,0,0,0,35,147,1,0,0,0,37,150,1,0,0,0,39,152,1,
		0,0,0,41,155,1,0,0,0,43,158,1,0,0,0,45,160,1,0,0,0,47,163,1,0,0,0,49,166,
		1,0,0,0,51,169,1,0,0,0,53,172,1,0,0,0,55,175,1,0,0,0,57,177,1,0,0,0,59,
		179,1,0,0,0,61,181,1,0,0,0,63,183,1,0,0,0,65,185,1,0,0,0,67,187,1,0,0,
		0,69,191,1,0,0,0,71,197,1,0,0,0,73,204,1,0,0,0,75,211,1,0,0,0,77,216,1,
		0,0,0,79,224,1,0,0,0,81,236,1,0,0,0,83,245,1,0,0,0,85,256,1,0,0,0,87,271,
		1,0,0,0,89,277,1,0,0,0,91,288,1,0,0,0,93,94,5,105,0,0,94,95,5,102,0,0,
		95,2,1,0,0,0,96,97,5,101,0,0,97,98,5,108,0,0,98,99,5,115,0,0,99,100,5,
		101,0,0,100,4,1,0,0,0,101,102,5,102,0,0,102,103,5,111,0,0,103,104,5,114,
		0,0,104,6,1,0,0,0,105,106,5,119,0,0,106,107,5,104,0,0,107,108,5,105,0,
		0,108,109,5,108,0,0,109,110,5,101,0,0,110,8,1,0,0,0,111,112,5,114,0,0,
		112,113,5,101,0,0,113,114,5,116,0,0,114,115,5,117,0,0,115,116,5,114,0,
		0,116,117,5,110,0,0,117,10,1,0,0,0,118,119,5,43,0,0,119,12,1,0,0,0,120,
		121,5,45,0,0,121,14,1,0,0,0,122,123,5,42,0,0,123,16,1,0,0,0,124,125,5,
		47,0,0,125,18,1,0,0,0,126,127,5,37,0,0,127,20,1,0,0,0,128,129,5,60,0,0,
		129,22,1,0,0,0,130,131,5,62,0,0,131,24,1,0,0,0,132,133,5,60,0,0,133,134,
		5,61,0,0,134,26,1,0,0,0,135,136,5,62,0,0,136,137,5,61,0,0,137,28,1,0,0,
		0,138,139,5,61,0,0,139,140,5,61,0,0,140,30,1,0,0,0,141,142,5,33,0,0,142,
		143,5,61,0,0,143,32,1,0,0,0,144,145,5,38,0,0,145,146,5,38,0,0,146,34,1,
		0,0,0,147,148,5,124,0,0,148,149,5,124,0,0,149,36,1,0,0,0,150,151,5,33,
		0,0,151,38,1,0,0,0,152,153,5,43,0,0,153,154,5,43,0,0,154,40,1,0,0,0,155,
		156,5,45,0,0,156,157,5,45,0,0,157,42,1,0,0,0,158,159,5,61,0,0,159,44,1,
		0,0,0,160,161,5,43,0,0,161,162,5,61,0,0,162,46,1,0,0,0,163,164,5,45,0,
		0,164,165,5,61,0,0,165,48,1,0,0,0,166,167,5,42,0,0,167,168,5,61,0,0,168,
		50,1,0,0,0,169,170,5,47,0,0,170,171,5,61,0,0,171,52,1,0,0,0,172,173,5,
		37,0,0,173,174,5,61,0,0,174,54,1,0,0,0,175,176,5,40,0,0,176,56,1,0,0,0,
		177,178,5,41,0,0,178,58,1,0,0,0,179,180,5,123,0,0,180,60,1,0,0,0,181,182,
		5,125,0,0,182,62,1,0,0,0,183,184,5,44,0,0,184,64,1,0,0,0,185,186,5,59,
		0,0,186,66,1,0,0,0,187,188,5,105,0,0,188,189,5,110,0,0,189,190,5,116,0,
		0,190,68,1,0,0,0,191,192,5,102,0,0,192,193,5,108,0,0,193,194,5,111,0,0,
		194,195,5,97,0,0,195,196,5,116,0,0,196,70,1,0,0,0,197,198,5,100,0,0,198,
		199,5,111,0,0,199,200,5,117,0,0,200,201,5,98,0,0,201,202,5,108,0,0,202,
		203,5,101,0,0,203,72,1,0,0,0,204,205,5,115,0,0,205,206,5,116,0,0,206,207,
		5,114,0,0,207,208,5,105,0,0,208,209,5,110,0,0,209,210,5,103,0,0,210,74,
		1,0,0,0,211,212,5,118,0,0,212,213,5,111,0,0,213,214,5,105,0,0,214,215,
		5,100,0,0,215,76,1,0,0,0,216,220,7,0,0,0,217,219,7,1,0,0,218,217,1,0,0,
		0,219,222,1,0,0,0,220,218,1,0,0,0,220,221,1,0,0,0,221,78,1,0,0,0,222,220,
		1,0,0,0,223,225,7,2,0,0,224,223,1,0,0,0,225,226,1,0,0,0,226,224,1,0,0,
		0,226,227,1,0,0,0,227,234,1,0,0,0,228,230,5,46,0,0,229,231,7,2,0,0,230,
		229,1,0,0,0,231,232,1,0,0,0,232,230,1,0,0,0,232,233,1,0,0,0,233,235,1,
		0,0,0,234,228,1,0,0,0,234,235,1,0,0,0,235,80,1,0,0,0,236,240,5,34,0,0,
		237,239,9,0,0,0,238,237,1,0,0,0,239,242,1,0,0,0,240,241,1,0,0,0,240,238,
		1,0,0,0,241,243,1,0,0,0,242,240,1,0,0,0,243,244,5,34,0,0,244,82,1,0,0,
		0,245,246,5,47,0,0,246,247,5,47,0,0,247,251,1,0,0,0,248,250,8,3,0,0,249,
		248,1,0,0,0,250,253,1,0,0,0,251,249,1,0,0,0,251,252,1,0,0,0,252,254,1,
		0,0,0,253,251,1,0,0,0,254,255,6,41,0,0,255,84,1,0,0,0,256,257,5,47,0,0,
		257,258,5,42,0,0,258,262,1,0,0,0,259,261,9,0,0,0,260,259,1,0,0,0,261,264,
		1,0,0,0,262,263,1,0,0,0,262,260,1,0,0,0,263,265,1,0,0,0,264,262,1,0,0,
		0,265,266,5,42,0,0,266,267,5,47,0,0,267,268,1,0,0,0,268,269,6,42,0,0,269,
		86,1,0,0,0,270,272,7,4,0,0,271,270,1,0,0,0,272,273,1,0,0,0,273,271,1,0,
		0,0,273,274,1,0,0,0,274,275,1,0,0,0,275,276,6,43,0,0,276,88,1,0,0,0,277,
		278,5,47,0,0,278,279,5,47,0,0,279,283,1,0,0,0,280,282,8,3,0,0,281,280,
		1,0,0,0,282,285,1,0,0,0,283,281,1,0,0,0,283,284,1,0,0,0,284,286,1,0,0,
		0,285,283,1,0,0,0,286,287,6,44,0,0,287,90,1,0,0,0,288,289,5,47,0,0,289,
		290,5,42,0,0,290,294,1,0,0,0,291,293,9,0,0,0,292,291,1,0,0,0,293,296,1,
		0,0,0,294,295,1,0,0,0,294,292,1,0,0,0,295,297,1,0,0,0,296,294,1,0,0,0,
		297,298,5,42,0,0,298,299,5,47,0,0,299,300,1,0,0,0,300,301,6,45,0,0,301,
		92,1,0,0,0,11,0,220,226,232,234,240,251,262,273,283,294,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
