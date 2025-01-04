// Generated from d:/Anul2/LFC/Compiler_LFC/Compiler_LFC/Grammar.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link GrammarParser}.
 */
public interface GrammarListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link GrammarParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(GrammarParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(GrammarParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#declaration}.
	 * @param ctx the parse tree
	 */
	void enterDeclaration(GrammarParser.DeclarationContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#declaration}.
	 * @param ctx the parse tree
	 */
	void exitDeclaration(GrammarParser.DeclarationContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#functionDefinition}.
	 * @param ctx the parse tree
	 */
	void enterFunctionDefinition(GrammarParser.FunctionDefinitionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#functionDefinition}.
	 * @param ctx the parse tree
	 */
	void exitFunctionDefinition(GrammarParser.FunctionDefinitionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#parameterList}.
	 * @param ctx the parse tree
	 */
	void enterParameterList(GrammarParser.ParameterListContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#parameterList}.
	 * @param ctx the parse tree
	 */
	void exitParameterList(GrammarParser.ParameterListContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#parameter}.
	 * @param ctx the parse tree
	 */
	void enterParameter(GrammarParser.ParameterContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#parameter}.
	 * @param ctx the parse tree
	 */
	void exitParameter(GrammarParser.ParameterContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#block}.
	 * @param ctx the parse tree
	 */
	void enterBlock(GrammarParser.BlockContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#block}.
	 * @param ctx the parse tree
	 */
	void exitBlock(GrammarParser.BlockContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(GrammarParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(GrammarParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#assignment}.
	 * @param ctx the parse tree
	 */
	void enterAssignment(GrammarParser.AssignmentContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#assignment}.
	 * @param ctx the parse tree
	 */
	void exitAssignment(GrammarParser.AssignmentContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void enterIfStatement(GrammarParser.IfStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#ifStatement}.
	 * @param ctx the parse tree
	 */
	void exitIfStatement(GrammarParser.IfStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void enterWhileStatement(GrammarParser.WhileStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#whileStatement}.
	 * @param ctx the parse tree
	 */
	void exitWhileStatement(GrammarParser.WhileStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void enterForStatement(GrammarParser.ForStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#forStatement}.
	 * @param ctx the parse tree
	 */
	void exitForStatement(GrammarParser.ForStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#returnStatement}.
	 * @param ctx the parse tree
	 */
	void enterReturnStatement(GrammarParser.ReturnStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#returnStatement}.
	 * @param ctx the parse tree
	 */
	void exitReturnStatement(GrammarParser.ReturnStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#expressionStatement}.
	 * @param ctx the parse tree
	 */
	void enterExpressionStatement(GrammarParser.ExpressionStatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#expressionStatement}.
	 * @param ctx the parse tree
	 */
	void exitExpressionStatement(GrammarParser.ExpressionStatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void enterExpression(GrammarParser.ExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#expression}.
	 * @param ctx the parse tree
	 */
	void exitExpression(GrammarParser.ExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#logicalOrExpression}.
	 * @param ctx the parse tree
	 */
	void enterLogicalOrExpression(GrammarParser.LogicalOrExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#logicalOrExpression}.
	 * @param ctx the parse tree
	 */
	void exitLogicalOrExpression(GrammarParser.LogicalOrExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#logicalAndExpression}.
	 * @param ctx the parse tree
	 */
	void enterLogicalAndExpression(GrammarParser.LogicalAndExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#logicalAndExpression}.
	 * @param ctx the parse tree
	 */
	void exitLogicalAndExpression(GrammarParser.LogicalAndExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#equalityExpression}.
	 * @param ctx the parse tree
	 */
	void enterEqualityExpression(GrammarParser.EqualityExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#equalityExpression}.
	 * @param ctx the parse tree
	 */
	void exitEqualityExpression(GrammarParser.EqualityExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#relationalExpression}.
	 * @param ctx the parse tree
	 */
	void enterRelationalExpression(GrammarParser.RelationalExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#relationalExpression}.
	 * @param ctx the parse tree
	 */
	void exitRelationalExpression(GrammarParser.RelationalExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#additiveExpression}.
	 * @param ctx the parse tree
	 */
	void enterAdditiveExpression(GrammarParser.AdditiveExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#additiveExpression}.
	 * @param ctx the parse tree
	 */
	void exitAdditiveExpression(GrammarParser.AdditiveExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#multiplicativeExpression}.
	 * @param ctx the parse tree
	 */
	void enterMultiplicativeExpression(GrammarParser.MultiplicativeExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#multiplicativeExpression}.
	 * @param ctx the parse tree
	 */
	void exitMultiplicativeExpression(GrammarParser.MultiplicativeExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#unaryExpression}.
	 * @param ctx the parse tree
	 */
	void enterUnaryExpression(GrammarParser.UnaryExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#unaryExpression}.
	 * @param ctx the parse tree
	 */
	void exitUnaryExpression(GrammarParser.UnaryExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#primaryExpression}.
	 * @param ctx the parse tree
	 */
	void enterPrimaryExpression(GrammarParser.PrimaryExpressionContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#primaryExpression}.
	 * @param ctx the parse tree
	 */
	void exitPrimaryExpression(GrammarParser.PrimaryExpressionContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void enterFunctionCall(GrammarParser.FunctionCallContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#functionCall}.
	 * @param ctx the parse tree
	 */
	void exitFunctionCall(GrammarParser.FunctionCallContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#argumentList}.
	 * @param ctx the parse tree
	 */
	void enterArgumentList(GrammarParser.ArgumentListContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#argumentList}.
	 * @param ctx the parse tree
	 */
	void exitArgumentList(GrammarParser.ArgumentListContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#identifier}.
	 * @param ctx the parse tree
	 */
	void enterIdentifier(GrammarParser.IdentifierContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#identifier}.
	 * @param ctx the parse tree
	 */
	void exitIdentifier(GrammarParser.IdentifierContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#literal}.
	 * @param ctx the parse tree
	 */
	void enterLiteral(GrammarParser.LiteralContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#literal}.
	 * @param ctx the parse tree
	 */
	void exitLiteral(GrammarParser.LiteralContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void enterType(GrammarParser.TypeContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#type}.
	 * @param ctx the parse tree
	 */
	void exitType(GrammarParser.TypeContext ctx);
	/**
	 * Enter a parse tree produced by {@link GrammarParser#assignmentOperator}.
	 * @param ctx the parse tree
	 */
	void enterAssignmentOperator(GrammarParser.AssignmentOperatorContext ctx);
	/**
	 * Exit a parse tree produced by {@link GrammarParser#assignmentOperator}.
	 * @param ctx the parse tree
	 */
	void exitAssignmentOperator(GrammarParser.AssignmentOperatorContext ctx);
}