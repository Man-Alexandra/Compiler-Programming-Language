// Mini-Language Grammar (ANTLR g4 file)

grammar Grammar;

// Parser Rules
program: (declaration | functionDefinition)* EOF;
declaration:
	type identifier (ASSIGN expression)? (
		COMMA identifier (ASSIGN expression)?
	)* SEMICOLON;
functionDefinition:
	type identifier LPAREN parameterList? RPAREN block;
parameterList: parameter (COMMA parameter)*;
parameter: type identifier;
block: LBRACE statement* RBRACE;
statement:
	declaration
	| assignment
	| ifStatement
	| whileStatement
	| forStatement
	| returnStatement
	| expressionStatement
	| block;
assignment: identifier assignmentOperator expression SEMICOLON;
ifStatement:
	IF LPAREN expression RPAREN statement (ELSE statement)?;
whileStatement: WHILE LPAREN expression RPAREN statement;
forStatement:
	FOR LPAREN declaration expression SEMICOLON expression RPAREN statement;
returnStatement: RETURN expression? SEMICOLON;
expressionStatement: expression SEMICOLON;
expression: logicalOrExpression | functionCall;
logicalOrExpression:
	logicalAndExpression (OR logicalAndExpression)*;
logicalAndExpression:
	equalityExpression (AND equalityExpression)*;
equalityExpression:
	relationalExpression ((EQ | NEQ) relationalExpression)*;
relationalExpression:
	additiveExpression ((LT | GT | LE | GE) additiveExpression)*;
additiveExpression:
	multiplicativeExpression (
		(PLUS | MINUS) multiplicativeExpression
	)*;
multiplicativeExpression:
	unaryExpression ((MUL | DIV | MOD) unaryExpression)*;
unaryExpression: (NOT | PLUS | MINUS | INCREMENT | DECREMENT)? primaryExpression;
primaryExpression:
	literal
	| identifier
	| LPAREN expression RPAREN
	| functionCall; // adăugăm regula pentru apeluri de funcți

functionCall: identifier LPAREN argumentList? RPAREN;

argumentList: expression (COMMA expression)*;

// Lexer Rules
identifier: IDENTIFIER;
literal: NUMBER | STRING_LITERAL;

// Keywords
type: INT | FLOAT | DOUBLE | STRING | VOID;
IF: 'if';
ELSE: 'else';
FOR: 'for';
WHILE: 'while';
RETURN: 'return';

// Operators
assignmentOperator:
	ASSIGN
	| ADD_ASSIGN
	| SUB_ASSIGN
	| MUL_ASSIGN
	| DIV_ASSIGN
	| MOD_ASSIGN;
PLUS: '+';
MINUS: '-';
MUL: '*';
DIV: '/';
MOD: '%';
LT: '<';
GT: '>';
LE: '<=';
GE: '>=';
EQ: '==';
NEQ: '!=';
AND: '&&';
OR: '||';
NOT: '!';
INCREMENT: '++';
DECREMENT: '--';
ASSIGN: '=';
ADD_ASSIGN: '+=';
SUB_ASSIGN: '-=';
MUL_ASSIGN: '*=';
DIV_ASSIGN: '/=';
MOD_ASSIGN: '%=';

// Delimiters
LPAREN: '(';
RPAREN: ')';
LBRACE: '{';
RBRACE: '}';
COMMA: ',';
SEMICOLON: ';';

// Keywords
INT: 'int';
FLOAT: 'float';
DOUBLE: 'double';
STRING: 'string';
VOID: 'void';

// Identifiers and Literals
IDENTIFIER: [a-zA-Z_][a-zA-Z_0-9]*;
NUMBER: [0-9]+ ('.' [0-9]+)?;
STRING_LITERAL: '"' .*? '"';

// Comments and Whitespace
COMMENT: '//' ~[\r\n]* -> skip;
MULTILINE_COMMENT: '/*' .*? '*/' -> skip;
WS: [ \t\r\n]+ -> skip;
LINE_COMMENT:
	'//' ~[\r\n]* -> skip; // Ignoră comentariile de tip linie
BLOCK_COMMENT:
	'/*' .*? '*/' -> skip; // Ignoră comentariile de tip bloc