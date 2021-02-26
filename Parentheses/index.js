function testBrackets(expressionToTest) {
    let bracketStack = [];
    let currentCharacter;
    const bracketLookup = {
            "(": ")",
            "[": "]",
            "{": "}",
        };
    const openBrackets = Object.keys(bracketLookup);
    const closeBrackets = Object.values(bracketLookup);

    for (let i = 0; i < expressionToTest.length; i++) {
        currentCharacter = expressionToTest[i];
        if (openBrackets.some(openBracket => currentCharacter === openBracket)) {
            bracketStack.push(currentCharacter);
        } else if (closeBrackets.some(closeBracket => currentCharacter === closeBracket)) {
            const lastOpenBracket = bracketStack.pop();
            if (bracketLookup[lastOpenBracket] !== currentCharacter) {
                return false;
            }
        }
    }

    return bracketStack.length === 0;
}

const expressionsToTest = ['([((({()})))])', '([((({()}))))'];
expressionsToTest.forEach(expressionToTest => console.log(`Expression to test: ${expressionToTest}  Result: ${testBrackets(expressionToTest)}`));
