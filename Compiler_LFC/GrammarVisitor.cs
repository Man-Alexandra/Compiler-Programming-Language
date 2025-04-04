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

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="GrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] GrammarParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] GrammarParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.functionDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDefinition([NotNull] GrammarParser.FunctionDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.parameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterList([NotNull] GrammarParser.ParameterListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameter([NotNull] GrammarParser.ParameterContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] GrammarParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] GrammarParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] GrammarParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] GrammarParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStatement([NotNull] GrammarParser.WhileStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForStatement([NotNull] GrammarParser.ForStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.returnStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnStatement([NotNull] GrammarParser.ReturnStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.expressionStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionStatement([NotNull] GrammarParser.ExpressionStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] GrammarParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.logicalOrExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalOrExpression([NotNull] GrammarParser.LogicalOrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.logicalAndExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalAndExpression([NotNull] GrammarParser.LogicalAndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.equalityExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityExpression([NotNull] GrammarParser.EqualityExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.relationalExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationalExpression([NotNull] GrammarParser.RelationalExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.additiveExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdditiveExpression([NotNull] GrammarParser.AdditiveExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.multiplicativeExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplicativeExpression([NotNull] GrammarParser.MultiplicativeExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.unaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryExpression([NotNull] GrammarParser.UnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.primaryExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrimaryExpression([NotNull] GrammarParser.PrimaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCall([NotNull] GrammarParser.FunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.argumentList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgumentList([NotNull] GrammarParser.ArgumentListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifier([NotNull] GrammarParser.IdentifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] GrammarParser.LiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] GrammarParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.assignmentOperator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentOperator([NotNull] GrammarParser.AssignmentOperatorContext context);
}
